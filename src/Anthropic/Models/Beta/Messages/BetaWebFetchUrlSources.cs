using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Which sources contribute to the set of URLs web fetch may fetch.
///
/// <para>Each key is a tagged variant: ``user_input`` is ``all`` or ``none``; the
/// two tool filters are ``all``, ``none``, ``only`` (only the named tools' results)
/// or ``except`` (every result but the named tools'). A named tool must be declared
/// in this request's ``tools[]``.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaWebFetchUrlSources, BetaWebFetchUrlSourcesFromRaw>))]
public sealed record class BetaWebFetchUrlSources : JsonModel
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

    public BetaWebFetchUrlSources() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebFetchUrlSources(BetaWebFetchUrlSources betaWebFetchUrlSources)
        : base(betaWebFetchUrlSources) { }
#pragma warning restore CS8618

    public BetaWebFetchUrlSources(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchUrlSources(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchUrlSourcesFromRaw.FromRawUnchecked"/>
    public static BetaWebFetchUrlSources FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebFetchUrlSourcesFromRaw : IFromRawJson<BetaWebFetchUrlSources>
{
    /// <inheritdoc/>
    public BetaWebFetchUrlSources FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchUrlSources.FromRawUnchecked(rawData);
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
                BetaWebFetchUrlSourceAll x => x.Type,
                BetaWebFetchUrlSourceNone x => x.Type,
                BetaWebFetchUrlSourceOnly x => x.Type,
                BetaWebFetchUrlSourceExcept x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public ClientToolResults(BetaWebFetchUrlSourceAll value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ClientToolResults(BetaWebFetchUrlSourceNone value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ClientToolResults(BetaWebFetchUrlSourceOnly value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ClientToolResults(BetaWebFetchUrlSourceExcept value, JsonElement? element = null)
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
    /// type <see cref="BetaWebFetchUrlSourceAll"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchUrlSourceAll(out var value)) {
    ///     // `value` is of type `BetaWebFetchUrlSourceAll`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchUrlSourceAll(
        [NotNullWhen(true)] out BetaWebFetchUrlSourceAll? value
    )
    {
        value = this.Value as BetaWebFetchUrlSourceAll;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchUrlSourceNone"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchUrlSourceNone(out var value)) {
    ///     // `value` is of type `BetaWebFetchUrlSourceNone`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchUrlSourceNone(
        [NotNullWhen(true)] out BetaWebFetchUrlSourceNone? value
    )
    {
        value = this.Value as BetaWebFetchUrlSourceNone;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchUrlSourceOnly"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchUrlSourceOnly(out var value)) {
    ///     // `value` is of type `BetaWebFetchUrlSourceOnly`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchUrlSourceOnly(
        [NotNullWhen(true)] out BetaWebFetchUrlSourceOnly? value
    )
    {
        value = this.Value as BetaWebFetchUrlSourceOnly;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchUrlSourceExcept"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchUrlSourceExcept(out var value)) {
    ///     // `value` is of type `BetaWebFetchUrlSourceExcept`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchUrlSourceExcept(
        [NotNullWhen(true)] out BetaWebFetchUrlSourceExcept? value
    )
    {
        value = this.Value as BetaWebFetchUrlSourceExcept;
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
    ///     (BetaWebFetchUrlSourceAll value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceNone value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceOnly value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceExcept value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaWebFetchUrlSourceAll> betaWebFetchUrlSourceAll,
        System::Action<BetaWebFetchUrlSourceNone> betaWebFetchUrlSourceNone,
        System::Action<BetaWebFetchUrlSourceOnly> betaWebFetchUrlSourceOnly,
        System::Action<BetaWebFetchUrlSourceExcept> betaWebFetchUrlSourceExcept
    )
    {
        switch (this.Value)
        {
            case BetaWebFetchUrlSourceAll value:
                betaWebFetchUrlSourceAll(value);
                break;
            case BetaWebFetchUrlSourceNone value:
                betaWebFetchUrlSourceNone(value);
                break;
            case BetaWebFetchUrlSourceOnly value:
                betaWebFetchUrlSourceOnly(value);
                break;
            case BetaWebFetchUrlSourceExcept value:
                betaWebFetchUrlSourceExcept(value);
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
    ///     (BetaWebFetchUrlSourceAll value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceNone value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceOnly value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceExcept value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaWebFetchUrlSourceAll, T> betaWebFetchUrlSourceAll,
        System::Func<BetaWebFetchUrlSourceNone, T> betaWebFetchUrlSourceNone,
        System::Func<BetaWebFetchUrlSourceOnly, T> betaWebFetchUrlSourceOnly,
        System::Func<BetaWebFetchUrlSourceExcept, T> betaWebFetchUrlSourceExcept
    )
    {
        return this.Value switch
        {
            BetaWebFetchUrlSourceAll value => betaWebFetchUrlSourceAll(value),
            BetaWebFetchUrlSourceNone value => betaWebFetchUrlSourceNone(value),
            BetaWebFetchUrlSourceOnly value => betaWebFetchUrlSourceOnly(value),
            BetaWebFetchUrlSourceExcept value => betaWebFetchUrlSourceExcept(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ClientToolResults"
            ),
        };
    }

    public static implicit operator ClientToolResults(BetaWebFetchUrlSourceAll value) => new(value);

    public static implicit operator ClientToolResults(BetaWebFetchUrlSourceNone value) =>
        new(value);

    public static implicit operator ClientToolResults(BetaWebFetchUrlSourceOnly value) =>
        new(value);

    public static implicit operator ClientToolResults(BetaWebFetchUrlSourceExcept value) =>
        new(value);

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
            (betaWebFetchUrlSourceAll) => betaWebFetchUrlSourceAll.Validate(),
            (betaWebFetchUrlSourceNone) => betaWebFetchUrlSourceNone.Validate(),
            (betaWebFetchUrlSourceOnly) => betaWebFetchUrlSourceOnly.Validate(),
            (betaWebFetchUrlSourceExcept) => betaWebFetchUrlSourceExcept.Validate()
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
            BetaWebFetchUrlSourceAll _ => 0,
            BetaWebFetchUrlSourceNone _ => 1,
            BetaWebFetchUrlSourceOnly _ => 2,
            BetaWebFetchUrlSourceExcept _ => 3,
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceAll>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceNone>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceOnly>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceExcept>(
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
                BetaWebFetchUrlSourceAll x => x.Type,
                BetaWebFetchUrlSourceNone x => x.Type,
                BetaWebFetchUrlSourceOnly x => x.Type,
                BetaWebFetchUrlSourceExcept x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public ServerToolResults(BetaWebFetchUrlSourceAll value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ServerToolResults(BetaWebFetchUrlSourceNone value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ServerToolResults(BetaWebFetchUrlSourceOnly value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ServerToolResults(BetaWebFetchUrlSourceExcept value, JsonElement? element = null)
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
    /// type <see cref="BetaWebFetchUrlSourceAll"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchUrlSourceAll(out var value)) {
    ///     // `value` is of type `BetaWebFetchUrlSourceAll`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchUrlSourceAll(
        [NotNullWhen(true)] out BetaWebFetchUrlSourceAll? value
    )
    {
        value = this.Value as BetaWebFetchUrlSourceAll;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchUrlSourceNone"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchUrlSourceNone(out var value)) {
    ///     // `value` is of type `BetaWebFetchUrlSourceNone`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchUrlSourceNone(
        [NotNullWhen(true)] out BetaWebFetchUrlSourceNone? value
    )
    {
        value = this.Value as BetaWebFetchUrlSourceNone;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchUrlSourceOnly"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchUrlSourceOnly(out var value)) {
    ///     // `value` is of type `BetaWebFetchUrlSourceOnly`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchUrlSourceOnly(
        [NotNullWhen(true)] out BetaWebFetchUrlSourceOnly? value
    )
    {
        value = this.Value as BetaWebFetchUrlSourceOnly;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchUrlSourceExcept"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchUrlSourceExcept(out var value)) {
    ///     // `value` is of type `BetaWebFetchUrlSourceExcept`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchUrlSourceExcept(
        [NotNullWhen(true)] out BetaWebFetchUrlSourceExcept? value
    )
    {
        value = this.Value as BetaWebFetchUrlSourceExcept;
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
    ///     (BetaWebFetchUrlSourceAll value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceNone value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceOnly value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceExcept value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaWebFetchUrlSourceAll> betaWebFetchUrlSourceAll,
        System::Action<BetaWebFetchUrlSourceNone> betaWebFetchUrlSourceNone,
        System::Action<BetaWebFetchUrlSourceOnly> betaWebFetchUrlSourceOnly,
        System::Action<BetaWebFetchUrlSourceExcept> betaWebFetchUrlSourceExcept
    )
    {
        switch (this.Value)
        {
            case BetaWebFetchUrlSourceAll value:
                betaWebFetchUrlSourceAll(value);
                break;
            case BetaWebFetchUrlSourceNone value:
                betaWebFetchUrlSourceNone(value);
                break;
            case BetaWebFetchUrlSourceOnly value:
                betaWebFetchUrlSourceOnly(value);
                break;
            case BetaWebFetchUrlSourceExcept value:
                betaWebFetchUrlSourceExcept(value);
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
    ///     (BetaWebFetchUrlSourceAll value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceNone value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceOnly value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceExcept value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaWebFetchUrlSourceAll, T> betaWebFetchUrlSourceAll,
        System::Func<BetaWebFetchUrlSourceNone, T> betaWebFetchUrlSourceNone,
        System::Func<BetaWebFetchUrlSourceOnly, T> betaWebFetchUrlSourceOnly,
        System::Func<BetaWebFetchUrlSourceExcept, T> betaWebFetchUrlSourceExcept
    )
    {
        return this.Value switch
        {
            BetaWebFetchUrlSourceAll value => betaWebFetchUrlSourceAll(value),
            BetaWebFetchUrlSourceNone value => betaWebFetchUrlSourceNone(value),
            BetaWebFetchUrlSourceOnly value => betaWebFetchUrlSourceOnly(value),
            BetaWebFetchUrlSourceExcept value => betaWebFetchUrlSourceExcept(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ServerToolResults"
            ),
        };
    }

    public static implicit operator ServerToolResults(BetaWebFetchUrlSourceAll value) => new(value);

    public static implicit operator ServerToolResults(BetaWebFetchUrlSourceNone value) =>
        new(value);

    public static implicit operator ServerToolResults(BetaWebFetchUrlSourceOnly value) =>
        new(value);

    public static implicit operator ServerToolResults(BetaWebFetchUrlSourceExcept value) =>
        new(value);

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
            (betaWebFetchUrlSourceAll) => betaWebFetchUrlSourceAll.Validate(),
            (betaWebFetchUrlSourceNone) => betaWebFetchUrlSourceNone.Validate(),
            (betaWebFetchUrlSourceOnly) => betaWebFetchUrlSourceOnly.Validate(),
            (betaWebFetchUrlSourceExcept) => betaWebFetchUrlSourceExcept.Validate()
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
            BetaWebFetchUrlSourceAll _ => 0,
            BetaWebFetchUrlSourceNone _ => 1,
            BetaWebFetchUrlSourceOnly _ => 2,
            BetaWebFetchUrlSourceExcept _ => 3,
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceAll>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceNone>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceOnly>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceExcept>(
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
                BetaWebFetchUrlSourceAll x => x.Type,
                BetaWebFetchUrlSourceNone x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public UserInput(BetaWebFetchUrlSourceAll value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UserInput(BetaWebFetchUrlSourceNone value, JsonElement? element = null)
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
    /// type <see cref="BetaWebFetchUrlSourceAll"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchUrlSourceAll(out var value)) {
    ///     // `value` is of type `BetaWebFetchUrlSourceAll`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchUrlSourceAll(
        [NotNullWhen(true)] out BetaWebFetchUrlSourceAll? value
    )
    {
        value = this.Value as BetaWebFetchUrlSourceAll;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchUrlSourceNone"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchUrlSourceNone(out var value)) {
    ///     // `value` is of type `BetaWebFetchUrlSourceNone`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchUrlSourceNone(
        [NotNullWhen(true)] out BetaWebFetchUrlSourceNone? value
    )
    {
        value = this.Value as BetaWebFetchUrlSourceNone;
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
    ///     (BetaWebFetchUrlSourceAll value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceNone value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaWebFetchUrlSourceAll> betaWebFetchUrlSourceAll,
        System::Action<BetaWebFetchUrlSourceNone> betaWebFetchUrlSourceNone
    )
    {
        switch (this.Value)
        {
            case BetaWebFetchUrlSourceAll value:
                betaWebFetchUrlSourceAll(value);
                break;
            case BetaWebFetchUrlSourceNone value:
                betaWebFetchUrlSourceNone(value);
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
    ///     (BetaWebFetchUrlSourceAll value) =&gt; {...},
    ///     (BetaWebFetchUrlSourceNone value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaWebFetchUrlSourceAll, T> betaWebFetchUrlSourceAll,
        System::Func<BetaWebFetchUrlSourceNone, T> betaWebFetchUrlSourceNone
    )
    {
        return this.Value switch
        {
            BetaWebFetchUrlSourceAll value => betaWebFetchUrlSourceAll(value),
            BetaWebFetchUrlSourceNone value => betaWebFetchUrlSourceNone(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of UserInput"
            ),
        };
    }

    public static implicit operator UserInput(BetaWebFetchUrlSourceAll value) => new(value);

    public static implicit operator UserInput(BetaWebFetchUrlSourceNone value) => new(value);

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
            (betaWebFetchUrlSourceAll) => betaWebFetchUrlSourceAll.Validate(),
            (betaWebFetchUrlSourceNone) => betaWebFetchUrlSourceNone.Validate()
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
            BetaWebFetchUrlSourceAll _ => 0,
            BetaWebFetchUrlSourceNone _ => 1,
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceAll>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSourceNone>(
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
