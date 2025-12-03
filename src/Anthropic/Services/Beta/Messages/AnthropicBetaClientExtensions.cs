using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta;

#pragma warning disable MEAI001 // [Experimental] APIs in Microsoft.Extensions.AI
#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace Microsoft.Extensions.AI;

public static class AnthropicBetaClientExtensions
{
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

        return new ToolUnionAITool(tool);
    }

    private sealed class AnthropicChatClient(
        Anthropic.Services.IBetaService betaService,
        string? defaultModelId,
        int? defaultMaxOutputTokens
    ) : IChatClient
    {
        private const int DefaultMaxTokens = 1024;

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
                    _betaService.Messages is MessageService { _client.BaseUrl: Uri baseUrl }
                        ? baseUrl
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
                            UsageDetails current = ToUsageDetails(deltaUsage);
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

                            case BetaInputJSONDelta inputDelta:
                                if (
                                    streamingFunctions is not null
                                    && streamingFunctions.TryGetValue(
                                        contentBlockDelta.Index,
                                        out var functionData
                                    )
                                )
                                {
                                    functionData.Arguments.Append(inputDelta.PartialJSON);
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
                            (systemMessages ??= []).Add(new() { Text = tc.Text });
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
                                    contents.Add(new BetaTextBlockParam() { Text = text });
                                }
                            }
                            else if (!string.IsNullOrWhiteSpace(text))
                            {
                                contents.Add(new BetaTextBlockParam() { Text = text });
                            }
                            break;

                        case TextReasoningContent trc when !string.IsNullOrEmpty(trc.Text):
                            contents.Add(
                                new BetaThinkingBlockParam()
                                {
                                    Thinking = trc.Text,
                                    Signature = trc.ProtectedData ?? string.Empty,
                                }
                            );
                            break;

                        case TextReasoningContent trc when !string.IsNullOrEmpty(trc.ProtectedData):
                            contents.Add(
                                new BetaRedactedThinkingBlockParam() { Data = trc.ProtectedData! }
                            );
                            break;

                        case DataContent dc when dc.HasTopLevelMediaType("image"):
                            contents.Add(
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
                            );
                            break;

                        case DataContent dc
                            when string.Equals(
                                dc.MediaType,
                                "application/pdf",
                                StringComparison.OrdinalIgnoreCase
                            ):
                            contents.Add(
                                new BetaRequestDocumentBlock()
                                {
                                    Source = new(
                                        new BetaBase64PDFSource()
                                        {
                                            Data = dc.Base64Data.ToString(),
                                        }
                                    ),
                                }
                            );
                            break;

                        case DataContent dc when dc.HasTopLevelMediaType("text"):
                            contents.Add(
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
                                }
                            );
                            break;

                        case UriContent uc when uc.HasTopLevelMediaType("image"):
                            contents.Add(
                                new BetaImageBlockParam()
                                {
                                    Source = new(
                                        new BetaURLImageSource() { URL = uc.Uri.AbsoluteUri }
                                    ),
                                }
                            );
                            break;

                        case UriContent uc
                            when string.Equals(
                                uc.MediaType,
                                "application/pdf",
                                StringComparison.OrdinalIgnoreCase
                            ):
                            contents.Add(
                                new BetaRequestDocumentBlock()
                                {
                                    Source = new(
                                        new BetaURLPDFSource() { URL = uc.Uri.AbsoluteUri }
                                    ),
                                }
                            );
                            break;

                        case HostedFileContent fc:
                            contents.Add(
                                new BetaRequestDocumentBlock()
                                {
                                    Source = new(new BetaFileDocumentSource(fc.FileId)),
                                }
                            );
                            break;

                        case FunctionCallContent fcc:
                            contents.Add(
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
                                }
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
                                                        new BetaBase64PDFSource()
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
                                                            new BetaURLImageSource()
                                                            {
                                                                URL = uc.Uri.AbsoluteUri,
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
                                                        new BetaURLPDFSource()
                                                        {
                                                            URL = uc.Uri.AbsoluteUri,
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
                                new BetaToolResultBlockParam()
                                {
                                    ToolUseID = frc.CallId,
                                    IsError = frc.Exception is not null,
                                    Content = result,
                                }
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
                                    OutputFormat = new BetaJSONOutputFormat()
                                    {
                                        Schema = new Dictionary<string, JsonElement>
                                        {
                                            ["type"] = JsonElement.Parse("\"object\""),
                                            ["properties"] = properties,
                                            ["required"] = required,
                                            ["additionalProperties"] = JsonElement.Parse("false"),
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
                    List<BetaRequestMCPServerURLDefinition>? mcpServers =
                        createParams.MCPServers?.ToList();
                    foreach (var tool in tools)
                    {
                        switch (tool)
                        {
                            case ToolUnionAITool raw:
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
                                            "properties",
                                            out JsonElement propsElement
                                        )
                                        && propsElement.ValueKind is JsonValueKind.Object
                                    )
                                    {
                                        foreach (JsonProperty p in propsElement.EnumerateObject())
                                        {
                                            properties[p.Name] = p.Value;
                                        }
                                    }

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
                                }

                                (createdTools ??= []).Add(
                                    new BetaTool()
                                    {
                                        Name = af.Name,
                                        Description = af.Description,
                                        InputSchema = new(properties) { Required = required },
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
                                (createdTools ??= []).Add(new BetaCodeExecutionTool20250825());
                                break;

                            case HostedMcpServerTool mcp:
                                (mcpServers ??= []).Add(
                                    mcp.AllowedTools is { Count: > 0 } allowedTools
                                        ? new()
                                        {
                                            Name = mcp.Name,
                                            URL = mcp.ServerAddress,
                                            ToolConfiguration = new()
                                            {
                                                AllowedTools = [.. allowedTools],
                                                Enabled = true,
                                            },
                                        }
                                        : new() { Name = mcp.Name, URL = mcp.ServerAddress }
                                );
                                break;
                        }
                    }

                    if (createdTools?.Count > 0)
                    {
                        createParams = createParams with { Tools = createdTools };
                    }

                    if (mcpServers?.Count > 0)
                    {
                        createParams = createParams with { MCPServers = mcpServers };
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

            return createParams;
        }

        private static UsageDetails ToUsageDetails(BetaUsage usage) =>
            ToUsageDetails(
                usage.InputTokens,
                usage.OutputTokens,
                usage.CacheCreationInputTokens,
                usage.CacheReadInputTokens
            );

        private static UsageDetails ToUsageDetails(BetaMessageDeltaUsage usage) =>
            ToUsageDetails(
                usage.InputTokens,
                usage.OutputTokens,
                usage.CacheCreationInputTokens,
                usage.CacheReadInputTokens
            );

        private static UsageDetails ToUsageDetails(
            long? inputTokens,
            long? outputTokens,
            long? cacheCreationInputTokens,
            long? cacheReadInputTokens
        )
        {
            UsageDetails usageDetails = new()
            {
                InputTokenCount = inputTokens,
                OutputTokenCount = outputTokens,
                TotalTokenCount =
                    (inputTokens is not null || outputTokens is not null)
                        ? (inputTokens ?? 0) + (outputTokens ?? 0)
                        : null,
            };

            if (cacheCreationInputTokens is not null)
            {
                (usageDetails.AdditionalCounts ??= [])[nameof(BetaUsage.CacheCreationInputTokens)] =
                    cacheCreationInputTokens.Value;
            }

            if (cacheReadInputTokens is not null)
            {
                (usageDetails.AdditionalCounts ??= [])[nameof(BetaUsage.CacheReadInputTokens)] =
                    cacheReadInputTokens.Value;
            }

            return usageDetails;
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

                case BetaMCPToolUseBlock mcpToolUse:
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

                case BetaMCPToolResultBlock mcpToolResult:
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
                    webSearchLocation.URL,
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

        private sealed class StreamingFunctionData
        {
            public string CallId { get; set; } = "";
            public string Name { get; set; } = "";
            public StringBuilder Arguments { get; } = new();
        }
    }

    private sealed class ToolUnionAITool(BetaToolUnion tool) : AITool
    {
        public BetaToolUnion Tool => tool;

        public override string Name => tool.Value?.GetType().Name ?? base.Name;

        public override object? GetService(System.Type serviceType, object? serviceKey = null) =>
            serviceKey is null && serviceType?.IsInstanceOfType(tool) is true
                ? tool
                : base.GetService(serviceType!, serviceKey);
    }
}
