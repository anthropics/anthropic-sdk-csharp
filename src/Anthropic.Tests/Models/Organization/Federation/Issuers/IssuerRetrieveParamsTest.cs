using System;
using Anthropic.Models.Organization.Federation.Issuers;

namespace Anthropic.Tests.Models.Organization.Federation.Issuers;

public class IssuerRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IssuerRetrieveParams { FederationIssuerID = "federation_issuer_id" };

        string expectedFederationIssuerID = "federation_issuer_id";

        Assert.Equal(expectedFederationIssuerID, parameters.FederationIssuerID);
    }

    [Fact]
    public void Url_Works()
    {
        IssuerRetrieveParams parameters = new() { FederationIssuerID = "federation_issuer_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/federation_issuers/federation_issuer_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IssuerRetrieveParams { FederationIssuerID = "federation_issuer_id" };

        IssuerRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
