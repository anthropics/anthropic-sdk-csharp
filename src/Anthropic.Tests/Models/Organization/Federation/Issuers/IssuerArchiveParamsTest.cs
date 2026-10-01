using System;
using Anthropic.Models.Organization.Federation.Issuers;

namespace Anthropic.Tests.Models.Organization.Federation.Issuers;

public class IssuerArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IssuerArchiveParams { FederationIssuerID = "federation_issuer_id" };

        string expectedFederationIssuerID = "federation_issuer_id";

        Assert.Equal(expectedFederationIssuerID, parameters.FederationIssuerID);
    }

    [Fact]
    public void Url_Works()
    {
        IssuerArchiveParams parameters = new() { FederationIssuerID = "federation_issuer_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/federation_issuers/federation_issuer_id/archive"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IssuerArchiveParams { FederationIssuerID = "federation_issuer_id" };

        IssuerArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
