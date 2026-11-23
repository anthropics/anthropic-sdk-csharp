using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class BetaExternalStorageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaExternalStorage
        {
            ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "display_name",
            ProviderConfig = new BetaAwsExternalStorageConfig()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            SetupTemplateVersion = "2",
            Status = new BetaPendingConfigurationExternalStorageStatus(),
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
        };

        string expectedID = "estrg_01SDCCSbTxrXDpWc1phhtcfK";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDisplayName = "display_name";
        BetaExternalStorageProviderConfig expectedProviderConfig =
            new BetaAwsExternalStorageConfig()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            };
        string expectedSetupTemplateVersion = "2";
        Status expectedStatus = new BetaPendingConfigurationExternalStorageStatus();
        JsonElement expectedType = JsonSerializer.SerializeToElement("external_storage");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedUserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedProviderConfig, model.ProviderConfig);
        Assert.Equal(expectedSetupTemplateVersion, model.SetupTemplateVersion);
        Assert.Equal(expectedStatus, model.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUserProfileID, model.UserProfileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaExternalStorage
        {
            ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "display_name",
            ProviderConfig = new BetaAwsExternalStorageConfig()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            SetupTemplateVersion = "2",
            Status = new BetaPendingConfigurationExternalStorageStatus(),
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalStorage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaExternalStorage
        {
            ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "display_name",
            ProviderConfig = new BetaAwsExternalStorageConfig()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            SetupTemplateVersion = "2",
            Status = new BetaPendingConfigurationExternalStorageStatus(),
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalStorage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "estrg_01SDCCSbTxrXDpWc1phhtcfK";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDisplayName = "display_name";
        BetaExternalStorageProviderConfig expectedProviderConfig =
            new BetaAwsExternalStorageConfig()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            };
        string expectedSetupTemplateVersion = "2";
        Status expectedStatus = new BetaPendingConfigurationExternalStorageStatus();
        JsonElement expectedType = JsonSerializer.SerializeToElement("external_storage");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedUserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedProviderConfig, deserialized.ProviderConfig);
        Assert.Equal(expectedSetupTemplateVersion, deserialized.SetupTemplateVersion);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUserProfileID, deserialized.UserProfileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaExternalStorage
        {
            ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "display_name",
            ProviderConfig = new BetaAwsExternalStorageConfig()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            SetupTemplateVersion = "2",
            Status = new BetaPendingConfigurationExternalStorageStatus(),
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaExternalStorage
        {
            ID = "estrg_01SDCCSbTxrXDpWc1phhtcfK",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "display_name",
            ProviderConfig = new BetaAwsExternalStorageConfig()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            SetupTemplateVersion = "2",
            Status = new BetaPendingConfigurationExternalStorageStatus(),
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
        };

        BetaExternalStorage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaExternalStorageProviderConfigTest : TestBase
{
    [Fact]
    public void BetaAwsExternalStorageValidationWorks()
    {
        BetaExternalStorageProviderConfig value = new BetaAwsExternalStorageConfig()
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };
        value.Validate();
    }

    [Fact]
    public void BetaGcpExternalStorageValidationWorks()
    {
        BetaExternalStorageProviderConfig value = new BetaGcpExternalStorageConfig()
        {
            BucketName = "acme-safety-retention",
            ProjectNumber = "123456789012",
            Region = "us-east5",
        };
        value.Validate();
    }

    [Fact]
    public void BetaAwsExternalStorageSerializationRoundtripWorks()
    {
        BetaExternalStorageProviderConfig value = new BetaAwsExternalStorageConfig()
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalStorageProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaGcpExternalStorageSerializationRoundtripWorks()
    {
        BetaExternalStorageProviderConfig value = new BetaGcpExternalStorageConfig()
        {
            BucketName = "acme-safety-retention",
            ProjectNumber = "123456789012",
            Region = "us-east5",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaExternalStorageProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaAwsExternalStorageTypeWorks()
    {
        BetaExternalStorageProviderConfig value = new BetaAwsExternalStorageConfig()
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };
        Assert.Equal(BetaExternalStorageProviderConfigType.Aws, value.Type.Value());
    }

    [Fact]
    public void BetaGcpExternalStorageTypeWorks()
    {
        BetaExternalStorageProviderConfig value = new BetaGcpExternalStorageConfig()
        {
            BucketName = "acme-safety-retention",
            ProjectNumber = "123456789012",
            Region = "us-east5",
        };
        Assert.Equal(BetaExternalStorageProviderConfigType.Gcp, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaExternalStorageProviderConfig value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "bucket_name": "acme-safety-retention",
                  "region": "us-east-2",
                  "type": "aws"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedBucketName = "acme-safety-retention";
        string expectedRegion = "us-east-2";
        ApiEnum<string, BetaExternalStorageProviderConfigType> expectedType =
            BetaExternalStorageProviderConfigType.Aws;

        Assert.Equal(expectedBucketName, value.BucketName);
        Assert.Equal(expectedRegion, value.Region);
        Assert.Equal(expectedType, value.Type);

        BetaExternalStorageProviderConfig emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.BucketName);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Region);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaExternalStorageProviderConfig mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "bucket_name": [
                    "invalid"
                  ],
                  "region": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.BucketName);
        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.Region);
    }
}

public class BetaExternalStorageProviderConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaExternalStorageProviderConfigType.Aws)]
    [InlineData(BetaExternalStorageProviderConfigType.Gcp)]
    public void Validation_Works(BetaExternalStorageProviderConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaExternalStorageProviderConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaExternalStorageProviderConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaExternalStorageProviderConfigType.Aws, 1206082585, "aws")]
    [InlineData(BetaExternalStorageProviderConfigType.Gcp, 1474161881, "gcp")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaExternalStorageProviderConfigType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaExternalStorageProviderConfigType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaExternalStorageProviderConfigType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaExternalStorageProviderConfigType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaExternalStorageProviderConfigType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Fact]
    public void BetaPendingConfigurationExternalStorageValidationWorks()
    {
        Status value = new BetaPendingConfigurationExternalStorageStatus();
        value.Validate();
    }

    [Fact]
    public void BetaAvailableExternalStorageValidationWorks()
    {
        Status value = new BetaAvailableExternalStorageStatus()
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };
        value.Validate();
    }

    [Fact]
    public void BetaActiveExternalStorageValidationWorks()
    {
        Status value = new BetaActiveExternalStorageStatus()
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };
        value.Validate();
    }

    [Fact]
    public void BetaDrainingExternalStorageValidationWorks()
    {
        Status value = new BetaDrainingExternalStorageStatus()
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RemovalStarted = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaPendingConfigurationExternalStorageSerializationRoundtripWorks()
    {
        Status value = new BetaPendingConfigurationExternalStorageStatus();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaAvailableExternalStorageSerializationRoundtripWorks()
    {
        Status value = new BetaAvailableExternalStorageStatus()
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaActiveExternalStorageSerializationRoundtripWorks()
    {
        Status value = new BetaActiveExternalStorageStatus()
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaDrainingExternalStorageSerializationRoundtripWorks()
    {
        Status value = new BetaDrainingExternalStorageStatus()
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RemovalStarted = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPendingConfigurationExternalStorageTypeWorks()
    {
        Status value = new BetaPendingConfigurationExternalStorageStatus();
        Assert.Equal(StatusType.PendingConfiguration, value.Type.Value());
    }

    [Fact]
    public void BetaAvailableExternalStorageTypeWorks()
    {
        Status value = new BetaAvailableExternalStorageStatus()
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };
        Assert.Equal(StatusType.Available, value.Type.Value());
    }

    [Fact]
    public void BetaActiveExternalStorageTypeWorks()
    {
        Status value = new BetaActiveExternalStorageStatus()
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };
        Assert.Equal(StatusType.Active, value.Type.Value());
    }

    [Fact]
    public void BetaDrainingExternalStorageTypeWorks()
    {
        Status value = new BetaDrainingExternalStorageStatus()
        {
            Healthy = true,
            LastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RemovalStarted = true,
        };
        Assert.Equal(StatusType.Draining, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Status value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "pending_configuration",
                  "healthy": true,
                  "last_checked_at": "2024-10-30T23:58:27.427722Z"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, StatusType> expectedType = StatusType.PendingConfiguration;
        bool expectedHealthy = true;
        DateTimeOffset expectedLastCheckedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedHealthy, value.Healthy);
        Assert.Equal(expectedLastCheckedAt, value.LastCheckedAt);

        Status emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Healthy);
        Assert.Null(emptyValue.LastCheckedAt);

        Status mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "healthy": [
                    "invalid"
                  ],
                  "last_checked_at": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.Healthy);
        Assert.Null(mismatchedValue.LastCheckedAt);
    }
}

public class StatusTypeTest : TestBase
{
    [Theory]
    [InlineData(StatusType.PendingConfiguration)]
    [InlineData(StatusType.Available)]
    [InlineData(StatusType.Active)]
    [InlineData(StatusType.Draining)]
    public void Validation_Works(StatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StatusType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StatusType.PendingConfiguration, 1530210094, "pending_configuration")]
    [InlineData(StatusType.Available, 1169705318, "available")]
    [InlineData(StatusType.Active, 1837619551, "active")]
    [InlineData(StatusType.Draining, 55463168, "draining")]
    public void EnumMemberSerializationRoundtrip_Works(
        StatusType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StatusType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StatusType>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, StatusType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StatusType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
