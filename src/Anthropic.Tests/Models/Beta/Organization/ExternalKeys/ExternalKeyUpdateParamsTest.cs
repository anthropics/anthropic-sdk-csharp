using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalKeys;

public class ExternalKeyUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalKeyUpdateParams
        {
            ExternalKeyID = "external_key_id",
            DisplayName = "x",
            Geo = ExternalKeyUpdateParamsGeo.Us,
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
        };

        string expectedExternalKeyID = "external_key_id";
        string expectedDisplayName = "x";
        ApiEnum<string, ExternalKeyUpdateParamsGeo> expectedGeo = ExternalKeyUpdateParamsGeo.Us;
        ExternalKeyUpdateParamsProviderConfig expectedProviderConfig =
            new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            };

        Assert.Equal(expectedExternalKeyID, parameters.ExternalKeyID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedGeo, parameters.Geo);
        Assert.Equal(expectedProviderConfig, parameters.ProviderConfig);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalKeyUpdateParams { ExternalKeyID = "external_key_id" };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.Geo);
        Assert.False(parameters.RawBodyData.ContainsKey("geo"));
        Assert.Null(parameters.ProviderConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("provider_config"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExternalKeyUpdateParams
        {
            ExternalKeyID = "external_key_id",

            DisplayName = null,
            Geo = null,
            ProviderConfig = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.Geo);
        Assert.True(parameters.RawBodyData.ContainsKey("geo"));
        Assert.Null(parameters.ProviderConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("provider_config"));
    }

    [Fact]
    public void Url_Works()
    {
        ExternalKeyUpdateParams parameters = new() { ExternalKeyID = "external_key_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/external_keys/external_key_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalKeyUpdateParams
        {
            ExternalKeyID = "external_key_id",
            DisplayName = "x",
            Geo = ExternalKeyUpdateParamsGeo.Us,
            ProviderConfig = new BetaAwsExternalKeyConfig()
            {
                KmsArn =
                    "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
                Region = "us-east-1",
                RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
            },
        };

        ExternalKeyUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ExternalKeyUpdateParamsGeoTest : TestBase
{
    [Theory]
    [InlineData(ExternalKeyUpdateParamsGeo.Us)]
    public void Validation_Works(ExternalKeyUpdateParamsGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalKeyUpdateParamsGeo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExternalKeyUpdateParamsGeo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExternalKeyUpdateParamsGeo.Us)]
    public void SerializationRoundtrip_Works(ExternalKeyUpdateParamsGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalKeyUpdateParamsGeo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExternalKeyUpdateParamsGeo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExternalKeyUpdateParamsGeo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExternalKeyUpdateParamsGeo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExternalKeyUpdateParamsProviderConfigTest : TestBase
{
    [Fact]
    public void BetaAwsExternalKeyValidationWorks()
    {
        ExternalKeyUpdateParamsProviderConfig value = new BetaAwsExternalKeyConfig()
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
        ExternalKeyUpdateParamsProviderConfig value = new BetaGcpExternalKeyConfig(
            "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key"
        );
        value.Validate();
    }

    [Fact]
    public void BetaAzureExternalKeyConfigParamValidationWorks()
    {
        ExternalKeyUpdateParamsProviderConfig value = new BetaAzureExternalKeyConfigParam()
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
        ExternalKeyUpdateParamsProviderConfig value = new BetaAwsExternalKeyConfig()
        {
            KmsArn = "arn:aws:kms:us-east-1:111122223333:key/abcd1234-5678-90ab-cdef-000011112222",
            Region = "us-east-1",
            RoleArn = "arn:aws:iam::111122223333:role/anthropic-cmek",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyUpdateParamsProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaGcpExternalKeySerializationRoundtripWorks()
    {
        ExternalKeyUpdateParamsProviderConfig value = new BetaGcpExternalKeyConfig(
            "projects/my-proj/locations/us/keyRings/my-ring/cryptoKeys/my-key"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyUpdateParamsProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaAzureExternalKeyConfigParamSerializationRoundtripWorks()
    {
        ExternalKeyUpdateParamsProviderConfig value = new BetaAzureExternalKeyConfigParam()
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalKeyUpdateParamsProviderConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
