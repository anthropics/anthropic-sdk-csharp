using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Organization.ExternalKeys;

public class ExternalKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalKey
        {
            ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Attachment = new ExternalKeyAttachedAttachment(),
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "prod-us-key",
            Geo = "us",
            ProviderConfig = new AwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string expectedID = "ekey_01SDCCSbTxrXDpWc1phhtcfK";
        Attachment expectedAttachment = new ExternalKeyAttachedAttachment();
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDisplayName = "prod-us-key";
        string expectedGeo = "us";
        ExternalKeyProviderConfig expectedProviderConfig = new AwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("external_key");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttachment, model.Attachment);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedGeo, model.Geo);
        Assert.Equal(expectedProviderConfig, model.ProviderConfig);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExternalKey
        {
            ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Attachment = new ExternalKeyAttachedAttachment(),
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "prod-us-key",
            Geo = "us",
            ProviderConfig = new AwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalKey
        {
            ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Attachment = new ExternalKeyAttachedAttachment(),
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "prod-us-key",
            Geo = "us",
            ProviderConfig = new AwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "ekey_01SDCCSbTxrXDpWc1phhtcfK";
        Attachment expectedAttachment = new ExternalKeyAttachedAttachment();
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDisplayName = "prod-us-key";
        string expectedGeo = "us";
        ExternalKeyProviderConfig expectedProviderConfig = new AwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("external_key");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttachment, deserialized.Attachment);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedGeo, deserialized.Geo);
        Assert.Equal(expectedProviderConfig, deserialized.ProviderConfig);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExternalKey
        {
            ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Attachment = new ExternalKeyAttachedAttachment(),
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "prod-us-key",
            Geo = "us",
            ProviderConfig = new AwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExternalKey
        {
            ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Attachment = new ExternalKeyAttachedAttachment(),
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "prod-us-key",
            Geo = "us",
            ProviderConfig = new AwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        ExternalKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttachmentTest : TestBase
{
    [Fact]
    public void ExternalKeyAttachedValidationWorks()
    {
        Attachment value = new ExternalKeyAttachedAttachment();
        value.Validate();
    }

    [Fact]
    public void ExternalKeyUnattachedValidationWorks()
    {
        Attachment value = new ExternalKeyUnattachedAttachment();
        value.Validate();
    }

    [Fact]
    public void ExternalKeyAttachedSerializationRoundtripWorks()
    {
        Attachment value = new ExternalKeyAttachedAttachment();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attachment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExternalKeyUnattachedSerializationRoundtripWorks()
    {
        Attachment value = new ExternalKeyUnattachedAttachment();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attachment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExternalKeyAttachedTypeWorks()
    {
        Attachment value = new ExternalKeyAttachedAttachment();
        Assert.Equal(AttachmentType.Attached, value.Type.Value());
    }

    [Fact]
    public void ExternalKeyUnattachedTypeWorks()
    {
        Attachment value = new ExternalKeyUnattachedAttachment();
        Assert.Equal(AttachmentType.Unattached, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Attachment value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "attached"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, AttachmentType> expectedType = AttachmentType.Attached;

        Assert.Equal(expectedType, value.Type);

        Attachment emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class AttachmentTypeTest : TestBase
{
    [Theory]
    [InlineData(AttachmentType.Attached)]
    [InlineData(AttachmentType.Unattached)]
    public void Validation_Works(AttachmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AttachmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AttachmentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AttachmentType.Attached)]
    [InlineData(AttachmentType.Unattached)]
    public void SerializationRoundtrip_Works(AttachmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AttachmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AttachmentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AttachmentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AttachmentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExternalKeyProviderConfigTest : TestBase
{
    [Fact]
    public void AwsExternalKeyValidationWorks()
    {
        ExternalKeyProviderConfig value = new AwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
        };
        value.Validate();
    }

    [Fact]
    public void GcpExternalKeyValidationWorks()
    {
        ExternalKeyProviderConfig value = new GcpExternalKeyConfig(
            "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key"
        );
        value.Validate();
    }

    [Fact]
    public void AzureExternalKeyValidationWorks()
    {
        ExternalKeyProviderConfig value = new AzureExternalKeyConfig()
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };
        value.Validate();
    }

    [Fact]
    public void AwsExternalKeySerializationRoundtripWorks()
    {
        ExternalKeyProviderConfig value = new AwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GcpExternalKeySerializationRoundtripWorks()
    {
        ExternalKeyProviderConfig value = new GcpExternalKeyConfig(
            "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AzureExternalKeySerializationRoundtripWorks()
    {
        ExternalKeyProviderConfig value = new AzureExternalKeyConfig()
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AwsExternalKeyTypeWorks()
    {
        ExternalKeyProviderConfig value = new AwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
        };
        Assert.Equal(ExternalKeyProviderConfigType.Aws, value.Type.Value());
    }

    [Fact]
    public void GcpExternalKeyTypeWorks()
    {
        ExternalKeyProviderConfig value = new GcpExternalKeyConfig(
            "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key"
        );
        Assert.Equal(ExternalKeyProviderConfigType.Gcp, value.Type.Value());
    }

    [Fact]
    public void AzureExternalKeyTypeWorks()
    {
        ExternalKeyProviderConfig value = new AzureExternalKeyConfig()
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };
        Assert.Equal(ExternalKeyProviderConfigType.Azure, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ExternalKeyProviderConfig value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "aws",
                  "key_name": "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ExternalKeyProviderConfigType> expectedType =
            ExternalKeyProviderConfigType.Aws;
        string expectedKeyName = "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedKeyName, value.KeyName);

        ExternalKeyProviderConfig emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.KeyName);

        ExternalKeyProviderConfig mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "key_name": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.KeyName);
    }
}

public class ExternalKeyProviderConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(ExternalKeyProviderConfigType.Aws)]
    [InlineData(ExternalKeyProviderConfigType.Gcp)]
    [InlineData(ExternalKeyProviderConfigType.Azure)]
    public void Validation_Works(ExternalKeyProviderConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalKeyProviderConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExternalKeyProviderConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExternalKeyProviderConfigType.Aws)]
    [InlineData(ExternalKeyProviderConfigType.Gcp)]
    [InlineData(ExternalKeyProviderConfigType.Azure)]
    public void SerializationRoundtrip_Works(ExternalKeyProviderConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalKeyProviderConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalKeyProviderConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExternalKeyProviderConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalKeyProviderConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
