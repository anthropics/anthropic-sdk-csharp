using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Beta.Messages;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol;
using BetaRole = Anthropic.Models.Beta.Messages.Role;
using McpContentBlock = ModelContextProtocol.Protocol.ContentBlock;
using McpRole = ModelContextProtocol.Protocol.Role;
using McpTool = ModelContextProtocol.Protocol.Tool;

namespace Anthropic.Helpers.Beta.Mcp;

/// <summary>
/// Helpers that convert Model Context Protocol (MCP) types into Anthropic beta API types.
///
/// <para>The typical flow is:</para>
/// <code>
/// // 1. Connect to an MCP server (e.g. via stdio or streamable HTTP).
/// var mcpClient = await McpClient.CreateAsync(transport);
///
/// // 2. List the server's tools and convert them to runnable tools.
/// var tools = await BetaMcp.ListToolsAsync(mcpClient);
///
/// // 3. Pass them to the tool runner alongside any tool definitions you defined yourself.
/// var runner = client.Beta.Messages.ToolRunner(parameters, tools);
/// await foreach (var message in runner) { ... }
/// </code>
/// </summary>
public static class BetaMcp
{
    private static readonly HashSet<string> SupportedImageMimeTypes = new(StringComparer.Ordinal)
    {
        "image/jpeg",
        "image/png",
        "image/gif",
        "image/webp",
    };

