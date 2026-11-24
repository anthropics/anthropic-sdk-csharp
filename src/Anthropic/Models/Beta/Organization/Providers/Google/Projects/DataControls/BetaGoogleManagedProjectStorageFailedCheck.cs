using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// One check that a verification attempt failed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectStorageFailedCheck,
        BetaGoogleManagedProjectStorageFailedCheckFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectStorageFailedCheck : JsonModel
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
    /// What failed and, where you can fix it, what to change.
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

    public BetaGoogleManagedProjectStorageFailedCheck() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectStorageFailedCheck(
        BetaGoogleManagedProjectStorageFailedCheck betaGoogleManagedProjectStorageFailedCheck
    )
        : base(betaGoogleManagedProjectStorageFailedCheck) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectStorageFailedCheck(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectStorageFailedCheck(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectStorageFailedCheckFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectStorageFailedCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectStorageFailedCheckFromRaw
    : IFromRawJson<BetaGoogleManagedProjectStorageFailedCheck>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectStorageFailedCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectStorageFailedCheck.FromRawUnchecked(rawData);
}

/// <summary>
/// Which check failed, such as `label_mismatch` or `grant_mismatch`. Anthropic may
/// add values.
/// </summary>
[JsonConverter(typeof(CheckConverter))]
public enum Check
{
    BucketSettings = 1657590918,
    DeletionPolicy = 2111554384,
    Encryption = 155610325,
    GrantMismatch = 1507018151,
    KmsKeyRefused = 657600060,
    LabelMismatch = 1449240828,
    LifecycleRules = 109828570,
    LocationMismatch = 1331180689,
    ProbeFailed = 216284840,
    ProjectNotVerified = 475678660,
    Versioning = 881011824,
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
            "bucket_settings" => Check.BucketSettings,
            "deletion_policy" => Check.DeletionPolicy,
            "encryption" => Check.Encryption,
            "grant_mismatch" => Check.GrantMismatch,
            "kms_key_refused" => Check.KmsKeyRefused,
            "label_mismatch" => Check.LabelMismatch,
            "lifecycle_rules" => Check.LifecycleRules,
            "location_mismatch" => Check.LocationMismatch,
            "probe_failed" => Check.ProbeFailed,
            "project_not_verified" => Check.ProjectNotVerified,
            "versioning" => Check.Versioning,
            _ => (Check)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Check value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Check.BucketSettings => "bucket_settings",
                Check.DeletionPolicy => "deletion_policy",
                Check.Encryption => "encryption",
                Check.GrantMismatch => "grant_mismatch",
                Check.KmsKeyRefused => "kms_key_refused",
                Check.LabelMismatch => "label_mismatch",
                Check.LifecycleRules => "lifecycle_rules",
                Check.LocationMismatch => "location_mismatch",
                Check.ProbeFailed => "probe_failed",
                Check.ProjectNotVerified => "project_not_verified",
                Check.Versioning => "versioning",
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
    Maintenance = 1316237503,
    MediaErasure = 81864433,
    Read = 932916289,
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
            "maintenance" => Role.Maintenance,
            "media_erasure" => Role.MediaErasure,
            "read" => Role.Read,
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
                Role.Maintenance => "maintenance",
                Role.MediaErasure => "media_erasure",
                Role.Read => "read",
                Role.Verify => "verify",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
