using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ServiceAccounts;

namespace Anthropic.Tests.Models.Beta.Organization.ServiceAccounts;

public class ServiceAccountUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ServiceAccountUpdateParams
        {
            ServiceAccountID = "service_account_id",
            Description = "description",
            OrganizationRole = ServiceAccountUpdateParamsOrganizationRole.Admin,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedServiceAccountID = "service_account_id";
        string expectedDescription = "description";
        ApiEnum<string, ServiceAccountUpdateParamsOrganizationRole> expectedOrganizationRole =
            ServiceAccountUpdateParamsOrganizationRole.Admin;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedOrganizationRole, parameters.OrganizationRole);
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
        var parameters = new ServiceAccountUpdateParams
        {
            ServiceAccountID = "service_account_id",
            Description = "description",
            OrganizationRole = ServiceAccountUpdateParamsOrganizationRole.Admin,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ServiceAccountUpdateParams
        {
            ServiceAccountID = "service_account_id",
            Description = "description",
            OrganizationRole = ServiceAccountUpdateParamsOrganizationRole.Admin,

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ServiceAccountUpdateParams
        {
            ServiceAccountID = "service_account_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.OrganizationRole);
        Assert.False(parameters.RawBodyData.ContainsKey("organization_role"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ServiceAccountUpdateParams
        {
            ServiceAccountID = "service_account_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Description = null,
            OrganizationRole = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.OrganizationRole);
        Assert.True(parameters.RawBodyData.ContainsKey("organization_role"));
    }

    [Fact]
    public void Url_Works()
    {
        ServiceAccountUpdateParams parameters = new() { ServiceAccountID = "service_account_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/service_accounts/service_account_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ServiceAccountUpdateParams parameters = new()
        {
            ServiceAccountID = "service_account_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ServiceAccountUpdateParams
        {
            ServiceAccountID = "service_account_id",
            Description = "description",
            OrganizationRole = ServiceAccountUpdateParamsOrganizationRole.Admin,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        ServiceAccountUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ServiceAccountUpdateParamsOrganizationRoleTest : TestBase
{
    [Theory]
    [InlineData(ServiceAccountUpdateParamsOrganizationRole.Admin)]
    [InlineData(ServiceAccountUpdateParamsOrganizationRole.Developer)]
    public void Validation_Works(ServiceAccountUpdateParamsOrganizationRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceAccountUpdateParamsOrganizationRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ServiceAccountUpdateParamsOrganizationRole>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ServiceAccountUpdateParamsOrganizationRole.Admin)]
    [InlineData(ServiceAccountUpdateParamsOrganizationRole.Developer)]
    public void SerializationRoundtrip_Works(ServiceAccountUpdateParamsOrganizationRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceAccountUpdateParamsOrganizationRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ServiceAccountUpdateParamsOrganizationRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ServiceAccountUpdateParamsOrganizationRole>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ServiceAccountUpdateParamsOrganizationRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
