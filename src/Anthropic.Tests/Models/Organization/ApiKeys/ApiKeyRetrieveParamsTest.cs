using System;
using Anthropic.Models.Organization.ApiKeys;

namespace Anthropic.Tests.Models.Organization.ApiKeys;

public class ApiKeyRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ApiKeyRetrieveParams { ApiKeyID = "api_key_id" };

        string expectedApiKeyID = "api_key_id";

        Assert.Equal(expectedApiKeyID, parameters.ApiKeyID);
    }

    [Fact]
    public void Url_Works()
    {
        ApiKeyRetrieveParams parameters = new() { ApiKeyID = "api_key_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/api_keys/api_key_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ApiKeyRetrieveParams { ApiKeyID = "api_key_id" };

        ApiKeyRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
