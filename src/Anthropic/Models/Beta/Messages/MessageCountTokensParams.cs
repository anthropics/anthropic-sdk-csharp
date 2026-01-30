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
using Messages = Anthropic.Models.Messages;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Count the number of tokens in a Message.
///
/// <para>The Token Count API can be used to count the number of tokens in a Message,
/// including tools, images, and documents, without creating it.</para>
///
/// <para>Learn more about token counting in our [user guide](https://docs.claude.com/en/docs/build-with-claude/token-counting)</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MessageCountTokensParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
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
    public required IReadOnlyList<BetaMessageParam> Messages
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<BetaMessageParam>>("messages");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<BetaMessageParam>>(
                "messages",
                ImmutableArray.ToImmutableArray(value)
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Messages::Model>>("model");
        }
        init { this._rawBodyData.Set("model", value); }
    }

    /// <summary>
    /// Context management configuration.
    ///
    /// <para>This allows you to control how Claude manages context across multiple
    /// requests, such as whether to clear function results or not.</para>
    /// </summary>
    public BetaContextManagementConfig? ContextManagement
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaContextManagementConfig>(
                "context_management"
            );
        }
        init { this._rawBodyData.Set("context_management", value); }
    }

    /// <summary>
    /// MCP servers to be utilized in this request
    /// </summary>
    public IReadOnlyList<BetaRequestMcpServerUrlDefinition>? McpServers
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<BetaRequestMcpServerUrlDefinition>
            >("mcp_servers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<BetaRequestMcpServerUrlDefinition>?>(
                "mcp_servers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Configuration options for the model's output, such as the output format.
    /// </summary>
    public BetaOutputConfig? OutputConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaOutputConfig>("output_config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("output_config", value);
        }
    }

    /// <summary>
    /// Deprecated: Use `output_config.format` instead. See [structured outputs](https://platform.claude.com/docs/en/build-with-claude/structured-outputs)
    ///
    /// <para>A schema to specify Claude's output format in responses. This parameter
    /// will be removed in a future release.</para>
    /// </summary>
    [System::Obsolete("deprecated")]
    public BetaJsonOutputFormat? OutputFormat
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaJsonOutputFormat>("output_format");
        }
        init { this._rawBodyData.Set("output_format", value); }
    }

    /// <summary>
    /// System prompt.
    ///
    /// <para>A system prompt is a way of providing context and instructions to Claude,
    /// such as specifying a particular goal or role. See our [guide to system prompts](https://docs.claude.com/en/docs/system-prompts).</para>
    /// </summary>
    public MessageCountTokensParamsSystem? System
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<MessageCountTokensParamsSystem>("system");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("system", value);
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
    public BetaThinkingConfigParam? Thinking
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaThinkingConfigParam>("thinking");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("thinking", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaToolChoice>("tool_choice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tool_choice", value);
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
    public IReadOnlyList<Tool>? Tools
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Tool>>("tools");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Tool>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public MessageCountTokensParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCountTokensParams(MessageCountTokensParams messageCountTokensParams)
        : base(messageCountTokensParams)
    {
        this._rawBodyData = new(messageCountTokensParams._rawBodyData);
    }
#pragma warning restore CS8618

    public MessageCountTokensParams(
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
    MessageCountTokensParams(
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
    public static MessageCountTokensParams FromRawUnchecked(
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

    public virtual bool Equals(MessageCountTokensParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/messages/count_tokens?beta=true"
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

/// <summary>
/// System prompt.
///
/// <para>A system prompt is a way of providing context and instructions to Claude,
/// such as specifying a particular goal or role. See our [guide to system prompts](https://docs.claude.com/en/docs/system-prompts).</para>
/// </summary>
[JsonConverter(typeof(MessageCountTokensParamsSystemConverter))]
public record class MessageCountTokensParamsSystem : ModelBase
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

    public MessageCountTokensParamsSystem(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MessageCountTokensParamsSystem(
        IReadOnlyList<BetaTextBlockParam> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public MessageCountTokensParamsSystem(JsonElement element)
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
    /// type <see cref="IReadOnlyList<BetaTextBlockParam>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTextBlockParams(out var value)) {
    ///     // `value` is of type `IReadOnlyList<BetaTextBlockParam>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextBlockParams(
        [NotNullWhen(true)] out IReadOnlyList<BetaTextBlockParam>? value
    )
    {
        value = this.Value as IReadOnlyList<BetaTextBlockParam>;
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
    ///     (IReadOnlyList<BetaTextBlockParam> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
            case IReadOnlyList<BetaTextBlockParam> value:
                betaTextBlockParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of MessageCountTokensParamsSystem"
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
    ///     (IReadOnlyList<BetaTextBlockParam> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of MessageCountTokensParamsSystem"
            ),
        };
    }

    public static implicit operator MessageCountTokensParamsSystem(string value) => new(value);

    public static implicit operator MessageCountTokensParamsSystem(
        List<BetaTextBlockParam> value
    ) => new((IReadOnlyList<BetaTextBlockParam>)value);

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
                "Data did not match any variant of MessageCountTokensParamsSystem"
            );
        }
    }

    public virtual bool Equals(MessageCountTokensParamsSystem? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            IReadOnlyList<BetaTextBlockParam> _ => 1,
            _ => -1,
        };
    }
}

