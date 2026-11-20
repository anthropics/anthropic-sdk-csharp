using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// One check that an External Storage's verification failed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaExternalStorageFailedCheck,
        BetaExternalStorageFailedCheckFromRaw
    >)
)]
public sealed record class BetaExternalStorageFailedCheck : JsonModel
{
    /// <summary>
    /// Name of the check that failed, such as `versioning`, for code to branch on.
    /// New names may be added; `other` is a check this API does not name. The value
    /// is a name with no data of its own.
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
    /// What failed and how to fix it, in plain words.
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
    /// The part of your access grant that the check is about, such as `ingest`:
    /// on AWS, one of the IAM roles your setup created; on Google Cloud, the grant
    /// to one of Anthropic's service accounts. `null` when the check is not about
    /// one. New names may be added. The value is a name with no data of its own.
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

    public BetaExternalStorageFailedCheck() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaExternalStorageFailedCheck(
        BetaExternalStorageFailedCheck betaExternalStorageFailedCheck
    )
        : base(betaExternalStorageFailedCheck) { }
#pragma warning restore CS8618

    public BetaExternalStorageFailedCheck(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaExternalStorageFailedCheck(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaExternalStorageFailedCheckFromRaw.FromRawUnchecked"/>
    public static BetaExternalStorageFailedCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaExternalStorageFailedCheckFromRaw : IFromRawJson<BetaExternalStorageFailedCheck>
{
    /// <inheritdoc/>
    public BetaExternalStorageFailedCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaExternalStorageFailedCheck.FromRawUnchecked(rawData);
}

/// <summary>
/// Name of the check that failed, such as `versioning`, for code to branch on. New
/// names may be added; `other` is a check this API does not name. The value is a
/// name with no data of its own.
/// </summary>
[JsonConverter(typeof(CheckConverter))]
public enum Check
{
    AlreadyRegistered = 158631525,
    AssumeRole = 1876443489,
    BucketEmpty = 1305928207,
    BucketNotConfirmed = 918755258,
    BucketPolicy = 2107579761,
    BucketSettings = 1657590918,
    DefaultEncryption = 1440153394,
    DeletionPolicy = 2111554384,
    Encryption = 155610325,
    GrantMismatch = 1507018151,
    KeyUsable = 543887558,
    KmsKeyRefused = 657600060,
    LifecycleNoArchive = 1468715562,
    LifecycleRules = 109828570,
    LifecycleTemplate = 911074938,
    LocationMismatch = 1331180689,
    ObjectLock = 1997137606,
    Other = 1780768880,
    OwnershipEnforced = 470671988,
    ProbeFailed = 216284840,
    ProbeObject = 1261609273,
    ProbeStorageClass = 368703233,
    PublicAccessBlock = 1382841879,
    Region = 963164134,
    Replication = 1407178793,
    RequestMetrics = 983592317,
    RequestPayment = 1428016388,
    TranscriptsSupport = 1529386364,
    TrustIngestRole = 398482245,
    TrustMaintenanceRole = 180404381,
    TrustMediaErasureRole = 658773160,
    TrustReadRole = 906687371,
    TrustTranscriptsRole = 1409503030,
    TrustTranscriptsVerifyRole = 1902907409,
    TrustVerifyRole = 1263153200,
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
            "already_registered" => Check.AlreadyRegistered,
            "assume_role" => Check.AssumeRole,
            "bucket_empty" => Check.BucketEmpty,
            "bucket_not_confirmed" => Check.BucketNotConfirmed,
            "bucket_policy" => Check.BucketPolicy,
            "bucket_settings" => Check.BucketSettings,
            "default_encryption" => Check.DefaultEncryption,
            "deletion_policy" => Check.DeletionPolicy,
            "encryption" => Check.Encryption,
            "grant_mismatch" => Check.GrantMismatch,
            "key_usable" => Check.KeyUsable,
            "kms_key_refused" => Check.KmsKeyRefused,
            "lifecycle_no_archive" => Check.LifecycleNoArchive,
            "lifecycle_rules" => Check.LifecycleRules,
            "lifecycle_template" => Check.LifecycleTemplate,
            "location_mismatch" => Check.LocationMismatch,
            "object_lock" => Check.ObjectLock,
            "other" => Check.Other,
            "ownership_enforced" => Check.OwnershipEnforced,
            "probe_failed" => Check.ProbeFailed,
            "probe_object" => Check.ProbeObject,
            "probe_storage_class" => Check.ProbeStorageClass,
            "public_access_block" => Check.PublicAccessBlock,
            "region" => Check.Region,
            "replication" => Check.Replication,
            "request_metrics" => Check.RequestMetrics,
            "request_payment" => Check.RequestPayment,
            "transcripts_support" => Check.TranscriptsSupport,
            "trust_ingest_role" => Check.TrustIngestRole,
            "trust_maintenance_role" => Check.TrustMaintenanceRole,
            "trust_media_erasure_role" => Check.TrustMediaErasureRole,
            "trust_read_role" => Check.TrustReadRole,
            "trust_transcripts_role" => Check.TrustTranscriptsRole,
            "trust_transcripts_verify_role" => Check.TrustTranscriptsVerifyRole,
            "trust_verify_role" => Check.TrustVerifyRole,
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
                Check.AlreadyRegistered => "already_registered",
                Check.AssumeRole => "assume_role",
                Check.BucketEmpty => "bucket_empty",
                Check.BucketNotConfirmed => "bucket_not_confirmed",
                Check.BucketPolicy => "bucket_policy",
                Check.BucketSettings => "bucket_settings",
                Check.DefaultEncryption => "default_encryption",
                Check.DeletionPolicy => "deletion_policy",
                Check.Encryption => "encryption",
                Check.GrantMismatch => "grant_mismatch",
                Check.KeyUsable => "key_usable",
                Check.KmsKeyRefused => "kms_key_refused",
                Check.LifecycleNoArchive => "lifecycle_no_archive",
                Check.LifecycleRules => "lifecycle_rules",
                Check.LifecycleTemplate => "lifecycle_template",
                Check.LocationMismatch => "location_mismatch",
                Check.ObjectLock => "object_lock",
                Check.Other => "other",
                Check.OwnershipEnforced => "ownership_enforced",
                Check.ProbeFailed => "probe_failed",
                Check.ProbeObject => "probe_object",
                Check.ProbeStorageClass => "probe_storage_class",
                Check.PublicAccessBlock => "public_access_block",
                Check.Region => "region",
                Check.Replication => "replication",
                Check.RequestMetrics => "request_metrics",
                Check.RequestPayment => "request_payment",
                Check.TranscriptsSupport => "transcripts_support",
                Check.TrustIngestRole => "trust_ingest_role",
                Check.TrustMaintenanceRole => "trust_maintenance_role",
                Check.TrustMediaErasureRole => "trust_media_erasure_role",
                Check.TrustReadRole => "trust_read_role",
                Check.TrustTranscriptsRole => "trust_transcripts_role",
                Check.TrustTranscriptsVerifyRole => "trust_transcripts_verify_role",
                Check.TrustVerifyRole => "trust_verify_role",
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
/// The part of your access grant that the check is about, such as `ingest`: on AWS,
/// one of the IAM roles your setup created; on Google Cloud, the grant to one of
/// Anthropic's service accounts. `null` when the check is not about one. New names
/// may be added. The value is a name with no data of its own.
/// </summary>
[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    Ingest = 218075399,
    Maintenance = 1316237503,
    MediaErasure = 81864433,
    Read = 932916289,
    Transcripts = 2100993259,
    TranscriptsVerify = 1063069548,
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
            "transcripts" => Role.Transcripts,
            "transcripts_verify" => Role.TranscriptsVerify,
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
                Role.Transcripts => "transcripts",
                Role.TranscriptsVerify => "transcripts_verify",
                Role.Verify => "verify",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