    /// <summary>
    /// Lists tools advertised by <paramref name="client"/> and converts them to
    /// <see cref="IBetaRunnableTool"/> instances ready to pass to the tool runner.
    /// </summary>
    public static async Task<IReadOnlyList<IBetaRunnableTool>> ListToolsAsync(
        McpClient client,
        BetaCacheControlEphemeral? cacheControl = null,
        bool? deferLoading = null,
        IReadOnlyList<BetaToolAllowedCaller>? allowedCallers = null,
        bool? eagerInputStreaming = null,
        IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? inputExamples = null,
        bool? strict = null,
        CancellationToken cancellationToken = default
    )
    {
        var mcpTools = await client
            .ListToolsAsync(cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return Tools(
            mcpTools,
            cacheControl,
            deferLoading,
            allowedCallers,
            eagerInputStreaming,
            inputExamples,
            strict
        );
    }

    /// <summary>
    /// Converts a list of MCP tools into <see cref="IBetaRunnableTool"/> instances.
    /// </summary>
    public static IReadOnlyList<IBetaRunnableTool> Tools(
        IEnumerable<McpClientTool> tools,
        BetaCacheControlEphemeral? cacheControl = null,
        bool? deferLoading = null,
        IReadOnlyList<BetaToolAllowedCaller>? allowedCallers = null,
        bool? eagerInputStreaming = null,
        IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? inputExamples = null,
        bool? strict = null
    )
    {
        return
        [
            .. tools.Select(t =>
                Tool(
                    t,
                    cacheControl,
                    deferLoading,
                    allowedCallers,
                    eagerInputStreaming,
                    inputExamples,
                    strict
                )
            ),
        ];
    }

    /// <summary>
    /// Converts a single MCP tool into a runnable tool. The returned tool's <c>Run</c> callback
    /// invokes the tool against the MCP server via <see cref="McpClientTool.CallAsync"/> and
    /// converts the result into Anthropic content blocks.
    /// </summary>
    public static IBetaRunnableTool Tool(
        McpClientTool tool,
        BetaCacheControlEphemeral? cacheControl = null,
        bool? deferLoading = null,
        IReadOnlyList<BetaToolAllowedCaller>? allowedCallers = null,
        bool? eagerInputStreaming = null,
        IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? inputExamples = null,
        bool? strict = null
    )
    {
        var protocolTool = tool.ProtocolTool;
        var betaTool = BuildBetaTool(
            protocolTool,
            cacheControl,
            deferLoading,
            allowedCallers,
            eagerInputStreaming,
            inputExamples,
            strict
        );

        return new BetaRunnableTool
        {
            Name = protocolTool.Name,
            Definition = new BetaToolUnion(betaTool),
            Run = async (toolUseBlock, cancellationToken) =>
            {
                var arguments = toolUseBlock.Input.ToDictionary(
                    kvp => kvp.Key,
                    kvp => (object?)kvp.Value
                );
                var result = await tool.CallAsync(arguments, cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return ConvertCallToolResult(result);
            },
        };
    }

    /// <summary>
    /// Converts an MCP prompt message into a <see cref="BetaMessageParam"/>.
    /// </summary>
    public static BetaMessageParam Message(
        PromptMessage message,
        BetaCacheControlEphemeral? cacheControl = null
    )
    {
        var role = message.Role switch
        {
            McpRole.User => BetaRole.User,
            McpRole.Assistant => BetaRole.Assistant,
            _ => throw new AnthropicInvalidDataException($"Unsupported MCP role: {message.Role}"),
        };
        return new BetaMessageParam
        {
            Role = role,
            Content = new BetaMessageParamContent(
                new List<BetaContentBlockParam> { Content(message.Content, cacheControl) }
            ),
        };
    }

    /// <summary>
    /// Converts a list of MCP prompt messages into <see cref="BetaMessageParam"/> instances.
    /// </summary>
    public static IReadOnlyList<BetaMessageParam> Messages(
        IEnumerable<PromptMessage> messages,
        BetaCacheControlEphemeral? cacheControl = null
    )
    {
        return [.. messages.Select(m => Message(m, cacheControl))];
    }

    /// <summary>
    /// Converts a single MCP content block into a <see cref="BetaContentBlockParam"/> suitable for
    /// inclusion in a message's content array.
    /// </summary>
    public static BetaContentBlockParam Content(
        McpContentBlock block,
        BetaCacheControlEphemeral? cacheControl = null
    )
    {
        return block switch
        {
            TextContentBlock text => new BetaTextBlockParam
            {
                Text = text.Text,
                CacheControl = cacheControl,
            },
            ImageContentBlock image => BuildImageBlock(
                Base64StringFromMemory(image.Data),
                image.MimeType,
                cacheControl
            ),
            EmbeddedResourceBlock resource => ResourceContentsToContentBlock(
                resource.Resource,
                cacheControl
            ),
            AudioContentBlock => throw new AnthropicInvalidDataException(
                "MCP audio content is not supported by the Anthropic API."
            ),
            ResourceLinkBlock => throw new AnthropicInvalidDataException(
                "MCP resource links must be resolved by the MCP client before conversion."
            ),
            _ => throw new AnthropicInvalidDataException(
                $"Unsupported MCP content type: {block.Type}"
            ),
        };
    }

    /// <summary>
    /// Converts an MCP <see cref="ReadResourceResult"/> into a content block, selecting the first
    /// resource with a supported MIME type.
    /// </summary>
    public static BetaContentBlockParam ResourceToContent(
        ReadResourceResult result,
        BetaCacheControlEphemeral? cacheControl = null
    )
    {
        if (result.Contents.Count == 0)
        {
            throw new AnthropicInvalidDataException(
                "Resource contents array must contain at least one item."
            );
        }
        var supported = result.Contents.FirstOrDefault(c =>
            IsSupportedResourceMimeType(c.MimeType)
        );
        if (supported == null)
        {
            var mimeTypes = string.Join(
                ", ",
                result.Contents.Select(c => c.MimeType).Where(m => m != null)
            );
            throw new AnthropicInvalidDataException(
                $"No supported MIME type found in resource contents. Available: {mimeTypes}"
            );
        }
        return ResourceContentsToContentBlock(supported, cacheControl);
    }

    /// <summary>
    /// Converts an MCP <see cref="ReadResourceResult"/> into a file tuple suitable for
    /// <c>Anthropic.Beta.Files.Upload(...)</c>. The first item in <c>Contents</c> is used,
    /// regardless of MIME type.
    /// </summary>
    public static (string? Filename, byte[] Data, string? MediaType) ResourceToFile(
        ReadResourceResult result
    )
    {
        if (result.Contents.Count == 0)
        {
            throw new AnthropicInvalidDataException(
                "Resource contents array must contain at least one item."
            );
        }
        var item = result.Contents[0];
        var filename = ExtractFilename(item.Uri);
        var data = ResourceContentsToBytes(item);
        return (filename, data, item.MimeType);
    }

    // ---------------------------------------------------------------------
    // Internals
    // ---------------------------------------------------------------------

    private static BetaTool BuildBetaTool(
        McpTool protocolTool,
        BetaCacheControlEphemeral? cacheControl,
        bool? deferLoading,
        IReadOnlyList<BetaToolAllowedCaller>? allowedCallers,
        bool? eagerInputStreaming,
        IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? inputExamples,
        bool? strict
    )
    {
        return new BetaTool
        {
            Name = protocolTool.Name,
            Description = protocolTool.Description,
            InputSchema = BuildInputSchema(protocolTool.InputSchema),
            CacheControl = cacheControl,
            DeferLoading = deferLoading,
            AllowedCallers = allowedCallers
                ?.Select(c => (ApiEnum<string, BetaToolAllowedCaller>)c)
                .ToList(),
            EagerInputStreaming = eagerInputStreaming,
            InputExamples = inputExamples,
            Strict = strict,
        };
    }

    private static InputSchema BuildInputSchema(JsonElement schema)
    {
        if (schema.ValueKind != JsonValueKind.Object)
        {
            throw new AnthropicInvalidDataException(
                $"MCP tool inputSchema must be a JSON object, got {schema.ValueKind}."
            );
        }

        var rawData = new Dictionary<string, JsonElement>(StringComparer.Ordinal);
        foreach (var prop in schema.EnumerateObject())
        {
            rawData[prop.Name] = prop.Value;
        }

        // The Anthropic API requires type="object".
        rawData["type"] = JsonSerializer.SerializeToElement("object");

        return InputSchema.FromRawUnchecked(rawData);
    }

    private static BetaContentBlockParam ResourceContentsToContentBlock(
        ResourceContents contents,
        BetaCacheControlEphemeral? cacheControl
    )
    {
        var mimeType = contents.MimeType;

        if (mimeType != null && SupportedImageMimeTypes.Contains(mimeType))
        {
            if (contents is not BlobResourceContents blob)
            {
                throw new AnthropicInvalidDataException(
                    $"Image resource must have blob data, not text. URI: {contents.Uri}"
                );
            }
            return BuildImageBlock(Base64StringFromMemory(blob.Blob), mimeType, cacheControl);
        }

        if (mimeType == "application/pdf")
        {
            if (contents is not BlobResourceContents blob)
            {
                throw new AnthropicInvalidDataException(
                    $"PDF resource must have blob data, not text. URI: {contents.Uri}"
                );
            }
            return new BetaRequestDocumentBlock
            {
                Source = new BetaRequestDocumentBlockSource(
                    new BetaBase64PdfSource { Data = Base64StringFromMemory(blob.Blob) }
                ),
                CacheControl = cacheControl,
            };
        }

        if (mimeType == null || mimeType.StartsWith("text/", StringComparison.Ordinal))
        {
            var data = contents switch
            {
                TextResourceContents text => text.Text,
                BlobResourceContents blob => Encoding.UTF8.GetString(blob.DecodedData.ToArray()),
                _ => throw new AnthropicInvalidDataException(
                    $"Unsupported resource contents type: {contents.GetType().Name}"
                ),
            };
            return new BetaRequestDocumentBlock
            {
                Source = new BetaRequestDocumentBlockSource(
                    new BetaPlainTextSource { Data = data }
                ),
                CacheControl = cacheControl,
            };
        }

        throw new AnthropicInvalidDataException(
            $"Unsupported MIME type \"{mimeType}\" for resource: {contents.Uri}"
        );
    }

    private static BetaImageBlockParam BuildImageBlock(
        string base64Data,
        string mimeType,
        BetaCacheControlEphemeral? cacheControl
    )
    {
        if (!SupportedImageMimeTypes.Contains(mimeType))
        {
            throw new AnthropicInvalidDataException($"Unsupported image MIME type: {mimeType}");
        }
        return new BetaImageBlockParam
        {
            Source = new BetaImageBlockParamSource(
                new BetaBase64ImageSource { Data = base64Data, MediaType = mimeType }
            ),
            CacheControl = cacheControl,
        };
    }

    private static BetaToolResultBlockParamContent ConvertCallToolResult(CallToolResult result)
    {
        if (result.IsError == true)
        {
            throw new BetaToolError(ConvertContentToToolResult(result.Content));
        }

        // If content is empty but structuredContent is present, JSON-encode it. The MCP spec
        // recommends servers also include a TextContent block, but doesn't require it.
        if (result.Content.Count == 0 && result.StructuredContent.HasValue)
        {
            return JsonSerializer.Serialize(result.StructuredContent.Value);
        }

        return ConvertContentToToolResult(result.Content);
    }

    private static BetaToolResultBlockParamContent ConvertContentToToolResult(
        IList<McpContentBlock> content
    )
    {
        var blocks = new List<Block>(content.Count);
        foreach (var item in content)
        {
            blocks.Add(ContentBlockToToolResultBlock(item));
        }
        return new BetaToolResultBlockParamContent(blocks);
    }

    private static Block ContentBlockToToolResultBlock(McpContentBlock block)
    {
        var converted = Content(block);
        if (converted.TryPickText(out var text))
        {
            return new Block(text);
        }
        if (converted.TryPickImage(out var image))
        {
            return new Block(image);
        }
        if (converted.TryPickRequestDocumentBlock(out var document))
        {
            return new Block(document);
        }
        throw new AnthropicInvalidDataException(
            $"MCP content block type {block.Type} is not supported in tool results."
        );
    }

    private static bool IsSupportedResourceMimeType(string? mimeType)
    {
        return mimeType == null
            || mimeType.StartsWith("text/", StringComparison.Ordinal)
            || mimeType == "application/pdf"
            || SupportedImageMimeTypes.Contains(mimeType);
    }

    private static byte[] ResourceContentsToBytes(ResourceContents contents)
    {
        return contents switch
        {
            BlobResourceContents blob => blob.DecodedData.ToArray(),
            TextResourceContents text => Encoding.UTF8.GetBytes(text.Text),
            _ => throw new AnthropicInvalidDataException(
                $"Unsupported resource contents type: {contents.GetType().Name}"
            ),
        };
    }

    private static string? ExtractFilename(string uri)
    {
        if (string.IsNullOrEmpty(uri))
        {
            return null;
        }
        if (Uri.TryCreate(uri, UriKind.Absolute, out var parsed))
        {
            var segments = parsed.AbsolutePath.Split('/');
            for (var i = segments.Length - 1; i >= 0; i--)
            {
                if (!string.IsNullOrEmpty(segments[i]))
                {
                    return Uri.UnescapeDataString(segments[i]);
                }
            }
            return null;
        }
        var lastSlash = uri.LastIndexOf('/');
        return lastSlash >= 0 && lastSlash < uri.Length - 1 ? uri.Substring(lastSlash + 1) : null;
    }

    private static string Base64StringFromMemory(ReadOnlyMemory<byte> base64Bytes)
    {
        // MCP wire format: ImageContentBlock.Data / BlobResourceContents.Blob hold the UTF-8 bytes
        // of the base64-encoded payload, not the raw decoded bytes. Decoding to UTF-8 yields the
        // base64 string the Anthropic API expects.
        return Encoding.UTF8.GetString(base64Bytes.ToArray());
    }
}
