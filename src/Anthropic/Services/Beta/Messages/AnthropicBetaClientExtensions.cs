using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta;

#pragma warning disable MEAI001 // [Experimental] APIs in Microsoft.Extensions.AI
#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace Microsoft.Extensions.AI;

public static class AnthropicBetaClientExtensions
{
    /// <summary>
    /// Creates an <see cref="AITool"/> to represent a skill for use with the Anthropic Skills API.
    /// </summary>
    /// <param name="skillParams">The skill parameters to wrap as an <see cref="AITool"/>.</param>
    /// <returns>The <paramref name="skillParams"/> wrapped as an <see cref="AITool"/>.</returns>
    /// <remarks>
    /// <para>
    /// The returned tool is only suitable for use with the <see cref="IChatClient"/> returned by
    /// <see cref="AsIChatClient"/> (or <see cref="IChatClient"/>s that delegate
    /// to such an instance). It is likely to be ignored by any other <see cref="IChatClient"/> implementation.
    /// </para>
    /// <para>
    /// When this tool is included in <see cref="ChatOptions.Tools"/>, the <see cref="IChatClient"/> will automatically:
    /// <list type="bullet">
    /// <item><description>Configure the container with the skill(s)</description></item>
    /// <item><description>Add the required beta headers (<c>code-execution-2025-08-25</c> and <c>skills-2025-10-02</c>)</description></item>
    /// <item><description>Add the code execution tool if not already present</description></item>
    /// </list>
    /// </para>
    /// <para>
    /// Example usage:
    /// <code>
    /// var options = new ChatOptions
    /// {
    ///     ModelId = "claude-sonnet-4-5-20250929",
    ///     MaxOutputTokens = 4096,
    ///     Tools =
    ///     [
    ///         new BetaSkillParams { Type = BetaSkillParamsType.Anthropic, SkillID = "pptx", Version = "latest" }.AsAITool(),
    ///         new BetaSkillParams { Type = BetaSkillParamsType.Anthropic, SkillID = "xlsx", Version = "latest" }.AsAITool(),
    ///     ]
    /// };
    /// </code>
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="skillParams"/> is <see langword="null"/>.</exception>
    public static AITool AsAITool(this BetaSkillParams skillParams)
    {
        if (skillParams is null)
        {
            throw new ArgumentNullException(nameof(skillParams));
        }

        return new BetaSkillsParamsAITool(skillParams);
    }

    /// <summary>Gets an <see cref="IChatClient"/> for use with this <see cref="IBetaService"/>.</summary>
    /// <param name="betaService">The beta service.</param>
    /// <param name="defaultModelId">
    /// The default ID of the model to use.
    /// If <see langword="null"/>, it must be provided per request via <see cref="ChatOptions.ModelId"/>.
    /// </param>
    /// <param name="defaultMaxOutputTokens">
    /// The default maximum number of tokens to generate in a response.
    /// This may be overridden with <see cref="ChatOptions.MaxOutputTokens"/>.
    /// If no value is provided for this parameter or in <see cref="ChatOptions"/>, a default maximum will be used.
    /// </param>
    /// <returns>An <see cref="IChatClient"/> that can be used to converse via the <see cref="IBetaService"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="betaService"/> is <see langword="null"/>.</exception>
    public static IChatClient AsIChatClient(
        this Anthropic.Services.IBetaService betaService,
        string? defaultModelId = null,
        int? defaultMaxOutputTokens = null
    )
    {
        if (betaService is null)
        {
            throw new ArgumentNullException(nameof(betaService));
        }

        if (defaultMaxOutputTokens is <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(defaultMaxOutputTokens),
                "Default max tokens must be greater than zero."
            );
        }

