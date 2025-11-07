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

namespace Anthropic.Client.Models.Beta.Messages;

/// <summary>
/// Count the number of tokens in a Message.
///
/// The Token Count API can be used to count the number of tokens in a Message, including
/// tools, images, and documents, without creating it.
///
/// Learn more about token counting in our [user guide](/en/docs/build-with-claude/token-counting)
/// </summary>
public sealed record class MessageCountTokensParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
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
            if (!this._bodyProperties.TryGetValue("messages", out JsonElement element))
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
            this._bodyProperties["messages"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("model", out JsonElement element))
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
            this._bodyProperties["model"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("context_management", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaContextManagementConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["context_management"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("mcp_servers", out JsonElement element))
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

            this._bodyProperties["mcp_servers"] = JsonSerializer.SerializeToElement(
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
    public System1? System
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("system", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System1?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["system"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("thinking", out JsonElement element))
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

            this._bodyProperties["thinking"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("tool_choice", out JsonElement element))
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

            this._bodyProperties["tool_choice"] = JsonSerializer.SerializeToElement(
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
    public List<Tool>? Tools
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("tools", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Tool>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["tools"] = JsonSerializer.SerializeToElement(
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

    public MessageCountTokensParams() { }

    public MessageCountTokensParams(
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
    MessageCountTokensParams(
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

    public static MessageCountTokensParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/messages/count_tokens?beta=true"
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

/// <summary>
/// System prompt.
///
/// A system prompt is a way of providing context and instructions to Claude, such
/// as specifying a particular goal or role. See our [guide to system prompts](https://docs.claude.com/en/docs/system-prompts).
/// </summary>
[JsonConverter(typeof(System1Converter))]
public record class System1
{
    public object Value { get; private init; }

    public System1(string value)
    {
        Value = value;
    }

    public System1(IReadOnlyList<BetaTextBlockParam> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    System1(UnknownVariant value)
    {
        Value = value;
    }

    public static System1 CreateUnknownVariant(JsonElement value)
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
                    "Data did not match any variant of System1"
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
                "Data did not match any variant of System1"
            ),
        };
    }

    public static implicit operator System1(string value) => new(value);

    public static implicit operator System1(List<BetaTextBlockParam> value) =>
        new((IReadOnlyList<BetaTextBlockParam>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of System1");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class System1Converter : JsonConverter<System1>
{
    public override System1? Read(
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
                return new System1(deserialized);
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
                return new System1(deserialized);
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

    public override void Write(Utf8JsonWriter writer, System1 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ToolConverter))]
public record class Tool
{
    public object Value { get; private init; }

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
                betaToolTextEditor20250124: (x) => x.CacheControl,
                betaToolTextEditor20250429: (x) => x.CacheControl,
                betaToolTextEditor20250728: (x) => x.CacheControl,
                betaWebSearchTool20250305: (x) => x.CacheControl,
                betaWebFetchTool20250910: (x) => x.CacheControl
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
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (_) => null,
                betaWebFetchTool20250910: (_) => null
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
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (_) => null,
                betaWebFetchTool20250910: (_) => null
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
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (_) => null,
                betaWebFetchTool20250910: (_) => null
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
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (x) => x.MaxUses,
                betaWebFetchTool20250910: (x) => x.MaxUses
            );
        }
    }

    public Tool(BetaTool value)
    {
        Value = value;
    }

    public Tool(BetaToolBash20241022 value)
    {
        Value = value;
    }

    public Tool(BetaToolBash20250124 value)
    {
        Value = value;
    }

    public Tool(BetaCodeExecutionTool20250522 value)
    {
        Value = value;
    }

    public Tool(BetaCodeExecutionTool20250825 value)
    {
        Value = value;
    }

    public Tool(BetaToolComputerUse20241022 value)
    {
        Value = value;
    }

    public Tool(BetaMemoryTool20250818 value)
    {
        Value = value;
    }

    public Tool(BetaToolComputerUse20250124 value)
    {
        Value = value;
    }

    public Tool(BetaToolTextEditor20241022 value)
    {
        Value = value;
    }

    public Tool(BetaToolTextEditor20250124 value)
    {
        Value = value;
    }

    public Tool(BetaToolTextEditor20250429 value)
    {
        Value = value;
    }

    public Tool(BetaToolTextEditor20250728 value)
    {
        Value = value;
    }

    public Tool(BetaWebSearchTool20250305 value)
    {
        Value = value;
    }

    public Tool(BetaWebFetchTool20250910 value)
    {
        Value = value;
    }

    Tool(UnknownVariant value)
    {
        Value = value;
    }

    public static Tool CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBeta([NotNullWhen(true)] out BetaTool? value)
    {
        value = this.Value as BetaTool;
        return value != null;
    }

    public bool TryPickBetaToolBash20241022([NotNullWhen(true)] out BetaToolBash20241022? value)
    {
        value = this.Value as BetaToolBash20241022;
        return value != null;
    }

    public bool TryPickBetaToolBash20250124([NotNullWhen(true)] out BetaToolBash20250124? value)
    {
        value = this.Value as BetaToolBash20250124;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionTool20250522(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250522? value
    )
    {
        value = this.Value as BetaCodeExecutionTool20250522;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionTool20250825(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250825? value
    )
    {
        value = this.Value as BetaCodeExecutionTool20250825;
        return value != null;
    }

    public bool TryPickBetaToolComputerUse20241022(
        [NotNullWhen(true)] out BetaToolComputerUse20241022? value
    )
    {
        value = this.Value as BetaToolComputerUse20241022;
        return value != null;
    }

    public bool TryPickBetaMemoryTool20250818([NotNullWhen(true)] out BetaMemoryTool20250818? value)
    {
        value = this.Value as BetaMemoryTool20250818;
        return value != null;
    }

    public bool TryPickBetaToolComputerUse20250124(
        [NotNullWhen(true)] out BetaToolComputerUse20250124? value
    )
    {
        value = this.Value as BetaToolComputerUse20250124;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20241022(
        [NotNullWhen(true)] out BetaToolTextEditor20241022? value
    )
    {
        value = this.Value as BetaToolTextEditor20241022;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250124(
        [NotNullWhen(true)] out BetaToolTextEditor20250124? value
    )
    {
        value = this.Value as BetaToolTextEditor20250124;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250429(
        [NotNullWhen(true)] out BetaToolTextEditor20250429? value
    )
    {
        value = this.Value as BetaToolTextEditor20250429;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250728(
        [NotNullWhen(true)] out BetaToolTextEditor20250728? value
    )
    {
        value = this.Value as BetaToolTextEditor20250728;
        return value != null;
    }

    public bool TryPickBetaWebSearchTool20250305(
        [NotNullWhen(true)] out BetaWebSearchTool20250305? value
    )
    {
        value = this.Value as BetaWebSearchTool20250305;
        return value != null;
    }

    public bool TryPickBetaWebFetchTool20250910(
        [NotNullWhen(true)] out BetaWebFetchTool20250910? value
    )
    {
        value = this.Value as BetaWebFetchTool20250910;
        return value != null;
    }

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
        System::Action<BetaToolTextEditor20250124> betaToolTextEditor20250124,
        System::Action<BetaToolTextEditor20250429> betaToolTextEditor20250429,
        System::Action<BetaToolTextEditor20250728> betaToolTextEditor20250728,
        System::Action<BetaWebSearchTool20250305> betaWebSearchTool20250305,
        System::Action<BetaWebFetchTool20250910> betaWebFetchTool20250910
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
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Tool");
        }
    }

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
        System::Func<BetaToolTextEditor20250124, T> betaToolTextEditor20250124,
        System::Func<BetaToolTextEditor20250429, T> betaToolTextEditor20250429,
        System::Func<BetaToolTextEditor20250728, T> betaToolTextEditor20250728,
        System::Func<BetaWebSearchTool20250305, T> betaWebSearchTool20250305,
        System::Func<BetaWebFetchTool20250910, T> betaWebFetchTool20250910
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
            BetaToolTextEditor20250124 value => betaToolTextEditor20250124(value),
            BetaToolTextEditor20250429 value => betaToolTextEditor20250429(value),
            BetaToolTextEditor20250728 value => betaToolTextEditor20250728(value),
            BetaWebSearchTool20250305 value => betaWebSearchTool20250305(value),
            BetaWebFetchTool20250910 value => betaWebFetchTool20250910(value),
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

    public static implicit operator Tool(BetaToolTextEditor20250124 value) => new(value);

    public static implicit operator Tool(BetaToolTextEditor20250429 value) => new(value);

    public static implicit operator Tool(BetaToolTextEditor20250728 value) => new(value);

    public static implicit operator Tool(BetaWebSearchTool20250305 value) => new(value);

    public static implicit operator Tool(BetaWebFetchTool20250910 value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Tool");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ToolConverter : JsonConverter<Tool>
{
    public override Tool? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaTool>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'BetaTool'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolBash20241022'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolBash20250124'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250522>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaCodeExecutionTool20250522'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250825>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaCodeExecutionTool20250825'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolComputerUse20241022'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaMemoryTool20250818'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolComputerUse20250124'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolTextEditor20241022'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolTextEditor20250124'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250429>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolTextEditor20250429'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250728>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolTextEditor20250728'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchTool20250305>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebSearchTool20250305'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchTool20250910>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Tool(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebFetchTool20250910'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Tool value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
