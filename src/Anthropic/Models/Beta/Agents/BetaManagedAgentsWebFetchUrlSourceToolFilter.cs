using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Which tools' results contribute URLs that may be fetched.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsWebFetchUrlSourceToolFilterConverter))]
public record class BetaManagedAgentsWebFetchUrlSourceToolFilter : ModelBase
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
                BetaManagedAgentsWebFetchUrlSourceAll x => x.Type,
                BetaManagedAgentsWebFetchUrlSourceNone x => x.Type,
                BetaManagedAgentsWebFetchUrlSourceOnly x => x.Type,
                BetaManagedAgentsWebFetchUrlSourceExcept x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public IReadOnlyList<BetaManagedAgentsWebFetchUrlSourceToolReference>? Tools
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsWebFetchUrlSourceAll _ => null,
                BetaManagedAgentsWebFetchUrlSourceNone _ => null,
                BetaManagedAgentsWebFetchUrlSourceOnly x => x.Tools,
                BetaManagedAgentsWebFetchUrlSourceExcept x => x.Tools,
                _ => WrappedJsonSerializer.GetNullableClassProperty<
                    IReadOnlyList<BetaManagedAgentsWebFetchUrlSourceToolReference>
                >(this.Json, "tools"),
            };
        }
    }

    public BetaManagedAgentsWebFetchUrlSourceToolFilter(
        BetaManagedAgentsWebFetchUrlSourceAll value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWebFetchUrlSourceToolFilter(
        BetaManagedAgentsWebFetchUrlSourceNone value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWebFetchUrlSourceToolFilter(
        BetaManagedAgentsWebFetchUrlSourceOnly value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWebFetchUrlSourceToolFilter(
        BetaManagedAgentsWebFetchUrlSourceExcept value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWebFetchUrlSourceToolFilter(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWebFetchUrlSourceAll"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAll(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWebFetchUrlSourceAll`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAll([NotNullWhen(true)] out BetaManagedAgentsWebFetchUrlSourceAll? value)
    {
        value = this.Value as BetaManagedAgentsWebFetchUrlSourceAll;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWebFetchUrlSourceNone"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNone(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWebFetchUrlSourceNone`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNone([NotNullWhen(true)] out BetaManagedAgentsWebFetchUrlSourceNone? value)
    {
        value = this.Value as BetaManagedAgentsWebFetchUrlSourceNone;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWebFetchUrlSourceOnly"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOnly(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWebFetchUrlSourceOnly`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOnly([NotNullWhen(true)] out BetaManagedAgentsWebFetchUrlSourceOnly? value)
    {
        value = this.Value as BetaManagedAgentsWebFetchUrlSourceOnly;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWebFetchUrlSourceExcept"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExcept(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWebFetchUrlSourceExcept`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExcept(
        [NotNullWhen(true)] out BetaManagedAgentsWebFetchUrlSourceExcept? value
    )
    {
        value = this.Value as BetaManagedAgentsWebFetchUrlSourceExcept;
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
    ///     (BetaManagedAgentsWebFetchUrlSourceAll value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchUrlSourceNone value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchUrlSourceOnly value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchUrlSourceExcept value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsWebFetchUrlSourceAll> all,
        System::Action<BetaManagedAgentsWebFetchUrlSourceNone> none,
        System::Action<BetaManagedAgentsWebFetchUrlSourceOnly> only,
        System::Action<BetaManagedAgentsWebFetchUrlSourceExcept> except
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsWebFetchUrlSourceAll value:
                all(value);
                break;
            case BetaManagedAgentsWebFetchUrlSourceNone value:
                none(value);
                break;
            case BetaManagedAgentsWebFetchUrlSourceOnly value:
                only(value);
                break;
            case BetaManagedAgentsWebFetchUrlSourceExcept value:
                except(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsWebFetchUrlSourceToolFilter"
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
    ///     (BetaManagedAgentsWebFetchUrlSourceAll value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchUrlSourceNone value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchUrlSourceOnly value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchUrlSourceExcept value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsWebFetchUrlSourceAll, T> all,
        System::Func<BetaManagedAgentsWebFetchUrlSourceNone, T> none,
        System::Func<BetaManagedAgentsWebFetchUrlSourceOnly, T> only,
        System::Func<BetaManagedAgentsWebFetchUrlSourceExcept, T> except
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsWebFetchUrlSourceAll value => all(value),
            BetaManagedAgentsWebFetchUrlSourceNone value => none(value),
            BetaManagedAgentsWebFetchUrlSourceOnly value => only(value),
            BetaManagedAgentsWebFetchUrlSourceExcept value => except(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsWebFetchUrlSourceToolFilter"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsWebFetchUrlSourceToolFilter(
        BetaManagedAgentsWebFetchUrlSourceAll value
    ) => new(value);

    public static implicit operator BetaManagedAgentsWebFetchUrlSourceToolFilter(
        BetaManagedAgentsWebFetchUrlSourceNone value
    ) => new(value);

    public static implicit operator BetaManagedAgentsWebFetchUrlSourceToolFilter(
        BetaManagedAgentsWebFetchUrlSourceOnly value
    ) => new(value);

    public static implicit operator BetaManagedAgentsWebFetchUrlSourceToolFilter(
        BetaManagedAgentsWebFetchUrlSourceExcept value
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
                "Data did not match any variant of BetaManagedAgentsWebFetchUrlSourceToolFilter"
            );
        }
        this.Switch(
            (all) => all.Validate(),
            (none) => none.Validate(),
            (only) => only.Validate(),
            (except) => except.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsWebFetchUrlSourceToolFilter? other) =>
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
            BetaManagedAgentsWebFetchUrlSourceAll _ => 0,
            BetaManagedAgentsWebFetchUrlSourceNone _ => 1,
            BetaManagedAgentsWebFetchUrlSourceOnly _ => 2,
            BetaManagedAgentsWebFetchUrlSourceExcept _ => 3,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsWebFetchUrlSourceToolFilterConverter
    : JsonConverter<BetaManagedAgentsWebFetchUrlSourceToolFilter>
{
    public override BetaManagedAgentsWebFetchUrlSourceToolFilter? Read(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceAll>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceNone>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceOnly>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceExcept>(
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
                return new BetaManagedAgentsWebFetchUrlSourceToolFilter(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsWebFetchUrlSourceToolFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
