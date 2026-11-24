using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Tests.Models.Beta.Organization.Providers.Google.Projects.DataControls;

public class BetaGoogleManagedProjectStorageFailedCheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectStorageFailedCheck
        {
            Check = Check.BucketSettings,
            Message = "message",
            Role = Role.Ingest,
        };

        ApiEnum<string, Check> expectedCheck = Check.BucketSettings;
        string expectedMessage = "message";
        ApiEnum<string, Role> expectedRole = Role.Ingest;

        Assert.Equal(expectedCheck, model.Check);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGoogleManagedProjectStorageFailedCheck
        {
            Check = Check.BucketSettings,
            Message = "message",
            Role = Role.Ingest,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageFailedCheck>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGoogleManagedProjectStorageFailedCheck
        {
            Check = Check.BucketSettings,
            Message = "message",
            Role = Role.Ingest,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageFailedCheck>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Check> expectedCheck = Check.BucketSettings;
        string expectedMessage = "message";
        ApiEnum<string, Role> expectedRole = Role.Ingest;

        Assert.Equal(expectedCheck, deserialized.Check);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGoogleManagedProjectStorageFailedCheck
        {
            Check = Check.BucketSettings,
            Message = "message",
            Role = Role.Ingest,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGoogleManagedProjectStorageFailedCheck
        {
            Check = Check.BucketSettings,
            Message = "message",
            Role = Role.Ingest,
        };

        BetaGoogleManagedProjectStorageFailedCheck copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckTest : TestBase
{
    [Theory]
    [InlineData(Check.BucketSettings)]
    [InlineData(Check.DeletionPolicy)]
    [InlineData(Check.Encryption)]
    [InlineData(Check.GrantMismatch)]
    [InlineData(Check.KmsKeyRefused)]
    [InlineData(Check.LabelMismatch)]
    [InlineData(Check.LifecycleRules)]
    [InlineData(Check.LocationMismatch)]
    [InlineData(Check.ProbeFailed)]
    [InlineData(Check.ProjectNotVerified)]
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
    [InlineData(Check.BucketSettings, 1657590918, "bucket_settings")]
    [InlineData(Check.DeletionPolicy, 2111554384, "deletion_policy")]
    [InlineData(Check.Encryption, 155610325, "encryption")]
    [InlineData(Check.GrantMismatch, 1507018151, "grant_mismatch")]
    [InlineData(Check.KmsKeyRefused, 657600060, "kms_key_refused")]
    [InlineData(Check.LabelMismatch, 1449240828, "label_mismatch")]
    [InlineData(Check.LifecycleRules, 109828570, "lifecycle_rules")]
    [InlineData(Check.LocationMismatch, 1331180689, "location_mismatch")]
    [InlineData(Check.ProbeFailed, 216284840, "probe_failed")]
    [InlineData(Check.ProjectNotVerified, 475678660, "project_not_verified")]
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
