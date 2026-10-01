using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(typeof(JsonModelConverter<BetaPlugin, BetaPluginFromRaw>))]
public sealed record class BetaPlugin : JsonModel
{
    /// <summary>
    /// The Plugin's ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// What the served version contains; null when not enumerated.
    /// </summary>
    public required IReadOnlyList<BetaPluginComponent>? Components
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaPluginComponent>>(
                "components"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaPluginComponent>?>(
                "components",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The served version's content scan; null when it has not been scanned.
    /// </summary>
    public required BetaPluginContentScan? ContentScan
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaPluginContentScan>("content_scan");
        }
        init { this._rawData.Set("content_scan", value); }
    }

    /// <summary>
    /// RFC 3339.
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
    /// Who created the Plugin; null when no creator is recorded.
    /// </summary>
    public required CreatedBy? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatedBy>("created_by");
        }
        init { this._rawData.Set("created_by", value); }
    }

    /// <summary>
    /// The served version's description.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The served version's display name.
    /// </summary>
    public required string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// The newest version.
    /// </summary>
    public required string LatestVersionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("latest_version_id");
        }
        init { this._rawData.Set("latest_version_id", value); }
    }

    /// <summary>
    /// The version string the served version's manifest declares.
    /// </summary>
    public required string? ManifestVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("manifest_version");
        }
        init { this._rawData.Set("manifest_version", value); }
    }

    /// <summary>
    /// The ID of the plugin marketplace the Plugin lives in.
    /// </summary>
    public required string MarketplaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("marketplace_id");
        }
        init { this._rawData.Set("marketplace_id", value); }
    }

    /// <summary>
    /// Lowercase identifier, unique within its plugin marketplace. Fixed for an
    /// organization-owned Plugin's lifetime; a member-owned Plugin's changes when
    /// its owner renames it in claude.ai, while its `id` stays the same.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Organization-owned Plugin: the organization-wide installation setting every
    /// member gets unless an RBAC Group they belong to holds its own — the Plugin's
    /// own setting, or its plugin marketplace's default. Null for a member-owned
    /// Plugin, which has shares instead. One of `required`, `auto_install`, `available`,
    /// `not_available`; a value this API does not yet name is returned as stored.
    /// </summary>
    public required ApiEnum<
        string,
        OrganizationInstallationPreference
    >? OrganizationInstallationPreference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, OrganizationInstallationPreference>
            >("organization_installation_preference");
        }
        init { this._rawData.Set("organization_installation_preference", value); }
    }

    /// <summary>
    /// Organization-owned Plugin: true while it has no organization-wide setting
    /// of its own and `organization_installation_preference` is its plugin marketplace's
    /// default. Null for a member-owned Plugin.
    /// </summary>
    public required bool? OrganizationInstallationPreferenceInherited
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "organization_installation_preference_inherited"
            );
        }
        init { this._rawData.Set("organization_installation_preference_inherited", value); }
    }

    /// <summary>
    /// Who owns the Plugin: the organization, or the member whose personal plugin
    /// marketplace it lives in.
    /// </summary>
    public required Owner Owner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Owner>("owner");
        }
        init { this._rawData.Set("owner", value); }
    }

    /// <summary>
    /// How far the served version reaches: `remote` when it declares an MCP server
    /// or a CLI, `privileged` when it declares a hook, monitor, language server or
    /// settings but nothing remote, `contained` otherwise; null when not classifiable.
    /// </summary>
    public required ApiEnum<string, Reach>? Reach
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Reach>>("reach");
        }
        init { this._rawData.Set("reach", value); }
    }

    /// <summary>
    /// The version claude.ai serves to members.
    /// </summary>
    public required string ServedVersionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("served_version_id");
        }
        init { this._rawData.Set("served_version_id", value); }
    }

    /// <summary>
    /// False while the served version follows each new version; true once it has
    /// been pinned to one.
    /// </summary>
    public required bool ServedVersionPinned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("served_version_pinned");
        }
        init { this._rawData.Set("served_version_pinned", value); }
    }

    /// <summary>
    /// Always `plugin`.
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
    /// RFC 3339. Moves on a new version and on a served-version change; a change
    /// to the Plugin's installation settings or shares does not move it.
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
        _ = this.ID;
        foreach (var item in this.Components ?? [])
        {
            item.Validate();
        }
        this.ContentScan?.Validate();
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.LatestVersionID;
        _ = this.ManifestVersion;
        _ = this.MarketplaceID;
        _ = this.Name;
        this.OrganizationInstallationPreference?.Validate();
        _ = this.OrganizationInstallationPreferenceInherited;
        this.Owner.Validate();
        this.Reach?.Validate();
        _ = this.ServedVersionID;
        _ = this.ServedVersionPinned;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("plugin")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaPlugin()
    {
        this.Type = JsonSerializer.SerializeToElement("plugin");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPlugin(BetaPlugin betaPlugin)
        : base(betaPlugin) { }
#pragma warning restore CS8618

    public BetaPlugin(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("plugin");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPlugin(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginFromRaw.FromRawUnchecked"/>
    public static BetaPlugin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginFromRaw : IFromRawJson<BetaPlugin>
{
    /// <inheritdoc/>
    public BetaPlugin FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPlugin.FromRawUnchecked(rawData);
}

/// <summary>
/// Who created the Plugin; null when no creator is recorded.
/// </summary>
[JsonConverter(typeof(CreatedByConverter))]
public record class CreatedBy : ModelBase
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
                BetaPluginUserActor x => x.Type,
                BetaPluginApiActor x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public CreatedBy(BetaPluginUserActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreatedBy(BetaPluginApiActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreatedBy(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginUserActor(out var value)) {
    ///     // `value` is of type `BetaPluginUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginUserActor([NotNullWhen(true)] out BetaPluginUserActor? value)
    {
        value = this.Value as BetaPluginUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginApiActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginApiActor(out var value)) {
    ///     // `value` is of type `BetaPluginApiActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginApiActor([NotNullWhen(true)] out BetaPluginApiActor? value)
    {
        value = this.Value as BetaPluginApiActor;
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
    ///     (BetaPluginUserActor value) =&gt; {...},
    ///     (BetaPluginApiActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaPluginUserActor> betaPluginUserActor,
        System::Action<BetaPluginApiActor> betaPluginApiActor
    )
    {
        switch (this.Value)
        {
            case BetaPluginUserActor value:
                betaPluginUserActor(value);
                break;
            case BetaPluginApiActor value:
                betaPluginApiActor(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of CreatedBy"
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
    ///     (BetaPluginUserActor value) =&gt; {...},
    ///     (BetaPluginApiActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaPluginUserActor, T> betaPluginUserActor,
        System::Func<BetaPluginApiActor, T> betaPluginApiActor
    )
    {
        return this.Value switch
        {
            BetaPluginUserActor value => betaPluginUserActor(value),
            BetaPluginApiActor value => betaPluginApiActor(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of CreatedBy"
            ),
        };
    }

    public static implicit operator CreatedBy(BetaPluginUserActor value) => new(value);

    public static implicit operator CreatedBy(BetaPluginApiActor value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of CreatedBy");
        }
        this.Switch(
            (betaPluginUserActor) => betaPluginUserActor.Validate(),
            (betaPluginApiActor) => betaPluginApiActor.Validate()
        );
    }

    public virtual bool Equals(CreatedBy? other) =>
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
            BetaPluginUserActor _ => 0,
            BetaPluginApiActor _ => 1,
            _ => -1,
        };
    }
}

sealed class CreatedByConverter : JsonConverter<CreatedBy?>
{
    public override CreatedBy? Read(
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
            case "user_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPluginUserActor>(
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
            case "api_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPluginApiActor>(
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
                return new CreatedBy(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreatedBy? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Organization-owned Plugin: the organization-wide installation setting every member
/// gets unless an RBAC Group they belong to holds its own — the Plugin's own setting,
/// or its plugin marketplace's default. Null for a member-owned Plugin, which has
/// shares instead. One of `required`, `auto_install`, `available`, `not_available`;
/// a value this API does not yet name is returned as stored.
/// </summary>
[JsonConverter(typeof(OrganizationInstallationPreferenceConverter))]
public enum OrganizationInstallationPreference
{
    AutoInstall,
    Available,
    NotAvailable,
    Required,
}

sealed class OrganizationInstallationPreferenceConverter
    : JsonConverter<OrganizationInstallationPreference>
{
    public override OrganizationInstallationPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto_install" => OrganizationInstallationPreference.AutoInstall,
            "available" => OrganizationInstallationPreference.Available,
            "not_available" => OrganizationInstallationPreference.NotAvailable,
            "required" => OrganizationInstallationPreference.Required,
            _ => (OrganizationInstallationPreference)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OrganizationInstallationPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OrganizationInstallationPreference.AutoInstall => "auto_install",
                OrganizationInstallationPreference.Available => "available",
                OrganizationInstallationPreference.NotAvailable => "not_available",
                OrganizationInstallationPreference.Required => "required",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Who owns the Plugin: the organization, or the member whose personal plugin marketplace
/// it lives in.
/// </summary>
[JsonConverter(typeof(OwnerConverter))]
public record class Owner : ModelBase
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
                BetaPluginOwnerOrganization x => x.Type,
                BetaPluginOwnerUser x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Owner(BetaPluginOwnerOrganization value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Owner(BetaPluginOwnerUser value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Owner(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginOwnerOrganization"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginOwnerOrganization(out var value)) {
    ///     // `value` is of type `BetaPluginOwnerOrganization`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginOwnerOrganization(
        [NotNullWhen(true)] out BetaPluginOwnerOrganization? value
    )
    {
        value = this.Value as BetaPluginOwnerOrganization;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginOwnerUser"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginOwnerUser(out var value)) {
    ///     // `value` is of type `BetaPluginOwnerUser`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginOwnerUser([NotNullWhen(true)] out BetaPluginOwnerUser? value)
    {
        value = this.Value as BetaPluginOwnerUser;
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
    ///     (BetaPluginOwnerOrganization value) =&gt; {...},
    ///     (BetaPluginOwnerUser value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaPluginOwnerOrganization> betaPluginOwnerOrganization,
        System::Action<BetaPluginOwnerUser> betaPluginOwnerUser
    )
    {
        switch (this.Value)
        {
            case BetaPluginOwnerOrganization value:
                betaPluginOwnerOrganization(value);
                break;
            case BetaPluginOwnerUser value:
                betaPluginOwnerUser(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Owner");
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
    ///     (BetaPluginOwnerOrganization value) =&gt; {...},
    ///     (BetaPluginOwnerUser value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaPluginOwnerOrganization, T> betaPluginOwnerOrganization,
        System::Func<BetaPluginOwnerUser, T> betaPluginOwnerUser
    )
    {
        return this.Value switch
        {
            BetaPluginOwnerOrganization value => betaPluginOwnerOrganization(value),
            BetaPluginOwnerUser value => betaPluginOwnerUser(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Owner"),
        };
    }

    public static implicit operator Owner(BetaPluginOwnerOrganization value) => new(value);

    public static implicit operator Owner(BetaPluginOwnerUser value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Owner");
        }
        this.Switch(
            (betaPluginOwnerOrganization) => betaPluginOwnerOrganization.Validate(),
            (betaPluginOwnerUser) => betaPluginOwnerUser.Validate()
        );
    }

    public virtual bool Equals(Owner? other) =>
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
            BetaPluginOwnerOrganization _ => 0,
            BetaPluginOwnerUser _ => 1,
            _ => -1,
        };
    }
}

sealed class OwnerConverter : JsonConverter<Owner>
{
    public override Owner? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaPluginOwnerOrganization>(
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
            case "user":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPluginOwnerUser>(
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
                return new Owner(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Owner value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// How far the served version reaches: `remote` when it declares an MCP server or
/// a CLI, `privileged` when it declares a hook, monitor, language server or settings
/// but nothing remote, `contained` otherwise; null when not classifiable.
/// </summary>
[JsonConverter(typeof(ReachConverter))]
public enum Reach
{
    Contained,
    Privileged,
    Remote,
}

sealed class ReachConverter : JsonConverter<Reach>
{
    public override Reach Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "contained" => Reach.Contained,
            "privileged" => Reach.Privileged,
            "remote" => Reach.Remote,
            _ => (Reach)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reach value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reach.Contained => "contained",
                Reach.Privileged => "privileged",
                Reach.Remote => "remote",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
