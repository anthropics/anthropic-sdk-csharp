using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<WebSearchToolResultBlock, WebSearchToolResultBlockFromRaw>)
)]
public sealed record class WebSearchToolResultBlock : JsonModel
{
    /// <summary>
    /// Tool invocation directly from the model.
    /// </summary>
    public required WebSearchToolResultBlockCaller Caller
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WebSearchToolResultBlockCaller>("caller");
        }
        init { this._rawData.Set("caller", value); }
    }

    public required WebSearchToolResultBlockContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WebSearchToolResultBlockContent>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public required string ToolUseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_use_id");
        }
        init { this._rawData.Set("tool_use_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Caller.Validate();
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("web_search_tool_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WebSearchToolResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("web_search_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebSearchToolResultBlock(WebSearchToolResultBlock webSearchToolResultBlock)
        : base(webSearchToolResultBlock) { }
#pragma warning restore CS8618

    public WebSearchToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_search_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebSearchToolResultBlockFromRaw.FromRawUnchecked"/>
    public static WebSearchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebSearchToolResultBlockFromRaw : IFromRawJson<WebSearchToolResultBlock>
{
    /// <inheritdoc/>
    public WebSearchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebSearchToolResultBlock.FromRawUnchecked(rawData);
}

/// <summary>
/// Tool invocation directly from the model.
/// </summary>
[JsonConverter(typeof(WebSearchToolResultBlockCallerConverter))]
public record class WebSearchToolResultBlockCaller : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return Match(
                direct: (x) => x.Type,
                serverTool: (x) => x.Type,
                serverToolCaller20260120: (x) => x.Type
            );
        }
    }

    public string? ToolID
    {
        get
        {
            return Match<string?>(
                direct: (_) => null,
                serverTool: (x) => x.ToolID,
                serverToolCaller20260120: (x) => x.ToolID
            );
        }
    }

    public WebSearchToolResultBlockCaller(DirectCaller value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebSearchToolResultBlockCaller(ServerToolCaller value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public WebSearchToolResultBlockCaller(
        ServerToolCaller20260120 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public WebSearchToolResultBlockCaller(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DirectCaller"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDirect(out var value)) {
    ///     // `value` is of type `DirectCaller`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDirect([NotNullWhen(true)] out DirectCaller? value)
    {
        value = this.Value as DirectCaller;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ServerToolCaller"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServerTool(out var value)) {
    ///     // `value` is of type `ServerToolCaller`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServerTool([NotNullWhen(true)] out ServerToolCaller? value)
    {
        value = this.Value as ServerToolCaller;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ServerToolCaller20260120"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServerToolCaller20260120(out var value)) {
    ///     // `value` is of type `ServerToolCaller20260120`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServerToolCaller20260120(
        [NotNullWhen(true)] out ServerToolCaller20260120? value
    )
    {
        value = this.Value as ServerToolCaller20260120;
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
    ///     (DirectCaller value) => {...},
    ///     (ServerToolCaller value) => {...},
    ///     (ServerToolCaller20260120 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<DirectCaller> direct,
        System::Action<ServerToolCaller> serverTool,
        System::Action<ServerToolCaller20260120> serverToolCaller20260120
    )
    {
        switch (this.Value)
        {
            case DirectCaller value:
                direct(value);
                break;
            case ServerToolCaller value:
                serverTool(value);
                break;
            case ServerToolCaller20260120 value:
                serverToolCaller20260120(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of WebSearchToolResultBlockCaller"
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
    ///     (DirectCaller value) => {...},
    ///     (ServerToolCaller value) => {...},
    ///     (ServerToolCaller20260120 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<DirectCaller, T> direct,
        System::Func<ServerToolCaller, T> serverTool,
        System::Func<ServerToolCaller20260120, T> serverToolCaller20260120
    )
    {
        return this.Value switch
        {
            DirectCaller value => direct(value),
            ServerToolCaller value => serverTool(value),
            ServerToolCaller20260120 value => serverToolCaller20260120(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockCaller"
            ),
        };
    }

    public static implicit operator WebSearchToolResultBlockCaller(DirectCaller value) =>
        new(value);

    public static implicit operator WebSearchToolResultBlockCaller(ServerToolCaller value) =>
        new(value);

    public static implicit operator WebSearchToolResultBlockCaller(
        ServerToolCaller20260120 value
    ) => new(value);

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
                "Data did not match any variant of WebSearchToolResultBlockCaller"
            );
        }
        this.Switch(
            (direct) => direct.Validate(),
            (serverTool) => serverTool.Validate(),
            (serverToolCaller20260120) => serverToolCaller20260120.Validate()
        );
    }

    public virtual bool Equals(WebSearchToolResultBlockCaller? other) =>
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
            DirectCaller _ => 0,
            ServerToolCaller _ => 1,
            ServerToolCaller20260120 _ => 2,
            _ => -1,
        };
    }
}

sealed class WebSearchToolResultBlockCallerConverter : JsonConverter<WebSearchToolResultBlockCaller>
{
    public override WebSearchToolResultBlockCaller? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "direct":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DirectCaller>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "code_execution_20250825":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ServerToolCaller>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "code_execution_20260120":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ServerToolCaller20260120>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new WebSearchToolResultBlockCaller(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebSearchToolResultBlockCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
