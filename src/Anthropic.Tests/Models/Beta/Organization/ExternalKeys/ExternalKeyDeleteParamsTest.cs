using System;
using Anthropic.Models.Beta.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalKeys;

public class ExternalKeyDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalKeyDeleteParams { ExternalKeyID = "external_key_id" };

        string expectedExternalKeyID = "external_key_id";

        Assert.Equal(expectedExternalKeyID, parameters.ExternalKeyID);
    }

    [Fact]
    public void Url_Works()
    {
        ExternalKeyDeleteParams parameters = new() { ExternalKeyID = "external_key_id" };

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
        var parameters = new ExternalKeyDeleteParams { ExternalKeyID = "external_key_id" };

        ExternalKeyDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
