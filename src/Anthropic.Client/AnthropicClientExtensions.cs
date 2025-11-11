using Anthropic.Client;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Messages;
using Anthropic.Client.Services;
using Anthropic.Client.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.AI;

public static class AnthropicClientExtensions
{
    /// <summary>Gets an <see cref="IChatClient"/> for use with this <see cref="IAnthropicClient"/>.</summary>
    /// <param name="client">The client.</param>
    /// <param name="defaultModelId">The default ID of the model to use. If <see langword="null"/>, it must be provided per request via <see cref="ChatOptions.ModelId"/>.</param>
    /// <returns>An <see cref="IChatClient"/> that can be used to converse via the <see cref="IAnthropicClient"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="client"/> is <see langword="null"/>.</exception>
    public static IChatClient AsIChatClient(this IAnthropicClient client, string? defaultModelId = null)
    {
        ArgumentNullException.ThrowIfNull(client);

        return new AnthropicChatClient(client.Messages, defaultModelId);
    }

    /// <summary>Gets an <see cref="IChatClient"/> for use with this <see cref="IMessageService"/>.</summary>
    /// <param name="messageService">The message service.</param>
    /// <param name="defaultModelId">The default ID of the model to use. If <see langword="null"/>, it must be provided per request via <see cref="ChatOptions.ModelId"/>.</param>
    /// <returns>An <see cref="IChatClient"/> that can be used to converse via the <see cref="IMessageService"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="messageService"/> is <see langword="null"/>.</exception>
    public static IChatClient AsIChatClient(this IMessageService messageService, string? defaultModelId = null)
    {
        ArgumentNullException.ThrowIfNull(messageService);

        return new AnthropicChatClient(messageService, defaultModelId);
    }

    private sealed class AnthropicChatClient(IMessageService messageService, string? defaultModelId) : IChatClient
    {
        private const int DefaultMaxTokens = 1024;

        private readonly IMessageService _messageService = messageService;
        private readonly string? _defaultModelId = defaultModelId;
        private ChatClientMetadata? _metadata;

        /// <inheritdoc />
        void IDisposable.Dispose() { }

        /// <inheritdoc />
        public object? GetService(System.Type serviceType, object? serviceKey = null)
        {
            ArgumentNullException.ThrowIfNull(serviceType);

            if (serviceKey is not null)
            {
                return null;
            }

            if (serviceType == typeof(ChatClientMetadata))
            {
                return _metadata ??= new ChatClientMetadata("anthropic", _messageService is MessageService { _client.BaseUrl: Uri baseUrl } ? baseUrl : null, _defaultModelId);
            }

            if (serviceType.IsInstanceOfType(_messageService))
            {
                return _messageService;
            }

            if (serviceType.IsInstanceOfType(this))
            {
                return this;
            }

            return null;
        }

        /// <inheritdoc />
        public async Task<ChatResponse> GetResponseAsync(
            IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(messages);

            List<MessageParam> messageParams = CreateMessageParams(messages, out List<TextBlockParam>? systemMessages);
            MessageCreateParams createParams = GetMessageCreateParams(messageParams, systemMessages, options);

            var createResult = await _messageService.Create(createParams);

            ChatMessage m = new(ChatRole.Assistant, [.. createResult.Content.Select(ToAIContent).OfType<AIContent>()])
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
            IEnumerable<ChatMessage> messages, ChatOptions? options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(messages);

            List<MessageParam> messageParams = CreateMessageParams(messages, out List<TextBlockParam>? systemMessages);
            MessageCreateParams createParams = GetMessageCreateParams(messageParams, systemMessages, options);
            
            string? messageId = null;
            string? modelID = null;
            UsageDetails? usageDetails = null;
            ChatFinishReason? finishReason = null;
            Dictionary<long, StreamingFunctionData>? streamingFunctions = null;

            await foreach (var createResult in _messageService.CreateStreaming(createParams).WithCancellation(cancellationToken))
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
                            if (usageDetails is null) usageDetails = current;
                            else usageDetails.Add(current);
                        }
                        break;

                    case RawMessageDeltaEvent rawMessageDelta:
                        finishReason = ToFinishReason(rawMessageDelta.Delta.StopReason);
                        if (rawMessageDelta.Usage is { } deltaUsage)
                        {
                            UsageDetails current = ToUsageDetails(deltaUsage);
                            if (usageDetails is null) usageDetails = current;
                            else usageDetails.Add(current);
                        }
                        break;

