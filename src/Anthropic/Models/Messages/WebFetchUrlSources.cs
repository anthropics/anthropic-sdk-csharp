using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// Which sources contribute to the set of URLs web fetch may fetch.
///
/// <para>Each key is a tagged variant: ``user_input`` is ``all`` or ``none``; the
/// two tool filters are ``all``, ``none``, ``only`` (only the named tools' results)
/// or ``except`` (every result but the named tools'). A named tool must be declared
/// in this request's ``tools[]``.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebFetchUrlSources, WebFetchUrlSourcesFromRaw>))]
public sealed record class WebFetchUrlSources : JsonModel
{
    /// <summary>
    /// Which client tools' results contribute fetchable URLs: "all", "none", or
    /// an only or except list of client tool names from tools[].
    /// </summary>
    public ClientToolResults? ClientToolResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ClientToolResults>("client_tool_results");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("client_tool_results", value);
        }
    }

    /// <summary>
    /// Which server tools' results contribute fetchable URLs: "all", "none", or
    /// an only or except list of server tool names from tools[]; only web_search
    /// and web_fetch results ever contribute.
    /// </summary>
    public ServerToolResults? ServerToolResults
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ServerToolResults>("server_tool_results");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("server_tool_results", value);
        }
    }

    /// <summary>
    /// Whether URLs in user messages are fetchable: "all" or "none".
    /// </summary>
    public UserInput? UserInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserInput>("user_input");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_input", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ClientToolResults?.Validate();
        this.ServerToolResults?.Validate();
        this.UserInput?.Validate();
    }

    public WebFetchUrlSources() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebFetchUrlSources(WebFetchUrlSources webFetchUrlSources)
        : base(webFetchUrlSources) { }
