using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using Messages = Anthropic.Client.Models.Messages;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages.Batches;

/// <summary>
/// Send a batch of Message creation requests.
///
/// The Message Batches API can be used to process multiple Messages API requests
/// at once. Once a Message Batch is created, it begins processing immediately. Batches
/// can take up to 24 hours to complete.
///
/// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
/// </summary>
public sealed record class BatchCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    /// <summary>
    /// List of requests for prompt completion. Each is an individual request to create
    /// a Message.
    /// </summary>
    public required List<Request> Requests
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("requests", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'requests' cannot be null",
                    new System::ArgumentOutOfRangeException("requests", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Request>>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'requests' cannot be null",
                    new System::ArgumentNullException("requests")
                );
        }
        init
        {
            this._bodyProperties["requests"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public List<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            if (!this._headerProperties.TryGetValue("betas", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, AnthropicBeta>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._headerProperties["betas"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BatchCreateParams() { }

    public BatchCreateParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCreateParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static BatchCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/messages/batches?beta=true"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Request>))]
public sealed record class Request : ModelBase, IFromRaw<Request>
{
    /// <summary>
    /// Developer-provided ID created for each request in a Message Batch. Useful
    /// for matching results to requests, as results may be given out of request order.
    ///
    /// Must be unique for each request within the Message Batch.
    /// </summary>
    public required string CustomID
    {
        get
        {
            if (!this._properties.TryGetValue("custom_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'custom_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "custom_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'custom_id' cannot be null",
                    new System::ArgumentNullException("custom_id")
                );
        }
        init
        {
            this._properties["custom_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Messages API creation parameters for the individual request.
    ///
    /// See the [Messages API reference](/en/api/messages) for full documentation
    /// on available parameters.
    /// </summary>
    public required Params Params
    {
        get
        {
            if (!this._properties.TryGetValue("params", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'params' cannot be null",
                    new System::ArgumentOutOfRangeException("params", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Params>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'params' cannot be null",
                    new System::ArgumentNullException("params")
                );
        }
        init
        {
            this._properties["params"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CustomID;
        this.Params.Validate();
    }

    public Request() { }

    public Request(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Request(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Request FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Messages API creation parameters for the individual request.
///
/// See the [Messages API reference](/en/api/messages) for full documentation on
/// available parameters.
/// </summary>
[JsonConverter(typeof(ModelConverter<Params>))]
public sealed record class Params : ModelBase, IFromRaw<Params>
{
    /// <summary>
    /// The maximum number of tokens to generate before stopping.
    ///
    /// Note that our models may stop _before_ reaching this maximum. This parameter
    /// only specifies the absolute maximum number of tokens to generate.
    ///
    /// Different models have different maximum values for this parameter.  See [models](https://docs.claude.com/en/docs/models-overview)
    /// for details.
    /// </summary>
    public required long MaxTokens
    {
        get
        {
            if (!this._properties.TryGetValue("max_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'max_tokens' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "max_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["max_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Input messages.
    ///
    /// Our models are trained to operate on alternating `user` and `assistant` conversational
    /// turns. When creating a new `Message`, you specify the prior conversational
    /// turns with the `messages` parameter, and the model then generates the next
    /// `Message` in the conversation. Consecutive `user` or `assistant` turns in
    /// your request will be combined into a single turn.
    ///
    /// Each input message must be an object with a `role` and `content`. You can
    /// specify a single `user`-role message, or you can include multiple `user`
    /// and `assistant` messages.
    ///
    /// If the final message uses the `assistant` role, the response content will
    /// continue immediately from the content in that message. This can be used to
    /// constrain part of the model's response.
    ///
    /// Example with a single `user` message:
    ///
    /// ```json [{"role": "user", "content": "Hello, Claude"}] ```
    ///
    /// Example with multiple conversational turns:
    ///
    /// ```json [   {"role": "user", "content": "Hello there."},   {"role": "assistant",
    /// "content": "Hi, I'm Claude. How can I help you?"},   {"role": "user", "content":
    /// "Can you explain LLMs in plain English?"}, ] ```
    ///
    /// Example with a partially-filled response from Claude:
    ///
    /// ```json [   {"role": "user", "content": "What's the Greek name for Sun? (A)
    /// Sol (B) Helios (C) Sun"},   {"role": "assistant", "content": "The best answer
    /// is ("}, ] ```
    ///
    /// Each input message `content` may be either a single `string` or an array
    /// of content blocks, where each block has a specific `type`. Using a `string`
    /// for `content` is shorthand for an array of one content block of type `"text"`.
    /// The following input messages are equivalent:
    ///
    /// ```json {"role": "user", "content": "Hello, Claude"} ```
    ///
    /// ```json {"role": "user", "content": [{"type": "text", "text": "Hello, Claude"}]} ```
    ///
    /// See [input examples](https://docs.claude.com/en/api/messages-examples).
    ///
    /// Note that if you want to include a [system prompt](https://docs.claude.com/en/docs/system-prompts),
    /// you can use the top-level `system` parameter — there is no `"system"` role
    /// for input messages in the Messages API.
    ///
    /// There is a limit of 100,000 messages in a single request.
    /// </summary>
    public required List<BetaMessageParam> Messages
    {
        get
        {
            if (!this._properties.TryGetValue("messages", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'messages' cannot be null",
                    new System::ArgumentOutOfRangeException("messages", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<BetaMessageParam>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'messages' cannot be null",
                    new System::ArgumentNullException("messages")
                );
        }
        init
        {
            this._properties["messages"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The model that will complete your prompt.\n\nSee [models](https://docs.anthropic.com/en/docs/models-overview)
    /// for additional details and options.
    /// </summary>
    public required ApiEnum<string, Messages::Model> Model
    {
        get
        {
            if (!this._properties.TryGetValue("model", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'model' cannot be null",
                    new System::ArgumentOutOfRangeException("model", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Messages::Model>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["model"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Container identifier for reuse across requests.
    /// </summary>
    public global::Anthropic.Client.Models.Beta.Messages.Batches.Container? Container
    {
        get
        {
            if (!this._properties.TryGetValue("container", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Anthropic.Client.Models.Beta.Messages.Batches.Container?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["container"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Context management configuration.
    ///
    /// This allows you to control how Claude manages context across multiple requests,
    /// such as whether to clear function results or not.
    /// </summary>
    public BetaContextManagementConfig? ContextManagement
    {
        get
        {
            if (!this._properties.TryGetValue("context_management", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaContextManagementConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["context_management"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// MCP servers to be utilized in this request
    /// </summary>
    public List<BetaRequestMCPServerURLDefinition>? MCPServers
    {
        get
        {
            if (!this._properties.TryGetValue("mcp_servers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<BetaRequestMCPServerURLDefinition>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["mcp_servers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An object describing metadata about the request.
    /// </summary>
    public BetaMetadata? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaMetadata?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Determines whether to use priority capacity (if available) or standard capacity
    /// for this request.
    ///
    /// Anthropic offers different levels of service for your API requests. See [service-tiers](https://docs.claude.com/en/api/service-tiers)
    /// for details.
    /// </summary>
    public ApiEnum<
        string,
        global::Anthropic.Client.Models.Beta.Messages.Batches.ServiceTier
    >? ServiceTier
    {
        get
        {
            if (!this._properties.TryGetValue("service_tier", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                global::Anthropic.Client.Models.Beta.Messages.Batches.ServiceTier
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["service_tier"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Custom text sequences that will cause the model to stop generating.
    ///
    /// Our models will normally stop when they have naturally completed their turn,
    /// which will result in a response `stop_reason` of `"end_turn"`.
    ///
    /// If you want the model to stop generating when it encounters custom strings
    /// of text, you can use the `stop_sequences` parameter. If the model encounters
    /// one of the custom sequences, the response `stop_reason` value will be `"stop_sequence"`
    /// and the response `stop_sequence` value will contain the matched stop sequence.
    /// </summary>
    public List<string>? StopSequences
    {
        get
        {
            if (!this._properties.TryGetValue("stop_sequences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["stop_sequences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to incrementally stream the response using server-sent events.
    ///
    /// See [streaming](https://docs.claude.com/en/api/messages-streaming) for details.
    /// </summary>
    public bool? Stream
    {
        get
        {
            if (!this._properties.TryGetValue("stream", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["stream"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// System prompt.
    ///
    /// A system prompt is a way of providing context and instructions to Claude,
    /// such as specifying a particular goal or role. See our [guide to system prompts](https://docs.claude.com/en/docs/system-prompts).
    /// </summary>
    public global::Anthropic.Client.Models.Beta.Messages.Batches.SystemModel? System
    {
        get
        {
            if (!this._properties.TryGetValue("system", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Anthropic.Client.Models.Beta.Messages.Batches.SystemModel?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["system"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Amount of randomness injected into the response.
    ///
    /// Defaults to `1.0`. Ranges from `0.0` to `1.0`. Use `temperature` closer to
    /// `0.0` for analytical / multiple choice, and closer to `1.0` for creative and
    /// generative tasks.
    ///
    /// Note that even with `temperature` of `0.0`, the results will not be fully deterministic.
    /// </summary>
    public double? Temperature
    {
        get
        {
            if (!this._properties.TryGetValue("temperature", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["temperature"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for enabling Claude's extended thinking.
    ///
    /// When enabled, responses include `thinking` content blocks showing Claude's
    /// thinking process before the final answer. Requires a minimum budget of 1,024
    /// tokens and counts towards your `max_tokens` limit.
    ///
    /// See [extended thinking](https://docs.claude.com/en/docs/build-with-claude/extended-thinking)
    /// for details.
    /// </summary>
    public BetaThinkingConfigParam? Thinking
    {
        get
        {
            if (!this._properties.TryGetValue("thinking", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaThinkingConfigParam?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["thinking"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// How the model should use the provided tools. The model can use a specific
    /// tool, any available tool, decide by itself, or not use tools at all.
    /// </summary>
    public BetaToolChoice? ToolChoice
    {
        get
        {
            if (!this._properties.TryGetValue("tool_choice", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaToolChoice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["tool_choice"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Definitions of tools that the model may use.
    ///
    /// If you include `tools` in your API request, the model may return `tool_use`
    /// content blocks that represent the model's use of those tools. You can then
    /// run those tools using the tool input generated by the model and then optionally
    /// return results back to the model using `tool_result` content blocks.
    ///
    /// There are two types of tools: **client tools** and **server tools**. The behavior
    /// described below applies to client tools. For [server tools](https://docs.claude.com/en/docs/agents-and-tools/tool-use/overview\#server-tools),
    /// see their individual documentation as each has its own behavior (e.g., the
    /// [web search tool](https://docs.claude.com/en/docs/agents-and-tools/tool-use/web-search-tool)).
    ///
    /// Each tool definition includes:
    ///
    /// * `name`: Name of the tool. * `description`: Optional, but strongly-recommended
    /// description of the tool. * `input_schema`: [JSON schema](https://json-schema.org/draft/2020-12)
    /// for the tool `input` shape that the model will produce in `tool_use` output
    /// content blocks.
    ///
    /// For example, if you defined `tools` as:
    ///
    /// ```json [   {     "name": "get_stock_price",     "description": "Get the current
    /// stock price for a given ticker symbol.",     "input_schema": {       "type":
    /// "object",       "properties": {         "ticker": {           "type": "string",
    ///           "description": "The stock ticker symbol, e.g. AAPL for Apple Inc."
    ///         }       },       "required": ["ticker"]     }   } ] ```
    ///
    /// And then asked the model "What's the S&P 500 at today?", the model might produce
    /// `tool_use` content blocks in the response like this:
    ///
    /// ```json [   {     "type": "tool_use",     "id": "toolu_01D7FLrfh4GYq7yT1ULFeyMV",
    ///     "name": "get_stock_price",     "input": { "ticker": "^GSPC" }   } ] ```
    ///
    /// You might then run your `get_stock_price` tool with `{"ticker": "^GSPC"}`
    /// as an input, and return the following back to the model in a subsequent `user` message:
    ///
    /// ```json [   {     "type": "tool_result",     "tool_use_id": "toolu_01D7FLrfh4GYq7yT1ULFeyMV",
    ///     "content": "259.75 USD"   } ] ```
    ///
    /// Tools can be used for workflows that include running client-side tools and
    /// functions, or more generally whenever you want the model to produce a particular
    /// JSON structure of output.
    ///
    /// See our [guide](https://docs.claude.com/en/docs/tool-use) for more details.
    /// </summary>
    public List<BetaToolUnion>? Tools
    {
        get
        {
            if (!this._properties.TryGetValue("tools", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<BetaToolUnion>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["tools"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only sample from the top K options for each subsequent token.
    ///
    /// Used to remove "long tail" low probability responses. [Learn more technical
    /// details here](https://towardsdatascience.com/how-to-sample-from-language-models-682bceb97277).
    ///
    /// Recommended for advanced use cases only. You usually only need to use `temperature`.
    /// </summary>
    public long? TopK
    {
        get
        {
            if (!this._properties.TryGetValue("top_k", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["top_k"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Use nucleus sampling.
    ///
    /// In nucleus sampling, we compute the cumulative distribution over all the
    /// options for each subsequent token in decreasing probability order and cut
    /// it off once it reaches a particular probability specified by `top_p`. You
    /// should either alter `temperature` or `top_p`, but not both.
    ///
    /// Recommended for advanced use cases only. You usually only need to use `temperature`.
    /// </summary>
    public double? TopP
    {
        get
        {
            if (!this._properties.TryGetValue("top_p", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["top_p"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.MaxTokens;
        foreach (var item in this.Messages)
        {
            item.Validate();
        }
        this.Model.Validate();
        this.Container?.Validate();
        this.ContextManagement?.Validate();
        foreach (var item in this.MCPServers ?? [])
        {
            item.Validate();
        }
        this.Metadata?.Validate();
        this.ServiceTier?.Validate();
        _ = this.StopSequences;
        _ = this.Stream;
        this.System?.Validate();
        _ = this.Temperature;
        this.Thinking?.Validate();
        this.ToolChoice?.Validate();
        foreach (var item in this.Tools ?? [])
        {
            item.Validate();
        }
        _ = this.TopK;
        _ = this.TopP;
    }

    public Params() { }

    public Params(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Params(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Params FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Container identifier for reuse across requests.
/// </summary>
[JsonConverter(typeof(global::Anthropic.Client.Models.Beta.Messages.Batches.ContainerConverter))]
public record class Container
{
    public object Value { get; private init; }

    public Container(BetaContainerParams value)
    {
        Value = value;
    }

    public Container(string value)
    {
        Value = value;
    }

    Container(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Anthropic.Client.Models.Beta.Messages.Batches.Container CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaContainerParams([NotNullWhen(true)] out BetaContainerParams? value)
    {
        value = this.Value as BetaContainerParams;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public void Switch(
        System::Action<BetaContainerParams> betaContainerParams,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case BetaContainerParams value:
                betaContainerParams(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Container"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaContainerParams, T> betaContainerParams,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            BetaContainerParams value => betaContainerParams(value),
            string value => @string(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Container"
            ),
        };
    }

    public static implicit operator global::Anthropic.Client.Models.Beta.Messages.Batches.Container(
        BetaContainerParams value
    ) => new(value);

    public static implicit operator global::Anthropic.Client.Models.Beta.Messages.Batches.Container(
        string value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Container");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ContainerConverter
    : JsonConverter<global::Anthropic.Client.Models.Beta.Messages.Batches.Container?>
{
    public override global::Anthropic.Client.Models.Beta.Messages.Batches.Container? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaContainerParams>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new global::Anthropic.Client.Models.Beta.Messages.Batches.Container(
                    deserialized
                );
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaContainerParams'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new global::Anthropic.Client.Models.Beta.Messages.Batches.Container(
                    deserialized
                );
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Client.Models.Beta.Messages.Batches.Container? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Determines whether to use priority capacity (if available) or standard capacity
/// for this request.
///
/// Anthropic offers different levels of service for your API requests. See [service-tiers](https://docs.claude.com/en/api/service-tiers)
/// for details.
/// </summary>
[JsonConverter(typeof(global::Anthropic.Client.Models.Beta.Messages.Batches.ServiceTierConverter))]
public enum ServiceTier
{
    Auto,
    StandardOnly,
}

sealed class ServiceTierConverter
    : JsonConverter<global::Anthropic.Client.Models.Beta.Messages.Batches.ServiceTier>
{
    public override global::Anthropic.Client.Models.Beta.Messages.Batches.ServiceTier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => global::Anthropic.Client.Models.Beta.Messages.Batches.ServiceTier.Auto,
            "standard_only" => global::Anthropic
                .Client
                .Models
                .Beta
                .Messages
                .Batches
                .ServiceTier
                .StandardOnly,
            _ => (global::Anthropic.Client.Models.Beta.Messages.Batches.ServiceTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Client.Models.Beta.Messages.Batches.ServiceTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Client.Models.Beta.Messages.Batches.ServiceTier.Auto => "auto",
                global::Anthropic.Client.Models.Beta.Messages.Batches.ServiceTier.StandardOnly =>
                    "standard_only",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// System prompt.
///
/// A system prompt is a way of providing context and instructions to Claude, such
/// as specifying a particular goal or role. See our [guide to system prompts](https://docs.claude.com/en/docs/system-prompts).
/// </summary>
[JsonConverter(typeof(global::Anthropic.Client.Models.Beta.Messages.Batches.SystemModelConverter))]
public record class SystemModel
{
    public object Value { get; private init; }

    public SystemModel(string value)
    {
        Value = value;
    }

    public SystemModel(IReadOnlyList<BetaTextBlockParam> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    SystemModel(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Anthropic.Client.Models.Beta.Messages.Batches.SystemModel CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBetaTextBlockParams(
        [NotNullWhen(true)] out IReadOnlyList<BetaTextBlockParam>? value
    )
    {
        value = this.Value as IReadOnlyList<BetaTextBlockParam>;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyList<BetaTextBlockParam>> betaTextBlockParams
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<BetaTextBlockParam> value:
                betaTextBlockParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of SystemModel"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<BetaTextBlockParam>, T> betaTextBlockParams
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<BetaTextBlockParam> value => betaTextBlockParams(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of SystemModel"
            ),
        };
    }

    public static implicit operator global::Anthropic.Client.Models.Beta.Messages.Batches.SystemModel(
        string value
    ) => new(value);

    public static implicit operator global::Anthropic.Client.Models.Beta.Messages.Batches.SystemModel(
        List<BetaTextBlockParam> value
    ) => new((IReadOnlyList<BetaTextBlockParam>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of SystemModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class SystemModelConverter
    : JsonConverter<global::Anthropic.Client.Models.Beta.Messages.Batches.SystemModel>
{
    public override global::Anthropic.Client.Models.Beta.Messages.Batches.SystemModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new global::Anthropic.Client.Models.Beta.Messages.Batches.SystemModel(
                    deserialized
                );
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<BetaTextBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new global::Anthropic.Client.Models.Beta.Messages.Batches.SystemModel(
                    deserialized
                );
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<BetaTextBlockParam>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Client.Models.Beta.Messages.Batches.SystemModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