                    case RawContentBlockStartEvent contentBlockStart:
                        switch (contentBlockStart.ContentBlock.Value)
                        {
                            case TextBlock text:
                                contents.Add(new TextContent(text.Text));
                                break;

                            case ThinkingBlock thinking:
                                contents.Add(new TextReasoningContent(thinking.Thinking) { ProtectedData = thinking.Signature });
                                break;

                            case RedactedThinkingBlock redactedThinking:
                                contents.Add(new TextReasoningContent(string.Empty) { ProtectedData = redactedThinking.Data });
                                break;

                            case ToolUseBlock toolUse:
                                streamingFunctions ??= [];
                                streamingFunctions[contentBlockStart.Index] = new StreamingFunctionData()
                                {
                                    CallId = toolUse.ID,
                                    Name = toolUse.Name,
                                };
                                break;
                        }
                        break;

                    case RawContentBlockDeltaEvent contentBlockDelta:
                        switch (contentBlockDelta.Delta.Value)
                        {
                            case TextDelta textDelta:
                                contents.Add(new TextContent(textDelta.Text));
                                break;

                            case InputJSONDelta inputDelta:
                                if (streamingFunctions is not null &&
                                    streamingFunctions.TryGetValue(contentBlockDelta.Index, out StreamingFunctionData? functionData))
                                {
                                    functionData.Arguments.Append(inputDelta.PartialJSON);
                                }
                                break;
                            
                            case ThinkingDelta thinkingDelta:
                                contents.Add(new TextReasoningContent(thinkingDelta.Thinking));
                                break;
                            
                            case SignatureDelta signatureDelta:
                                contents.Add(new TextReasoningContent(null) { ProtectedData = signatureDelta.Signature });
                                break;
                        }
                        break;

                    case RawContentBlockStopEvent contentBlockStop:
                        if (streamingFunctions is not null)
                        {
                            foreach (var sf in streamingFunctions)
                            {
                                contents.Add(new FunctionCallContent(
                                    sf.Value.CallId, 
                                    sf.Value.Name,
                                    JsonSerializer.Deserialize<Dictionary<string, object?>>(sf.Value.Arguments.ToString(), AIJsonUtilities.DefaultOptions) ?? []));
                            }
                        }
                        break;
                }

