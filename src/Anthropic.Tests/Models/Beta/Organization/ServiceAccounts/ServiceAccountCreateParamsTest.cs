using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ServiceAccounts;

namespace Anthropic.Tests.Models.Beta.Organization.ServiceAccounts;

public class ServiceAccountCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ServiceAccountCreateParams
        {
            Name = "ci-deploy-bot",
            Description = "description",
            OrganizationRole = OrganizationRole.Admin,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedName = "ci-deploy-bot";
        string expectedDescription = "description";
        ApiEnum<string, OrganizationRole> expectedOrganizationRole = OrganizationRole.Admin;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedName, parameters.Name);
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
        var parameters = new ServiceAccountCreateParams
        {
            Name = "ci-deploy-bot",
            Description = "description",
        };

        Assert.Null(parameters.OrganizationRole);
        Assert.False(parameters.RawBodyData.ContainsKey("organization_role"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ServiceAccountCreateParams
        {
            Name = "ci-deploy-bot",
            Description = "description",

            // Null should be interpreted as omitted for these properties
            OrganizationRole = null,
            Betas = null,
        };

        Assert.Null(parameters.OrganizationRole);
        Assert.False(parameters.RawBodyData.ContainsKey("organization_role"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ServiceAccountCreateParams
        {
            Name = "ci-deploy-bot",
            OrganizationRole = OrganizationRole.Admin,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ServiceAccountCreateParams
        {
            Name = "ci-deploy-bot",
            OrganizationRole = OrganizationRole.Admin,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        ServiceAccountCreateParams parameters = new() { Name = "ci-deploy-bot" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/service_accounts?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ServiceAccountCreateParams parameters = new()
        {
            Name = "ci-deploy-bot",
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
        var parameters = new ServiceAccountCreateParams
        {
            Name = "ci-deploy-bot",
            Description = "description",
            OrganizationRole = OrganizationRole.Admin,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        ServiceAccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class OrganizationRoleTest : TestBase
{
    [Theory]
    [InlineData(OrganizationRole.Admin)]
    [InlineData(OrganizationRole.Developer)]
    public void Validation_Works(OrganizationRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrganizationRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrganizationRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OrganizationRole.Admin)]
    [InlineData(OrganizationRole.Developer)]
    public void SerializationRoundtrip_Works(OrganizationRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrganizationRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrganizationRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrganizationRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrganizationRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
