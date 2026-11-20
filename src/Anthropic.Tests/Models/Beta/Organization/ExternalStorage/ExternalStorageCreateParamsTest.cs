using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class ExternalStorageCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalStorageCreateParams
        {
            ProviderConfig = new BetaAwsExternalStorageConfigParam()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            DisplayName = "x",
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        ProviderConfig expectedProviderConfig = new BetaAwsExternalStorageConfigParam()
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };
        string expectedDisplayName = "x";
        string expectedUserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedProviderConfig, parameters.ProviderConfig);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedUserProfileID, parameters.UserProfileID);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalStorageCreateParams
        {
            ProviderConfig = new BetaAwsExternalStorageConfigParam()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            DisplayName = "x",
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExternalStorageCreateParams
        {
            ProviderConfig = new BetaAwsExternalStorageConfigParam()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            DisplayName = "x",
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new ExternalStorageCreateParams
        {
            ProviderConfig = new BetaAwsExternalStorageConfigParam()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            DisplayName = "x",
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalStorageCreateParams
        {
            ProviderConfig = new BetaAwsExternalStorageConfigParam()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_profile_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExternalStorageCreateParams
        {
            ProviderConfig = new BetaAwsExternalStorageConfigParam()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],

            DisplayName = null,
            UserProfileID = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.UserProfileID);
        Assert.True(parameters.RawBodyData.ContainsKey("user_profile_id"));
    }

    [Fact]
    public void Url_Works()
    {
        ExternalStorageCreateParams parameters = new()
        {
            ProviderConfig = new BetaAwsExternalStorageConfigParam()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/external_storage"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ExternalStorageCreateParams parameters = new()
        {
            ProviderConfig = new BetaAwsExternalStorageConfigParam()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,efs-2026-10-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalStorageCreateParams
        {
            ProviderConfig = new BetaAwsExternalStorageConfigParam()
            {
                AccountID = "111122223333",
                BucketName = "acme-safety-retention",
                Region = "us-east-2",
            },
            DisplayName = "x",
            UserProfileID = "uprof_01SDCCSbTxrXDpWc1phhtcfK",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        ExternalStorageCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProviderConfigTest : TestBase
{
    [Fact]
    public void BetaAwsExternalStorageConfigParamValidationWorks()
    {
        ProviderConfig value = new BetaAwsExternalStorageConfigParam()
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };
        value.Validate();
    }

    [Fact]
    public void BetaGcpExternalStorageConfigParamValidationWorks()
    {
        ProviderConfig value = new BetaGcpExternalStorageConfigParam()
        {
            BucketName = "acme-safety-retention",
            ProjectNumber = "123456789012",
            Region = "us-east5",
        };
        value.Validate();
    }

    [Fact]
    public void BetaAwsExternalStorageConfigParamSerializationRoundtripWorks()
    {
        ProviderConfig value = new BetaAwsExternalStorageConfigParam()
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaGcpExternalStorageConfigParamSerializationRoundtripWorks()
    {
        ProviderConfig value = new BetaGcpExternalStorageConfigParam()
        {
            BucketName = "acme-safety-retention",
            ProjectNumber = "123456789012",
            Region = "us-east5",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaAwsExternalStorageConfigParamTypeWorks()
    {
        ProviderConfig value = new BetaAwsExternalStorageConfigParam()
        {
            AccountID = "111122223333",
            BucketName = "acme-safety-retention",
            Region = "us-east-2",
        };
        Assert.Equal(ProviderConfigType.Aws, value.Type.Value());
    }

    [Fact]
    public void BetaGcpExternalStorageConfigParamTypeWorks()
    {
        ProviderConfig value = new BetaGcpExternalStorageConfigParam()
        {
            BucketName = "acme-safety-retention",
            ProjectNumber = "123456789012",
            Region = "us-east5",
        };
        Assert.Equal(ProviderConfigType.Gcp, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ProviderConfig value = new(
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
        ApiEnum<string, ProviderConfigType> expectedType = ProviderConfigType.Aws;

        Assert.Equal(expectedBucketName, value.BucketName);
        Assert.Equal(expectedRegion, value.Region);
        Assert.Equal(expectedType, value.Type);

        ProviderConfig emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.BucketName);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Region);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        ProviderConfig mismatchedValue = new(
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

public class ProviderConfigTypeTest : TestBase
{
    [Theory]
    [InlineData(ProviderConfigType.Aws)]
    [InlineData(ProviderConfigType.Gcp)]
    public void Validation_Works(ProviderConfigType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProviderConfigType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProviderConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProviderConfigType.Aws, 1206082585, "aws")]
    [InlineData(ProviderConfigType.Gcp, 1474161881, "gcp")]
    public void EnumMemberSerializationRoundtrip_Works(
        ProviderConfigType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProviderConfigType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProviderConfigType>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProviderConfigType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProviderConfigType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
