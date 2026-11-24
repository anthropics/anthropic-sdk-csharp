using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// One check that a verification attempt failed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedStorageFailedCheck,
        BetaGoogleManagedStorageFailedCheckFromRaw
    >)
)]
public sealed record class BetaGoogleManagedStorageFailedCheck : JsonModel
{
    /// <summary>
    /// Which check failed, such as `label_mismatch` or `grant_mismatch`. Anthropic
    /// may add values.
    /// </summary>
    public required ApiEnum<string, Check> Check
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Check>>("check");
        }
        init { this._rawData.Set("check", value); }
    }

    /// <summary>
    /// What failed and, where the end customer can fix it, what to change.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// On a check about one of the accounts that Anthropic uses to reach the bucket,
    /// that account's kind of access, such as `ingest`. `null` on any other check.
    /// Anthropic may add values.
    /// </summary>
    public required ApiEnum<string, Role>? Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Role>>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Check.Validate();
        _ = this.Message;
        this.Role?.Validate();
    }

    public BetaGoogleManagedStorageFailedCheck() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedStorageFailedCheck(
        BetaGoogleManagedStorageFailedCheck betaGoogleManagedStorageFailedCheck
    )
        : base(betaGoogleManagedStorageFailedCheck) { }
#pragma warning restore CS8618

    public BetaGoogleManagedStorageFailedCheck(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedStorageFailedCheck(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedStorageFailedCheckFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedStorageFailedCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedStorageFailedCheckFromRaw : IFromRawJson<BetaGoogleManagedStorageFailedCheck>
{
    /// <inheritdoc/>
    public BetaGoogleManagedStorageFailedCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedStorageFailedCheck.FromRawUnchecked(rawData);
}

/// <summary>
/// Which check failed, such as `label_mismatch` or `grant_mismatch`. Anthropic may
/// add values.
/// </summary>
[JsonConverter(typeof(CheckConverter))]
public enum Check
{
    LabelMismatch = 1449240828,
    LocationMismatch = 1331180689,
    Encryption = 155610325,
    Versioning = 881011824,
    BucketSettings = 1657590918,
    LifecycleRules = 109828570,
    DeletionPolicy = 2111554384,
    GrantMismatch = 1507018151,
    KmsKeyRefused = 657600060,
    ProbeFailed = 216284840,
    ProjectNotVerified = 475678660,
}

sealed class CheckConverter : JsonConverter<Check>
{
    public override Check Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "label_mismatch" => Check.LabelMismatch,
            "location_mismatch" => Check.LocationMismatch,
            "encryption" => Check.Encryption,
            "versioning" => Check.Versioning,
            "bucket_settings" => Check.BucketSettings,
            "lifecycle_rules" => Check.LifecycleRules,
            "deletion_policy" => Check.DeletionPolicy,
            "grant_mismatch" => Check.GrantMismatch,
            "kms_key_refused" => Check.KmsKeyRefused,
            "probe_failed" => Check.ProbeFailed,
            "project_not_verified" => Check.ProjectNotVerified,
            _ => (Check)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Check value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Check.LabelMismatch => "label_mismatch",
                Check.LocationMismatch => "location_mismatch",
                Check.Encryption => "encryption",
                Check.Versioning => "versioning",
                Check.BucketSettings => "bucket_settings",
                Check.LifecycleRules => "lifecycle_rules",
                Check.DeletionPolicy => "deletion_policy",
                Check.GrantMismatch => "grant_mismatch",
                Check.KmsKeyRefused => "kms_key_refused",
                Check.ProbeFailed => "probe_failed",
                Check.ProjectNotVerified => "project_not_verified",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// On a check about one of the accounts that Anthropic uses to reach the bucket,
/// that account's kind of access, such as `ingest`. `null` on any other check. Anthropic
/// may add values.
/// </summary>
[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    Ingest = 218075399,
    Read = 932916289,
    Maintenance = 1316237503,
    MediaErasure = 81864433,
    Verify = 1153841761,
}

sealed class RoleConverter : JsonConverter<Role>
{
    public override Role Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ingest" => Role.Ingest,
            "read" => Role.Read,
            "maintenance" => Role.Maintenance,
            "media_erasure" => Role.MediaErasure,
            "verify" => Role.Verify,
            _ => (Role)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Role.Ingest => "ingest",
                Role.Read => "read",
                Role.Maintenance => "maintenance",
                Role.MediaErasure => "media_erasure",
                Role.Verify => "verify",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
