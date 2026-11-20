using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

[JsonConverter(typeof(BetaClaudeCodeManagedSettingsModeConverter))]
public record class BetaClaudeCodeManagedSettingsMode : ModelBase
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

    public ApiEnum<string, BetaClaudeCodeManagedSettingsModeType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaClaudeCodeManagedSettingsOrganizationMode _ =>
                    BetaClaudeCodeManagedSettingsModeType.Organization,
                BetaClaudeCodeManagedSettingsRbacGroupsMode _ =>
                    BetaClaudeCodeManagedSettingsModeType.RbacGroups,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaClaudeCodeManagedSettingsModeType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaClaudeCodeManagedSettingsMode(
        BetaClaudeCodeManagedSettingsOrganizationMode value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeCodeManagedSettingsMode(
        BetaClaudeCodeManagedSettingsRbacGroupsMode value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeCodeManagedSettingsMode(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeCodeManagedSettingsOrganizationMode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganization(out var value)) {
    ///     // `value` is of type `BetaClaudeCodeManagedSettingsOrganizationMode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganization(
        [NotNullWhen(true)] out BetaClaudeCodeManagedSettingsOrganizationMode? value
    )
    {
        value = this.Value as BetaClaudeCodeManagedSettingsOrganizationMode;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeCodeManagedSettingsRbacGroupsMode"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRbacGroups(out var value)) {
    ///     // `value` is of type `BetaClaudeCodeManagedSettingsRbacGroupsMode`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRbacGroups(
        [NotNullWhen(true)] out BetaClaudeCodeManagedSettingsRbacGroupsMode? value
    )
    {
        value = this.Value as BetaClaudeCodeManagedSettingsRbacGroupsMode;
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
    ///     (BetaClaudeCodeManagedSettingsOrganizationMode value) =&gt; {...},
    ///     (BetaClaudeCodeManagedSettingsRbacGroupsMode value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaClaudeCodeManagedSettingsOrganizationMode> organization,
        Action<BetaClaudeCodeManagedSettingsRbacGroupsMode> rbacGroups
    )
    {
        switch (this.Value)
        {
            case BetaClaudeCodeManagedSettingsOrganizationMode value:
                organization(value);
                break;
            case BetaClaudeCodeManagedSettingsRbacGroupsMode value:
                rbacGroups(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaClaudeCodeManagedSettingsMode"
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
    ///     (BetaClaudeCodeManagedSettingsOrganizationMode value) =&gt; {...},
    ///     (BetaClaudeCodeManagedSettingsRbacGroupsMode value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaClaudeCodeManagedSettingsOrganizationMode, T> organization,
        Func<BetaClaudeCodeManagedSettingsRbacGroupsMode, T> rbacGroups
    )
    {
        return this.Value switch
        {
            BetaClaudeCodeManagedSettingsOrganizationMode value => organization(value),
            BetaClaudeCodeManagedSettingsRbacGroupsMode value => rbacGroups(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaClaudeCodeManagedSettingsMode"
            ),
        };
    }

    public static implicit operator BetaClaudeCodeManagedSettingsMode(
        BetaClaudeCodeManagedSettingsOrganizationMode value
    ) => new(value);

    public static implicit operator BetaClaudeCodeManagedSettingsMode(
        BetaClaudeCodeManagedSettingsRbacGroupsMode value
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
                "Data did not match any variant of BetaClaudeCodeManagedSettingsMode"
            );
        }
        this.Switch(
            (organization) => organization.Validate(),
            (rbacGroups) => rbacGroups.Validate()
        );
    }

    public virtual bool Equals(BetaClaudeCodeManagedSettingsMode? other) =>
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
            BetaClaudeCodeManagedSettingsOrganizationMode _ => 0,
            BetaClaudeCodeManagedSettingsRbacGroupsMode _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaClaudeCodeManagedSettingsModeConverter
    : JsonConverter<BetaClaudeCodeManagedSettingsMode>
{
    public override BetaClaudeCodeManagedSettingsMode? Read(
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
                        JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsOrganizationMode>(
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
                        JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsRbacGroupsMode>(
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
                return new BetaClaudeCodeManagedSettingsMode(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeCodeManagedSettingsMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaClaudeCodeManagedSettingsModeTypeConverter))]
public enum BetaClaudeCodeManagedSettingsModeType
{
    Organization = 0,
    RbacGroups = 1,
}

sealed class BetaClaudeCodeManagedSettingsModeTypeConverter
    : JsonConverter<BetaClaudeCodeManagedSettingsModeType>
{
    public override BetaClaudeCodeManagedSettingsModeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "organization" => BetaClaudeCodeManagedSettingsModeType.Organization,
            "rbac_groups" => BetaClaudeCodeManagedSettingsModeType.RbacGroups,
            _ => (BetaClaudeCodeManagedSettingsModeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeCodeManagedSettingsModeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaClaudeCodeManagedSettingsModeType.Organization => "organization",
                BetaClaudeCodeManagedSettingsModeType.RbacGroups => "rbac_groups",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
