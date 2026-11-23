using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class BetaExternalStorageFailedCheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaExternalStorageFailedCheck
        {
            Check = Check.AlreadyRegistered,
            Message = "message",
            Role = Role.Ingest,
        };

        ApiEnum<string, Check> expectedCheck = Check.AlreadyRegistered;
        string expectedMessage = "message";
        ApiEnum<string, Role> expectedRole = Role.Ingest;

        Assert.Equal(expectedCheck, model.Check);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaExternalStorageFailedCheck
        {
            Check = Check.AlreadyRegistered,
            Message = "message",
            Role = Role.Ingest,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalStorageFailedCheck>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaExternalStorageFailedCheck
        {
            Check = Check.AlreadyRegistered,
            Message = "message",
            Role = Role.Ingest,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalStorageFailedCheck>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Check> expectedCheck = Check.AlreadyRegistered;
        string expectedMessage = "message";
        ApiEnum<string, Role> expectedRole = Role.Ingest;

        Assert.Equal(expectedCheck, deserialized.Check);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaExternalStorageFailedCheck
        {
            Check = Check.AlreadyRegistered,
            Message = "message",
            Role = Role.Ingest,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaExternalStorageFailedCheck
        {
            Check = Check.AlreadyRegistered,
            Message = "message",
            Role = Role.Ingest,
        };

        BetaExternalStorageFailedCheck copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckTest : TestBase
{
    [Theory]
    [InlineData(Check.AlreadyRegistered)]
    [InlineData(Check.AssumeRole)]
    [InlineData(Check.BucketEmpty)]
    [InlineData(Check.BucketNotConfirmed)]
    [InlineData(Check.BucketPolicy)]
    [InlineData(Check.BucketSettings)]
    [InlineData(Check.DefaultEncryption)]
    [InlineData(Check.DeletionPolicy)]
    [InlineData(Check.Encryption)]
    [InlineData(Check.GrantMismatch)]
    [InlineData(Check.KeyUsable)]
    [InlineData(Check.KmsKeyRefused)]
    [InlineData(Check.LifecycleNoArchive)]
    [InlineData(Check.LifecycleRules)]
    [InlineData(Check.LifecycleTemplate)]
    [InlineData(Check.LocationMismatch)]
    [InlineData(Check.ObjectLock)]
    [InlineData(Check.Other)]
    [InlineData(Check.OwnershipEnforced)]
    [InlineData(Check.ProbeFailed)]
    [InlineData(Check.ProbeObject)]
    [InlineData(Check.ProbeStorageClass)]
    [InlineData(Check.PublicAccessBlock)]
    [InlineData(Check.Region)]
    [InlineData(Check.Replication)]
    [InlineData(Check.RequestMetrics)]
    [InlineData(Check.RequestPayment)]
    [InlineData(Check.TranscriptsSupport)]
    [InlineData(Check.TrustIngestRole)]
    [InlineData(Check.TrustMaintenanceRole)]
    [InlineData(Check.TrustMediaErasureRole)]
    [InlineData(Check.TrustReadRole)]
    [InlineData(Check.TrustTranscriptsRole)]
    [InlineData(Check.TrustTranscriptsVerifyRole)]
    [InlineData(Check.TrustVerifyRole)]
    [InlineData(Check.Versioning)]
    public void Validation_Works(Check rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Check> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Check>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Check.AlreadyRegistered, 158631525, "already_registered")]
    [InlineData(Check.AssumeRole, 1876443489, "assume_role")]
    [InlineData(Check.BucketEmpty, 1305928207, "bucket_empty")]
    [InlineData(Check.BucketNotConfirmed, 918755258, "bucket_not_confirmed")]
    [InlineData(Check.BucketPolicy, 2107579761, "bucket_policy")]
    [InlineData(Check.BucketSettings, 1657590918, "bucket_settings")]
    [InlineData(Check.DefaultEncryption, 1440153394, "default_encryption")]
    [InlineData(Check.DeletionPolicy, 2111554384, "deletion_policy")]
    [InlineData(Check.Encryption, 155610325, "encryption")]
    [InlineData(Check.GrantMismatch, 1507018151, "grant_mismatch")]
    [InlineData(Check.KeyUsable, 543887558, "key_usable")]
    [InlineData(Check.KmsKeyRefused, 657600060, "kms_key_refused")]
    [InlineData(Check.LifecycleNoArchive, 1468715562, "lifecycle_no_archive")]
    [InlineData(Check.LifecycleRules, 109828570, "lifecycle_rules")]
    [InlineData(Check.LifecycleTemplate, 911074938, "lifecycle_template")]
    [InlineData(Check.LocationMismatch, 1331180689, "location_mismatch")]
    [InlineData(Check.ObjectLock, 1997137606, "object_lock")]
    [InlineData(Check.Other, 1780768880, "other")]
    [InlineData(Check.OwnershipEnforced, 470671988, "ownership_enforced")]
    [InlineData(Check.ProbeFailed, 216284840, "probe_failed")]
    [InlineData(Check.ProbeObject, 1261609273, "probe_object")]
    [InlineData(Check.ProbeStorageClass, 368703233, "probe_storage_class")]
    [InlineData(Check.PublicAccessBlock, 1382841879, "public_access_block")]
    [InlineData(Check.Region, 963164134, "region")]
    [InlineData(Check.Replication, 1407178793, "replication")]
    [InlineData(Check.RequestMetrics, 983592317, "request_metrics")]
    [InlineData(Check.RequestPayment, 1428016388, "request_payment")]
    [InlineData(Check.TranscriptsSupport, 1529386364, "transcripts_support")]
    [InlineData(Check.TrustIngestRole, 398482245, "trust_ingest_role")]
    [InlineData(Check.TrustMaintenanceRole, 180404381, "trust_maintenance_role")]
    [InlineData(Check.TrustMediaErasureRole, 658773160, "trust_media_erasure_role")]
    [InlineData(Check.TrustReadRole, 906687371, "trust_read_role")]
    [InlineData(Check.TrustTranscriptsRole, 1409503030, "trust_transcripts_role")]
    [InlineData(Check.TrustTranscriptsVerifyRole, 1902907409, "trust_transcripts_verify_role")]
    [InlineData(Check.TrustVerifyRole, 1263153200, "trust_verify_role")]
    [InlineData(Check.Versioning, 881011824, "versioning")]
    public void EnumMemberSerializationRoundtrip_Works(Check rawValue, int number, string apiValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Check> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Check>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Check>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Check>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.Ingest)]
    [InlineData(Role.Maintenance)]
    [InlineData(Role.MediaErasure)]
    [InlineData(Role.Read)]
    [InlineData(Role.Transcripts)]
    [InlineData(Role.TranscriptsVerify)]
    [InlineData(Role.Verify)]
    public void Validation_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.Ingest, 218075399, "ingest")]
    [InlineData(Role.Maintenance, 1316237503, "maintenance")]
    [InlineData(Role.MediaErasure, 81864433, "media_erasure")]
    [InlineData(Role.Read, 932916289, "read")]
    [InlineData(Role.Transcripts, 2100993259, "transcripts")]
    [InlineData(Role.TranscriptsVerify, 1063069548, "transcripts_verify")]
    [InlineData(Role.Verify, 1153841761, "verify")]
    public void EnumMemberSerializationRoundtrip_Works(Role rawValue, int number, string apiValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