sealed class MessageCountTokensParamsSystemConverter : JsonConverter<MessageCountTokensParamsSystem>
{
    public override MessageCountTokensParamsSystem? Read(
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
            var deserialized = JsonSerializer.Deserialize<List<BetaTextBlockParam>>(
                element,
                options
            );
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
        MessageCountTokensParamsSystem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Configuration for a group of tools from an MCP server.
///
/// <para>Allows configuring enabled status and defer_loading for all tools from
/// an MCP server, with optional per-tool overrides.</para>
/// </summary>
[JsonConverter(typeof(ToolConverter))]
public record class Tool : ModelBase
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

    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<BetaCacheControlEphemeral?>(
                beta: (x) => x.CacheControl,
                betaToolBash20241022: (x) => x.CacheControl,
                betaToolBash20250124: (x) => x.CacheControl,
                betaCodeExecutionTool20250522: (x) => x.CacheControl,
                betaCodeExecutionTool20250825: (x) => x.CacheControl,
                betaToolComputerUse20241022: (x) => x.CacheControl,
                betaMemoryTool20250818: (x) => x.CacheControl,
                betaToolComputerUse20250124: (x) => x.CacheControl,
                betaToolTextEditor20241022: (x) => x.CacheControl,
                betaToolComputerUse20251124: (x) => x.CacheControl,
                betaToolTextEditor20250124: (x) => x.CacheControl,
                betaToolTextEditor20250429: (x) => x.CacheControl,
                betaToolTextEditor20250728: (x) => x.CacheControl,
                betaWebSearchTool20250305: (x) => x.CacheControl,
                betaWebFetchTool20250910: (x) => x.CacheControl,
                betaToolSearchToolBm25_20251119: (x) => x.CacheControl,
                betaToolSearchToolRegex20251119: (x) => x.CacheControl,
                betaMcpToolset: (x) => x.CacheControl
            );
        }
    }

    public bool? DeferLoading
    {
        get
        {
            return Match<bool?>(
                beta: (x) => x.DeferLoading,
                betaToolBash20241022: (x) => x.DeferLoading,
                betaToolBash20250124: (x) => x.DeferLoading,
                betaCodeExecutionTool20250522: (x) => x.DeferLoading,
                betaCodeExecutionTool20250825: (x) => x.DeferLoading,
                betaToolComputerUse20241022: (x) => x.DeferLoading,
                betaMemoryTool20250818: (x) => x.DeferLoading,
                betaToolComputerUse20250124: (x) => x.DeferLoading,
                betaToolTextEditor20241022: (x) => x.DeferLoading,
                betaToolComputerUse20251124: (x) => x.DeferLoading,
                betaToolTextEditor20250124: (x) => x.DeferLoading,
                betaToolTextEditor20250429: (x) => x.DeferLoading,
                betaToolTextEditor20250728: (x) => x.DeferLoading,
                betaWebSearchTool20250305: (x) => x.DeferLoading,
                betaWebFetchTool20250910: (x) => x.DeferLoading,
                betaToolSearchToolBm25_20251119: (x) => x.DeferLoading,
                betaToolSearchToolRegex20251119: (x) => x.DeferLoading,
                betaMcpToolset: (_) => null
            );
        }
    }

    public bool? Strict
    {
        get
        {
            return Match<bool?>(
                beta: (x) => x.Strict,
                betaToolBash20241022: (x) => x.Strict,
                betaToolBash20250124: (x) => x.Strict,
                betaCodeExecutionTool20250522: (x) => x.Strict,
                betaCodeExecutionTool20250825: (x) => x.Strict,
                betaToolComputerUse20241022: (x) => x.Strict,
                betaMemoryTool20250818: (x) => x.Strict,
                betaToolComputerUse20250124: (x) => x.Strict,
                betaToolTextEditor20241022: (x) => x.Strict,
                betaToolComputerUse20251124: (x) => x.Strict,
                betaToolTextEditor20250124: (x) => x.Strict,
                betaToolTextEditor20250429: (x) => x.Strict,
                betaToolTextEditor20250728: (x) => x.Strict,
                betaWebSearchTool20250305: (x) => x.Strict,
                betaWebFetchTool20250910: (x) => x.Strict,
                betaToolSearchToolBm25_20251119: (x) => x.Strict,
                betaToolSearchToolRegex20251119: (x) => x.Strict,
                betaMcpToolset: (_) => null
            );
        }
    }

    public long? DisplayHeightPx
    {
        get
        {
            return Match<long?>(
                beta: (_) => null,
                betaToolBash20241022: (_) => null,
                betaToolBash20250124: (_) => null,
                betaCodeExecutionTool20250522: (_) => null,
                betaCodeExecutionTool20250825: (_) => null,
                betaToolComputerUse20241022: (x) => x.DisplayHeightPx,
                betaMemoryTool20250818: (_) => null,
                betaToolComputerUse20250124: (x) => x.DisplayHeightPx,
                betaToolTextEditor20241022: (_) => null,
                betaToolComputerUse20251124: (x) => x.DisplayHeightPx,
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (_) => null,
                betaWebFetchTool20250910: (_) => null,
                betaToolSearchToolBm25_20251119: (_) => null,
                betaToolSearchToolRegex20251119: (_) => null,
                betaMcpToolset: (_) => null
            );
        }
    }

    public long? DisplayWidthPx
    {
        get
        {
            return Match<long?>(
                beta: (_) => null,
                betaToolBash20241022: (_) => null,
                betaToolBash20250124: (_) => null,
                betaCodeExecutionTool20250522: (_) => null,
                betaCodeExecutionTool20250825: (_) => null,
                betaToolComputerUse20241022: (x) => x.DisplayWidthPx,
                betaMemoryTool20250818: (_) => null,
                betaToolComputerUse20250124: (x) => x.DisplayWidthPx,
                betaToolTextEditor20241022: (_) => null,
                betaToolComputerUse20251124: (x) => x.DisplayWidthPx,
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (_) => null,
                betaWebFetchTool20250910: (_) => null,
                betaToolSearchToolBm25_20251119: (_) => null,
                betaToolSearchToolRegex20251119: (_) => null,
                betaMcpToolset: (_) => null
            );
        }
    }

    public long? DisplayNumber
    {
        get
        {
            return Match<long?>(
                beta: (_) => null,
                betaToolBash20241022: (_) => null,
                betaToolBash20250124: (_) => null,
                betaCodeExecutionTool20250522: (_) => null,
                betaCodeExecutionTool20250825: (_) => null,
                betaToolComputerUse20241022: (x) => x.DisplayNumber,
                betaMemoryTool20250818: (_) => null,
                betaToolComputerUse20250124: (x) => x.DisplayNumber,
                betaToolTextEditor20241022: (_) => null,
                betaToolComputerUse20251124: (x) => x.DisplayNumber,
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (_) => null,
                betaWebFetchTool20250910: (_) => null,
                betaToolSearchToolBm25_20251119: (_) => null,
                betaToolSearchToolRegex20251119: (_) => null,
                betaMcpToolset: (_) => null
            );
        }
    }

    public long? MaxUses
    {
        get
        {
            return Match<long?>(
                beta: (_) => null,
                betaToolBash20241022: (_) => null,
                betaToolBash20250124: (_) => null,
                betaCodeExecutionTool20250522: (_) => null,
                betaCodeExecutionTool20250825: (_) => null,
                betaToolComputerUse20241022: (_) => null,
                betaMemoryTool20250818: (_) => null,
                betaToolComputerUse20250124: (_) => null,
                betaToolTextEditor20241022: (_) => null,
                betaToolComputerUse20251124: (_) => null,
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (x) => x.MaxUses,
                betaWebFetchTool20250910: (x) => x.MaxUses,
                betaToolSearchToolBm25_20251119: (_) => null,
                betaToolSearchToolRegex20251119: (_) => null,
                betaMcpToolset: (_) => null
            );
        }
    }

    public Tool(BetaTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaToolBash20241022 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaToolBash20250124 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaCodeExecutionTool20250522 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaCodeExecutionTool20250825 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaToolComputerUse20241022 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaMemoryTool20250818 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaToolComputerUse20250124 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaToolTextEditor20241022 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaToolComputerUse20251124 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaToolTextEditor20250124 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaToolTextEditor20250429 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaToolTextEditor20250728 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaWebSearchTool20250305 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaWebFetchTool20250910 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaToolSearchToolBm25_20251119 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaToolSearchToolRegex20251119 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(BetaMcpToolset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBeta(out var value)) {
    ///     // `value` is of type `BetaTool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBeta([NotNullWhen(true)] out BetaTool? value)
    {
        value = this.Value as BetaTool;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolBash20241022"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolBash20241022(out var value)) {
    ///     // `value` is of type `BetaToolBash20241022`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolBash20241022([NotNullWhen(true)] out BetaToolBash20241022? value)
    {
        value = this.Value as BetaToolBash20241022;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolBash20250124"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolBash20250124(out var value)) {
    ///     // `value` is of type `BetaToolBash20250124`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolBash20250124([NotNullWhen(true)] out BetaToolBash20250124? value)
    {
        value = this.Value as BetaToolBash20250124;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCodeExecutionTool20250522"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCodeExecutionTool20250522(out var value)) {
    ///     // `value` is of type `BetaCodeExecutionTool20250522`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCodeExecutionTool20250522(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250522? value
    )
    {
        value = this.Value as BetaCodeExecutionTool20250522;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCodeExecutionTool20250825"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCodeExecutionTool20250825(out var value)) {
    ///     // `value` is of type `BetaCodeExecutionTool20250825`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCodeExecutionTool20250825(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250825? value
    )
    {
        value = this.Value as BetaCodeExecutionTool20250825;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolComputerUse20241022"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolComputerUse20241022(out var value)) {
    ///     // `value` is of type `BetaToolComputerUse20241022`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolComputerUse20241022(
        [NotNullWhen(true)] out BetaToolComputerUse20241022? value
    )
    {
        value = this.Value as BetaToolComputerUse20241022;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMemoryTool20250818"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaMemoryTool20250818(out var value)) {
    ///     // `value` is of type `BetaMemoryTool20250818`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaMemoryTool20250818([NotNullWhen(true)] out BetaMemoryTool20250818? value)
    {
        value = this.Value as BetaMemoryTool20250818;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolComputerUse20250124"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolComputerUse20250124(out var value)) {
    ///     // `value` is of type `BetaToolComputerUse20250124`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolComputerUse20250124(
        [NotNullWhen(true)] out BetaToolComputerUse20250124? value
    )
    {
        value = this.Value as BetaToolComputerUse20250124;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolTextEditor20241022"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolTextEditor20241022(out var value)) {
    ///     // `value` is of type `BetaToolTextEditor20241022`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolTextEditor20241022(
        [NotNullWhen(true)] out BetaToolTextEditor20241022? value
    )
    {
        value = this.Value as BetaToolTextEditor20241022;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolComputerUse20251124"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolComputerUse20251124(out var value)) {
    ///     // `value` is of type `BetaToolComputerUse20251124`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolComputerUse20251124(
        [NotNullWhen(true)] out BetaToolComputerUse20251124? value
    )
    {
        value = this.Value as BetaToolComputerUse20251124;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolTextEditor20250124"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolTextEditor20250124(out var value)) {
    ///     // `value` is of type `BetaToolTextEditor20250124`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolTextEditor20250124(
        [NotNullWhen(true)] out BetaToolTextEditor20250124? value
    )
    {
        value = this.Value as BetaToolTextEditor20250124;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolTextEditor20250429"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolTextEditor20250429(out var value)) {
    ///     // `value` is of type `BetaToolTextEditor20250429`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolTextEditor20250429(
        [NotNullWhen(true)] out BetaToolTextEditor20250429? value
    )
    {
        value = this.Value as BetaToolTextEditor20250429;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolTextEditor20250728"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolTextEditor20250728(out var value)) {
    ///     // `value` is of type `BetaToolTextEditor20250728`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolTextEditor20250728(
        [NotNullWhen(true)] out BetaToolTextEditor20250728? value
    )
    {
        value = this.Value as BetaToolTextEditor20250728;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebSearchTool20250305"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebSearchTool20250305(out var value)) {
    ///     // `value` is of type `BetaWebSearchTool20250305`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebSearchTool20250305(
        [NotNullWhen(true)] out BetaWebSearchTool20250305? value
    )
    {
        value = this.Value as BetaWebSearchTool20250305;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchTool20250910"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchTool20250910(out var value)) {
    ///     // `value` is of type `BetaWebFetchTool20250910`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchTool20250910(
        [NotNullWhen(true)] out BetaWebFetchTool20250910? value
    )
    {
        value = this.Value as BetaWebFetchTool20250910;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolSearchToolBm25_20251119"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolSearchToolBm25_20251119(out var value)) {
    ///     // `value` is of type `BetaToolSearchToolBm25_20251119`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolSearchToolBm25_20251119(
        [NotNullWhen(true)] out BetaToolSearchToolBm25_20251119? value
    )
    {
        value = this.Value as BetaToolSearchToolBm25_20251119;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolSearchToolRegex20251119"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolSearchToolRegex20251119(out var value)) {
    ///     // `value` is of type `BetaToolSearchToolRegex20251119`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolSearchToolRegex20251119(
        [NotNullWhen(true)] out BetaToolSearchToolRegex20251119? value
    )
    {
        value = this.Value as BetaToolSearchToolRegex20251119;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMcpToolset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaMcpToolset(out var value)) {
    ///     // `value` is of type `BetaMcpToolset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaMcpToolset([NotNullWhen(true)] out BetaMcpToolset? value)
    {
        value = this.Value as BetaMcpToolset;
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
    ///     (BetaTool value) => {...},
    ///     (BetaToolBash20241022 value) => {...},
    ///     (BetaToolBash20250124 value) => {...},
    ///     (BetaCodeExecutionTool20250522 value) => {...},
    ///     (BetaCodeExecutionTool20250825 value) => {...},
    ///     (BetaToolComputerUse20241022 value) => {...},
    ///     (BetaMemoryTool20250818 value) => {...},
    ///     (BetaToolComputerUse20250124 value) => {...},
    ///     (BetaToolTextEditor20241022 value) => {...},
    ///     (BetaToolComputerUse20251124 value) => {...},
    ///     (BetaToolTextEditor20250124 value) => {...},
    ///     (BetaToolTextEditor20250429 value) => {...},
    ///     (BetaToolTextEditor20250728 value) => {...},
    ///     (BetaWebSearchTool20250305 value) => {...},
    ///     (BetaWebFetchTool20250910 value) => {...},
    ///     (BetaToolSearchToolBm25_20251119 value) => {...},
    ///     (BetaToolSearchToolRegex20251119 value) => {...},
    ///     (BetaMcpToolset value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaTool> beta,
        System::Action<BetaToolBash20241022> betaToolBash20241022,
        System::Action<BetaToolBash20250124> betaToolBash20250124,
        System::Action<BetaCodeExecutionTool20250522> betaCodeExecutionTool20250522,
        System::Action<BetaCodeExecutionTool20250825> betaCodeExecutionTool20250825,
        System::Action<BetaToolComputerUse20241022> betaToolComputerUse20241022,
        System::Action<BetaMemoryTool20250818> betaMemoryTool20250818,
        System::Action<BetaToolComputerUse20250124> betaToolComputerUse20250124,
        System::Action<BetaToolTextEditor20241022> betaToolTextEditor20241022,
        System::Action<BetaToolComputerUse20251124> betaToolComputerUse20251124,
        System::Action<BetaToolTextEditor20250124> betaToolTextEditor20250124,
        System::Action<BetaToolTextEditor20250429> betaToolTextEditor20250429,
        System::Action<BetaToolTextEditor20250728> betaToolTextEditor20250728,
        System::Action<BetaWebSearchTool20250305> betaWebSearchTool20250305,
        System::Action<BetaWebFetchTool20250910> betaWebFetchTool20250910,
        System::Action<BetaToolSearchToolBm25_20251119> betaToolSearchToolBm25_20251119,
        System::Action<BetaToolSearchToolRegex20251119> betaToolSearchToolRegex20251119,
        System::Action<BetaMcpToolset> betaMcpToolset
    )
    {
        switch (this.Value)
        {
            case BetaTool value:
                beta(value);
                break;
            case BetaToolBash20241022 value:
                betaToolBash20241022(value);
                break;
            case BetaToolBash20250124 value:
                betaToolBash20250124(value);
                break;
            case BetaCodeExecutionTool20250522 value:
                betaCodeExecutionTool20250522(value);
                break;
            case BetaCodeExecutionTool20250825 value:
                betaCodeExecutionTool20250825(value);
                break;
            case BetaToolComputerUse20241022 value:
                betaToolComputerUse20241022(value);
                break;
            case BetaMemoryTool20250818 value:
                betaMemoryTool20250818(value);
                break;
            case BetaToolComputerUse20250124 value:
                betaToolComputerUse20250124(value);
                break;
            case BetaToolTextEditor20241022 value:
                betaToolTextEditor20241022(value);
                break;
            case BetaToolComputerUse20251124 value:
                betaToolComputerUse20251124(value);
                break;
            case BetaToolTextEditor20250124 value:
                betaToolTextEditor20250124(value);
                break;
            case BetaToolTextEditor20250429 value:
                betaToolTextEditor20250429(value);
                break;
            case BetaToolTextEditor20250728 value:
                betaToolTextEditor20250728(value);
                break;
            case BetaWebSearchTool20250305 value:
                betaWebSearchTool20250305(value);
                break;
            case BetaWebFetchTool20250910 value:
                betaWebFetchTool20250910(value);
                break;
            case BetaToolSearchToolBm25_20251119 value:
                betaToolSearchToolBm25_20251119(value);
                break;
            case BetaToolSearchToolRegex20251119 value:
                betaToolSearchToolRegex20251119(value);
                break;
            case BetaMcpToolset value:
                betaMcpToolset(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Tool");
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
    ///     (BetaTool value) => {...},
    ///     (BetaToolBash20241022 value) => {...},
    ///     (BetaToolBash20250124 value) => {...},
    ///     (BetaCodeExecutionTool20250522 value) => {...},
    ///     (BetaCodeExecutionTool20250825 value) => {...},
    ///     (BetaToolComputerUse20241022 value) => {...},
    ///     (BetaMemoryTool20250818 value) => {...},
    ///     (BetaToolComputerUse20250124 value) => {...},
    ///     (BetaToolTextEditor20241022 value) => {...},
    ///     (BetaToolComputerUse20251124 value) => {...},
    ///     (BetaToolTextEditor20250124 value) => {...},
    ///     (BetaToolTextEditor20250429 value) => {...},
    ///     (BetaToolTextEditor20250728 value) => {...},
    ///     (BetaWebSearchTool20250305 value) => {...},
    ///     (BetaWebFetchTool20250910 value) => {...},
    ///     (BetaToolSearchToolBm25_20251119 value) => {...},
    ///     (BetaToolSearchToolRegex20251119 value) => {...},
    ///     (BetaMcpToolset value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaTool, T> beta,
        System::Func<BetaToolBash20241022, T> betaToolBash20241022,
        System::Func<BetaToolBash20250124, T> betaToolBash20250124,
        System::Func<BetaCodeExecutionTool20250522, T> betaCodeExecutionTool20250522,
        System::Func<BetaCodeExecutionTool20250825, T> betaCodeExecutionTool20250825,
        System::Func<BetaToolComputerUse20241022, T> betaToolComputerUse20241022,
        System::Func<BetaMemoryTool20250818, T> betaMemoryTool20250818,
        System::Func<BetaToolComputerUse20250124, T> betaToolComputerUse20250124,
        System::Func<BetaToolTextEditor20241022, T> betaToolTextEditor20241022,
        System::Func<BetaToolComputerUse20251124, T> betaToolComputerUse20251124,
        System::Func<BetaToolTextEditor20250124, T> betaToolTextEditor20250124,
        System::Func<BetaToolTextEditor20250429, T> betaToolTextEditor20250429,
        System::Func<BetaToolTextEditor20250728, T> betaToolTextEditor20250728,
        System::Func<BetaWebSearchTool20250305, T> betaWebSearchTool20250305,
        System::Func<BetaWebFetchTool20250910, T> betaWebFetchTool20250910,
        System::Func<BetaToolSearchToolBm25_20251119, T> betaToolSearchToolBm25_20251119,
        System::Func<BetaToolSearchToolRegex20251119, T> betaToolSearchToolRegex20251119,
        System::Func<BetaMcpToolset, T> betaMcpToolset
    )
    {
        return this.Value switch
        {
            BetaTool value => beta(value),
            BetaToolBash20241022 value => betaToolBash20241022(value),
            BetaToolBash20250124 value => betaToolBash20250124(value),
            BetaCodeExecutionTool20250522 value => betaCodeExecutionTool20250522(value),
            BetaCodeExecutionTool20250825 value => betaCodeExecutionTool20250825(value),
            BetaToolComputerUse20241022 value => betaToolComputerUse20241022(value),
            BetaMemoryTool20250818 value => betaMemoryTool20250818(value),
            BetaToolComputerUse20250124 value => betaToolComputerUse20250124(value),
            BetaToolTextEditor20241022 value => betaToolTextEditor20241022(value),
            BetaToolComputerUse20251124 value => betaToolComputerUse20251124(value),
            BetaToolTextEditor20250124 value => betaToolTextEditor20250124(value),
            BetaToolTextEditor20250429 value => betaToolTextEditor20250429(value),
            BetaToolTextEditor20250728 value => betaToolTextEditor20250728(value),
            BetaWebSearchTool20250305 value => betaWebSearchTool20250305(value),
            BetaWebFetchTool20250910 value => betaWebFetchTool20250910(value),
            BetaToolSearchToolBm25_20251119 value => betaToolSearchToolBm25_20251119(value),
            BetaToolSearchToolRegex20251119 value => betaToolSearchToolRegex20251119(value),
            BetaMcpToolset value => betaMcpToolset(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Tool"),
        };
    }

    public static implicit operator Tool(BetaTool value) => new(value);

    public static implicit operator Tool(BetaToolBash20241022 value) => new(value);

    public static implicit operator Tool(BetaToolBash20250124 value) => new(value);

    public static implicit operator Tool(BetaCodeExecutionTool20250522 value) => new(value);

    public static implicit operator Tool(BetaCodeExecutionTool20250825 value) => new(value);

    public static implicit operator Tool(BetaToolComputerUse20241022 value) => new(value);

    public static implicit operator Tool(BetaMemoryTool20250818 value) => new(value);

    public static implicit operator Tool(BetaToolComputerUse20250124 value) => new(value);

    public static implicit operator Tool(BetaToolTextEditor20241022 value) => new(value);

    public static implicit operator Tool(BetaToolComputerUse20251124 value) => new(value);

    public static implicit operator Tool(BetaToolTextEditor20250124 value) => new(value);

    public static implicit operator Tool(BetaToolTextEditor20250429 value) => new(value);

    public static implicit operator Tool(BetaToolTextEditor20250728 value) => new(value);

    public static implicit operator Tool(BetaWebSearchTool20250305 value) => new(value);

    public static implicit operator Tool(BetaWebFetchTool20250910 value) => new(value);

    public static implicit operator Tool(BetaToolSearchToolBm25_20251119 value) => new(value);

    public static implicit operator Tool(BetaToolSearchToolRegex20251119 value) => new(value);

    public static implicit operator Tool(BetaMcpToolset value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Tool");
        }
        this.Switch(
            (beta) => beta.Validate(),
            (betaToolBash20241022) => betaToolBash20241022.Validate(),
            (betaToolBash20250124) => betaToolBash20250124.Validate(),
            (betaCodeExecutionTool20250522) => betaCodeExecutionTool20250522.Validate(),
            (betaCodeExecutionTool20250825) => betaCodeExecutionTool20250825.Validate(),
            (betaToolComputerUse20241022) => betaToolComputerUse20241022.Validate(),
            (betaMemoryTool20250818) => betaMemoryTool20250818.Validate(),
            (betaToolComputerUse20250124) => betaToolComputerUse20250124.Validate(),
            (betaToolTextEditor20241022) => betaToolTextEditor20241022.Validate(),
            (betaToolComputerUse20251124) => betaToolComputerUse20251124.Validate(),
            (betaToolTextEditor20250124) => betaToolTextEditor20250124.Validate(),
            (betaToolTextEditor20250429) => betaToolTextEditor20250429.Validate(),
            (betaToolTextEditor20250728) => betaToolTextEditor20250728.Validate(),
            (betaWebSearchTool20250305) => betaWebSearchTool20250305.Validate(),
            (betaWebFetchTool20250910) => betaWebFetchTool20250910.Validate(),
            (betaToolSearchToolBm25_20251119) => betaToolSearchToolBm25_20251119.Validate(),
            (betaToolSearchToolRegex20251119) => betaToolSearchToolRegex20251119.Validate(),
            (betaMcpToolset) => betaMcpToolset.Validate()
        );
    }

    public virtual bool Equals(Tool? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaTool _ => 0,
            BetaToolBash20241022 _ => 1,
            BetaToolBash20250124 _ => 2,
            BetaCodeExecutionTool20250522 _ => 3,
            BetaCodeExecutionTool20250825 _ => 4,
            BetaToolComputerUse20241022 _ => 5,
            BetaMemoryTool20250818 _ => 6,
            BetaToolComputerUse20250124 _ => 7,
            BetaToolTextEditor20241022 _ => 8,
            BetaToolComputerUse20251124 _ => 9,
            BetaToolTextEditor20250124 _ => 10,
            BetaToolTextEditor20250429 _ => 11,
            BetaToolTextEditor20250728 _ => 12,
            BetaWebSearchTool20250305 _ => 13,
            BetaWebFetchTool20250910 _ => 14,
            BetaToolSearchToolBm25_20251119 _ => 15,
            BetaToolSearchToolRegex20251119 _ => 16,
            BetaMcpToolset _ => 17,
            _ => -1,
        };
    }
}

sealed class ToolConverter : JsonConverter<Tool>
{
    public override Tool? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaTool>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20241022>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20250124>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250522>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250825>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20241022>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20250124>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20241022>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20251124>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250124>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250429>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250728>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchTool20250305>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchTool20250910>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolBm25_20251119>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolRegex20251119>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaMcpToolset>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Tool value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
