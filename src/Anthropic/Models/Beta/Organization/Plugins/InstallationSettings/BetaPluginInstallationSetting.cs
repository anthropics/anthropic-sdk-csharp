using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

/// <summary>
/// The installation setting an organization-owned Plugin holds for one target. It
/// has no ID of its own: it is addressed by the Plugin's ID and the target.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaPluginInstallationSetting, BetaPluginInstallationSettingFromRaw>)
)]
public sealed record class BetaPluginInstallationSetting : JsonModel
{
    /// <summary>
    /// When the target was first given a setting for this Plugin.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The setting the target holds for this Plugin. One of `required`, `auto_install`,
    /// `available`, `not_available`; a value this API does not yet name is returned
    /// as stored.
    /// </summary>
    public required ApiEnum<
        string,
        BetaPluginInstallationSettingInstallationPreference
    > InstallationPreference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaPluginInstallationSettingInstallationPreference>
            >("installation_preference");
        }
        init { this._rawData.Set("installation_preference", value); }
    }

    /// <summary>
    /// The Plugin's ID.
    /// </summary>
    public required string PluginID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plugin_id");
        }
        init { this._rawData.Set("plugin_id", value); }
    }

    /// <summary>
    /// Whose setting this is: `organization` (the Plugin's own organization-wide
    /// setting) or `rbac_group` (one RBAC Group's own setting); `organization_member`
    /// does not occur here.
    /// </summary>
    public required BetaPluginInstallationSettingTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaPluginInstallationSettingTarget>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// Always `plugin_installation_setting`.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// When its setting last changed.
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        this.InstallationPreference.Validate();
        _ = this.PluginID;
        this.Target.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("plugin_installation_setting")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaPluginInstallationSetting()
    {
        this.Type = JsonSerializer.SerializeToElement("plugin_installation_setting");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginInstallationSetting(
        BetaPluginInstallationSetting betaPluginInstallationSetting
    )
        : base(betaPluginInstallationSetting) { }
#pragma warning restore CS8618

    public BetaPluginInstallationSetting(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("plugin_installation_setting");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginInstallationSetting(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginInstallationSettingFromRaw.FromRawUnchecked"/>
    public static BetaPluginInstallationSetting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginInstallationSettingFromRaw : IFromRawJson<BetaPluginInstallationSetting>
{
    /// <inheritdoc/>
    public BetaPluginInstallationSetting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginInstallationSetting.FromRawUnchecked(rawData);
}

/// <summary>
/// The setting the target holds for this Plugin. One of `required`, `auto_install`,
/// `available`, `not_available`; a value this API does not yet name is returned
/// as stored.
/// </summary>
[JsonConverter(typeof(BetaPluginInstallationSettingInstallationPreferenceConverter))]
public enum BetaPluginInstallationSettingInstallationPreference
{
    AutoInstall,
    Available,
    NotAvailable,
    Required,
}

sealed class BetaPluginInstallationSettingInstallationPreferenceConverter
    : JsonConverter<BetaPluginInstallationSettingInstallationPreference>
{
    public override BetaPluginInstallationSettingInstallationPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto_install" => BetaPluginInstallationSettingInstallationPreference.AutoInstall,
            "available" => BetaPluginInstallationSettingInstallationPreference.Available,
            "not_available" => BetaPluginInstallationSettingInstallationPreference.NotAvailable,
            "required" => BetaPluginInstallationSettingInstallationPreference.Required,
            _ => (BetaPluginInstallationSettingInstallationPreference)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaPluginInstallationSettingInstallationPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaPluginInstallationSettingInstallationPreference.AutoInstall => "auto_install",
                BetaPluginInstallationSettingInstallationPreference.Available => "available",
                BetaPluginInstallationSettingInstallationPreference.NotAvailable => "not_available",
                BetaPluginInstallationSettingInstallationPreference.Required => "required",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whose setting this is: `organization` (the Plugin's own organization-wide setting)
/// or `rbac_group` (one RBAC Group's own setting); `organization_member` does not
/// occur here.
/// </summary>
[JsonConverter(typeof(BetaPluginInstallationSettingTargetConverter))]
public record class BetaPluginInstallationSettingTarget : ModelBase
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
                BetaPluginTargetOrganization x => x.Type,
                BetaPluginTargetRbacGroup x => x.Type,
                BetaPluginTargetOrganizationMember x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaPluginInstallationSettingTarget(
        BetaPluginTargetOrganization value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaPluginInstallationSettingTarget(
        BetaPluginTargetRbacGroup value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaPluginInstallationSettingTarget(
        BetaPluginTargetOrganizationMember value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaPluginInstallationSettingTarget(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginTargetOrganization"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginTargetOrganization(out var value)) {
    ///     // `value` is of type `BetaPluginTargetOrganization`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginTargetOrganization(
        [NotNullWhen(true)] out BetaPluginTargetOrganization? value
    )
    {
        value = this.Value as BetaPluginTargetOrganization;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginTargetRbacGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginTargetRbacGroup(out var value)) {
    ///     // `value` is of type `BetaPluginTargetRbacGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginTargetRbacGroup(
        [NotNullWhen(true)] out BetaPluginTargetRbacGroup? value
    )
    {
        value = this.Value as BetaPluginTargetRbacGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginTargetOrganizationMember"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginTargetOrganizationMember(out var value)) {
    ///     // `value` is of type `BetaPluginTargetOrganizationMember`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginTargetOrganizationMember(
        [NotNullWhen(true)] out BetaPluginTargetOrganizationMember? value
    )
    {
        value = this.Value as BetaPluginTargetOrganizationMember;
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
    ///     (BetaPluginTargetOrganization value) =&gt; {...},
    ///     (BetaPluginTargetRbacGroup value) =&gt; {...},
    ///     (BetaPluginTargetOrganizationMember value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaPluginTargetOrganization> betaPluginTargetOrganization,
        System::Action<BetaPluginTargetRbacGroup> betaPluginTargetRbacGroup,
        System::Action<BetaPluginTargetOrganizationMember> betaPluginTargetOrganizationMember
    )
    {
        switch (this.Value)
        {
            case BetaPluginTargetOrganization value:
                betaPluginTargetOrganization(value);
                break;
            case BetaPluginTargetRbacGroup value:
                betaPluginTargetRbacGroup(value);
                break;
            case BetaPluginTargetOrganizationMember value:
                betaPluginTargetOrganizationMember(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaPluginInstallationSettingTarget"
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
    ///     (BetaPluginTargetOrganization value) =&gt; {...},
    ///     (BetaPluginTargetRbacGroup value) =&gt; {...},
    ///     (BetaPluginTargetOrganizationMember value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaPluginTargetOrganization, T> betaPluginTargetOrganization,
        System::Func<BetaPluginTargetRbacGroup, T> betaPluginTargetRbacGroup,
        System::Func<BetaPluginTargetOrganizationMember, T> betaPluginTargetOrganizationMember
    )
    {
        return this.Value switch
        {
            BetaPluginTargetOrganization value => betaPluginTargetOrganization(value),
            BetaPluginTargetRbacGroup value => betaPluginTargetRbacGroup(value),
            BetaPluginTargetOrganizationMember value => betaPluginTargetOrganizationMember(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaPluginInstallationSettingTarget"
            ),
        };
    }

    public static implicit operator BetaPluginInstallationSettingTarget(
        BetaPluginTargetOrganization value
    ) => new(value);

    public static implicit operator BetaPluginInstallationSettingTarget(
        BetaPluginTargetRbacGroup value
    ) => new(value);

    public static implicit operator BetaPluginInstallationSettingTarget(
        BetaPluginTargetOrganizationMember value
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
                "Data did not match any variant of BetaPluginInstallationSettingTarget"
            );
        }
        this.Switch(
            (betaPluginTargetOrganization) => betaPluginTargetOrganization.Validate(),
            (betaPluginTargetRbacGroup) => betaPluginTargetRbacGroup.Validate(),
            (betaPluginTargetOrganizationMember) => betaPluginTargetOrganizationMember.Validate()
        );
    }

    public virtual bool Equals(BetaPluginInstallationSettingTarget? other) =>
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
            BetaPluginTargetOrganization _ => 0,
            BetaPluginTargetRbacGroup _ => 1,
            BetaPluginTargetOrganizationMember _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaPluginInstallationSettingTargetConverter
    : JsonConverter<BetaPluginInstallationSettingTarget>
{
    public override BetaPluginInstallationSettingTarget? Read(
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
            case "organization":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPluginTargetOrganization>(
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
            case "rbac_group":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPluginTargetRbacGroup>(
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
            case "organization_member":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaPluginTargetOrganizationMember>(
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
                return new BetaPluginInstallationSettingTarget(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaPluginInstallationSettingTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
