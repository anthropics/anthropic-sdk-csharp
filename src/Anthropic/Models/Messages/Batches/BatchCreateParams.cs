using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages.Batches;

/// <summary>
/// Send a batch of Message creation requests.
///
/// <para>The Message Batches API can be used to process multiple Messages API requests
/// at once. Once a Message Batch is created, it begins processing immediately. Batches
/// can take up to 24 hours to complete.</para>
///
/// <para>Learn more about the Message Batches API in our [user guide](https://docs.claude.com/en/docs/build-with-claude/batch-processing)</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BatchCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// List of requests for prompt completion. Each is an individual request to
    /// create a Message.
    /// </summary>
    public required IReadOnlyList<Request> Requests
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Request>>("requests");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Request>>(
                "requests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public BatchCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchCreateParams(BatchCreateParams batchCreateParams)
        : base(batchCreateParams)
    {
        this._rawBodyData = new(batchCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BatchCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static BatchCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(BatchCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/messages/batches"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<Request, RequestFromRaw>))]
public sealed record class Request : JsonModel
{
    /// <summary>
    /// Developer-provided ID created for each request in a Message Batch. Useful
    /// for matching results to requests, as results may be given out of request order.
    ///
    /// <para>Must be unique for each request within the Message Batch.</para>
    /// </summary>
    public required string CustomID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("custom_id");
        }
        init { this._rawData.Set("custom_id", value); }
    }

    /// <summary>
    /// Messages API creation parameters for the individual request.
    ///
    /// <para>See the [Messages API reference](https://docs.claude.com/en/api/messages)
    /// for full documentation on available parameters.</para>
    /// </summary>
    public required Params Params
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Params>("params");
        }
        init { this._rawData.Set("params", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomID;
        this.Params.Validate();
    }

    public Request() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Request(Request request)
        : base(request) { }
#pragma warning restore CS8618

    public Request(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Request(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestFromRaw.FromRawUnchecked"/>
    public static Request FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequestFromRaw : IFromRawJson<Request>
{
    /// <inheritdoc/>
    public Request FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Request.FromRawUnchecked(rawData);
}

/// <summary>
/// Messages API creation parameters for the individual request.
///
/// <para>See the [Messages API reference](https://docs.claude.com/en/api/messages)
/// for full documentation on available parameters.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Params, ParamsFromRaw>))]
public sealed record class Params : JsonModel
{
    /// <summary>
    /// The maximum number of tokens to generate before stopping.
    ///
    /// <para>Note that our models may stop _before_ reaching this maximum. This parameter
    /// only specifies the absolute maximum number of tokens to generate.</para>
    ///
    /// <para>Different models have different maximum values for this parameter.
    /// See [models](https://docs.claude.com/en/docs/models-overview) for details.</para>
    /// </summary>
    public required long MaxTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("max_tokens");
        }
        init { this._rawData.Set("max_tokens", value); }
    }

    /// <summary>
    /// Input messages.
    ///
    /// <para>Our models are trained to operate on alternating `user` and `assistant`
    /// conversational turns. When creating a new `Message`, you specify the prior
    /// conversational turns with the `messages` parameter, and the model then generates
    /// the next `Message` in the conversation. Consecutive `user` or `assistant`
    /// turns in your request will be combined into a single turn.</para>
    ///
    /// <para>Each input message must be an object with a `role` and `content`. You
    /// can specify a single `user`-role message, or you can include multiple `user`
    /// and `assistant` messages.</para>
    ///
    /// <para>If the final message uses the `assistant` role, the response content
    /// will continue immediately from the content in that message. This can be used
    /// to constrain part of the model's response.</para>
    ///
    /// <para>Example with a single `user` message:</para>
    ///
    /// <para>```json [{"role": "user", "content": "Hello, Claude"}] ```</para>
    ///
    /// <para>Example with multiple conversational turns:</para>
    ///
    /// <para>```json [   {"role": "user", "content": "Hello there."},   {"role":
    /// "assistant", "content": "Hi, I'm Claude. How can I help you?"},   {"role":
    /// "user", "content": "Can you explain LLMs in plain English?"}, ] ```</para>
    ///
    /// <para>Example with a partially-filled response from Claude:</para>
    ///
    /// <para>```json [   {"role": "user", "content": "What's the Greek name for
    /// Sun? (A) Sol (B) Helios (C) Sun"},   {"role": "assistant", "content": "The
    /// best answer is ("}, ] ```</para>
    ///
    /// <para>Each input message `content` may be either a single `string` or an
    /// array of content blocks, where each block has a specific `type`. Using a `string`
    /// for `content` is shorthand for an array of one content block of type `"text"`.
    /// The following input messages are equivalent:</para>
    ///
    /// <para>```json {"role": "user", "content": "Hello, Claude"} ```</para>
    ///
    /// <para>```json {"role": "user", "content": [{"type": "text", "text": "Hello,
    /// Claude"}]} ```</para>
    ///
    /// <para>See [input examples](https://docs.claude.com/en/api/messages-examples).</para>
    ///
    /// <para>Note that if you want to include a [system prompt](https://docs.claude.com/en/docs/system-prompts),
    /// you can use the top-level `system` parameter — there is no `"system"` role
    /// for input messages in the Messages API.</para>
    ///
    /// <para>There is a limit of 100,000 messages in a single request.</para>
    /// </summary>
    public required IReadOnlyList<MessageParam> Messages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MessageParam>>("messages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MessageParam>>(
                "messages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The model that will complete your prompt.\n\nSee [models](https://docs.anthropic.com/en/docs/models-overview)
    /// for additional details and options.
    /// </summary>
    public required ApiEnum<string, Model> Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Model>>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// An object describing metadata about the request.
    /// </summary>
    public Metadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metadata>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Determines whether to use priority capacity (if available) or standard capacity
    /// for this request.
    ///
    /// <para>Anthropic offers different levels of service for your API requests.
    /// See [service-tiers](https://docs.claude.com/en/api/service-tiers) for details.</para>
    /// </summary>
    public ApiEnum<string, ServiceTier>? ServiceTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ServiceTier>>("service_tier");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("service_tier", value);
        }
    }

    /// <summary>
    /// Custom text sequences that will cause the model to stop generating.
    ///
    /// <para>Our models will normally stop when they have naturally completed their
    /// turn, which will result in a response `stop_reason` of `"end_turn"`.</para>
    ///
    /// <para>If you want the model to stop generating when it encounters custom
    /// strings of text, you can use the `stop_sequences` parameter. If the model
    /// encounters one of the custom sequences, the response `stop_reason` value
    /// will be `"stop_sequence"` and the response `stop_sequence` value will contain
    /// the matched stop sequence.</para>
    /// </summary>
    public IReadOnlyList<string>? StopSequences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("stop_sequences");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "stop_sequences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether to incrementally stream the response using server-sent events.
    ///
    /// <para>See [streaming](https://docs.claude.com/en/api/messages-streaming)
    /// for details.</para>
    /// </summary>
    public bool? Stream
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("stream");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stream", value);
        }
    }

    /// <summary>
    /// System prompt.
    ///
    /// <para>A system prompt is a way of providing context and instructions to Claude,
    /// such as specifying a particular goal or role. See our [guide to system prompts](https://docs.claude.com/en/docs/system-prompts).</para>
    /// </summary>
    public ParamsSystem? System
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ParamsSystem>("system");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("system", value);
        }
    }

    /// <summary>
    /// Amount of randomness injected into the response.
    ///
    /// <para>Defaults to `1.0`. Ranges from `0.0` to `1.0`. Use `temperature` closer
    /// to `0.0` for analytical / multiple choice, and closer to `1.0` for creative
    /// and generative tasks.</para>
    ///
    /// <para>Note that even with `temperature` of `0.0`, the results will not be
    /// fully deterministic.</para>
    /// </summary>
    public double? Temperature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("temperature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("temperature", value);
        }
    }

    /// <summary>
    /// Configuration for enabling Claude's extended thinking.
    ///
    /// <para>When enabled, responses include `thinking` content blocks showing Claude's
    /// thinking process before the final answer. Requires a minimum budget of 1,024
    /// tokens and counts towards your `max_tokens` limit.</para>
    ///
    /// <para>See [extended thinking](https://docs.claude.com/en/docs/build-with-claude/extended-thinking)
    /// for details.</para>
    /// </summary>
    public ThinkingConfigParam? Thinking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ThinkingConfigParam>("thinking");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("thinking", value);
        }
    }

    /// <summary>
    /// How the model should use the provided tools. The model can use a specific
    /// tool, any available tool, decide by itself, or not use tools at all.
    /// </summary>
    public ToolChoice? ToolChoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ToolChoice>("tool_choice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tool_choice", value);
        }
    }

    /// <summary>
    /// Definitions of tools that the model may use.
    ///
    /// <para>If you include `tools` in your API request, the model may return `tool_use`
    /// content blocks that represent the model's use of those tools. You can then
    /// run those tools using the tool input generated by the model and then optionally
    /// return results back to the model using `tool_result` content blocks.</para>
    ///
    /// <para>There are two types of tools: **client tools** and **server tools**.
    /// The behavior described below applies to client tools. For [server tools](https://docs.claude.com/en/docs/agents-and-tools/tool-use/overview\#server-tools),
    /// see their individual documentation as each has its own behavior (e.g., the
    /// [web search tool](https://docs.claude.com/en/docs/agents-and-tools/tool-use/web-search-tool)).</para>
    ///
    /// <para>Each tool definition includes:</para>
    ///
    /// <para>* `name`: Name of the tool. * `description`: Optional, but strongly-recommended
    /// description of the tool. * `input_schema`: [JSON schema](https://json-schema.org/draft/2020-12)
    /// for the tool `input` shape that the model will produce in `tool_use` output
    /// content blocks.</para>
    ///
    /// <para>For example, if you defined `tools` as:</para>
    ///
    /// <para>```json [   {     "name": "get_stock_price",     "description": "Get
    /// the current stock price for a given ticker symbol.",     "input_schema": {
    ///       "type": "object",       "properties": {         "ticker": {
    ///    "type": "string",           "description": "The stock ticker symbol, e.g.
    /// AAPL for Apple Inc."         }       },       "required": ["ticker"]
    /// }   } ] ```</para>
    ///
    /// <para>And then asked the model "What's the S&P 500 at today?", the model might
    /// produce `tool_use` content blocks in the response like this:</para>
    ///
    /// <para>```json [   {     "type": "tool_use",     "id": "toolu_01D7FLrfh4GYq7yT1ULFeyMV",
    ///     "name": "get_stock_price",     "input": { "ticker": "^GSPC" }   } ] ```</para>
    ///
    /// <para>You might then run your `get_stock_price` tool with `{"ticker": "^GSPC"}`
    /// as an input, and return the following back to the model in a subsequent `user` message:</para>
    ///
    /// <para>```json [   {     "type": "tool_result",     "tool_use_id": "toolu_01D7FLrfh4GYq7yT1ULFeyMV",
    ///     "content": "259.75 USD"   } ] ```</para>
    ///
    /// <para>Tools can be used for workflows that include running client-side tools
    /// and functions, or more generally whenever you want the model to produce a
    /// particular JSON structure of output.</para>
    ///
    /// <para>See our [guide](https://docs.claude.com/en/docs/tool-use) for more details.</para>
    /// </summary>
    public IReadOnlyList<ToolUnion>? Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ToolUnion>>("tools");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ToolUnion>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Only sample from the top K options for each subsequent token.
    ///
    /// <para>Used to remove "long tail" low probability responses. [Learn more technical
    /// details here](https://towardsdatascience.com/how-to-sample-from-language-models-682bceb97277).</para>
    ///
    /// <para>Recommended for advanced use cases only. You usually only need to use `temperature`.</para>
    /// </summary>
    public long? TopK
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("top_k");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("top_k", value);
        }
    }

    /// <summary>
    /// Use nucleus sampling.
    ///
    /// <para>In nucleus sampling, we compute the cumulative distribution over all
    /// the options for each subsequent token in decreasing probability order and
    /// cut it off once it reaches a particular probability specified by `top_p`.
    /// You should either alter `temperature` or `top_p`, but not both.</para>
    ///
    /// <para>Recommended for advanced use cases only. You usually only need to use `temperature`.</para>
    /// </summary>
    public double? TopP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("top_p");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("top_p", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaxTokens;
        foreach (var item in this.Messages)
        {
            item.Validate();
        }
        this.Model.Validate();
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Params(Params params_)
        : base(params_) { }
#pragma warning restore CS8618

    public Params(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Params(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParamsFromRaw.FromRawUnchecked"/>
    public static Params FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParamsFromRaw : IFromRawJson<Params>
{
    /// <inheritdoc/>
    public Params FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Params.FromRawUnchecked(rawData);
}

/// <summary>
/// Determines whether to use priority capacity (if available) or standard capacity
/// for this request.
///
/// <para>Anthropic offers different levels of service for your API requests. See
/// [service-tiers](https://docs.claude.com/en/api/service-tiers) for details.</para>
/// </summary>
[JsonConverter(typeof(ServiceTierConverter))]
public enum ServiceTier
{
    Auto,
    StandardOnly,
}

sealed class ServiceTierConverter : JsonConverter<ServiceTier>
{
    public override ServiceTier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => ServiceTier.Auto,
            "standard_only" => ServiceTier.StandardOnly,
            _ => (ServiceTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ServiceTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ServiceTier.Auto => "auto",
                ServiceTier.StandardOnly => "standard_only",
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
/// <para>A system prompt is a way of providing context and instructions to Claude,
/// such as specifying a particular goal or role. See our [guide to system prompts](https://docs.claude.com/en/docs/system-prompts).</para>
/// </summary>
[JsonConverter(typeof(ParamsSystemConverter))]
public record class ParamsSystem : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ParamsSystem(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ParamsSystem(IReadOnlyList<TextBlockParam> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ParamsSystem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<TextBlockParam>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextBlockParams(out var value)) {
    ///     // `value` is of type `IReadOnlyList<TextBlockParam>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextBlockParams([NotNullWhen(true)] out IReadOnlyList<TextBlockParam>? value)
    {
        value = this.Value as IReadOnlyList<TextBlockParam>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (IReadOnlyList<TextBlockParam> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyList<TextBlockParam>> textBlockParams
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<TextBlockParam> value:
                textBlockParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ParamsSystem"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (IReadOnlyList<TextBlockParam> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<TextBlockParam>, T> textBlockParams
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<TextBlockParam> value => textBlockParams(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ParamsSystem"
            ),
        };
    }

    public static implicit operator ParamsSystem(string value) => new(value);

    public static implicit operator ParamsSystem(List<TextBlockParam> value) =>
        new((IReadOnlyList<TextBlockParam>)value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ParamsSystem"
            );
        }
    }

    public virtual bool Equals(ParamsSystem? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ParamsSystemConverter : JsonConverter<ParamsSystem>
{
    public override ParamsSystem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<TextBlockParam>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParamsSystem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
