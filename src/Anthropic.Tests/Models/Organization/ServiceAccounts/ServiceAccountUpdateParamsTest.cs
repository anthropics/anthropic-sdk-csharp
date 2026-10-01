using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.ServiceAccounts;

namespace Anthropic.Tests.Models.Organization.ServiceAccounts;

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
        };

        string expectedServiceAccountID = "service_account_id";
        string expectedDescription = "description";
        ApiEnum<string, ServiceAccountUpdateParamsOrganizationRole> expectedOrganizationRole =
            ServiceAccountUpdateParamsOrganizationRole.Admin;

        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedOrganizationRole, parameters.OrganizationRole);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ServiceAccountUpdateParams { ServiceAccountID = "service_account_id" };

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
                    "https://api.anthropic.com/v1/organizations/service_accounts/service_account_id"
                ),
                url
            )
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