                yield return new ChatResponseUpdate(ChatRole.Assistant, contents)
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
                yield return new ChatResponseUpdate(ChatRole.Assistant, [new UsageContent(usageDetails)])
                {
                    CreatedAt = DateTimeOffset.UtcNow,
                    FinishReason = finishReason,
                    MessageId = messageId,
                    ModelId = modelID,
                    ResponseId = messageId,
                };
            }
        }

        private static List<MessageParam> CreateMessageParams(IEnumerable<ChatMessage> messages, out List<TextBlockParam>? systemMessages)
        {
            List<MessageParam> messageParams = [];
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

                List<ContentBlockParam> contents = [];

                foreach (AIContent content in message.Contents)
                {
                    switch (content)
                    {
                        case TextContent tc:
                            string text = tc.Text;
                            if (message.Role == ChatRole.Assistant)
                            {
                                text = text.TrimEnd();
                                if (!string.IsNullOrWhiteSpace(text))
                                {
                                    contents.Add(new ContentBlockParam(new TextBlockParam() { Text = text }));
                                }
                            }
                            else if (!string.IsNullOrWhiteSpace(text))
                            {
                                contents.Add(new ContentBlockParam(new TextBlockParam() { Text = text }));
                            }
                            break;

                        case TextReasoningContent trc when !string.IsNullOrEmpty(trc.Text):
                            contents.Add(new ContentBlockParam(new ThinkingBlockParam()
                            {
                                Thinking = trc.Text,
                                Signature = trc.ProtectedData ?? string.Empty,
                            }));
                            break;

                        case TextReasoningContent trc when !string.IsNullOrEmpty(trc.ProtectedData):
                            contents.Add(new ContentBlockParam(new RedactedThinkingBlockParam()
                            {
                                Data = trc.ProtectedData,
                            }));
                            break;

                        case DataContent dc when dc.HasTopLevelMediaType("image"):
                            contents.Add(new ContentBlockParam(new ImageBlockParam()
                            {
                                Source = new(new Base64ImageSource() { Data = dc.Base64Data.ToString(), MediaType = dc.MediaType })
                            }));
                            break;

                        case DataContent dc when string.Equals(dc.MediaType, "application/pdf", StringComparison.OrdinalIgnoreCase):
                            contents.Add(new ContentBlockParam(new DocumentBlockParam()
                            {
                                Source = new(new Base64PDFSource() { Data = dc.Base64Data.ToString() }),
                            }));
                            break;

                        case DataContent dc when dc.HasTopLevelMediaType("text"):
                            contents.Add(new ContentBlockParam(new DocumentBlockParam()
                            {
                                Source = new(new PlainTextSource() { Data = Encoding.UTF8.GetString(Convert.FromBase64String(dc.Base64Data.ToString())) })
                            }));
                            break;

                        case UriContent uc when uc.HasTopLevelMediaType("image"):
                            contents.Add(new ContentBlockParam(new ImageBlockParam()
                            {
                                Source = new(new URLImageSource() { URL = uc.Uri.AbsoluteUri }),
                            }));
                            break;

                        case UriContent uc when string.Equals(uc.MediaType, "application/pdf", StringComparison.OrdinalIgnoreCase):
                            contents.Add(new ContentBlockParam(new DocumentBlockParam()
                            {
                                Source = new(new URLPDFSource() { URL = uc.Uri.AbsoluteUri }),
                            }));
                            break;

                        case FunctionCallContent fcc:
                            contents.Add(new ContentBlockParam(new ToolUseBlockParam()
                            {
                                ID = fcc.CallId,
                                Name = fcc.Name,
                                Input = fcc.Arguments?.ToDictionary(e => e.Key, e => e.Value is JsonElement je ? je : JsonSerializer.SerializeToElement(e.Value, AIJsonUtilities.DefaultOptions)) ?? [],
                            }));
                            break;

                        case FunctionResultContent frc:
                            contents.Add(new ContentBlockParam(new ToolResultBlockParam()
                            {
                                ToolUseID = frc.CallId,
                                IsError = frc.Exception is not null,
                                Content = new(JsonSerializer.Serialize(frc.Result, AIJsonUtilities.DefaultOptions)),
                            }));
                            break;
                    }
                }

                if (contents.Count == 0)
                {
                    continue;
                }

                messageParams.Add(new()
                {
                    Role = message.Role == ChatRole.Assistant ? Role.Assistant : Role.User,
                    Content = new(contents),
                });
            }

            if (messageParams.Count == 0)
            {
                messageParams.Add(new() { Role = Role.User, Content = new("\u200b") }); // zero-width space
            }

            return messageParams;
        }

        private MessageCreateParams GetMessageCreateParams(List<MessageParam> messages, List<TextBlockParam>? systemMessages, ChatOptions? options)
        {
            // MessageCreateParams exposes all of its properties as init-only. It also always initializes elements in those init members even
            // when assigning null. And as init-only members can't be conditionally assigned, it's impossible for to create the MessageCreateParams
            // here in the way we need to. Instead, we populate a dictionary, and then use that dictionary to populate the MessageCreateParams
            // in one go.

            Dictionary<string, JsonElement>? bodyProperties = null;

            if (options?.RawRepresentationFactory?.Invoke(this) is MessageCreateParams rawMcp)
            {
                bodyProperties = new(rawMcp.BodyProperties);

                // Merge existing messages if there were any in the raw representation
                if (bodyProperties.TryGetValue("messages", out JsonElement existingMessageJson) &&
                    JsonSerializer.Deserialize<List<MessageParam>>(existingMessageJson, ModelBase.SerializerOptions) is { } existingMessages)
                {
                    messages.InsertRange(0, existingMessages);
                }
            }
            else
            {
                bodyProperties = [];
            }

            // MessageCreateParams.Messages
            bodyProperties["messages"] = JsonSerializer.SerializeToElement(messages, ModelBase.SerializerOptions);

            // MessageCreateParams.Model
            string? modelId = bodyProperties.TryGetValue("model", out JsonElement existingModelJson) ?
                JsonSerializer.Deserialize<string>(existingModelJson, ModelBase.SerializerOptions) :
                null;
            modelId ??= options?.ModelId ?? _defaultModelId;
            bodyProperties["model"] = !string.IsNullOrWhiteSpace(modelId) ?
                JsonSerializer.SerializeToElement(modelId, ModelBase.SerializerOptions) :
                throw new InvalidOperationException("Model ID must be specified either in ChatOptions or as the default for the client.");

            // MessageCreateParams.MaxTokens
            if (!bodyProperties.TryGetValue("max_tokens", out _))
            {
                bodyProperties["max_tokens"] = JsonSerializer.SerializeToElement(options?.MaxOutputTokens ?? DefaultMaxTokens, ModelBase.SerializerOptions);
            }

            if (options is not null)
            {
                if (options.Instructions is { } instructions)
                {
                    (systemMessages ??= []).Add(new TextBlockParam() { Text = instructions });
                }

                // MessageCreateParams.StopSequences
                if (options.StopSequences is { } stopSequences)
                {
                    List<string>? existingStopSequences = bodyProperties.TryGetValue("stop_sequences", out JsonElement stopSequencesJson) ?
                        JsonSerializer.Deserialize<List<string>>(stopSequencesJson, ModelBase.SerializerOptions) :
                        null;

                    existingStopSequences = existingStopSequences is not null ?
                        [.. existingStopSequences, .. stopSequences] :
                        [.. stopSequences];

                    bodyProperties["stop_sequences"] = JsonSerializer.SerializeToElement(existingStopSequences, ModelBase.SerializerOptions);
                }

                // MessageCreateParams.Temperature
                if (options.Temperature is { } temperature && !bodyProperties.ContainsKey("temperature"))
                {
                    bodyProperties["temperature"] = JsonSerializer.SerializeToElement((double)temperature, ModelBase.SerializerOptions);
                }

                // MessageCreateParams.TopK
                if (options.TopK is { } topK && !bodyProperties.ContainsKey("top_k"))
                {
                    bodyProperties["top_k"] = JsonSerializer.SerializeToElement(topK, ModelBase.SerializerOptions);
                }

                // MessageCreateParams.TopP
                if (options.TopP is { } topP && !bodyProperties.ContainsKey("top_p"))
                {
                    bodyProperties["top_p"] = JsonSerializer.SerializeToElement((double)topP, ModelBase.SerializerOptions);
                }

                // MessageCreateParams.Tools
                List<ToolUnion>? createdTools = bodyProperties.TryGetValue("tools", out JsonElement toolsJson) ?
                    JsonSerializer.Deserialize<List<ToolUnion>>(toolsJson, ModelBase.SerializerOptions) :
                    null;
                if (options.Tools is { } tools)
                {
                    foreach (var tool in tools)
                    {
                        switch (tool)
                        {
                            case AIFunctionDeclaration af:
                                JsonElement inputSchema = af.JsonSchema;
                                if (inputSchema.ValueKind is JsonValueKind.Object &&
                                    inputSchema.TryGetProperty("properties", out JsonElement propsElement) && propsElement.ValueKind is JsonValueKind.Object &&
                                    inputSchema.TryGetProperty("required", out JsonElement reqElement) && reqElement.ValueKind is JsonValueKind.Array)
                                {
                                    Dictionary<string, JsonElement> properties = [];
                                    List<string> required = [];

                                    foreach (JsonProperty p in propsElement.EnumerateObject())
                                    {
                                        properties[p.Name] = p.Value;
                                    }

                                    foreach (JsonElement r in reqElement.EnumerateArray())
                                    {
                                        if (r.ValueKind is JsonValueKind.String && r.GetString() is { } s && !string.IsNullOrWhiteSpace(s))
                                        {
                                            required.Add(s);
                                        }
                                    }

                                    (createdTools ??= []).Add(new ToolUnion(new Tool()
                                    {
                                        Name = af.Name,
                                        Description = af.Description,
                                        InputSchema = new(properties)
                                        {
                                            Required = required,
                                        },
                                    }));
                                }
                                break;

                            case HostedWebSearchTool:
                                (createdTools ??= []).Add(new ToolUnion(new WebSearchTool20250305()));
                                break;
                        }
                    }

                    if (createdTools?.Count > 0)
                    {
                        bodyProperties["tools"] = JsonSerializer.SerializeToElement(createdTools, ModelBase.SerializerOptions);
                    }
                }

                if (!bodyProperties.ContainsKey("tool_choice") &&
                    createdTools is { Count: > 0 } &&
                    options.ToolMode is { } toolMode)
                {
                    ToolChoice? toolChoice =
                        toolMode is AutoChatToolMode ? new ToolChoice(new ToolChoiceAuto() { DisableParallelToolUse = !options.AllowMultipleToolCalls }) :
                        toolMode is NoneChatToolMode ? new ToolChoice(new ToolChoiceNone()) :
                        toolMode is RequiredChatToolMode ? new ToolChoice(new ToolChoiceAny() { DisableParallelToolUse = !options.AllowMultipleToolCalls }) :
                        null;
                    if (toolChoice is not null)
                    {
                        bodyProperties["tool_choice"] = JsonSerializer.SerializeToElement(toolChoice, ModelBase.SerializerOptions);
                    }
                }
            }

            if (systemMessages is not null)
            {
                if (bodyProperties.TryGetValue("system", out JsonElement systemJson))
                {
                    if (systemJson.ValueKind is JsonValueKind.String)
                    {
                        systemMessages.Insert(0, new TextBlockParam() { Text = systemJson.GetString() ?? string.Empty });
                    }
                    else if (systemJson.ValueKind is JsonValueKind.Array)
                    {
                        systemMessages.AddRange(JsonSerializer.Deserialize<List<TextBlockParam>>(systemJson, ModelBase.SerializerOptions)!);
                    }
                }

                bodyProperties["system"] = JsonSerializer.SerializeToElement(systemMessages, ModelBase.SerializerOptions);
            }

            return MessageCreateParams.FromRawUnchecked(
                new Dictionary<string, JsonElement>(), 
                new Dictionary<string, JsonElement>(), 
                bodyProperties);
        }

        private static UsageDetails ToUsageDetails(Usage usage) =>
            ToUsageDetails(usage.InputTokens, usage.OutputTokens, usage.CacheCreationInputTokens, usage.CacheReadInputTokens);

        private static UsageDetails ToUsageDetails(MessageDeltaUsage usage) =>
            ToUsageDetails(usage.InputTokens, usage.OutputTokens, usage.CacheCreationInputTokens, usage.CacheReadInputTokens);

        private static UsageDetails ToUsageDetails(long? inputTokens, long? outputTokens, long? cacheCreationInputTokens, long? cacheReadInputTokens)
        {
            UsageDetails usageDetails = new()
            {
                InputTokenCount = inputTokens,
                OutputTokenCount = outputTokens,
                TotalTokenCount = (inputTokens is not null || outputTokens is not null) ? (inputTokens ?? 0) + (outputTokens ?? 0) : null,
            };

            if (cacheCreationInputTokens is not null)
            {
                (usageDetails.AdditionalCounts ??= [])[nameof(Usage.CacheCreationInputTokens)] = cacheCreationInputTokens.Value;
            }

            if (cacheReadInputTokens is not null)
            {
                (usageDetails.AdditionalCounts ??= [])[nameof(Usage.CacheReadInputTokens)] = cacheReadInputTokens.Value;
            }

            return usageDetails;
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

        private static AIContent? ToAIContent(ContentBlock block)
        {
            switch (block.Value)
            {
                case TextBlock text:
                    TextContent tc = new TextContent(text.Text);
                    if (text.Citations is { Count: > 0 })
                    {
                        tc.Annotations = [.. text.Citations.Select(ToAIAnnotation).OfType<AIAnnotation>()];
                    }

                    return tc;

                case ThinkingBlock thinking:
                    return new TextReasoningContent(thinking.Thinking) { ProtectedData = thinking.Signature };

                case RedactedThinkingBlock redactedThinking:
                    return new TextReasoningContent(string.Empty) { ProtectedData = redactedThinking.Data };

                case ToolUseBlock toolUse:
                    return new FunctionCallContent(
                        toolUse.ID,
                        toolUse.Name,
                        toolUse.Properties.TryGetValue("input", out JsonElement element) ?
                            JsonSerializer.Deserialize<Dictionary<string, object?>>(element, AIJsonUtilities.DefaultOptions) :
                            null);
            }
         
            return null;
        }

        private static AIAnnotation? ToAIAnnotation(TextCitation citation)
        {
            CitationAnnotation annotation = new()
            {
                Title = citation.Title,
                Snippet = citation.CitedText,
                FileId = citation.FileID,
                AnnotatedRegions = [new TextSpanAnnotatedRegion()
                {
                    StartIndex = (int?)citation.StartBlockIndex,
                    EndIndex = (int?)citation.EndBlockIndex,
                }]
            };

            if (citation.Value is CitationsWebSearchResultLocation webCitation)
            {
                annotation.Url = Uri.TryCreate(webCitation.URL, UriKind.Absolute, out Uri? url) ? url : null;
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
}