#pragma warning restore CS8618

    public WebFetchUrlSources(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebFetchUrlSources(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebFetchUrlSourcesFromRaw.FromRawUnchecked"/>
    public static WebFetchUrlSources FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebFetchUrlSourcesFromRaw : IFromRawJson<WebFetchUrlSources>
{
    /// <inheritdoc/>
    public WebFetchUrlSources FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebFetchUrlSources.FromRawUnchecked(rawData);
}

/// <summary>
/// Which client tools' results contribute fetchable URLs: "all", "none", or an only
/// or except list of client tool names from tools[].
/// </summary>
[JsonConverter(typeof(ClientToolResultsConverter))]
public record class ClientToolResults : ModelBase
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
            return this.Value switch
            {
                WebFetchUrlSourceAll x => x.Type,
                WebFetchUrlSourceNone x => x.Type,
                WebFetchUrlSourceOnly x => x.Type,
                WebFetchUrlSourceExcept x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public ClientToolResults(WebFetchUrlSourceAll value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ClientToolResults(WebFetchUrlSourceNone value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ClientToolResults(WebFetchUrlSourceOnly value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ClientToolResults(WebFetchUrlSourceExcept value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ClientToolResults(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchUrlSourceAll"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchUrlSourceAll(out var value)) {
    ///     // `value` is of type `WebFetchUrlSourceAll`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchUrlSourceAll([NotNullWhen(true)] out WebFetchUrlSourceAll? value)
    {
        value = this.Value as WebFetchUrlSourceAll;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchUrlSourceNone"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchUrlSourceNone(out var value)) {
    ///     // `value` is of type `WebFetchUrlSourceNone`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchUrlSourceNone([NotNullWhen(true)] out WebFetchUrlSourceNone? value)
    {
        value = this.Value as WebFetchUrlSourceNone;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchUrlSourceOnly"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchUrlSourceOnly(out var value)) {
    ///     // `value` is of type `WebFetchUrlSourceOnly`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchUrlSourceOnly([NotNullWhen(true)] out WebFetchUrlSourceOnly? value)
    {
        value = this.Value as WebFetchUrlSourceOnly;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchUrlSourceExcept"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchUrlSourceExcept(out var value)) {
    ///     // `value` is of type `WebFetchUrlSourceExcept`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchUrlSourceExcept(
        [NotNullWhen(true)] out WebFetchUrlSourceExcept? value
    )
    {
        value = this.Value as WebFetchUrlSourceExcept;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (WebFetchUrlSourceAll value) =&gt; {...},
    ///     (WebFetchUrlSourceNone value) =&gt; {...},
    ///     (WebFetchUrlSourceOnly value) =&gt; {...},
    ///     (WebFetchUrlSourceExcept value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<WebFetchUrlSourceAll> webFetchUrlSourceAll,
        System::Action<WebFetchUrlSourceNone> webFetchUrlSourceNone,
        System::Action<WebFetchUrlSourceOnly> webFetchUrlSourceOnly,
        System::Action<WebFetchUrlSourceExcept> webFetchUrlSourceExcept
    )
    {
        switch (this.Value)
        {
            case WebFetchUrlSourceAll value:
                webFetchUrlSourceAll(value);
                break;
            case WebFetchUrlSourceNone value:
                webFetchUrlSourceNone(value);
                break;
            case WebFetchUrlSourceOnly value:
                webFetchUrlSourceOnly(value);
                break;
            case WebFetchUrlSourceExcept value:
                webFetchUrlSourceExcept(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ClientToolResults"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (WebFetchUrlSourceAll value) =&gt; {...},
    ///     (WebFetchUrlSourceNone value) =&gt; {...},
    ///     (WebFetchUrlSourceOnly value) =&gt; {...},
    ///     (WebFetchUrlSourceExcept value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<WebFetchUrlSourceAll, T> webFetchUrlSourceAll,
        System::Func<WebFetchUrlSourceNone, T> webFetchUrlSourceNone,
        System::Func<WebFetchUrlSourceOnly, T> webFetchUrlSourceOnly,
        System::Func<WebFetchUrlSourceExcept, T> webFetchUrlSourceExcept
    )
    {
        return this.Value switch
        {
            WebFetchUrlSourceAll value => webFetchUrlSourceAll(value),
            WebFetchUrlSourceNone value => webFetchUrlSourceNone(value),
            WebFetchUrlSourceOnly value => webFetchUrlSourceOnly(value),
            WebFetchUrlSourceExcept value => webFetchUrlSourceExcept(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ClientToolResults"
            ),
        };
    }

    public static implicit operator ClientToolResults(WebFetchUrlSourceAll value) => new(value);

    public static implicit operator ClientToolResults(WebFetchUrlSourceNone value) => new(value);

    public static implicit operator ClientToolResults(WebFetchUrlSourceOnly value) => new(value);

    public static implicit operator ClientToolResults(WebFetchUrlSourceExcept value) => new(value);

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
                "Data did not match any variant of ClientToolResults"
            );
        }
        this.Switch(
            (webFetchUrlSourceAll) => webFetchUrlSourceAll.Validate(),
            (webFetchUrlSourceNone) => webFetchUrlSourceNone.Validate(),
            (webFetchUrlSourceOnly) => webFetchUrlSourceOnly.Validate(),
            (webFetchUrlSourceExcept) => webFetchUrlSourceExcept.Validate()
        );
    }

    public virtual bool Equals(ClientToolResults? other) =>
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
            WebFetchUrlSourceAll _ => 0,
            WebFetchUrlSourceNone _ => 1,
            WebFetchUrlSourceOnly _ => 2,
            WebFetchUrlSourceExcept _ => 3,
            _ => -1,
        };
    }
}

sealed class ClientToolResultsConverter : JsonConverter<ClientToolResults>
{
    public override ClientToolResults? Read(
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
            case "all":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceAll>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "none":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceNone>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "only":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceOnly>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "except":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceExcept>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ClientToolResults(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClientToolResults value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Which server tools' results contribute fetchable URLs: "all", "none", or an only
/// or except list of server tool names from tools[]; only web_search and web_fetch
/// results ever contribute.
/// </summary>
[JsonConverter(typeof(ServerToolResultsConverter))]
public record class ServerToolResults : ModelBase
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
            return this.Value switch
            {
                WebFetchUrlSourceAll x => x.Type,
                WebFetchUrlSourceNone x => x.Type,
                WebFetchUrlSourceOnly x => x.Type,
                WebFetchUrlSourceExcept x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public ServerToolResults(WebFetchUrlSourceAll value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ServerToolResults(WebFetchUrlSourceNone value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ServerToolResults(WebFetchUrlSourceOnly value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ServerToolResults(WebFetchUrlSourceExcept value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ServerToolResults(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchUrlSourceAll"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchUrlSourceAll(out var value)) {
    ///     // `value` is of type `WebFetchUrlSourceAll`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchUrlSourceAll([NotNullWhen(true)] out WebFetchUrlSourceAll? value)
    {
        value = this.Value as WebFetchUrlSourceAll;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchUrlSourceNone"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchUrlSourceNone(out var value)) {
    ///     // `value` is of type `WebFetchUrlSourceNone`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchUrlSourceNone([NotNullWhen(true)] out WebFetchUrlSourceNone? value)
    {
        value = this.Value as WebFetchUrlSourceNone;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchUrlSourceOnly"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchUrlSourceOnly(out var value)) {
    ///     // `value` is of type `WebFetchUrlSourceOnly`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchUrlSourceOnly([NotNullWhen(true)] out WebFetchUrlSourceOnly? value)
    {
        value = this.Value as WebFetchUrlSourceOnly;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchUrlSourceExcept"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchUrlSourceExcept(out var value)) {
    ///     // `value` is of type `WebFetchUrlSourceExcept`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchUrlSourceExcept(
        [NotNullWhen(true)] out WebFetchUrlSourceExcept? value
    )
    {
        value = this.Value as WebFetchUrlSourceExcept;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (WebFetchUrlSourceAll value) =&gt; {...},
    ///     (WebFetchUrlSourceNone value) =&gt; {...},
    ///     (WebFetchUrlSourceOnly value) =&gt; {...},
    ///     (WebFetchUrlSourceExcept value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<WebFetchUrlSourceAll> webFetchUrlSourceAll,
        System::Action<WebFetchUrlSourceNone> webFetchUrlSourceNone,
        System::Action<WebFetchUrlSourceOnly> webFetchUrlSourceOnly,
        System::Action<WebFetchUrlSourceExcept> webFetchUrlSourceExcept
    )
    {
        switch (this.Value)
        {
            case WebFetchUrlSourceAll value:
                webFetchUrlSourceAll(value);
                break;
            case WebFetchUrlSourceNone value:
                webFetchUrlSourceNone(value);
                break;
            case WebFetchUrlSourceOnly value:
                webFetchUrlSourceOnly(value);
                break;
            case WebFetchUrlSourceExcept value:
                webFetchUrlSourceExcept(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ServerToolResults"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (WebFetchUrlSourceAll value) =&gt; {...},
    ///     (WebFetchUrlSourceNone value) =&gt; {...},
    ///     (WebFetchUrlSourceOnly value) =&gt; {...},
    ///     (WebFetchUrlSourceExcept value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<WebFetchUrlSourceAll, T> webFetchUrlSourceAll,
        System::Func<WebFetchUrlSourceNone, T> webFetchUrlSourceNone,
        System::Func<WebFetchUrlSourceOnly, T> webFetchUrlSourceOnly,
        System::Func<WebFetchUrlSourceExcept, T> webFetchUrlSourceExcept
    )
    {
        return this.Value switch
        {
            WebFetchUrlSourceAll value => webFetchUrlSourceAll(value),
            WebFetchUrlSourceNone value => webFetchUrlSourceNone(value),
            WebFetchUrlSourceOnly value => webFetchUrlSourceOnly(value),
            WebFetchUrlSourceExcept value => webFetchUrlSourceExcept(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ServerToolResults"
            ),
        };
    }

    public static implicit operator ServerToolResults(WebFetchUrlSourceAll value) => new(value);

    public static implicit operator ServerToolResults(WebFetchUrlSourceNone value) => new(value);

    public static implicit operator ServerToolResults(WebFetchUrlSourceOnly value) => new(value);

    public static implicit operator ServerToolResults(WebFetchUrlSourceExcept value) => new(value);

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
                "Data did not match any variant of ServerToolResults"
            );
        }
        this.Switch(
            (webFetchUrlSourceAll) => webFetchUrlSourceAll.Validate(),
            (webFetchUrlSourceNone) => webFetchUrlSourceNone.Validate(),
            (webFetchUrlSourceOnly) => webFetchUrlSourceOnly.Validate(),
            (webFetchUrlSourceExcept) => webFetchUrlSourceExcept.Validate()
        );
    }

    public virtual bool Equals(ServerToolResults? other) =>
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
            WebFetchUrlSourceAll _ => 0,
            WebFetchUrlSourceNone _ => 1,
            WebFetchUrlSourceOnly _ => 2,
            WebFetchUrlSourceExcept _ => 3,
            _ => -1,
        };
    }
}

sealed class ServerToolResultsConverter : JsonConverter<ServerToolResults>
{
    public override ServerToolResults? Read(
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
            case "all":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceAll>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "none":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceNone>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "only":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceOnly>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "except":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceExcept>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ServerToolResults(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ServerToolResults value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Whether URLs in user messages are fetchable: "all" or "none".
/// </summary>
[JsonConverter(typeof(UserInputConverter))]
public record class UserInput : ModelBase
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
            return this.Value switch
            {
                WebFetchUrlSourceAll x => x.Type,
                WebFetchUrlSourceNone x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public UserInput(WebFetchUrlSourceAll value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UserInput(WebFetchUrlSourceNone value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UserInput(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchUrlSourceAll"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchUrlSourceAll(out var value)) {
    ///     // `value` is of type `WebFetchUrlSourceAll`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchUrlSourceAll([NotNullWhen(true)] out WebFetchUrlSourceAll? value)
    {
        value = this.Value as WebFetchUrlSourceAll;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchUrlSourceNone"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchUrlSourceNone(out var value)) {
    ///     // `value` is of type `WebFetchUrlSourceNone`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchUrlSourceNone([NotNullWhen(true)] out WebFetchUrlSourceNone? value)
    {
        value = this.Value as WebFetchUrlSourceNone;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (WebFetchUrlSourceAll value) =&gt; {...},
    ///     (WebFetchUrlSourceNone value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<WebFetchUrlSourceAll> webFetchUrlSourceAll,
        System::Action<WebFetchUrlSourceNone> webFetchUrlSourceNone
    )
    {
        switch (this.Value)
        {
            case WebFetchUrlSourceAll value:
                webFetchUrlSourceAll(value);
                break;
            case WebFetchUrlSourceNone value:
                webFetchUrlSourceNone(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of UserInput"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (WebFetchUrlSourceAll value) =&gt; {...},
    ///     (WebFetchUrlSourceNone value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<WebFetchUrlSourceAll, T> webFetchUrlSourceAll,
        System::Func<WebFetchUrlSourceNone, T> webFetchUrlSourceNone
    )
    {
        return this.Value switch
        {
            WebFetchUrlSourceAll value => webFetchUrlSourceAll(value),
            WebFetchUrlSourceNone value => webFetchUrlSourceNone(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of UserInput"
            ),
        };
    }

    public static implicit operator UserInput(WebFetchUrlSourceAll value) => new(value);

    public static implicit operator UserInput(WebFetchUrlSourceNone value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of UserInput");
        }
        this.Switch(
            (webFetchUrlSourceAll) => webFetchUrlSourceAll.Validate(),
            (webFetchUrlSourceNone) => webFetchUrlSourceNone.Validate()
        );
    }

    public virtual bool Equals(UserInput? other) =>
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
            WebFetchUrlSourceAll _ => 0,
            WebFetchUrlSourceNone _ => 1,
            _ => -1,
        };
    }
}

sealed class UserInputConverter : JsonConverter<UserInput>
{
    public override UserInput? Read(
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
            case "all":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceAll>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "none":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFetchUrlSourceNone>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new UserInput(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserInput value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
