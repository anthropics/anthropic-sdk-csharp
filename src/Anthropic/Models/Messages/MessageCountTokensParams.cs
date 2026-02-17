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

namespace Anthropic.Models.Messages;

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
    public required IReadOnlyList<MessageParam> Messages
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<MessageParam>>("messages");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<MessageParam>>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Model>>("model");
        }
        init { this._rawBodyData.Set("model", value); }
    }

    /// <summary>
    /// Configuration options for the model's output, such as the output format.
    /// </summary>
    public OutputConfig? OutputConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<OutputConfig>("output_config");
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
    /// The inference speed mode for this request. `"fast"` enables high output-tokens-per-second inference.
    /// </summary>
    public ApiEnum<string, MessageCountTokensParamsSpeed>? Speed
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, MessageCountTokensParamsSpeed>
            >("speed");
        }
        init { this._rawBodyData.Set("speed", value); }
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
    public ThinkingConfigParam? Thinking
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ThinkingConfigParam>("thinking");
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
    public ToolChoice? ToolChoice
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ToolChoice>("tool_choice");
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
    public IReadOnlyList<MessageCountTokensTool>? Tools
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<MessageCountTokensTool>>(
                "tools"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<MessageCountTokensTool>?>(
                "tools",
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
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/messages/count_tokens"
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
/// The inference speed mode for this request. `"fast"` enables high output-tokens-per-second inference.
/// </summary>
[JsonConverter(typeof(MessageCountTokensParamsSpeedConverter))]
public enum MessageCountTokensParamsSpeed
{
    Standard,
    Fast,
}

sealed class MessageCountTokensParamsSpeedConverter : JsonConverter<MessageCountTokensParamsSpeed>
{
    public override MessageCountTokensParamsSpeed Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => MessageCountTokensParamsSpeed.Standard,
            "fast" => MessageCountTokensParamsSpeed.Fast,
            _ => (MessageCountTokensParamsSpeed)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCountTokensParamsSpeed value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MessageCountTokensParamsSpeed.Standard => "standard",
                MessageCountTokensParamsSpeed.Fast => "fast",
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
        IReadOnlyList<TextBlockParam> value,
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
                "Data did not match any variant of MessageCountTokensParamsSystem"
            ),
        };
    }

    public static implicit operator MessageCountTokensParamsSystem(string value) => new(value);

    public static implicit operator MessageCountTokensParamsSystem(List<TextBlockParam> value) =>
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
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            IReadOnlyList<TextBlockParam> _ => 1,
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
        MessageCountTokensParamsSystem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
