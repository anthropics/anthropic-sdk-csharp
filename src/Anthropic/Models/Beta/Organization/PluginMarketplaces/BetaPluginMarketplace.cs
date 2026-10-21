using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Plugins = Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Models.Beta.Organization.PluginMarketplaces;

[JsonConverter(typeof(JsonModelConverter<BetaPluginMarketplace, BetaPluginMarketplaceFromRaw>))]
public sealed record class BetaPluginMarketplace : JsonModel
{
    /// <summary>
    /// The plugin marketplace's ID, prefixed `marketplace_`.
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
    /// RFC 3339.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Organization plugin marketplace: the organization-wide setting every Plugin
    /// in it with no setting of its own gets. Null for a member's personal plugin
    /// marketplace. One of `required`, `auto_install`, `available`, `not_available`;
    /// a value this API does not yet name is returned as stored.
    /// </summary>
    public required ApiEnum<
        string,
        BetaPluginMarketplaceDefaultInstallationPreference
    >? DefaultInstallationPreference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaPluginMarketplaceDefaultInstallationPreference>
            >("default_installation_preference");
        }
        init { this._rawData.Set("default_installation_preference", value); }
    }

    /// <summary>
    /// RFC 3339. When the most recent synchronization attempt to finish did so,
    /// whatever its outcome; for a repository plugin marketplace no synchronization
    /// has run on yet, when it was created. Null for a plugin marketplace that is
    /// not synchronized from a repository.
    /// </summary>
    public required DateTimeOffset? LastSyncEndedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_sync_ended_at");
        }
        init { this._rawData.Set("last_sync_ended_at", value); }
    }

    /// <summary>
    /// The commit the last synchronization attempt that reached the repository read,
    /// whether or not its content was then accepted (see `sync_status`); an attempt
    /// that ends `failed_auth` or `failed_transient` leaves it unchanged. Null until
    /// an attempt has first read the repository, and for a plugin marketplace that
    /// is not synchronized from a repository.
    /// </summary>
    public required string? LastSyncReadSha
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_sync_read_sha");
        }
        init { this._rawData.Set("last_sync_read_sha", value); }
    }

    /// <summary>
    /// Fixed for the plugin marketplace's lifetime.
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
    /// The organization, or the member whose personal plugin marketplace it is.
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
    /// Where the plugin marketplace's Plugins come from: `manual` when they are uploaded;
    /// `github`, `gitlab` or `public_git` when they are synchronized from the Git
    /// repository the owner connected, into which nothing can be uploaded; `directory`
    /// is Anthropic's own catalog, which this API does not list. A value this API
    /// does not yet name is returned as stored.
    /// </summary>
    public required ApiEnum<string, BetaPluginMarketplaceSource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaPluginMarketplaceSource>>(
                "source"
            );
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Outcome of the plugin marketplace's most recent synchronization: one of `success`,
    /// `in_progress`, `failed_content`, `failed_transient`, `failed_auth`, `failed_limits`;
    /// a value this API does not yet name is returned as stored. Null until a synchronization
    /// is first attempted — so always for a `manual` plugin marketplace.
    /// </summary>
    public required ApiEnum<string, SyncStatus>? SyncStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SyncStatus>>("sync_status");
        }
        init { this._rawData.Set("sync_status", value); }
    }

    /// <summary>
    /// Always `plugin_marketplace`.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.DefaultInstallationPreference?.Validate();
        _ = this.LastSyncEndedAt;
        _ = this.LastSyncReadSha;
        _ = this.Name;
        this.Owner.Validate();
        this.Source.Validate();
        this.SyncStatus?.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("plugin_marketplace")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaPluginMarketplace()
    {
        this.Type = JsonSerializer.SerializeToElement("plugin_marketplace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginMarketplace(BetaPluginMarketplace betaPluginMarketplace)
        : base(betaPluginMarketplace) { }
#pragma warning restore CS8618

    public BetaPluginMarketplace(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("plugin_marketplace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginMarketplace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginMarketplaceFromRaw.FromRawUnchecked"/>
    public static BetaPluginMarketplace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginMarketplaceFromRaw : IFromRawJson<BetaPluginMarketplace>
{
    /// <inheritdoc/>
    public BetaPluginMarketplace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginMarketplace.FromRawUnchecked(rawData);
}

/// <summary>
/// Organization plugin marketplace: the organization-wide setting every Plugin in
/// it with no setting of its own gets. Null for a member's personal plugin marketplace.
/// One of `required`, `auto_install`, `available`, `not_available`; a value this
/// API does not yet name is returned as stored.
/// </summary>
[JsonConverter(typeof(BetaPluginMarketplaceDefaultInstallationPreferenceConverter))]
public enum BetaPluginMarketplaceDefaultInstallationPreference
{
    AutoInstall,
    Available,
    NotAvailable,
    Required,
}

sealed class BetaPluginMarketplaceDefaultInstallationPreferenceConverter
    : JsonConverter<BetaPluginMarketplaceDefaultInstallationPreference>
{
    public override BetaPluginMarketplaceDefaultInstallationPreference Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto_install" => BetaPluginMarketplaceDefaultInstallationPreference.AutoInstall,
            "available" => BetaPluginMarketplaceDefaultInstallationPreference.Available,
            "not_available" => BetaPluginMarketplaceDefaultInstallationPreference.NotAvailable,
            "required" => BetaPluginMarketplaceDefaultInstallationPreference.Required,
            _ => (BetaPluginMarketplaceDefaultInstallationPreference)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaPluginMarketplaceDefaultInstallationPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaPluginMarketplaceDefaultInstallationPreference.AutoInstall => "auto_install",
                BetaPluginMarketplaceDefaultInstallationPreference.Available => "available",
                BetaPluginMarketplaceDefaultInstallationPreference.NotAvailable => "not_available",
                BetaPluginMarketplaceDefaultInstallationPreference.Required => "required",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The organization, or the member whose personal plugin marketplace it is.
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
                Plugins::BetaPluginOwnerOrganization x => x.Type,
                Plugins::BetaPluginOwnerUser x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Owner(Plugins::BetaPluginOwnerOrganization value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Owner(Plugins::BetaPluginOwnerUser value, JsonElement? element = null)
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
    /// type <see cref="Plugins::BetaPluginOwnerOrganization"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginOwnerOrganization(out var value)) {
    ///     // `value` is of type `Plugins::BetaPluginOwnerOrganization`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginOwnerOrganization(
        [NotNullWhen(true)] out Plugins::BetaPluginOwnerOrganization? value
    )
    {
        value = this.Value as Plugins::BetaPluginOwnerOrganization;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Plugins::BetaPluginOwnerUser"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginOwnerUser(out var value)) {
    ///     // `value` is of type `Plugins::BetaPluginOwnerUser`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginOwnerUser(
        [NotNullWhen(true)] out Plugins::BetaPluginOwnerUser? value
    )
    {
        value = this.Value as Plugins::BetaPluginOwnerUser;
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
    ///     (Plugins::BetaPluginOwnerOrganization value) =&gt; {...},
    ///     (Plugins::BetaPluginOwnerUser value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Plugins::BetaPluginOwnerOrganization> betaPluginOwnerOrganization,
        Action<Plugins::BetaPluginOwnerUser> betaPluginOwnerUser
    )
    {
        switch (this.Value)
        {
            case Plugins::BetaPluginOwnerOrganization value:
                betaPluginOwnerOrganization(value);
                break;
            case Plugins::BetaPluginOwnerUser value:
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
    ///     (Plugins::BetaPluginOwnerOrganization value) =&gt; {...},
    ///     (Plugins::BetaPluginOwnerUser value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Plugins::BetaPluginOwnerOrganization, T> betaPluginOwnerOrganization,
        Func<Plugins::BetaPluginOwnerUser, T> betaPluginOwnerUser
    )
    {
        return this.Value switch
        {
            Plugins::BetaPluginOwnerOrganization value => betaPluginOwnerOrganization(value),
            Plugins::BetaPluginOwnerUser value => betaPluginOwnerUser(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Owner"),
        };
    }

    public static implicit operator Owner(Plugins::BetaPluginOwnerOrganization value) => new(value);

    public static implicit operator Owner(Plugins::BetaPluginOwnerUser value) => new(value);

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
            Plugins::BetaPluginOwnerOrganization _ => 0,
            Plugins::BetaPluginOwnerUser _ => 1,
            _ => -1,
        };
    }
}

sealed class OwnerConverter : JsonConverter<Owner>
{
    public override Owner? Read(
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
                        JsonSerializer.Deserialize<Plugins::BetaPluginOwnerOrganization>(
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
                    var deserialized = JsonSerializer.Deserialize<Plugins::BetaPluginOwnerUser>(
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
/// Where the plugin marketplace's Plugins come from: `manual` when they are uploaded;
/// `github`, `gitlab` or `public_git` when they are synchronized from the Git repository
/// the owner connected, into which nothing can be uploaded; `directory` is Anthropic's
/// own catalog, which this API does not list. A value this API does not yet name
/// is returned as stored.
/// </summary>
[JsonConverter(typeof(BetaPluginMarketplaceSourceConverter))]
public enum BetaPluginMarketplaceSource
{
    Directory,
    GitHub,
    Gitlab,
    Manual,
    PublicGit,
}

sealed class BetaPluginMarketplaceSourceConverter : JsonConverter<BetaPluginMarketplaceSource>
{
    public override BetaPluginMarketplaceSource Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "directory" => BetaPluginMarketplaceSource.Directory,
            "github" => BetaPluginMarketplaceSource.GitHub,
            "gitlab" => BetaPluginMarketplaceSource.Gitlab,
            "manual" => BetaPluginMarketplaceSource.Manual,
            "public_git" => BetaPluginMarketplaceSource.PublicGit,
            _ => (BetaPluginMarketplaceSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaPluginMarketplaceSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaPluginMarketplaceSource.Directory => "directory",
                BetaPluginMarketplaceSource.GitHub => "github",
                BetaPluginMarketplaceSource.Gitlab => "gitlab",
                BetaPluginMarketplaceSource.Manual => "manual",
                BetaPluginMarketplaceSource.PublicGit => "public_git",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Outcome of the plugin marketplace's most recent synchronization: one of `success`,
/// `in_progress`, `failed_content`, `failed_transient`, `failed_auth`, `failed_limits`;
/// a value this API does not yet name is returned as stored. Null until a synchronization
/// is first attempted — so always for a `manual` plugin marketplace.
/// </summary>
[JsonConverter(typeof(SyncStatusConverter))]
public enum SyncStatus
{
    FailedAuth,
    FailedContent,
    FailedLimits,
    FailedTransient,
    InProgress,
    Success,
}

sealed class SyncStatusConverter : JsonConverter<SyncStatus>
{
    public override SyncStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "failed_auth" => SyncStatus.FailedAuth,
            "failed_content" => SyncStatus.FailedContent,
            "failed_limits" => SyncStatus.FailedLimits,
            "failed_transient" => SyncStatus.FailedTransient,
            "in_progress" => SyncStatus.InProgress,
            "success" => SyncStatus.Success,
            _ => (SyncStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SyncStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SyncStatus.FailedAuth => "failed_auth",
                SyncStatus.FailedContent => "failed_content",
                SyncStatus.FailedLimits => "failed_limits",
                SyncStatus.FailedTransient => "failed_transient",
                SyncStatus.InProgress => "in_progress",
                SyncStatus.Success => "success",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