        return new AnthropicChatClient(betaService, defaultModelId, defaultMaxOutputTokens);
    }

    /// <summary>Creates an <see cref="AITool"/> to represent a raw <see cref="BetaToolUnion"/>.</summary>
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
    /// map the supplied <see cref="BetaToolUnion"/> to any of those types, it simply wraps it as-is:
    /// the <see cref="IChatClient"/> returned by <see cref="AsIChatClient"/> will
    /// be able to unwrap the <see cref="BetaToolUnion"/> when it processes the list of tools.
    /// </para>
    /// </remarks>
    public static AITool AsAITool(this BetaToolUnion tool)
    {
        if (tool is null)
        {
            throw new ArgumentNullException(nameof(tool));
        }

        return new BetaToolUnionAITool(tool);
    }

    private sealed class AnthropicChatClient(
        Anthropic.Services.IBetaService betaService,
        string? defaultModelId,
        int? defaultMaxOutputTokens
    ) : IChatClient
    {
        private const int DefaultMaxTokens = 1024;
        private const string MeaiUserAgentHeaderKey = "User-Agent";

        private static readonly FrozenDictionary<string, JsonElement> s_meaiHeaderData =
            new Dictionary<string, JsonElement>
            {
                [MeaiUserAgentHeaderKey] = JsonSerializer.SerializeToElement(
                    CreateMeaiUserAgentValue()
                ),
            }.ToFrozenDictionary();

        private static string CreateMeaiUserAgentValue()
        {
            const string Name = "MEAI";

            if (
                typeof(IChatClient)
                    .Assembly.GetCustomAttribute<System.Reflection.AssemblyInformationalVersionAttribute>()
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

        private static readonly AIJsonSchemaTransformCache s_transformCache = new(
            new AIJsonSchemaTransformOptions
            {
                DisallowAdditionalProperties = true,
                TransformSchemaNode = (ctx, schemaNode) =>
                {
                    if (schemaNode is JsonObject schemaObj)
                    {
                        // From https://platform.claude.com/docs/en/build-with-claude/structured-outputs
                        ReadOnlySpan<string> unsupportedProperties =
                        [
                            "minimum",
                            "maximum",
                            "multipleOf",
                            "minLength",
                            "maxLength",
                        ];

                        foreach (string propName in unsupportedProperties)
                        {
                            _ = schemaObj.Remove(propName);
                        }

                        // Handle nullable union types (e.g., "type": ["integer", "null"]) for
                        // non-required properties. The C# MCP SDK generates these for optional
                        // parameters, but structured outputs doesn't support union types.
                        // Only transform non-required properties; required + nullable is an
                        // incompatible schema that should fail at the API level.
                        if (
                            schemaObj.TryGetPropertyValue("properties", out JsonNode? propsNode)
                            && propsNode is JsonObject propsObj
                        )
                        {
                            HashSet<string> requiredProps = [];
                            if (
                                schemaObj.TryGetPropertyValue("required", out JsonNode? reqNode)
                                && reqNode is JsonArray reqArray
                            )
                            {
                                foreach (JsonNode? req in reqArray)
                                {
                                    if (req?.GetValue<string>() is string reqName)
                                    {
                                        requiredProps.Add(reqName);
                                    }
                                }
                            }

                            foreach (var prop in propsObj)
                            {
                                if (requiredProps.Contains(prop.Key))
                                {
                                    continue;
                                }

                                if (prop.Value is not JsonObject propSchema)
                                {
                                    continue;
                                }

                                if (
                                    !propSchema.TryGetPropertyValue("type", out JsonNode? typeNode)
                                    || typeNode is not JsonArray typeArray
                                )
                                {
                                    continue;
                                }

                                int nullIndex = -1;
                                for (int i = 0; i < typeArray.Count; i++)
                                {
                                    if (typeArray[i]?.GetValue<string>() == "null")
                                    {
                                        nullIndex = i;
                                        break;
                                    }
                                }

                                if (nullIndex < 0)
                                {
                                    continue;
                                }

                                typeArray.RemoveAt(nullIndex);

                                if (typeArray.Count == 1)
                                {
                                    propSchema["type"] = typeArray[0]?.DeepClone();
                                }

                                if (
                                    propSchema.TryGetPropertyValue(
                                        "default",
                                        out JsonNode? defaultNode
                                    )
                                    && defaultNode is JsonValue defaultValue
                                    && defaultValue.GetValueKind() == JsonValueKind.Null
                                )
                                {
                                    propSchema.Remove("default");
                                }
                            }
                        }
                    }

                    return schemaNode;
                },
            }
        );

        private readonly Anthropic.Services.IBetaService _betaService = betaService;
        private readonly string? _defaultModelId = defaultModelId;
        private readonly int _defaultMaxTokens = defaultMaxOutputTokens ?? DefaultMaxTokens;
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
                    _betaService.Messages is MessageService { _client.BaseUrl: string baseUrl }
                        ? new Uri(baseUrl)
                        : null,
                    _defaultModelId
                );
            }

            if (serviceType.IsInstanceOfType(_betaService))
            {
                return _betaService;
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

            List<BetaMessageParam> messageParams = CreateMessageParams(
                messages,
                out List<BetaTextBlockParam>? systemMessages
            );
            MessageCreateParams createParams = GetMessageCreateParams(
                messageParams,
                systemMessages,
                options
            );

            var createResult = await _betaService.Messages.Create(createParams, cancellationToken);

            ChatMessage m = new(ChatRole.Assistant, [.. createResult.Content.Select(ToAIContent)])
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

            List<BetaMessageParam> messageParams = CreateMessageParams(
                messages,
                out List<BetaTextBlockParam>? systemMessages
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
                var createResult in _betaService
                    .Messages.CreateStreaming(createParams, cancellationToken)
                    .WithCancellation(cancellationToken)
            )
            {
                List<AIContent> contents = [];

                switch (createResult.Value)
                {
                    case BetaRawMessageStartEvent rawMessageStart:
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

                    case BetaRawMessageDeltaEvent rawMessageDelta:
                        finishReason = ToFinishReason(rawMessageDelta.Delta.StopReason);
                        if (rawMessageDelta.Usage is { } deltaUsage)
                        {
                            // https://platform.claude.com/docs/en/build-with-claude/streaming
                            // "The token counts shown in the usage field of the message_delta event are cumulative."
                            usageDetails = ToUsageDetails(deltaUsage);
                        }
                        break;

                    case BetaRawContentBlockStartEvent contentBlockStart:
                        switch (contentBlockStart.ContentBlock.Value)
                        {
                            case BetaTextBlock text:
                                contents.Add(
                                    new TextContent(text.Text) { RawRepresentation = text }
                                );
                                break;

                            case BetaThinkingBlock thinking:
                                contents.Add(
                                    new TextReasoningContent(thinking.Thinking)
                                    {
                                        ProtectedData = thinking.Signature,
                                        RawRepresentation = thinking,
                                    }
                                );
                                break;

                            case BetaRedactedThinkingBlock redactedThinking:
                                contents.Add(
                                    new TextReasoningContent(string.Empty)
                                    {
                                        ProtectedData = redactedThinking.Data,
                                        RawRepresentation = redactedThinking,
                                    }
                                );
                                break;

                            case BetaToolUseBlock toolUse:
                                streamingFunctions ??= [];
                                streamingFunctions[contentBlockStart.Index] = new()
                                {
                                    CallId = toolUse.ID,
                                    Name = toolUse.Name,
                                };
                                break;
                        }
                        break;

                    case BetaRawContentBlockDeltaEvent contentBlockDelta:
                        switch (contentBlockDelta.Delta.Value)
                        {
                            case BetaTextDelta textDelta:
                                contents.Add(
                                    new TextContent(textDelta.Text)
                                    {
                                        RawRepresentation = textDelta,
                                    }
                                );
                                break;

                            case BetaInputJsonDelta inputDelta:
                                if (
                                    streamingFunctions is not null
                                    && streamingFunctions.TryGetValue(
                                        contentBlockDelta.Index,
                                        out var functionData
                                    )
                                )
                                {
                                    functionData.Arguments.Append(inputDelta.PartialJson);
                                }
                                break;

                            case BetaThinkingDelta thinkingDelta:
                                contents.Add(
                                    new TextReasoningContent(thinkingDelta.Thinking)
                                    {
                                        RawRepresentation = thinkingDelta,
                                    }
                                );
                                break;

                            case BetaSignatureDelta signatureDelta:
                                contents.Add(
                                    new TextReasoningContent(null)
                                    {
                                        ProtectedData = signatureDelta.Signature,
                                        RawRepresentation = signatureDelta,
                                    }
                                );
                                break;
                        }
                        break;

                    case BetaRawContentBlockStopEvent contentBlockStop:
                        if (streamingFunctions is not null)
                        {
                            foreach (var sf in streamingFunctions)
                            {
                                contents.Add(
                                    FunctionCallContent.CreateFromParsedArguments(
                                        sf.Value.Arguments.ToString(),
                                        sf.Value.CallId,
                                        sf.Value.Name,
                                        json =>
                                            (Dictionary<string, object?>?)
                                                JsonSerializer.Deserialize(
                                                    json,
                                                    AIJsonUtilities.DefaultOptions.GetTypeInfo(
                                                        typeof(Dictionary<string, object?>)
                                                    )
                                                )
                                    )
                                );
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
                    RawRepresentation = createResult,
                    ResponseId = messageId,
                    ModelId = modelID,
                };
            }

            if (usageDetails is not null)
            {
                yield return new(ChatRole.Assistant, [new UsageContent(usageDetails)])
                {
                    CreatedAt = DateTimeOffset.UtcNow,
                    FinishReason = finishReason,
                    MessageId = messageId,
                    ResponseId = messageId,
                    ModelId = modelID,
                };
            }
        }

        private static List<BetaMessageParam> CreateMessageParams(
            IEnumerable<ChatMessage> messages,
            out List<BetaTextBlockParam>? systemMessages
        )
        {
            List<BetaMessageParam> messageParams = [];
            systemMessages = null;

            foreach (ChatMessage message in messages)
            {
                if (message.Role == ChatRole.System)
                {
                    foreach (AIContent content in message.Contents)
                    {
                        if (content is TextContent tc)
                        {
                            var block = new BetaTextBlockParam { Text = tc.Text };
                            (systemMessages ??= []).Add(WithCacheControlFrom(block, tc));
                        }
                    }

                    continue;
                }

                List<BetaContentBlockParam> contents = [];

                foreach (AIContent content in message.Contents)
                {
                    switch (content)
                    {
                        case AIContent ac
                            when ac.RawRepresentation is BetaContentBlockParam rawContent:
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
                                            new BetaTextBlockParam() { Text = text },
                                            tc
                                        )
                                    );
                                }
                            }
                            else if (!string.IsNullOrWhiteSpace(text))
                            {
                                contents.Add(
                                    WithCacheControlFrom(
                                        new BetaTextBlockParam() { Text = text },
                                        tc
                                    )
                                );
                            }
                            break;

                        case TextReasoningContent trc when !string.IsNullOrEmpty(trc.Text):
                            contents.Add(
                                WithCacheControlFrom(
                                    new BetaThinkingBlockParam()
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
                                    new BetaRedactedThinkingBlockParam()
                                    {
                                        Data = trc.ProtectedData!,
                                    },
                                    trc
                                )
                            );
                            break;

                        case DataContent dc when dc.HasTopLevelMediaType("image"):
                            contents.Add(
                                WithCacheControlFrom(
                                    new BetaImageBlockParam()
                                    {
                                        Source = new(
                                            new BetaBase64ImageSource()
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
                                    new BetaRequestDocumentBlock()
                                    {
                                        Source = new(
                                            new BetaBase64PdfSource()
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
                                    new BetaRequestDocumentBlock()
                                    {
                                        Source = new(
                                            new BetaPlainTextSource()
                                            {
#if NET
                                                Data = Encoding.UTF8.GetString(dc.Data.Span),
#else
                                                Data = Encoding.UTF8.GetString(dc.Data.ToArray()),
#endif
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
                                    new BetaImageBlockParam()
                                    {
                                        Source = new(
                                            new BetaUrlImageSource() { Url = uc.Uri.AbsoluteUri }
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
                                    new BetaRequestDocumentBlock()
                                    {
                                        Source = new(
                                            new BetaUrlPdfSource() { Url = uc.Uri.AbsoluteUri }
                                        ),
                                    },
                                    uc
                                )
                            );
                            break;

                        case HostedFileContent fc:
                            contents.Add(
                                WithCacheControlFrom(
                                    new BetaRequestDocumentBlock()
                                    {
                                        Source = new(new BetaFileDocumentSource(fc.FileId)),
                                    },
                                    fc
                                )
                            );
                            break;

                        case FunctionCallContent fcc:
                            contents.Add(
                                WithCacheControlFrom(
                                    new BetaToolUseBlockParam()
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
                            BetaToolResultBlockParamContent result = frc.Result switch
                            {
                                BetaToolResultBlockParamContent btrbpc => btrbpc,

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
                                                new BetaTextBlockParam() { Text = tc.Text }
                                            ),

                                            DataContent dc when dc.HasTopLevelMediaType("image") =>
                                                new Block(
                                                    new BetaImageBlockParam()
                                                    {
                                                        Source = new(
                                                            new BetaBase64ImageSource()
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
                                                new BetaRequestDocumentBlock()
                                                {
                                                    Source = new(
                                                        new BetaBase64PdfSource()
                                                        {
                                                            Data = dc.Base64Data.ToString(),
                                                        }
                                                    ),
                                                }
                                            ),

                                            DataContent dc when dc.HasTopLevelMediaType("text") =>
                                                new Block(
                                                    new BetaRequestDocumentBlock()
                                                    {
                                                        Source = new(
                                                            new BetaPlainTextSource()
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
                                                    new BetaImageBlockParam()
                                                    {
                                                        Source = new(
                                                            new BetaUrlImageSource()
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
                                                new BetaRequestDocumentBlock()
                                                {
                                                    Source = new(
                                                        new BetaUrlPdfSource()
                                                        {
                                                            Url = uc.Uri.AbsoluteUri,
                                                        }
                                                    ),
                                                }
                                            ),

                                            HostedFileContent fc => new Block(
                                                new BetaRequestDocumentBlock()
                                                {
                                                    Source = new(
                                                        new BetaFileDocumentSource(fc.FileId)
                                                    ),
                                                }
                                            ),

                                            _ => new Block(
                                                new BetaTextBlockParam()
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
                                    new BetaToolResultBlockParam()
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

            if (messageParams.Count == 0)
            {
                messageParams.Add(new() { Role = Role.User, Content = new("\u200b") }); // zero-width space
            }

            return messageParams;
        }

        /// <summary>
        /// Applies cache control from an <see cref="AIContent"/> to a beta content block param if configured.
        /// </summary>
        /// <remarks>
        /// Converts from <see cref="Anthropic.Models.Messages.CacheControlEphemeral"/> (used by the extension)
        /// to <see cref="BetaCacheControlEphemeral"/> (used by the beta API).
        /// Note: BetaThinkingBlockParam and BetaRedactedThinkingBlockParam do not support cache control.
        /// </remarks>
        private static T WithCacheControlFrom<T>(T block, AIContent content)
            where T : class
        {
            var cacheControl = content.GetCacheControl();
            if (cacheControl is null)
            {
                return block;
            }

            // Convert non-beta CacheControlEphemeral to BetaCacheControlEphemeral
            // Note: Ttl enum exists in both namespaces, using fully qualified names to disambiguate
            var betaCacheControl = new BetaCacheControlEphemeral
            {
                Ttl = cacheControl.Ttl?.Value() switch
                {
                    Anthropic.Models.Messages.Ttl.Ttl5m => Anthropic.Models.Beta.Messages.Ttl.Ttl5m,
                    Anthropic.Models.Messages.Ttl.Ttl1h => Anthropic.Models.Beta.Messages.Ttl.Ttl1h,
                    _ => null,
                },
            };

            return block switch
            {
                BetaTextBlockParam tb => (tb with { CacheControl = betaCacheControl }) as T
                    ?? block,
                BetaImageBlockParam ib => (ib with { CacheControl = betaCacheControl }) as T
                    ?? block,
                BetaRequestDocumentBlock db => (db with { CacheControl = betaCacheControl }) as T
                    ?? block,
                BetaToolUseBlockParam tub => (tub with { CacheControl = betaCacheControl }) as T
                    ?? block,
                BetaToolResultBlockParam trb => (trb with { CacheControl = betaCacheControl }) as T
                    ?? block,
                _ => block,
            };
        }

        private MessageCreateParams GetMessageCreateParams(
            List<BetaMessageParam> messages,
            List<BetaTextBlockParam>? systemMessages,
            ChatOptions? options
        )
        {
            // Get the initial MessageCreateParams, either with a raw representation provided by the options
            // or with only the required properties set.
            MessageCreateParams? createParams =
                options?.RawRepresentationFactory?.Invoke(this) as MessageCreateParams;
            if (createParams is not null)
            {
                // Merge any messages preconfigured on the params with the ones provided to the IChatClient.
                createParams = createParams with
                {
                    Messages = [.. createParams.Messages, .. messages],
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

            HashSet<string>? betaHeaders = createParams.Betas is { Count: > 0 }
                ? [.. createParams.Betas]
                : null;
            int originalBetaHeadersCount = betaHeaders?.Count ?? 0;

            if (options is not null)
            {
                if (options.Instructions is { } instructions)
                {
                    (systemMessages ??= []).Add(new BetaTextBlockParam() { Text = instructions });
                }

                if (
                    createParams.OutputFormat is null
                    && options.ResponseFormat is { } responseFormat
                )
                {
                    switch (responseFormat)
                    {
                        case ChatResponseFormatJson formatJson when formatJson.Schema is not null:
                            JsonElement schema = s_transformCache
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
                                    OutputConfig = new BetaOutputConfig()
                                    {
                                        Format = new BetaJsonOutputFormat()
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
                    List<BetaToolUnion>? createdTools = createParams.Tools?.ToList();
                    List<BetaRequestMcpServerUrlDefinition>? mcpServers =
                        createParams.McpServers?.ToList();
                    List<BetaSkillParams>? skills = null;
                    foreach (var tool in tools)
                    {
                        switch (tool)
                        {
                            case BetaSkillsParamsAITool skillTool:
                                (betaHeaders ??= []).Add("skills-2025-10-02");
                                betaHeaders.Add("code-execution-2025-08-25");

                                (skills ??= []).Add(skillTool.SkillParams);
                                break;

                            case BetaToolUnionAITool raw:
                                (createdTools ??= []).Add(raw.Tool);
                                break;

                            case AIFunctionDeclaration af:
                                Dictionary<string, JsonElement> properties = [];
                                List<string> required = [];
                                JsonElement inputSchema = af.JsonSchema;
                                if (inputSchema.ValueKind is JsonValueKind.Object)
                                {
                                    if (
                                        inputSchema.TryGetProperty(
                                            "required",
                                            out JsonElement reqElement
                                        )
                                        && reqElement.ValueKind is JsonValueKind.Array
                                    )
                                    {
                                        foreach (JsonElement r in reqElement.EnumerateArray())
                                        {
                                            if (
                                                r.ValueKind is JsonValueKind.String
                                                && r.GetString() is { } s
                                                && !string.IsNullOrWhiteSpace(s)
                                            )
                                            {
                                                required.Add(s);
                                            }
                                        }
                                    }

                                    if (
                                        inputSchema.TryGetProperty(
                                            "properties",
                                            out JsonElement propsElement
                                        )
                                        && propsElement.ValueKind is JsonValueKind.Object
                                    )
                                    {
                                        foreach (JsonProperty p in propsElement.EnumerateObject())
                                        {
                                            // Transform nullable union types for non-required properties
                                            properties[p.Name] = required.Contains(p.Name)
                                                ? p.Value
                                                : TransformNullableUnionType(p.Value);
                                        }
                                    }
                                }

                                (createdTools ??= []).Add(
                                    new BetaTool()
                                    {
                                        Name = af.Name,
                                        Description = af.Description,
                                        InputSchema = new InputSchema()
                                        {
                                            Properties = properties,
                                            Required = required,
                                        },
                                        DeferLoading = GetValue<bool?>(
                                            af,
                                            nameof(BetaTool.DeferLoading)
                                        ),
                                        Strict = GetValue<bool?>(af, nameof(BetaTool.Strict)),
                                        InputExamples = GetValue<
                                            List<Dictionary<string, JsonElement>>
                                        >(af, nameof(BetaTool.InputExamples)),
                                        AllowedCallers = GetValue<
                                            List<ApiEnum<string, BetaToolAllowedCaller>>
                                        >(af, nameof(BetaTool.AllowedCallers)),
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
                                (createdTools ??= []).Add(new BetaWebSearchTool20250305());
                                break;

                            case HostedCodeInterpreterTool:
                                (betaHeaders ??= []).Add("code-execution-2025-08-25");
                                (createdTools ??= []).Add(new BetaCodeExecutionTool20250825());
                                break;

                            case HostedMcpServerTool mcp:
                                (betaHeaders ??= []).Add("mcp-client-2025-11-20");
                                (mcpServers ??= []).Add(
                                    mcp.AllowedTools is { Count: > 0 } allowedTools
                                        ? new()
                                        {
                                            Name = mcp.Name,
                                            Url = mcp.ServerAddress,
                                            ToolConfiguration = new()
                                            {
                                                AllowedTools = [.. allowedTools],
                                                Enabled = true,
                                            },
                                        }
                                        : new() { Name = mcp.Name, Url = mcp.ServerAddress }
                                );
                                break;
                        }
                    }

                    if (skills?.Count > 0)
                    {
                        // Merge with any existing skills in the container
                        if (
                            createParams.Container is { } existingContainer
                            && existingContainer.TryPickBetaContainerParams(
                                out var existingContainerParams
                            )
                            && existingContainerParams.Skills is { Count: > 0 } existingSkills
                        )
                        {
                            skills.InsertRange(0, existingSkills);
                        }

                        createParams = createParams with
                        {
                            Container = new BetaContainerParams() { Skills = skills },
                        };

                        // Ensure code execution tool is present
                        bool hasCodeExecutionTool =
                            createdTools?.Any(t => t.Value is BetaCodeExecutionTool20250825)
                            == true;
                        if (!hasCodeExecutionTool)
                        {
                            (betaHeaders ??= []).Add("code-execution-2025-08-25");
                            (createdTools ??= []).Add(new BetaCodeExecutionTool20250825());
                        }
                    }

                    if (createdTools?.Count > 0)
                    {
                        createParams = createParams with { Tools = createdTools };
                    }

                    if (mcpServers?.Count > 0)
                    {
                        createParams = createParams with { McpServers = mcpServers };
                    }
                }

                if (createParams.ToolChoice is null && options.ToolMode is { } toolMode)
                {
                    BetaToolChoice? toolChoice =
                        toolMode is AutoChatToolMode
                            ? new BetaToolChoiceAuto()
                            {
                                DisableParallelToolUse = !options.AllowMultipleToolCalls,
                            }
                        : toolMode is NoneChatToolMode ? new BetaToolChoiceNone()
                        : toolMode is RequiredChatToolMode
                            ? new BetaToolChoiceAny()
                            {
                                DisableParallelToolUse = !options.AllowMultipleToolCalls,
                            }
                        : (BetaToolChoice?)null;
                    if (toolChoice is not null)
                    {
                        createParams = createParams with { ToolChoice = toolChoice };
                    }
                }
            }

            if (systemMessages is not null)
            {
                if (createParams.System is { } existingSystem)
                {
                    if (existingSystem.Value is string existingMessage)
                    {
                        systemMessages.Insert(
                            0,
                            new BetaTextBlockParam() { Text = existingMessage }
                        );
                    }
                    else if (
                        existingSystem.Value is IReadOnlyList<BetaTextBlockParam> existingMessages
                    )
                    {
                        systemMessages.InsertRange(0, existingMessages);
                    }
                }

                createParams = createParams with { System = systemMessages };
            }

            if (betaHeaders is not null && betaHeaders.Count != originalBetaHeadersCount)
            {
                createParams = createParams with { Betas = [.. betaHeaders] };
            }

            // Merge the MEAI user-agent header with existing headers
            return AddMeaiHeaders(createParams);
        }

        private static MessageCreateParams AddMeaiHeaders(MessageCreateParams createParams)
        {
            Dictionary<string, JsonElement> mergedHeaders = new(s_meaiHeaderData);

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

        private static UsageDetails ToUsageDetails(BetaUsage usage) =>
            ToUsageDetails(
                usage.InputTokens,
                usage.OutputTokens,
                usage.CacheCreationInputTokens,
                usage.CacheReadInputTokens,
                usage.ServerToolUse
            );

        private static UsageDetails ToUsageDetails(BetaMessageDeltaUsage usage) =>
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
            BetaServerToolUsage? serverToolUsage
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
                (usageDetails.AdditionalCounts ??= [])[nameof(BetaUsage.CacheCreationInputTokens)] =
                    cacheCreationInputTokens.Value;
            }

            if (serverToolUsage?.WebFetchRequests is > 0)
            {
                (usageDetails.AdditionalCounts ??= [])[
                    nameof(BetaServerToolUsage.WebFetchRequests)
                ] = serverToolUsage.WebFetchRequests;
            }

            if (serverToolUsage?.WebSearchRequests is > 0)
            {
                (usageDetails.AdditionalCounts ??= [])[
                    nameof(BetaServerToolUsage.WebSearchRequests)
                ] = serverToolUsage.WebSearchRequests;
            }

            return usageDetails;

            static long? NullableSum(long? a, long? b) =>
                a is not null || b is not null ? (a ?? 0) + (b ?? 0) : null;
        }

        private static ChatFinishReason? ToFinishReason(
            ApiEnum<string, BetaStopReason>? stopReason
        ) =>
            stopReason?.Value() switch
            {
                null => null,
                BetaStopReason.Refusal => ChatFinishReason.ContentFilter,
                BetaStopReason.MaxTokens => ChatFinishReason.Length,
                BetaStopReason.ToolUse => ChatFinishReason.ToolCalls,
                _ => ChatFinishReason.Stop,
            };

        private static AIContent ToAIContent(BetaContentBlock block)
        {
            static AIContent FromBetaTextBlock(BetaTextBlock text)
            {
                TextContent tc = new(text.Text) { RawRepresentation = text };

                if (text.Citations is { Count: > 0 })
                {
                    tc.Annotations =
                    [
                        .. text.Citations.Select(ToAIAnnotation).OfType<AIAnnotation>(),
                    ];
                }

                return tc;
            }

            switch (block.Value)
            {
                case BetaTextBlock text:
                    return FromBetaTextBlock(text);

                case BetaThinkingBlock thinking:
                    return new TextReasoningContent(thinking.Thinking)
                    {
                        ProtectedData = thinking.Signature,
                        RawRepresentation = thinking,
                    };

                case BetaRedactedThinkingBlock redactedThinking:
                    return new TextReasoningContent(string.Empty)
                    {
                        ProtectedData = redactedThinking.Data,
                        RawRepresentation = redactedThinking,
                    };

                case BetaToolUseBlock toolUse:
                    return new FunctionCallContent(
                        toolUse.ID,
                        toolUse.Name,
                        toolUse.RawData.TryGetValue("input", out JsonElement element)
                            ? (Dictionary<string, object?>?)
                                JsonSerializer.Deserialize(
                                    element,
                                    AIJsonUtilities.DefaultOptions.GetTypeInfo(
                                        typeof(Dictionary<string, object?>)
                                    )
                                )
                            : null
                    )
                    {
                        RawRepresentation = toolUse,
                    };

                case BetaMcpToolUseBlock mcpToolUse:
                    return new McpServerToolCallContent(
                        mcpToolUse.ID,
                        mcpToolUse.Name,
                        mcpToolUse.ServerName
                    )
                    {
                        Arguments = mcpToolUse.Input.ToDictionary(
                            e => e.Key,
                            e => (object?)e.Value
                        ),
                        RawRepresentation = mcpToolUse,
                    };

                case BetaMcpToolResultBlock mcpToolResult:
                    return new McpServerToolResultContent(mcpToolResult.ToolUseID)
                    {
                        Output = mcpToolResult.IsError
                            ? [new ErrorContent(mcpToolResult.Content.Value?.ToString())]
                            : mcpToolResult.Content.Value switch
                            {
                                string s => [new TextContent(s)],
                                IReadOnlyList<BetaTextBlock> texts => texts
                                    .Select(FromBetaTextBlock)
                                    .ToList(),
                                _ => null,
                            },
                        RawRepresentation = mcpToolResult,
                    };

                case BetaCodeExecutionToolResultBlock ce:
                {
                    CodeInterpreterToolResultContent c = new()
                    {
                        CallId = ce.ToolUseID,
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

                    return c;
                }

                case BetaBashCodeExecutionToolResultBlock ce:
                // This is the same as BetaCodeExecutionToolResultBlock but with a different type names.
                // Keep both of them in sync.
                {
                    CodeInterpreterToolResultContent c = new()
                    {
                        CallId = ce.ToolUseID,
                        RawRepresentation = ce,
                    };

                    if (ce.Content.TryPickBetaBashCodeExecutionToolResultError(out var ceError))
                    {
                        (c.Outputs ??= []).Add(
                            new ErrorContent(null)
                            {
                                ErrorCode = ceError.ErrorCode.Value().ToString(),
                            }
                        );
                    }

                    if (ce.Content.TryPickBetaBashCodeExecutionResultBlock(out var ceOutput))
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

                default:
                    return new AIContent() { RawRepresentation = block.Value };
            }
        }

        private static AIAnnotation? ToAIAnnotation(BetaTextCitation citation)
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
            else if (citation.TryPickCitationSearchResultLocation(out var searchLocation))
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

        /// <summary>
        /// Transforms a property schema with nullable union type (e.g., "type": ["integer", "null"])
        /// to a simple type (e.g., "type": "integer") and removes "default": null.
        /// This handles schemas generated by the C# MCP SDK for optional nullable parameters.
        /// </summary>
        private static JsonElement TransformNullableUnionType(JsonElement propertySchema)
        {
            if (propertySchema.ValueKind is not JsonValueKind.Object)
            {
                return propertySchema;
            }

            if (
                !propertySchema.TryGetProperty("type", out JsonElement typeElement)
                || typeElement.ValueKind is not JsonValueKind.Array
            )
            {
                return propertySchema;
            }

            List<JsonElement> nonNullTypes = [];
            bool hasNull = false;
            foreach (JsonElement t in typeElement.EnumerateArray())
            {
                if (t.ValueKind is JsonValueKind.String && t.GetString() == "null")
                {
                    hasNull = true;
                }
                else
                {
                    nonNullTypes.Add(t);
                }
            }

            if (!hasNull || nonNullTypes.Count == 0)
            {
                return propertySchema;
            }

            var transformed = new Dictionary<string, JsonElement>();
            foreach (JsonProperty prop in propertySchema.EnumerateObject())
            {
                if (prop.Name == "type")
                {
                    if (nonNullTypes.Count == 1)
                    {
                        transformed["type"] = nonNullTypes[0];
                    }
                    else
                    {
                        transformed["type"] = JsonSerializer.SerializeToElement(
                            nonNullTypes.Select(t => t.GetString())
                        );
                    }
                }
                else if (prop.Name == "default")
                {
                    if (prop.Value.ValueKind is not JsonValueKind.Null)
                    {
                        transformed[prop.Name] = prop.Value;
                    }
                }
                else
                {
                    transformed[prop.Name] = prop.Value;
                }
            }

            return JsonSerializer.SerializeToElement(transformed);
        }

        private sealed class StreamingFunctionData
        {
            public string CallId { get; set; } = "";
            public string Name { get; set; } = "";
            public StringBuilder Arguments { get; } = new();
        }
    }

    private sealed class BetaToolUnionAITool(BetaToolUnion tool) : AITool
    {
        public BetaToolUnion Tool => tool;

        public override string Name => tool.Value?.GetType().Name ?? base.Name;

        public override object? GetService(System.Type serviceType, object? serviceKey = null) =>
            serviceKey is null && serviceType?.IsInstanceOfType(tool) is true
                ? tool
                : base.GetService(serviceType!, serviceKey);
    }

    private sealed class BetaSkillsParamsAITool(BetaSkillParams skillParams) : AITool
    {
        public BetaSkillParams SkillParams => skillParams;

        public override string Name => SkillParams.SkillID;

        public override object? GetService(System.Type serviceType, object? serviceKey = null) =>
            serviceKey is null && serviceType?.IsInstanceOfType(skillParams) is true
                ? skillParams
                : base.GetService(serviceType!, serviceKey);
    }
}
