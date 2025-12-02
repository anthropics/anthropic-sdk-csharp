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
/// </summary>
public sealed record class MessageCountTokensParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
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
            if (!this._rawBodyData.TryGetValue("messages", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'messages' cannot be null",
                    new System::ArgumentOutOfRangeException("messages", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<MessageParam>>(
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
            this._rawBodyData["messages"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._rawBodyData.TryGetValue("model", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'model' cannot be null",
                    new System::ArgumentOutOfRangeException("model", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Model>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'model' cannot be null",
                    new System::ArgumentNullException("model")
                );
        }
        init
        {
            this._rawBodyData["model"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// System prompt.
    ///
    /// <para>A system prompt is a way of providing context and instructions to Claude,
    /// such as specifying a particular goal or role. See our [guide to system prompts](https://docs.claude.com/en/docs/system-prompts).</para>
    /// </summary>
    public System1? System
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("system", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System1?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["system"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this._rawBodyData.TryGetValue("thinking", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ThinkingConfigParam?>(
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

            this._rawBodyData["thinking"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this._rawBodyData.TryGetValue("tool_choice", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ToolChoice?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["tool_choice"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this._rawBodyData.TryGetValue("tools", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<MessageCountTokensTool>?>(
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

            this._rawBodyData["tools"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public MessageCountTokensParams() { }

    public MessageCountTokensParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCountTokensParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/messages/count_tokens"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// System prompt.
///
/// <para>A system prompt is a way of providing context and instructions to Claude,
/// such as specifying a particular goal or role. See our [guide to system prompts](https://docs.claude.com/en/docs/system-prompts).</para>
/// </summary>
[JsonConverter(typeof(System1Converter))]
public record class System1
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public System1(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public System1(IReadOnlyList<TextBlockParam> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public System1(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickTextBlockParams([NotNullWhen(true)] out IReadOnlyList<TextBlockParam>? value)
    {
        value = this.Value as IReadOnlyList<TextBlockParam>;
        return value != null;
    }

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
            case List<TextBlockParam> value:
                textBlockParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of System1"
                );
        }
    }

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
                "Data did not match any variant of System1"
            ),
        };
    }

    public static implicit operator System1(string value) => new(value);

    public static implicit operator System1(List<TextBlockParam> value) =>
        new((IReadOnlyList<TextBlockParam>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of System1");
        }
    }

    public virtual bool Equals(System1? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class System1Converter : JsonConverter<System1>
{
    public override System1? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<TextBlockParam>>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, System1 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
