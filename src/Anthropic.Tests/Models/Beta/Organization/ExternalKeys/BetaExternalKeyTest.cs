using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalKeys;

public class BetaExternalKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaExternalKey
        {
            ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Attachment = new BetaExternalKeyAttachedAttachment(),
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "prod-us-key",
            Geo = "us",
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string expectedID = "ekey_01SDCCSbTxrXDpWc1phhtcfK";
        Attachment expectedAttachment = new BetaExternalKeyAttachedAttachment();
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDisplayName = "prod-us-key";
        string expectedGeo = "us";
        BetaExternalKeyProviderConfig expectedProviderConfig = new BetaAwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
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
        var model = new BetaExternalKey
        {
            ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Attachment = new BetaExternalKeyAttachedAttachment(),
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "prod-us-key",
            Geo = "us",
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaExternalKey
        {
            ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Attachment = new BetaExternalKeyAttachedAttachment(),
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "prod-us-key",
            Geo = "us",
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "ekey_01SDCCSbTxrXDpWc1phhtcfK";
        Attachment expectedAttachment = new BetaExternalKeyAttachedAttachment();
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDisplayName = "prod-us-key";
        string expectedGeo = "us";
        BetaExternalKeyProviderConfig expectedProviderConfig = new BetaAwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
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
        var model = new BetaExternalKey
        {
            ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Attachment = new BetaExternalKeyAttachedAttachment(),
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "prod-us-key",
            Geo = "us",
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaExternalKey
        {
            ID = "ekey_01SDCCSbTxrXDpWc1phhtcfK",
            Attachment = new BetaExternalKeyAttachedAttachment(),
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "prod-us-key",
            Geo = "us",
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        BetaExternalKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttachmentTest : TestBase
{
    [Fact]
    public void BetaExternalKeyAttachedValidationWorks()
    {
        Attachment value = new BetaExternalKeyAttachedAttachment();
        value.Validate();
    }

    [Fact]
    public void BetaExternalKeyUnattachedValidationWorks()
    {
        Attachment value = new BetaExternalKeyUnattachedAttachment();
        value.Validate();
    }

    [Fact]
    public void BetaExternalKeyAttachedSerializationRoundtripWorks()
    {
        Attachment value = new BetaExternalKeyAttachedAttachment();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attachment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaExternalKeyUnattachedSerializationRoundtripWorks()
    {
        Attachment value = new BetaExternalKeyUnattachedAttachment();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attachment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaExternalKeyAttachedTypeWorks()
    {
        Attachment value = new BetaExternalKeyAttachedAttachment();
        Assert.Equal(AttachmentType.Attached, value.Type.Value());
    }

    [Fact]
    public void BetaExternalKeyUnattachedTypeWorks()
    {
        Attachment value = new BetaExternalKeyUnattachedAttachment();
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

public class BetaExternalKeyProviderConfigTest : TestBase
{
    [Fact]
    public void BetaAwsExternalKeyValidationWorks()
    {
        BetaExternalKeyProviderConfig value = new BetaAwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
        };
        value.Validate();
    }

    [Fact]
    public void BetaGcpExternalKeyValidationWorks()
    {
        BetaExternalKeyProviderConfig value = new BetaGcpExternalKeyConfig(
            "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key"
        );
        value.Validate();
    }

    [Fact]
    public void BetaAzureExternalKeyValidationWorks()
    {
        BetaExternalKeyProviderConfig value = new BetaAzureExternalKeyConfig()
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };
        value.Validate();
    }

    [Fact]
    public void BetaAwsExternalKeySerializationRoundtripWorks()
    {
        BetaExternalKeyProviderConfig value = new BetaAwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalKeyProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaGcpExternalKeySerializationRoundtripWorks()
    {
        BetaExternalKeyProviderConfig value = new BetaGcpExternalKeyConfig(
            "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalKeyProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaAzureExternalKeySerializationRoundtripWorks()
    {
        BetaExternalKeyProviderConfig value = new BetaAzureExternalKeyConfig()
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalKeyProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaAwsExternalKeyTypeWorks()
    {
        BetaExternalKeyProviderConfig value = new BetaAwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
        };
        Assert.Equal(BetaExternalKeyProviderConfigType.Aws, value.Type.Value());
    }

    [Fact]
    public void BetaGcpExternalKeyTypeWorks()
    {
        BetaExternalKeyProviderConfig value = new BetaGcpExternalKeyConfig(
            "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key"
        );
        Assert.Equal(BetaExternalKeyProviderConfigType.Gcp, value.Type.Value());
    }

    [Fact]
    public void BetaAzureExternalKeyTypeWorks()
    {
        BetaExternalKeyProviderConfig value = new BetaAzureExternalKeyConfig()
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };
        Assert.Equal(BetaExternalKeyProviderConfigType.Azure, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaExternalKeyProviderConfig value = new(
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

        ApiEnum<string, BetaExternalKeyProviderConfigType> expectedType =
            BetaExternalKeyProviderConfigType.Aws;
        string expectedKeyName = "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedKeyName, value.KeyName);

        BetaExternalKeyProviderConfig emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.KeyName);

        BetaExternalKeyProviderConfig mismatchedValue = new(
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

public class BetaExternalKeyProviderConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaExternalKeyProviderConfigType.Aws)]
    [InlineData(BetaExternalKeyProviderConfigType.Gcp)]
    [InlineData(BetaExternalKeyProviderConfigType.Azure)]
    public void Validation_Works(BetaExternalKeyProviderConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaExternalKeyProviderConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaExternalKeyProviderConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaExternalKeyProviderConfigType.Aws)]
    [InlineData(BetaExternalKeyProviderConfigType.Gcp)]
    [InlineData(BetaExternalKeyProviderConfigType.Azure)]
    public void SerializationRoundtrip_Works(BetaExternalKeyProviderConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaExternalKeyProviderConfigType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaExternalKeyProviderConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaExternalKeyProviderConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaExternalKeyProviderConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
