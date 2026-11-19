using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

[JsonConverter(typeof(BetaClaudeCodeManagedSettingsModeParamConverter))]
public record class BetaClaudeCodeManagedSettingsModeParam : ModelBase
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

    public ApiEnum<string, BetaClaudeCodeManagedSettingsModeParamType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaClaudeCodeManagedSettingsOrganizationModeParam _ =>
                    BetaClaudeCodeManagedSettingsModeParamType.Organization,
                BetaClaudeCodeManagedSettingsRbacGroupsModeParam _ =>
                    BetaClaudeCodeManagedSettingsModeParamType.RbacGroups,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaClaudeCodeManagedSettingsModeParamType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaClaudeCodeManagedSettingsModeParam(
        BetaClaudeCodeManagedSettingsOrganizationModeParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeCodeManagedSettingsModeParam(
        BetaClaudeCodeManagedSettingsRbacGroupsModeParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeCodeManagedSettingsModeParam(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeCodeManagedSettingsOrganizationModeParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganization(out var value)) {
    ///     // `value` is of type `BetaClaudeCodeManagedSettingsOrganizationModeParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganization(
        [NotNullWhen(true)] out BetaClaudeCodeManagedSettingsOrganizationModeParam? value
    )
    {
        value = this.Value as BetaClaudeCodeManagedSettingsOrganizationModeParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeCodeManagedSettingsRbacGroupsModeParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRbacGroups(out var value)) {
    ///     // `value` is of type `BetaClaudeCodeManagedSettingsRbacGroupsModeParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRbacGroups(
        [NotNullWhen(true)] out BetaClaudeCodeManagedSettingsRbacGroupsModeParam? value
    )
    {
        value = this.Value as BetaClaudeCodeManagedSettingsRbacGroupsModeParam;
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
    ///     (BetaClaudeCodeManagedSettingsOrganizationModeParam value) =&gt; {...},
    ///     (BetaClaudeCodeManagedSettingsRbacGroupsModeParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaClaudeCodeManagedSettingsOrganizationModeParam> organization,
        Action<BetaClaudeCodeManagedSettingsRbacGroupsModeParam> rbacGroups
    )
    {
        switch (this.Value)
        {
            case BetaClaudeCodeManagedSettingsOrganizationModeParam value:
                organization(value);
                break;
            case BetaClaudeCodeManagedSettingsRbacGroupsModeParam value:
                rbacGroups(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaClaudeCodeManagedSettingsModeParam"
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
    ///     (BetaClaudeCodeManagedSettingsOrganizationModeParam value) =&gt; {...},
    ///     (BetaClaudeCodeManagedSettingsRbacGroupsModeParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaClaudeCodeManagedSettingsOrganizationModeParam, T> organization,
        Func<BetaClaudeCodeManagedSettingsRbacGroupsModeParam, T> rbacGroups
    )
    {
        return this.Value switch
        {
            BetaClaudeCodeManagedSettingsOrganizationModeParam value => organization(value),
            BetaClaudeCodeManagedSettingsRbacGroupsModeParam value => rbacGroups(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaClaudeCodeManagedSettingsModeParam"
            ),
        };
    }

    public static implicit operator BetaClaudeCodeManagedSettingsModeParam(
        BetaClaudeCodeManagedSettingsOrganizationModeParam value
    ) => new(value);

    public static implicit operator BetaClaudeCodeManagedSettingsModeParam(
        BetaClaudeCodeManagedSettingsRbacGroupsModeParam value
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
                "Data did not match any variant of BetaClaudeCodeManagedSettingsModeParam"
            );
        }
        this.Switch(
            (organization) => organization.Validate(),
            (rbacGroups) => rbacGroups.Validate()
        );
    }

    public virtual bool Equals(BetaClaudeCodeManagedSettingsModeParam? other) =>
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
            BetaClaudeCodeManagedSettingsOrganizationModeParam _ => 0,
            BetaClaudeCodeManagedSettingsRbacGroupsModeParam _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaClaudeCodeManagedSettingsModeParamConverter
    : JsonConverter<BetaClaudeCodeManagedSettingsModeParam>
{
    public override BetaClaudeCodeManagedSettingsModeParam? Read(
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
            case "organization":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsOrganizationModeParam>(
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
            case "rbac_groups":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsRbacGroupsModeParam>(
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
                return new BetaClaudeCodeManagedSettingsModeParam(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeCodeManagedSettingsModeParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaClaudeCodeManagedSettingsModeParamTypeConverter))]
public enum BetaClaudeCodeManagedSettingsModeParamType
{
    Organization = 0,
    RbacGroups = 1,
}

sealed class BetaClaudeCodeManagedSettingsModeParamTypeConverter
    : JsonConverter<BetaClaudeCodeManagedSettingsModeParamType>
{
    public override BetaClaudeCodeManagedSettingsModeParamType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "organization" => BetaClaudeCodeManagedSettingsModeParamType.Organization,
            "rbac_groups" => BetaClaudeCodeManagedSettingsModeParamType.RbacGroups,
            _ => (BetaClaudeCodeManagedSettingsModeParamType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeCodeManagedSettingsModeParamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaClaudeCodeManagedSettingsModeParamType.Organization => "organization",
                BetaClaudeCodeManagedSettingsModeParamType.RbacGroups => "rbac_groups",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
