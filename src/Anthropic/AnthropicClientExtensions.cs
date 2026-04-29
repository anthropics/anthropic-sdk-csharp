using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic;
using Anthropic.Core;
using Anthropic.Models.Messages;

#pragma warning disable MEAI001 // [Experimental] APIs in Microsoft.Extensions.AI
#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace Microsoft.Extensions.AI;

public static class AnthropicClientExtensions
{
    /// <summary>Gets an <see cref="IChatClient"/> for use with this <see cref="IAnthropicClient"/>.</summary>
    /// <param name="client">The client.</param>
    /// <param name="defaultModelId">
    /// The default ID of the model to use.
    /// If <see langword="null"/>, it must be provided per request via <see cref="ChatOptions.ModelId"/>.
    /// </param>
    /// <param name="defaultMaxOutputTokens">
    /// The default maximum number of tokens to generate in a response.
    /// This may be overridden with <see cref="ChatOptions.MaxOutputTokens"/>.
    /// If no value is provided for this parameter or in <see cref="ChatOptions"/>, a default maximum will be used.
    /// </param>
    /// <returns>An <see cref="IChatClient"/> that can be used to converse via the <see cref="IAnthropicClient"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="client"/> is <see langword="null"/>.</exception>
    public static IChatClient AsIChatClient(
        this IAnthropicClient client,
        string? defaultModelId = null,
        int? defaultMaxOutputTokens = null
    )
    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        if (defaultMaxOutputTokens is <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(defaultMaxOutputTokens),
                "Default max tokens must be greater than zero."
            );
        }

        return new AnthropicChatClient(client, defaultModelId, defaultMaxOutputTokens);
    }

    /// <summary>Creates an <see cref="AITool"/> to represent a raw <see cref="ToolUnion"/>.</summary>
    /// <param name="tool">The tool to wrap as an <see cref="AITool"/>.</param>
    /// <returns>The <paramref name="tool"/> wrapped as an <see cref="AITool"/>.</returns>
    /// <remarks>
    /// <para>
    /// The returned tool is only suitable for use with the <see cref="IChatClient"/> returned by
    /// <see cref="AsIChatClient"/> (or <see cref="IChatClient"/>s that delegate
    /// to such an instance). It is likely to be ignored by any other <see cref="IChatClient"/> implementation.
    /// </para>
    /// <para>
    /// When a tool has a corresponding <see cref="AITool"/>-derived type already defined in Microsoft.Extensions.AI,
    /// such as <see cref="AIFunction"/>, <see cref="HostedWebSearchTool"/>, <see cref="HostedMcpServerTool"/>, or
    /// <see cref="HostedFileSearchTool"/>, those types should be preferred instead of this method, as they are more portable,
    /// capable of being respected by any <see cref="IChatClient"/> implementation. This method does not attempt to
    /// map the supplied <see cref="ToolUnion"/> to any of those types, it simply wraps it as-is:
    /// the <see cref="IChatClient"/> returned by <see cref="AsIChatClient"/> will
    /// be able to unwrap the <see cref="ToolUnion"/> when it processes the list of tools.
    /// </para>
    /// </remarks>
    public static AITool AsAITool(this ToolUnion tool)
    {
        if (tool is null)
        {
            throw new ArgumentNullException(nameof(tool));
        }

        return new ToolUnionAITool(tool);
    }

    /// <summary>Serializer options using relaxed encoding for description augmentation.</summary>
    /// <remarks>
    /// Matches the behavior of JavaScript's <c>JSON.stringify()</c> and Python's <c>json.dumps()</c>,
    /// which do not escape characters like <c>+</c>, <c>'</c>, or <c>&amp;</c>. The default
    /// <see cref="JavaScriptEncoder"/> would escape these (e.g., <c>+</c> → <c>\u002B</c>),
    /// producing less readable descriptions for the model.
    /// </remarks>
    private static readonly JsonSerializerOptions s_relaxedJsonOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    /// <summary>Supported string formats for Anthropic structured outputs.</summary>
    /// <remarks>
    /// Matches the TypeScript and Python SDK transform behavior:
    /// <list type="bullet">
    /// <item><see href="https://github.com/anthropics/anthropic-sdk-typescript/blob/main/src/lib/transform-json-schema.ts"/></item>
    /// <item><see href="https://github.com/anthropics/anthropic-sdk-python/blob/main/src/anthropic/lib/_parse/_transform.py"/></item>
    /// </list>
    /// </remarks>
    private static readonly HashSet<string> s_supportedStringFormats = new(StringComparer.Ordinal)
    {
        "date-time",
        "time",
        "date",
        "duration",
        "email",
        "hostname",
        "uri",
        "ipv4",
        "ipv6",
        "uuid",
    };

    /// <summary>Properties supported across all JSON Schema types.</summary>
    /// <remarks>
    /// <c>enum</c> and <c>const</c> are included here but are NOT in the TypeScript/Python SDK whitelists.
    /// They are deliberately preserved because MEAI generates <c>enum</c> for .NET enum types and both
    /// keywords are natively supported by the Anthropic API.
    /// </remarks>
    private static readonly HashSet<string> s_supportedBaseSchemaProperties = new(
        StringComparer.Ordinal
    )
    {
        "type",
        "description",
        "title",
        "$ref",
        "$defs",
        "anyOf",
        "allOf",
        "enum",
        "const",
    };

    /// <summary>Properties supported for object schemas.</summary>
    private static readonly HashSet<string> s_supportedObjectSchemaProperties = new(
        s_supportedBaseSchemaProperties,
        StringComparer.Ordinal
    )
    {
        "properties",
        "required",
        "additionalProperties",
    };

    /// <summary>Properties supported for string schemas.</summary>
    private static readonly HashSet<string> s_supportedStringSchemaProperties = new(
        s_supportedBaseSchemaProperties,
        StringComparer.Ordinal
    )
    {
        "format",
    };

    /// <summary>Properties supported for array schemas.</summary>
    private static readonly HashSet<string> s_supportedArraySchemaProperties = new(
        s_supportedBaseSchemaProperties,
        StringComparer.Ordinal
    )
    {
        "items",
        "minItems",
    };

    /// <summary>
    /// Gets a shared cache for JSON schema transformations for Anthropic's structured output features.
    /// </summary>
    /// <remarks>
    /// Transforms schemas using the same whitelist approach as the TypeScript and Python SDKs:
    /// unsupported constraints are removed and appended to the description so the model
    /// might still follow them. See:
    /// <list type="bullet">
    /// <item><see href="https://github.com/anthropics/anthropic-sdk-typescript/blob/main/src/lib/transform-json-schema.ts"/></item>
    /// <item><see href="https://github.com/anthropics/anthropic-sdk-python/blob/main/src/anthropic/lib/_parse/_transform.py"/></item>
    /// </list>
    /// </remarks>
    internal static AIJsonSchemaTransformCache JsonSchemaTransformCache { get; } =
        new(
            new AIJsonSchemaTransformOptions
            {
                DisallowAdditionalProperties = true,
                TransformSchemaNode = static (ctx, schemaNode) =>
                {
                    if (schemaNode is not JsonObject schemaObj)
                    {
                        return schemaNode;
                    }

                    // Convert oneOf to anyOf, matching TS/Python SDK behavior.
                    // The Anthropic API documents anyOf but not oneOf for union types.
                    if (
                        schemaObj.TryGetPropertyValue("oneOf", out JsonNode? oneOfNode)
                        && oneOfNode is not null
                    )
                    {
                        schemaObj.Remove("oneOf");
                        schemaObj["anyOf"] = oneOfNode;
                    }

                    // Determine the schema type for type-specific handling.
                    string? type =
                        schemaObj.TryGetPropertyValue("type", out JsonNode? typeNode)
                        && typeNode is JsonValue
                            ? typeNode.GetValue<string>()
                            : null;

                    List<KeyValuePair<string, string>>? removed = null;

                    // String format: only supported formats are kept.
                    if (
                        type == "string"
                        && schemaObj.TryGetPropertyValue("format", out JsonNode? formatNode)
                        && formatNode?.GetValue<string>() is string format
                        && !s_supportedStringFormats.Contains(format)
                    )
                    {
                        string serialized = formatNode!.ToJsonString(s_relaxedJsonOptions);
                        schemaObj.Remove("format");
                        (removed ??= []).Add(new("format", serialized));
                    }

                    // Array minItems: only 0 and 1 are directly supported.
                    if (
                        type == "array"
                        && schemaObj.TryGetPropertyValue("minItems", out JsonNode? minItemsNode)
                        && minItemsNode is JsonValue minItemsJsonValue
                        && minItemsJsonValue.TryGetValue(out int minItems)
                        && minItems is not (0 or 1)
                    )
                    {
                        string serialized = minItemsNode.ToJsonString(s_relaxedJsonOptions);
                        schemaObj.Remove("minItems");
                        (removed ??= []).Add(new("minItems", serialized));
                    }

                    // Remove all properties not in the supported set for this schema type.
                    HashSet<string> supported = type switch
                    {
                        "object" => s_supportedObjectSchemaProperties,
                        "string" => s_supportedStringSchemaProperties,
                        "array" => s_supportedArraySchemaProperties,
                        _ => s_supportedBaseSchemaProperties,
                    };

                    foreach (KeyValuePair<string, JsonNode?> prop in schemaObj.ToArray())
                    {
                        if (!supported.Contains(prop.Key))
                        {
                            string serialized =
                                prop.Value?.ToJsonString(s_relaxedJsonOptions) ?? "null";
                            schemaObj.Remove(prop.Key);
                            (removed ??= []).Add(new(prop.Key, serialized));
                        }
                    }

                    // Append removed constraints to description so the model might
                    // still follow them.
                    if (removed is { Count: > 0 })
                    {
                        string? existing = schemaObj.TryGetPropertyValue(
                            "description",
                            out JsonNode? descNode
                        )
                            ? descNode?.GetValue<string>()
                            : null;

                        string constraintInfo =
                            "{"
                            + string.Join(", ", removed.Select(c => $"{c.Key}: {c.Value}"))
                            + "}";

                        schemaObj["description"] = existing is not null
                            ? $"{existing}\n\n{constraintInfo}"
                            : constraintInfo;
                    }

                    return schemaNode;
                },
            }
        );

    /// <summary>
    /// Gets a shared set of header data to include in requests from the <see cref="IChatClient"/> implementation for Anthropic.
    /// </summary>
    internal static Dictionary<string, JsonElement> MeaiHeaderData { get; } =
        new() { ["User-Agent"] = JsonSerializer.SerializeToElement(CreateMeaiUserAgentValue()) };

    private static string CreateMeaiUserAgentValue()
    {
        const string Name = "MEAI";

        if (
            typeof(IChatClient)
                .Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion
            is string version
        )
        {
            int pos = version.IndexOf('+');
            if (pos >= 0)
            {
                version = version.Substring(0, pos);
            }

            if (version.Length > 0)
            {
                return $"{Name}/{version}";
            }
        }

        return Name;
    }

    // TODO: When targeting a version of .NET that exposes MediaTypeMap (Microsoft.Extensions.AI),
    // these dictionaries can be replaced with MediaTypeMap.GetMediaType / MediaTypeMap.GetExtension.

    /// <summary>
    /// Maps file extensions (with leading dot) to MIME types.
    /// Grouped by category, sorted alphabetically by extension within each group.
    /// </summary>
    private static readonly Dictionary<string, string> s_extensionToMediaType = new(
        StringComparer.OrdinalIgnoreCase
    )
    {
        // Archives
        [".7z"] = "application/x-7z-compressed",
        [".gz"] = "application/gzip",
        [".rar"] = "application/vnd.rar",
        [".tar"] = "application/x-tar",
        [".zip"] = "application/zip",

        // Audio
        [".mp3"] = "audio/mpeg",
        [".ogg"] = "audio/ogg",
        [".wav"] = "audio/wav",

        // Code
        [".c"] = "text/x-c",
        [".cpp"] = "text/x-c++",
        [".cs"] = "text/x-csharp",
        [".css"] = "text/css",
        [".go"] = "text/x-go",
        [".java"] = "text/x-java-source",
        [".js"] = "text/javascript",
        [".jsx"] = "text/javascript",
        [".py"] = "text/x-python",
        [".r"] = "text/x-r",
        [".rb"] = "text/x-ruby",
        [".rs"] = "text/x-rust",
        [".sh"] = "application/x-sh",
        [".sql"] = "application/sql",
        [".swift"] = "text/x-swift",
        [".ts"] = "text/typescript",
        [".tsx"] = "text/typescript",
        [".wasm"] = "application/wasm",

        // Data
        [".csv"] = "text/csv",
        [".json"] = "application/json",
        [".jsonl"] = "application/jsonl",
        [".tsv"] = "text/tab-separated-values",
        [".xml"] = "application/xml",
        [".yaml"] = "application/yaml",
        [".yml"] = "application/yaml",

        // Documents
        [".doc"] = "application/msword",
        [".docx"] = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        [".epub"] = "application/epub+zip",
        [".odt"] = "application/vnd.oasis.opendocument.text",
        [".pdf"] = "application/pdf",
        [".pptx"] = "application/vnd.openxmlformats-officedocument.presentationml.presentation",
        [".rtf"] = "application/rtf",
        [".xls"] = "application/vnd.ms-excel",
        [".xlsx"] = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",

        // Images
        [".bmp"] = "image/bmp",
        [".gif"] = "image/gif",
        [".ico"] = "image/x-icon",
        [".jpeg"] = "image/jpeg",
        [".jpg"] = "image/jpeg",
        [".png"] = "image/png",
        [".svg"] = "image/svg+xml",
        [".tif"] = "image/tiff",
        [".tiff"] = "image/tiff",
        [".webp"] = "image/webp",

        // Text/Markup
        [".htm"] = "text/html",
        [".html"] = "text/html",
        [".md"] = "text/markdown",
        [".txt"] = "text/plain",

        // Video
        [".mp4"] = "video/mp4",
        [".webm"] = "video/webm",
    };

    /// <summary>
    /// Reverse mapping from MIME type to a preferred file extension (with leading dot).
    /// Built from <see cref="s_extensionToMediaType"/>, preferring the last extension per media type
    /// (which, given the alphabetical ordering, favors longer canonical forms like .html over .htm).
    /// </summary>
    private static readonly Dictionary<string, string> s_mediaTypeToExtension =
        BuildMediaTypeToExtension();

    private static Dictionary<string, string> BuildMediaTypeToExtension()
    {
        Dictionary<string, string> result = new(StringComparer.OrdinalIgnoreCase);
        foreach (KeyValuePair<string, string> kvp in s_extensionToMediaType)
        {
            result[kvp.Value] = kvp.Key;
        }

        // Override with preferred extensions where multiple map to the same media type.
        result["image/jpeg"] = ".jpg";
        result["application/yaml"] = ".yaml";
        result["text/javascript"] = ".js";
        result["text/typescript"] = ".ts";

        return result;
    }

    /// <summary>Infers a media type from the file extension in a URL or path, defaulting to <c>application/octet-stream</c>.</summary>
    internal static string InferMediaTypeFromExtension(string urlOrPath)
    {
        if (
            Path.GetExtension(urlOrPath) is { Length: > 0 } ext
            && s_extensionToMediaType.TryGetValue(ext, out string? mediaType)
        )
        {
            return mediaType;
        }

        return "application/octet-stream";
    }

    /// <summary>Infers a file extension (including the leading dot) from a media type, defaulting to empty string.</summary>
    internal static string InferExtensionFromMediaType(string? mediaType) =>
        mediaType is not null
        && s_mediaTypeToExtension.TryGetValue(mediaType, out string? extension)
            ? extension
            : "";

    private sealed class AnthropicChatClient(
        IAnthropicClient anthropicClient,
        string? defaultModelId,
        int? defaultMaxTokens
    ) : IChatClient
    {
        private const int DefaultMaxTokens = 1024;

        private readonly IAnthropicClient _anthropicClient = anthropicClient;
        private readonly string? _defaultModelId = defaultModelId;
        private readonly int _defaultMaxTokens = defaultMaxTokens ?? DefaultMaxTokens;
        private ChatClientMetadata? _metadata;

        /// <inheritdoc />
        void IDisposable.Dispose() { }

        /// <inheritdoc />
        public object? GetService(System.Type serviceType, object? serviceKey = null)
        {
            if (serviceType is null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (serviceKey is not null)
            {
                return null;
            }

            if (serviceType == typeof(ChatClientMetadata))
            {
                return _metadata ??= new(
                    "anthropic",
                    new Uri(_anthropicClient.BaseUrl),
                    _defaultModelId
                );
            }

            if (serviceType.IsInstanceOfType(_anthropicClient))
            {
                return _anthropicClient;
            }

            if (serviceType.IsInstanceOfType(this))
            {
                return this;
            }

            return null;
        }

        /// <inheritdoc />
        public async Task<ChatResponse> GetResponseAsync(
            IEnumerable<ChatMessage> messages,
            ChatOptions? options = null,
            CancellationToken cancellationToken = default
        )
        {
            if (messages is null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            List<MessageParam> messageParams = CreateMessageParams(
                messages,
                out List<TextBlockParam>? systemMessages
            );
            MessageCreateParams createParams = GetMessageCreateParams(
                messageParams,
                systemMessages,
                options
            );

            // When thinking is enabled, the auto-increased max_tokens may exceed the
            // client-side non-streaming token limit. Use a streaming-level timeout to
            // bypass that check while still providing appropriate timeout behavior.
            var messageService = _anthropicClient.Messages;
            if (createParams.Thinking is ThinkingConfigParam { Value: ThinkingConfigEnabled })
            {
                messageService = messageService.WithOptions(opts =>
                    opts with
                    {
                        Timeout = ClientOptions.TimeoutFromMaxTokens(
                            createParams.MaxTokens,
                            isStreaming: true,
                            createParams.Model
                        ),
                    }
                );
            }

            var createResult = await messageService.Create(createParams, cancellationToken);

            ChatMessage m = new(
                ChatRole.Assistant,
                [.. createResult.Content.Select(c => ContentBlockValueToAIContent(c.Value))]
            )
            {
                CreatedAt = DateTimeOffset.UtcNow,
                MessageId = createResult.ID,
            };

            return new(m)
            {
                CreatedAt = m.CreatedAt,
                FinishReason = ToFinishReason(createResult.StopReason),
                ModelId = createResult.Model.Raw() ?? createParams.Model.Raw(),
                RawRepresentation = createResult,
                ResponseId = m.MessageId,
                Usage = createResult.Usage is { } usage ? ToUsageDetails(usage) : null,
            };
        }

        /// <inheritdoc />
        public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(
            IEnumerable<ChatMessage> messages,
            ChatOptions? options = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default
        )
        {
            if (messages is null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            List<MessageParam> messageParams = CreateMessageParams(
                messages,
                out List<TextBlockParam>? systemMessages
            );
            MessageCreateParams createParams = GetMessageCreateParams(
                messageParams,
                systemMessages,
                options
            );

            string? messageId = null;
            string? modelID = null;
            UsageDetails? usageDetails = null;
            ChatFinishReason? finishReason = null;
            Dictionary<long, StreamingFunctionData>? streamingFunctions = null;

            await foreach (
                var createResult in _anthropicClient
                    .Messages.CreateStreaming(createParams, cancellationToken)
                    .WithCancellation(cancellationToken)
            )
            {
                List<AIContent> contents = [];

                switch (createResult.Value)
                {
                    case RawMessageStartEvent rawMessageStart:
                        if (string.IsNullOrWhiteSpace(messageId))
                        {
                            messageId = rawMessageStart.Message.ID;
                        }

                        if (string.IsNullOrWhiteSpace(modelID))
                        {
                            modelID = rawMessageStart.Message.Model;
                        }

                        if (rawMessageStart.Message.Usage is { } usage)
                        {
                            UsageDetails current = ToUsageDetails(usage);
                            if (usageDetails is null)
                            {
                                usageDetails = current;
                            }
                            else
                            {
                                usageDetails.Add(current);
                            }
                        }
                        break;

                    case RawMessageDeltaEvent rawMessageDelta:
                        finishReason = ToFinishReason(rawMessageDelta.Delta.StopReason);
                        if (rawMessageDelta.Usage is { } deltaUsage)
                        {
                            // https://platform.claude.com/docs/en/build-with-claude/streaming
                            // "The token counts shown in the usage field of the message_delta event are cumulative."
                            usageDetails = ToUsageDetails(deltaUsage);
                        }
                        break;

                    case RawContentBlockStartEvent contentBlockStart:
                        switch (contentBlockStart.ContentBlock.Value)
                        {
                            case TextBlock text:
                                contents.Add(
                                    new TextContent(text.Text) { RawRepresentation = text }
                                );
                                break;

                            case ThinkingBlock thinking:
                                contents.Add(
                                    new TextReasoningContent(thinking.Thinking)
                                    {
                                        ProtectedData = thinking.Signature,
                                        RawRepresentation = thinking,
                                    }
                                );
                                break;

                            case RedactedThinkingBlock redactedThinking:
                                contents.Add(
                                    new TextReasoningContent(string.Empty)
                                    {
                                        ProtectedData = redactedThinking.Data,
                                        RawRepresentation = redactedThinking,
                                    }
                                );
                                break;

                            case ToolUseBlock toolUse:
                                streamingFunctions ??= [];
                                streamingFunctions[contentBlockStart.Index] = new()
                                {
                                    CallId = toolUse.ID,
                                    Name = toolUse.Name,
                                };
                                break;

                            case ServerToolUseBlock serverToolUse:
                                streamingFunctions ??= [];
                                streamingFunctions[contentBlockStart.Index] = new()
                                {
                                    CallId = serverToolUse.ID,
                                    ServerToolName = serverToolUse.Name.Value(),
                                    InitialInput = serverToolUse.Input is { Count: > 0 }
                                        ? serverToolUse.Input
                                        : null,
                                    RawRepresentation = serverToolUse,
                                };
                                break;

                            case WebSearchToolResultBlock:
                            case WebFetchToolResultBlock:
                            case CodeExecutionToolResultBlock:
                            case BashCodeExecutionToolResultBlock:
                            case TextEditorCodeExecutionToolResultBlock:
                            case ToolSearchToolResultBlock:
                            case ContainerUploadBlock:
                                contents.Add(
                                    ContentBlockValueToAIContent(
                                        contentBlockStart.ContentBlock.Value
                                    )
                                );
                                break;
                        }
                        break;

                    case RawContentBlockDeltaEvent contentBlockDelta:
                        switch (contentBlockDelta.Delta.Value)
                        {
                            case TextDelta textDelta:
                                contents.Add(
                                    new TextContent(textDelta.Text)
                                    {
                                        RawRepresentation = textDelta,
                                    }
                                );
                                break;

                            case InputJsonDelta inputDelta:
                                if (
                                    streamingFunctions is not null
                                    && streamingFunctions.TryGetValue(
                                        contentBlockDelta.Index,
                                        out StreamingFunctionData? functionData
                                    )
                                )
                                {
                                    functionData.Arguments.Append(inputDelta.PartialJson);
                                }
                                break;

                            case ThinkingDelta thinkingDelta:
                                contents.Add(
                                    new TextReasoningContent(thinkingDelta.Thinking)
                                    {
                                        RawRepresentation = thinkingDelta,
                                    }
                                );
                                break;

                            case SignatureDelta signatureDelta:
                                contents.Add(
                                    new TextReasoningContent(null)
                                    {
                                        ProtectedData = signatureDelta.Signature,
                                        RawRepresentation = signatureDelta,
                                    }
                                );
                                break;

                            case CitationsDelta citationsDelta:
                                if (ToAIAnnotation(citationsDelta.Citation) is { } streamAnnotation)
                                {
                                    contents.Add(
                                        new TextContent(string.Empty)
                                        {
                                            RawRepresentation = citationsDelta,
                                            Annotations = [streamAnnotation],
                                        }
                                    );
                                }
                                break;
                        }
                        break;

                    case RawContentBlockStopEvent contentBlockStop:
                        if (streamingFunctions is not null)
                        {
                            foreach (var sf in streamingFunctions)
                            {
                                contents.Add(CreateStreamingToolCallContent(sf.Value));
                            }

                            streamingFunctions.Clear();
                        }
                        break;
                }

                yield return new(ChatRole.Assistant, contents)
                {
                    CreatedAt = DateTimeOffset.UtcNow,
                    FinishReason = finishReason,
                    MessageId = messageId,
                    ModelId = modelID,
                    RawRepresentation = createResult,
                    ResponseId = messageId,
                };
            }

            if (usageDetails is not null)
            {
                yield return new(ChatRole.Assistant, [new UsageContent(usageDetails)])
                {
                    CreatedAt = DateTimeOffset.UtcNow,
                    FinishReason = finishReason,
                    MessageId = messageId,
                    ModelId = modelID,
                    ResponseId = messageId,
                };
            }
        }

        private static List<MessageParam> CreateMessageParams(
            IEnumerable<ChatMessage> messages,
            out List<TextBlockParam>? systemMessages
        )
        {
            List<MessageParam> messageParams = [];
            systemMessages = null;

            foreach (ChatMessage message in messages)
            {
                if (message.Role == ChatRole.System)
                {
                    foreach (AIContent content in message.Contents)
                    {
                        switch (content)
                        {
                            case AIContent ac when ac.RawRepresentation is TextBlockParam raw:
                                (systemMessages ??= []).Add(raw);
                                break;

                            case TextContent tc:
                                var block = new TextBlockParam { Text = tc.Text };
                                (systemMessages ??= []).Add(WithCacheControlFrom(block, tc));
                                break;
                        }
                    }

                    continue;
                }

                List<ContentBlockParam> contents = [];

                foreach (AIContent content in message.Contents)
                {
                    switch (content)
                    {
                        case AIContent ac when ac.RawRepresentation is ContentBlockParam rawContent:
                            contents.Add(rawContent);
                            break;

                        case TextContent tc:
                            string text = tc.Text;
                            if (message.Role == ChatRole.Assistant)
                            {
                                text = text.TrimEnd();
                                if (!string.IsNullOrWhiteSpace(text))
                                {
                                    contents.Add(
                                        WithCacheControlFrom(
                                            new TextBlockParam() { Text = text },
                                            tc
                                        )
                                    );
                                }
                            }
                            else if (!string.IsNullOrWhiteSpace(text))
                            {
                                contents.Add(
                                    WithCacheControlFrom(new TextBlockParam() { Text = text }, tc)
                                );
                            }
                            break;

                        case TextReasoningContent trc when !string.IsNullOrEmpty(trc.Text):
                            contents.Add(
                                WithCacheControlFrom(
                                    new ThinkingBlockParam()
                                    {
                                        Thinking = trc.Text,
                                        Signature = trc.ProtectedData ?? string.Empty,
                                    },
                                    trc
                                )
                            );
                            break;

                        case TextReasoningContent trc when !string.IsNullOrEmpty(trc.ProtectedData):
                            contents.Add(
                                WithCacheControlFrom(
                                    new RedactedThinkingBlockParam() { Data = trc.ProtectedData! },
                                    trc
                                )
                            );
                            break;

                        case DataContent dc when dc.HasTopLevelMediaType("image"):
                            contents.Add(
                                WithCacheControlFrom(
                                    new ImageBlockParam()
                                    {
                                        Source = new(
                                            new Base64ImageSource()
                                            {
                                                Data = dc.Base64Data.ToString(),
                                                MediaType = dc.MediaType,
                                            }
                                        ),
                                    },
                                    dc
                                )
                            );
                            break;

                        case DataContent dc
                            when string.Equals(
                                dc.MediaType,
                                "application/pdf",
                                StringComparison.OrdinalIgnoreCase
                            ):
                            contents.Add(
                                WithCacheControlFrom(
                                    new DocumentBlockParam()
                                    {
                                        Source = new(
                                            new Base64PdfSource()
                                            {
                                                Data = dc.Base64Data.ToString(),
                                            }
                                        ),
                                    },
                                    dc
                                )
                            );
                            break;

                        case DataContent dc when dc.HasTopLevelMediaType("text"):
                            contents.Add(
                                WithCacheControlFrom(
                                    new DocumentBlockParam()
                                    {
                                        Source = new(
                                            new PlainTextSource()
                                            {
                                                Data = Encoding.UTF8.GetString(dc.Data.ToArray()),
                                            }
                                        ),
                                    },
                                    dc
                                )
                            );
                            break;

                        case UriContent uc when uc.HasTopLevelMediaType("image"):
                            contents.Add(
                                WithCacheControlFrom(
                                    new ImageBlockParam()
                                    {
                                        Source = new(
                                            new UrlImageSource() { Url = uc.Uri.AbsoluteUri }
                                        ),
                                    },
                                    uc
                                )
                            );
                            break;

                        case UriContent uc
                            when string.Equals(
                                uc.MediaType,
                                "application/pdf",
                                StringComparison.OrdinalIgnoreCase
                            ):
                            contents.Add(
                                WithCacheControlFrom(
                                    new DocumentBlockParam()
                                    {
                                        Source = new(
                                            new UrlPdfSource() { Url = uc.Uri.AbsoluteUri }
                                        ),
                                    },
                                    uc
                                )
                            );
                            break;

                        case FunctionCallContent fcc:
                            contents.Add(
                                WithCacheControlFrom(
                                    new ToolUseBlockParam()
                                    {
                                        ID = fcc.CallId,
                                        Name = fcc.Name,
                                        Input =
                                            fcc.Arguments?.ToDictionary(
                                                e => e.Key,
                                                e =>
                                                    e.Value is JsonElement je
                                                        ? je
                                                        : JsonSerializer.SerializeToElement(
                                                            e.Value,
                                                            AIJsonUtilities.DefaultOptions.GetTypeInfo(
                                                                typeof(object)
                                                            )
                                                        )
                                            ) ?? [],
                                    },
                                    fcc
                                )
                            );
                            break;

                        case FunctionResultContent frc:
                            ToolResultBlockParamContent result = frc.Result switch
                            {
                                ToolResultBlockParamContent trbpc => trbpc,

                                string s => new(s),

                                AIContent aiContent => new(ToResultBlocks([aiContent])),

                                IEnumerable<AIContent> aiContents => new(
                                    ToResultBlocks(aiContents)
                                ),

                                _ => new(
                                    JsonSerializer.Serialize(
                                        frc.Result,
                                        AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(object))
                                    )
                                ),
                            };

                            static IReadOnlyList<Block> ToResultBlocks(
                                IEnumerable<AIContent> aiContents
                            )
                            {
                                List<Block> blocks = [];
                                foreach (AIContent ac in aiContents)
                                {
                                    blocks.Add(
                                        ac switch
                                        {
                                            AIContent ai
                                                when ai.RawRepresentation is Block rawBlock =>
                                                rawBlock,

                                            TextContent tc => new Block(
                                                new TextBlockParam() { Text = tc.Text }
                                            ),

                                            DataContent dc when dc.HasTopLevelMediaType("image") =>
                                                new Block(
                                                    new ImageBlockParam()
                                                    {
                                                        Source = new(
                                                            new Base64ImageSource()
                                                            {
                                                                Data = dc.Base64Data.ToString(),
                                                                MediaType = dc.MediaType,
                                                            }
                                                        ),
                                                    }
                                                ),

                                            DataContent dc
                                                when string.Equals(
                                                    dc.MediaType,
                                                    "application/pdf",
                                                    StringComparison.OrdinalIgnoreCase
                                                ) => new Block(
                                                new DocumentBlockParam()
                                                {
                                                    Source = new(
                                                        new Base64PdfSource()
                                                        {
                                                            Data = dc.Base64Data.ToString(),
                                                        }
                                                    ),
                                                }
                                            ),

                                            DataContent dc when dc.HasTopLevelMediaType("text") =>
                                                new Block(
                                                    new DocumentBlockParam()
                                                    {
                                                        Source = new(
                                                            new PlainTextSource()
                                                            {
#if NET
                                                                Data = Encoding.UTF8.GetString(
                                                                    dc.Data.Span
                                                                ),
#else
                                                                Data = Encoding.UTF8.GetString(
                                                                    dc.Data.ToArray()
                                                                ),
#endif
                                                            }
                                                        ),
                                                    }
                                                ),

                                            UriContent uc when uc.HasTopLevelMediaType("image") =>
                                                new Block(
                                                    new ImageBlockParam()
                                                    {
                                                        Source = new(
                                                            new UrlImageSource()
                                                            {
                                                                Url = uc.Uri.AbsoluteUri,
                                                            }
                                                        ),
                                                    }
                                                ),

                                            UriContent uc
                                                when string.Equals(
                                                    uc.MediaType,
                                                    "application/pdf",
                                                    StringComparison.OrdinalIgnoreCase
                                                ) => new Block(
                                                new DocumentBlockParam()
                                                {
                                                    Source = new(
                                                        new UrlPdfSource()
                                                        {
                                                            Url = uc.Uri.AbsoluteUri,
                                                        }
                                                    ),
                                                }
                                            ),

                                            _ => new Block(
                                                new TextBlockParam()
                                                {
                                                    Text = JsonSerializer.Serialize(
                                                        ac,
                                                        AIJsonUtilities.DefaultOptions.GetTypeInfo(
                                                            typeof(object)
                                                        )
                                                    ),
                                                }
                                            ),
                                        }
                                    );
                                }

                                return blocks;
                            }

                            contents.Add(
                                WithCacheControlFrom(
                                    new ToolResultBlockParam()
                                    {
                                        ToolUseID = frc.CallId,
                                        IsError = frc.Exception is not null,
                                        Content = result,
                                    },
                                    frc
                                )
                            );
                            break;
                    }
                }

                if (contents.Count == 0)
                {
                    continue;
                }

                messageParams.Add(
                    new()
                    {
                        Role = message.Role == ChatRole.Assistant ? Role.Assistant : Role.User,
                        Content = contents,
                    }
                );
            }

            return messageParams;
        }

        /// <summary>
        /// Applies cache control from an <see cref="AIContent"/> to a content block param if configured.
        /// </summary>
        /// <remarks>
        /// Note: ThinkingBlockParam and RedactedThinkingBlockParam do not support cache control.
        /// </remarks>
        private static T WithCacheControlFrom<T>(T block, AIContent content)
            where T : class
        {
            var cacheControl = content.GetCacheControl();
            if (cacheControl is null)
            {
                return block;
            }

            return block switch
            {
                TextBlockParam tb => (tb with { CacheControl = cacheControl }) as T ?? block,
                ImageBlockParam ib => (ib with { CacheControl = cacheControl }) as T ?? block,
                DocumentBlockParam db => (db with { CacheControl = cacheControl }) as T ?? block,
                ToolUseBlockParam tub => (tub with { CacheControl = cacheControl }) as T ?? block,
                ToolResultBlockParam trb => (trb with { CacheControl = cacheControl }) as T
                    ?? block,
                _ => block,
            };
        }

        private MessageCreateParams GetMessageCreateParams(
            List<MessageParam> messages,
            List<TextBlockParam>? systemMessages,
            ChatOptions? options
        )
        {
            // Get the initial MessageCreateParams, either with a raw representation provided by the options
            // or with only the required properties set.
            MessageCreateParams? createParams =
                options?.RawRepresentationFactory?.Invoke(this) as MessageCreateParams;

            // Anthropic requires at least one message. If no messages were provided either directly
            // or via the RawRepresentationFactory, add an empty message.
            var createParamsOriginalMessages = createParams?.Messages;
            if (createParamsOriginalMessages is not { Count: > 0 } && messages.Count == 0)
            {
                messages.Add(new MessageParam() { Role = Role.User, Content = new("\u200b") }); // zero-width space
            }

            if (createParams is not null)
            {
                // Merge any messages preconfigured on the params with the ones provided to the IChatClient.
                createParams = createParams with
                {
                    Messages = [.. createParamsOriginalMessages ?? [], .. messages],
                };
            }
            else
            {
                createParams = new MessageCreateParams()
                {
                    MaxTokens = options?.MaxOutputTokens ?? _defaultMaxTokens,
                    Messages = messages,
                    Model =
                        options?.ModelId
                        ?? _defaultModelId
                        ?? throw new InvalidOperationException(
                            "Model ID must be specified either in ChatOptions or as the default for the client."
                        ),
                };
            }

            // Handle any other options to propagate to the create params.
            if (options is not null)
            {
                if (options.Instructions is { } instructions)
                {
                    (systemMessages ??= []).Add(new TextBlockParam() { Text = instructions });
                }

                if (
                    createParams.OutputConfig?.Format is null
                    && options.ResponseFormat is { } responseFormat
                )
                {
                    switch (responseFormat)
                    {
                        case ChatResponseFormatJson formatJson when formatJson.Schema is not null:
                            JsonElement schema = JsonSchemaTransformCache
                                .GetOrCreateTransformedSchema(formatJson)
                                .GetValueOrDefault();
                            if (
                                schema.TryGetProperty("properties", out JsonElement properties)
                                && properties.ValueKind is JsonValueKind.Object
                                && schema.TryGetProperty("required", out JsonElement required)
                                && required.ValueKind is JsonValueKind.Array
                            )
                            {
                                createParams = createParams with
                                {
                                    OutputConfig = (
                                        createParams.OutputConfig ?? new OutputConfig()
                                    ) with
                                    {
                                        Format = new JsonOutputFormat()
                                        {
                                            Schema = new Dictionary<string, JsonElement>
                                            {
                                                ["type"] = JsonElement.Parse("\"object\""),
                                                ["properties"] = properties,
                                                ["required"] = required,
                                                ["additionalProperties"] = JsonElement.Parse(
                                                    "false"
                                                ),
                                            },
                                        },
                                    },
                                };
                            }
                            break;
                    }
                }

                if (options.StopSequences is { Count: > 0 } stopSequences)
                {
                    createParams = createParams.StopSequences is { } existingSequences
                        ? createParams with
                        {
                            StopSequences = [.. existingSequences, .. stopSequences],
                        }
                        : createParams with
                        {
                            StopSequences = [.. stopSequences],
                        };
                }

                if (createParams.Temperature is null && options.Temperature is { } temperature)
                {
                    createParams = createParams with { Temperature = temperature };
                }

                if (createParams.TopK is null && options.TopK is { } topK)
                {
                    createParams = createParams with { TopK = topK };
                }

                if (createParams.TopP is null && options.TopP is { } topP)
                {
                    createParams = createParams with { TopP = topP };
                }

                if (options.Tools is { } tools)
                {
                    List<ToolUnion>? createdTools = createParams.Tools?.ToList();
                    foreach (var tool in tools)
                    {
                        switch (tool)
                        {
                            case ToolUnionAITool raw:
                                (createdTools ??= []).Add(raw.Tool);
                                break;

                            case AIFunctionDeclaration af:
                                JsonElement inputSchema =
                                    JsonSchemaTransformCache.GetOrCreateTransformedSchema(af);
                                Dictionary<string, JsonElement> schemaData = [];
                                if (inputSchema.ValueKind is JsonValueKind.Object)
                                {
                                    foreach (JsonProperty p in inputSchema.EnumerateObject())
                                    {
                                        schemaData[p.Name] = p.Value;
                                    }
                                }

                                (createdTools ??= []).Add(
                                    new Tool()
                                    {
                                        Name = af.Name,
                                        Description = af.Description,
                                        InputSchema = new InputSchema(schemaData),
                                        DeferLoading = GetValue<bool?>(
                                            af,
                                            nameof(Tool.DeferLoading)
                                        ),
                                        Strict = GetValue<bool?>(af, nameof(Tool.Strict)),
                                        InputExamples = GetValue<
                                            List<Dictionary<string, JsonElement>>
                                        >(af, nameof(Tool.InputExamples)),
                                        AllowedCallers = GetValue<
                                            List<ApiEnum<string, ToolAllowedCaller>>
                                        >(af, nameof(Tool.AllowedCallers)),
                                    }
                                );

                                static T? GetValue<T>(AIFunctionDeclaration af, string name) =>
                                    af.AdditionalProperties?.TryGetValue(name, out var value)
                                        is true
                                    && value is T tValue
                                        ? tValue
                                        : default;
                                break;

                            case HostedWebSearchTool:
                                (createdTools ??= []).Add(new WebSearchTool20250305());
                                break;

                            case HostedCodeInterpreterTool:
                                (createdTools ??= []).Add(new CodeExecutionTool20250825());
                                break;
                        }
                    }

                    if (createdTools?.Count > 0)
                    {
                        createParams = createParams with { Tools = createdTools };
                    }
                }

                if (createParams.ToolChoice is null && options.ToolMode is { } toolMode)
                {
                    ToolChoice? toolChoice =
                        toolMode is AutoChatToolMode
                            ? new ToolChoiceAuto()
                            {
                                DisableParallelToolUse = !options.AllowMultipleToolCalls,
                            }
                        : toolMode is NoneChatToolMode ? new ToolChoiceNone()
                        : toolMode is RequiredChatToolMode
                            ? new ToolChoiceAny()
                            {
                                DisableParallelToolUse = !options.AllowMultipleToolCalls,
                            }
                        : (ToolChoice?)null;
                    if (toolChoice is not null)
                    {
                        createParams = createParams with { ToolChoice = toolChoice };
                    }
                }

                if (createParams.Thinking is null && options.Reasoning is { } reasoning)
                {
                    ThinkingConfigParam? thinkingConfig = null;
                    if (reasoning.Effort is ReasoningEffort.None)
                    {
                        thinkingConfig = new(new ThinkingConfigDisabled());
                    }
                    else
                    {
                        long? budgetTokens = reasoning.Effort switch
                        {
                            ReasoningEffort.Low => 1024,
                            ReasoningEffort.Medium => 8192,
                            ReasoningEffort.High => 16384,
                            ReasoningEffort.ExtraHigh => 32768,
                            _ => null,
                        };

                        if (budgetTokens is { } budget)
                        {
                            // Anthropic requires thinking budget >= 1024 and < max tokens.
                            bool autoIncreaseMaxTokens = false;
                            if (createParams.MaxTokens <= budget)
                            {
                                if (options.MaxOutputTokens is not null)
                                {
                                    // Caller explicitly set MaxOutputTokens. Clamp the budget to fit,
                                    // and skip thinking if it can't meet the minimum.
                                    budget = createParams.MaxTokens - 1;
                                }
                                else
                                {
                                    autoIncreaseMaxTokens = true;
                                }
                            }

                            if (budget >= 1024)
                            {
                                if (autoIncreaseMaxTokens)
                                {
                                    // Caller didn't set MaxOutputTokens. Auto-increase max_tokens
                                    // to accommodate the thinking budget plus room for output.
                                    createParams = createParams with
                                    {
                                        MaxTokens = budget + _defaultMaxTokens,
                                    };
                                }

                                thinkingConfig = new(new ThinkingConfigEnabled(budget));
                            }
                        }
                    }

                    if (
                        thinkingConfig is not null
                        && reasoning.Output is ReasoningOutput.None
                        && thinkingConfig.Value is ThinkingConfigEnabled enabled
                    )
                    {
                        thinkingConfig = new(
                            enabled with
                            {
                                Display = ThinkingConfigEnabledDisplay.Omitted,
                            }
                        );
                    }

                    if (thinkingConfig is not null)
                    {
                        createParams = createParams with { Thinking = thinkingConfig };
                    }
                }
            }

            if (systemMessages is not null)
            {
                if (createParams.System is { } existingSystem)
                {
                    if (existingSystem.Value is string existingMessage)
                    {
                        systemMessages.Insert(0, new TextBlockParam() { Text = existingMessage });
                    }
                    else if (existingSystem.Value is IReadOnlyList<TextBlockParam> existingMessages)
                    {
                        systemMessages.InsertRange(0, existingMessages);
                    }
                }

                createParams = createParams with { System = systemMessages };
            }

            // Merge the MEAI user-agent header with existing headers
            return AddMeaiHeaders(createParams);
        }

        private static MessageCreateParams AddMeaiHeaders(MessageCreateParams createParams)
        {
            Dictionary<string, JsonElement> mergedHeaders = new(MeaiHeaderData);

            foreach (var header in createParams.RawHeaderData)
            {
                mergedHeaders[header.Key] = header.Value;
            }

            return MessageCreateParams.FromRawUnchecked(
                mergedHeaders,
                createParams.RawQueryData,
                createParams.RawBodyData
            );
        }

        private static UsageDetails ToUsageDetails(Usage usage) =>
            ToUsageDetails(
                usage.InputTokens,
                usage.OutputTokens,
                usage.CacheCreationInputTokens,
                usage.CacheReadInputTokens,
                usage.ServerToolUse
            );

        private static UsageDetails ToUsageDetails(MessageDeltaUsage usage) =>
            ToUsageDetails(
                usage.InputTokens,
                usage.OutputTokens,
                usage.CacheCreationInputTokens,
                usage.CacheReadInputTokens,
                usage.ServerToolUse
            );

        private static UsageDetails ToUsageDetails(
            long? inputTokens,
            long? outputTokens,
            long? cacheCreationInputTokens,
            long? cacheReadInputTokens,
            ServerToolUsage? serverToolUsage
        )
        {
            UsageDetails usageDetails = new()
            {
                // From https://platform.claude.com/docs/en/build-with-claude/prompt-caching:
                // "To calculate total input tokens:"
                // "total_input_tokens = cache_read_input_tokens + cache_creation_input_tokens + input_tokens"
                InputTokenCount = NullableSum(
                    NullableSum(cacheReadInputTokens, cacheCreationInputTokens),
                    inputTokens
                ),

                CachedInputTokenCount = cacheReadInputTokens,

                OutputTokenCount = outputTokens,
            };

            usageDetails.TotalTokenCount = NullableSum(
                usageDetails.InputTokenCount,
                usageDetails.OutputTokenCount
            );

            if (cacheCreationInputTokens is > 0)
            {
                (usageDetails.AdditionalCounts ??= [])[nameof(Usage.CacheCreationInputTokens)] =
                    cacheCreationInputTokens.Value;
            }

            if (serverToolUsage?.WebFetchRequests is > 0)
            {
                (usageDetails.AdditionalCounts ??= [])[nameof(ServerToolUsage.WebFetchRequests)] =
                    serverToolUsage.WebFetchRequests;
            }

            if (serverToolUsage?.WebSearchRequests is > 0)
            {
                (usageDetails.AdditionalCounts ??= [])[nameof(ServerToolUsage.WebSearchRequests)] =
                    serverToolUsage.WebSearchRequests;
            }

            return usageDetails;

            static long? NullableSum(long? a, long? b) =>
                a is not null || b is not null ? (a ?? 0) + (b ?? 0) : null;
        }

        private static ChatFinishReason? ToFinishReason(ApiEnum<string, StopReason>? stopReason) =>
            stopReason?.Value() switch
            {
                null => null,
                StopReason.Refusal => ChatFinishReason.ContentFilter,
                StopReason.MaxTokens => ChatFinishReason.Length,
                StopReason.ToolUse => ChatFinishReason.ToolCalls,
                _ => ChatFinishReason.Stop,
            };

        private static AIContent ContentBlockValueToAIContent(object? blockValue)
        {
            switch (blockValue)
            {
                case TextBlock text:
                    TextContent tc = new(text.Text) { RawRepresentation = text };

                    if (text.Citations is { Count: > 0 })
                    {
                        tc.Annotations =
                        [
                            .. text.Citations.Select(ToAIAnnotation).OfType<AIAnnotation>(),
                        ];
                    }

                    return tc;

                case ThinkingBlock thinking:
                    return new TextReasoningContent(thinking.Thinking)
                    {
                        ProtectedData = thinking.Signature,
                        RawRepresentation = thinking,
                    };

                case RedactedThinkingBlock redactedThinking:
                    return new TextReasoningContent(string.Empty)
                    {
                        ProtectedData = redactedThinking.Data,
                        RawRepresentation = redactedThinking,
                    };

                case ToolUseBlock toolUse:
                    var fcc = FunctionCallContent.CreateFromParsedArguments(
                        toolUse.RawData.TryGetValue("input", out JsonElement element)
                            ? element.GetRawText()
                            : "{}",
                        toolUse.ID,
                        toolUse.Name,
                        json =>
                            (Dictionary<string, object?>?)
                                JsonSerializer.Deserialize(
                                    json,
                                    AIJsonUtilities.DefaultOptions.GetTypeInfo(
                                        typeof(Dictionary<string, object?>)
                                    )
                                )
                    );
                    fcc.RawRepresentation = toolUse;
                    return fcc;

                case CodeExecutionToolResultBlock ce:
                {
                    CodeInterpreterToolResultContent c = new(ce.ToolUseID)
                    {
                        RawRepresentation = ce,
                    };

                    if (ce.Content.TryPickError(out var ceError))
                    {
                        (c.Outputs ??= []).Add(
                            new ErrorContent(null)
                            {
                                ErrorCode = ceError.ErrorCode.Value().ToString(),
                            }
                        );
                    }

                    if (ce.Content.TryPickResultBlock(out var ceOutput))
                    {
                        if (!string.IsNullOrWhiteSpace(ceOutput.Stdout))
                        {
                            (c.Outputs ??= []).Add(new TextContent(ceOutput.Stdout));
                        }

                        if (!string.IsNullOrWhiteSpace(ceOutput.Stderr) || ceOutput.ReturnCode != 0)
                        {
                            (c.Outputs ??= []).Add(
                                new ErrorContent(ceOutput.Stderr)
                                {
                                    ErrorCode = ceOutput.ReturnCode.ToString(
                                        CultureInfo.InvariantCulture
                                    ),
                                }
                            );
                        }

                        if (ceOutput.Content is { Count: > 0 })
                        {
                            foreach (var ceOutputContent in ceOutput.Content)
                            {
                                (c.Outputs ??= []).Add(
                                    new HostedFileContent(ceOutputContent.FileID)
                                );
                            }
                        }
                    }

                    if (ce.Content.TryPickEncryptedCodeExecutionResultBlock(out var ceEncrypted))
                    {
                        // Unlike with the non-encrypted case above, we skip Stdout, as here it's encrypted.

                        if (
                            !string.IsNullOrWhiteSpace(ceEncrypted.Stderr)
                            || ceEncrypted.ReturnCode != 0
                        )
                        {
                            (c.Outputs ??= []).Add(
                                new ErrorContent(ceEncrypted.Stderr)
                                {
                                    ErrorCode = ceEncrypted.ReturnCode.ToString(
                                        CultureInfo.InvariantCulture
                                    ),
                                }
                            );
                        }

                        if (ceEncrypted.Content is { Count: > 0 })
                        {
                            foreach (var ceOutputContent in ceEncrypted.Content)
                            {
                                (c.Outputs ??= []).Add(
                                    new HostedFileContent(ceOutputContent.FileID)
                                );
                            }
                        }
                    }

                    return c;
                }

                case BashCodeExecutionToolResultBlock ce:
                {
                    CodeInterpreterToolResultContent c = new(ce.ToolUseID)
                    {
                        RawRepresentation = ce,
                    };

                    if (ce.Content.TryPickBashCodeExecutionToolResultError(out var ceError))
                    {
                        (c.Outputs ??= []).Add(
                            new ErrorContent(null)
                            {
                                ErrorCode = ceError.ErrorCode.Value().ToString(),
                            }
                        );
                    }

                    if (ce.Content.TryPickBashCodeExecutionResultBlock(out var ceOutput))
                    {
                        if (!string.IsNullOrWhiteSpace(ceOutput.Stdout))
                        {
                            (c.Outputs ??= []).Add(new TextContent(ceOutput.Stdout));
                        }

                        if (!string.IsNullOrWhiteSpace(ceOutput.Stderr) || ceOutput.ReturnCode != 0)
                        {
                            (c.Outputs ??= []).Add(
                                new ErrorContent(ceOutput.Stderr)
                                {
                                    ErrorCode = ceOutput.ReturnCode.ToString(
                                        CultureInfo.InvariantCulture
                                    ),
                                }
                            );
                        }

                        if (ceOutput.Content is { Count: > 0 })
                        {
                            foreach (var ceOutputContent in ceOutput.Content)
                            {
                                (c.Outputs ??= []).Add(
                                    new HostedFileContent(ceOutputContent.FileID)
                                );
                            }
                        }
                    }

                    return c;
                }

                case ServerToolUseBlock serverToolUse:
                {
                    Name nameValue = serverToolUse.Name.Value();
                    switch (nameValue)
                    {
                        case Name.WebSearch:
                        case Name.WebFetch:
                            WebSearchToolCallContent wsc = new(serverToolUse.ID)
                            {
                                RawRepresentation = serverToolUse,
                            };
                            if (
                                serverToolUse.Input?.TryGetValue(
                                    "query",
                                    out JsonElement queryElement
                                ) == true
                                && queryElement.ValueKind == JsonValueKind.String
                            )
                            {
                                (wsc.Queries ??= []).Add(queryElement.GetString()!);
                            }

                            return wsc;

                        case Name.CodeExecution:
                        case Name.BashCodeExecution:
                        case Name.TextEditorCodeExecution:
                            CodeInterpreterToolCallContent cic = new(serverToolUse.ID)
                            {
                                RawRepresentation = serverToolUse,
                            };

                            // CodeExecution (Python) uses "code"; Bash/TextEditor use "command".
                            if (
                                (
                                    serverToolUse.Input?.TryGetValue(
                                        "code",
                                        out JsonElement codeElement
                                    ) == true
                                    || serverToolUse.Input?.TryGetValue("command", out codeElement)
                                        == true
                                )
                                && codeElement.ValueKind == JsonValueKind.String
                            )
                            {
                                string code = codeElement.GetString()!;
                                string mediaType =
                                    nameValue == Name.CodeExecution ? "text/x-python"
                                    : nameValue == Name.BashCodeExecution ? "application/x-sh"
                                    : "text/plain";
                                (cic.Inputs ??= []).Add(
                                    new DataContent(Encoding.UTF8.GetBytes(code), mediaType)
                                );
                            }

                            return cic;

                        default:
                            return new ToolCallContent(serverToolUse.ID)
                            {
                                RawRepresentation = serverToolUse,
                            };
                    }
                }

                case WebSearchToolResultBlock wsResult:
                {
                    WebSearchToolResultContent wsrc = new(wsResult.ToolUseID)
                    {
                        RawRepresentation = wsResult,
                    };

                    if (wsResult.Content.TryPickWebSearchResultBlocks(out var searchResults))
                    {
                        foreach (var result in searchResults)
                        {
                            (wsrc.Results ??= []).Add(
                                new UriContent(result.Url, InferMediaTypeFromExtension(result.Url))
                                {
                                    RawRepresentation = result,
                                }
                            );
                        }
                    }
                    else if (wsResult.Content.TryPickError(out var wsError))
                    {
                        (wsrc.Results ??= []).Add(
                            new ErrorContent(null)
                            {
                                ErrorCode = wsError.ErrorCode.Value().ToString(),
                                RawRepresentation = wsError,
                            }
                        );
                    }

                    return wsrc;
                }

                case WebFetchToolResultBlock wfResult:
                {
                    WebSearchToolResultContent wfrc = new(wfResult.ToolUseID)
                    {
                        RawRepresentation = wfResult,
                    };

                    if (wfResult.Content.TryPickWebFetchBlock(out var fetchBlock))
                    {
                        (wfrc.Results ??= []).Add(
                            new UriContent(
                                fetchBlock.Url,
                                InferMediaTypeFromExtension(fetchBlock.Url)
                            )
                            {
                                RawRepresentation = fetchBlock,
                            }
                        );
                    }
                    else if (wfResult.Content.TryPickWebFetchToolResultErrorBlock(out var wfError))
                    {
                        (wfrc.Results ??= []).Add(
                            new ErrorContent(null)
                            {
                                ErrorCode = wfError.ErrorCode.Value().ToString(),
                                RawRepresentation = wfError,
                            }
                        );
                    }

                    return wfrc;
                }

                case TextEditorCodeExecutionToolResultBlock te:
                {
                    CodeInterpreterToolResultContent c = new(te.ToolUseID)
                    {
                        RawRepresentation = te,
                    };

                    if (te.Content.TryPickTextEditorCodeExecutionToolResultError(out var teError))
                    {
                        (c.Outputs ??= []).Add(
                            new ErrorContent(teError.ErrorMessage)
                            {
                                ErrorCode = teError.ErrorCode.Value().ToString(),
                                RawRepresentation = teError,
                            }
                        );
                    }
                    else if (
                        te.Content.TryPickTextEditorCodeExecutionViewResultBlock(out var viewResult)
                    )
                    {
                        (c.Outputs ??= []).Add(
                            new TextContent(viewResult.Content) { RawRepresentation = viewResult }
                        );
                    }
                    else if (
                        te.Content.TryPickTextEditorCodeExecutionCreateResultBlock(
                            out var createResult
                        )
                    )
                    {
                        (c.Outputs ??= []).Add(
                            new TextContent(
                                createResult.IsFileUpdate ? "File updated" : "File created"
                            )
                            {
                                RawRepresentation = createResult,
                            }
                        );
                    }
                    else if (
                        te.Content.TryPickTextEditorCodeExecutionStrReplaceResultBlock(
                            out var replaceResult
                        )
                    )
                    {
                        (c.Outputs ??= []).Add(
                            new TextContent(
                                replaceResult.Lines is { Count: > 0 }
                                    ? string.Join("\n", replaceResult.Lines)
                                    : "String replacement applied"
                            )
                            {
                                RawRepresentation = replaceResult,
                            }
                        );
                    }

                    return c;
                }

                case ToolSearchToolResultBlock ts:
                    return new ToolResultContent(ts.ToolUseID) { RawRepresentation = ts };

                case ContainerUploadBlock containerUpload:
                    return new HostedFileContent(containerUpload.FileID)
                    {
                        RawRepresentation = containerUpload,
                    };

                default:
                    return new AIContent() { RawRepresentation = blockValue };
            }
        }

        private static AIContent CreateStreamingToolCallContent(StreamingFunctionData functionData)
        {
            if (functionData.ServerToolName is not Name serverToolName)
            {
                return FunctionCallContent.CreateFromParsedArguments(
                    functionData.Arguments.ToString(),
                    functionData.CallId,
                    functionData.Name,
                    json =>
                        json.Length == 0
                            ? null
                            : (Dictionary<string, object?>?)
                                JsonSerializer.Deserialize(
                                    json,
                                    AIJsonUtilities.DefaultOptions.GetTypeInfo(
                                        typeof(Dictionary<string, object?>)
                                    )
                                )
                );
            }

            IReadOnlyDictionary<string, JsonElement>? input = functionData.InitialInput;
            if (functionData.Arguments.Length > 0)
            {
                try
                {
                    input = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                        functionData.Arguments.ToString()
                    );
                }
                catch (JsonException) { }
            }

            switch (serverToolName)
            {
                case Name.WebSearch:
                case Name.WebFetch:
                    WebSearchToolCallContent wsc = new(functionData.CallId)
                    {
                        RawRepresentation = functionData.RawRepresentation,
                    };
                    if (
                        input?.TryGetValue("query", out JsonElement queryElement) == true
                        && queryElement.ValueKind == JsonValueKind.String
                    )
                    {
                        (wsc.Queries ??= []).Add(queryElement.GetString()!);
                    }

                    return wsc;

                case Name.CodeExecution:
                case Name.BashCodeExecution:
                case Name.TextEditorCodeExecution:
                    CodeInterpreterToolCallContent cic = new(functionData.CallId)
                    {
                        RawRepresentation = functionData.RawRepresentation,
                    };

                    // CodeExecution (Python) uses "code"; Bash/TextEditor use "command".
                    if (
                        (
                            input?.TryGetValue("code", out JsonElement codeElement) == true
                            || input?.TryGetValue("command", out codeElement) == true
                        )
                        && codeElement.ValueKind == JsonValueKind.String
                    )
                    {
                        string code = codeElement.GetString()!;
                        string mediaType =
                            serverToolName == Name.CodeExecution ? "text/x-python"
                            : serverToolName == Name.BashCodeExecution ? "application/x-sh"
                            : "text/plain";
                        (cic.Inputs ??= []).Add(
                            new DataContent(Encoding.UTF8.GetBytes(code), mediaType)
                        );
                    }

                    return cic;

                default:
                    return new ToolCallContent(functionData.CallId)
                    {
                        RawRepresentation = functionData.RawRepresentation,
                    };
            }
        }

        private static CitationAnnotation? ToAIAnnotation(TextCitation citation)
        {
            CitationAnnotation annotation = new()
            {
                Title = citation.Title ?? citation.DocumentTitle,
                Snippet = citation.CitedText,
                FileId = citation.FileID,
            };

            if (citation.TryPickCitationsWebSearchResultLocation(out var webSearchLocation))
            {
                annotation.Url = Uri.TryCreate(
                    webSearchLocation.Url,
                    UriKind.Absolute,
                    out Uri? url
                )
                    ? url
                    : null;
            }
            else if (citation.TryPickCitationsSearchResultLocation(out var searchLocation))
            {
                annotation.Url = Uri.TryCreate(
                    searchLocation.Source,
                    UriKind.Absolute,
                    out Uri? url
                )
                    ? url
                    : null;
            }

            return annotation;
        }

        private static CitationAnnotation? ToAIAnnotation(Citation citation)
        {
            CitationAnnotation annotation = new()
            {
                Title = citation.Title ?? citation.DocumentTitle,
                Snippet = citation.CitedText,
                FileId = citation.FileID,
            };

            if (citation.TryPickCitationsWebSearchResultLocation(out var webSearchLocation))
            {
                annotation.Url = Uri.TryCreate(
                    webSearchLocation.Url,
                    UriKind.Absolute,
                    out Uri? url
                )
                    ? url
                    : null;
            }
            else if (citation.TryPickCitationsSearchResultLocation(out var searchLocation))
            {
                annotation.Url = Uri.TryCreate(
                    searchLocation.Source,
                    UriKind.Absolute,
                    out Uri? url
                )
                    ? url
                    : null;
            }

            return annotation;
        }

        private sealed class StreamingFunctionData
        {
            public string CallId { get; set; } = "";
            public string Name { get; set; } = "";
            public Name? ServerToolName { get; set; }
            public IReadOnlyDictionary<string, JsonElement>? InitialInput { get; set; }
            public object? RawRepresentation { get; set; }
            public StringBuilder Arguments { get; } = new();
        }
    }

    private sealed class ToolUnionAITool(ToolUnion tool) : AITool
    {
        public ToolUnion Tool => tool;

        public override string Name => tool.Value?.GetType().Name ?? base.Name;

        public override object? GetService(System.Type serviceType, object? serviceKey = null) =>
            serviceKey is null && serviceType?.IsInstanceOfType(tool) is true
                ? tool
                : base.GetService(serviceType!, serviceKey);
    }
}
