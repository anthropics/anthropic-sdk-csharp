using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ComplianceSettings;

[JsonConverter(typeof(ComplianceSettingsStateParamConverter))]
public record class ComplianceSettingsStateParam : ModelBase
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
                ComplianceSettingsStateEnabledParam x => x.Type,
                ComplianceSettingsStateDisabledParam x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public ComplianceSettingsStateParam(
        ComplianceSettingsStateEnabledParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ComplianceSettingsStateParam(
        ComplianceSettingsStateDisabledParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ComplianceSettingsStateParam(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComplianceSettingsStateEnabledParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `ComplianceSettingsStateEnabledParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled([NotNullWhen(true)] out ComplianceSettingsStateEnabledParam? value)
    {
        value = this.Value as ComplianceSettingsStateEnabledParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComplianceSettingsStateDisabledParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `ComplianceSettingsStateDisabledParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled([NotNullWhen(true)] out ComplianceSettingsStateDisabledParam? value)
    {
        value = this.Value as ComplianceSettingsStateDisabledParam;
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
    ///     (ComplianceSettingsStateEnabledParam value) =&gt; {...},
    ///     (ComplianceSettingsStateDisabledParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ComplianceSettingsStateEnabledParam> enabled,
        Action<ComplianceSettingsStateDisabledParam> disabled
    )
    {
        switch (this.Value)
        {
            case ComplianceSettingsStateEnabledParam value:
                enabled(value);
                break;
            case ComplianceSettingsStateDisabledParam value:
                disabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ComplianceSettingsStateParam"
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
    ///     (ComplianceSettingsStateEnabledParam value) =&gt; {...},
    ///     (ComplianceSettingsStateDisabledParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ComplianceSettingsStateEnabledParam, T> enabled,
        Func<ComplianceSettingsStateDisabledParam, T> disabled
    )
    {
        return this.Value switch
        {
            ComplianceSettingsStateEnabledParam value => enabled(value),
            ComplianceSettingsStateDisabledParam value => disabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ComplianceSettingsStateParam"
            ),
        };
    }

    public static implicit operator ComplianceSettingsStateParam(
        ComplianceSettingsStateEnabledParam value
    ) => new(value);

    public static implicit operator ComplianceSettingsStateParam(
        ComplianceSettingsStateDisabledParam value
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
                "Data did not match any variant of ComplianceSettingsStateParam"
            );
        }
        this.Switch((enabled) => enabled.Validate(), (disabled) => disabled.Validate());
    }

    public virtual bool Equals(ComplianceSettingsStateParam? other) =>
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
            ComplianceSettingsStateEnabledParam _ => 0,
            ComplianceSettingsStateDisabledParam _ => 1,
            _ => -1,
        };
    }
}

sealed class ComplianceSettingsStateParamConverter : JsonConverter<ComplianceSettingsStateParam>
{
    public override ComplianceSettingsStateParam? Read(
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
                        JsonSerializer.Deserialize<ComplianceSettingsStateEnabledParam>(
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
                        JsonSerializer.Deserialize<ComplianceSettingsStateDisabledParam>(
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
                return new ComplianceSettingsStateParam(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ComplianceSettingsStateParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
