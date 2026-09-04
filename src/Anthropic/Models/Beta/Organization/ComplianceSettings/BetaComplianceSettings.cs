using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ComplianceSettings;

[JsonConverter(typeof(JsonModelConverter<BetaComplianceSettings, BetaComplianceSettingsFromRaw>))]
public sealed record class BetaComplianceSettings : JsonModel
{
    /// <summary>
    /// Whether the Compliance API is enabled for this organization.
    /// </summary>
    public required BetaComplianceSettingsState State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaComplianceSettingsState>("state");
        }
        init { this._rawData.Set("state", value); }
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
        this.State.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("compliance_settings")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceSettings()
    {
        this.Type = JsonSerializer.SerializeToElement("compliance_settings");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceSettings(BetaComplianceSettings betaComplianceSettings)
        : base(betaComplianceSettings) { }
#pragma warning restore CS8618

    public BetaComplianceSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compliance_settings");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceSettingsFromRaw.FromRawUnchecked"/>
    public static BetaComplianceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComplianceSettings(BetaComplianceSettingsState state)
        : this()
    {
        this.State = state;
    }
}

class BetaComplianceSettingsFromRaw : IFromRawJson<BetaComplianceSettings>
{
    /// <inheritdoc/>
    public BetaComplianceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the Compliance API is enabled for this organization.
/// </summary>
[JsonConverter(typeof(BetaComplianceSettingsStateConverter))]
public record class BetaComplianceSettingsState : ModelBase
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
                BetaComplianceSettingsStateEnabled x => x.Type,
                BetaComplianceSettingsStateDisabled x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaComplianceSettingsState(
        BetaComplianceSettingsStateEnabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceSettingsState(
        BetaComplianceSettingsStateDisabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceSettingsState(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceSettingsStateEnabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaComplianceSettingsStateEnabled(out var value)) {
    ///     // `value` is of type `BetaComplianceSettingsStateEnabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaComplianceSettingsStateEnabled(
        [NotNullWhen(true)] out BetaComplianceSettingsStateEnabled? value
    )
    {
        value = this.Value as BetaComplianceSettingsStateEnabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceSettingsStateDisabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaComplianceSettingsStateDisabled(out var value)) {
    ///     // `value` is of type `BetaComplianceSettingsStateDisabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaComplianceSettingsStateDisabled(
        [NotNullWhen(true)] out BetaComplianceSettingsStateDisabled? value
    )
    {
        value = this.Value as BetaComplianceSettingsStateDisabled;
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
    ///     (BetaComplianceSettingsStateEnabled value) =&gt; {...},
    ///     (BetaComplianceSettingsStateDisabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaComplianceSettingsStateEnabled> betaComplianceSettingsStateEnabled,
        Action<BetaComplianceSettingsStateDisabled> betaComplianceSettingsStateDisabled
    )
    {
        switch (this.Value)
        {
            case BetaComplianceSettingsStateEnabled value:
                betaComplianceSettingsStateEnabled(value);
                break;
            case BetaComplianceSettingsStateDisabled value:
                betaComplianceSettingsStateDisabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaComplianceSettingsState"
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
    ///     (BetaComplianceSettingsStateEnabled value) =&gt; {...},
    ///     (BetaComplianceSettingsStateDisabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaComplianceSettingsStateEnabled, T> betaComplianceSettingsStateEnabled,
        Func<BetaComplianceSettingsStateDisabled, T> betaComplianceSettingsStateDisabled
    )
    {
        return this.Value switch
        {
            BetaComplianceSettingsStateEnabled value => betaComplianceSettingsStateEnabled(value),
            BetaComplianceSettingsStateDisabled value => betaComplianceSettingsStateDisabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaComplianceSettingsState"
            ),
        };
    }

    public static implicit operator BetaComplianceSettingsState(
        BetaComplianceSettingsStateEnabled value
    ) => new(value);

    public static implicit operator BetaComplianceSettingsState(
        BetaComplianceSettingsStateDisabled value
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
                "Data did not match any variant of BetaComplianceSettingsState"
            );
        }
        this.Switch(
            (betaComplianceSettingsStateEnabled) => betaComplianceSettingsStateEnabled.Validate(),
            (betaComplianceSettingsStateDisabled) => betaComplianceSettingsStateDisabled.Validate()
        );
    }

    public virtual bool Equals(BetaComplianceSettingsState? other) =>
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
            BetaComplianceSettingsStateEnabled _ => 0,
            BetaComplianceSettingsStateDisabled _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaComplianceSettingsStateConverter : JsonConverter<BetaComplianceSettingsState>
{
    public override BetaComplianceSettingsState? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "enabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComplianceSettingsStateEnabled>(
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
            case "disabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComplianceSettingsStateDisabled>(
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
                return new BetaComplianceSettingsState(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceSettingsState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
