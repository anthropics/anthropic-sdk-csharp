using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalKeys;

public class ExternalKeyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalKeyCreateParams
        {
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
            DisplayName = "x",
            Geo = Geo.Us,
        };

        ProviderConfig expectedProviderConfig = new BetaAwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
        };
        string expectedDisplayName = "x";
        ApiEnum<string, Geo> expectedGeo = Geo.Us;

        Assert.Equal(expectedProviderConfig, parameters.ProviderConfig);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedGeo, parameters.Geo);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalKeyCreateParams
        {
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
            DisplayName = "x",
        };

        Assert.Null(parameters.Geo);
        Assert.False(parameters.RawBodyData.ContainsKey("geo"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExternalKeyCreateParams
        {
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
            DisplayName = "x",

            // Null should be interpreted as omitted for these properties
            Geo = null,
        };

        Assert.Null(parameters.Geo);
        Assert.False(parameters.RawBodyData.ContainsKey("geo"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalKeyCreateParams
        {
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
            Geo = Geo.Us,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExternalKeyCreateParams
        {
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
            Geo = Geo.Us,

            DisplayName = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
    }

    [Fact]
    public void Url_Works()
    {
        ExternalKeyCreateParams parameters = new()
        {
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/external_keys?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalKeyCreateParams
        {
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
            DisplayName = "x",
            Geo = Geo.Us,
        };

        ExternalKeyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProviderConfigTest : TestBase
{
    [Fact]
    public void BetaAwsExternalKeyValidationWorks()
    {
        ProviderConfig value = new BetaAwsExternalKeyConfig()
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
        ProviderConfig value = new BetaGcpExternalKeyConfig(
            "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key"
        );
        value.Validate();
    }

    [Fact]
    public void BetaAzureExternalKeyConfigParamValidationWorks()
    {
        ProviderConfig value = new BetaAzureExternalKeyConfigParam()
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
        ProviderConfig value = new BetaAwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaGcpExternalKeySerializationRoundtripWorks()
    {
        ProviderConfig value = new BetaGcpExternalKeyConfig(
            "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaAzureExternalKeyConfigParamSerializationRoundtripWorks()
    {
        ProviderConfig value = new BetaAzureExternalKeyConfigParam()
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GeoTest : TestBase
{
    [Theory]
    [InlineData(Geo.Us)]
    public void Validation_Works(Geo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Geo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Geo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Geo.Us)]
    public void SerializationRoundtrip_Works(Geo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Geo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Geo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Geo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Geo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
