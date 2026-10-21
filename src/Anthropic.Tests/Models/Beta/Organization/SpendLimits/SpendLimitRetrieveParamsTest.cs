using System;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class SpendLimitRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SpendLimitRetrieveParams { SpendLimitID = "spend_limit_id" };

        string expectedSpendLimitID = "spend_limit_id";

        Assert.Equal(expectedSpendLimitID, parameters.SpendLimitID);
    }

    [Fact]
    public void Url_Works()
    {
        SpendLimitRetrieveParams parameters = new() { SpendLimitID = "spend_limit_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/spend_limits/spend_limit_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SpendLimitRetrieveParams { SpendLimitID = "spend_limit_id" };

        SpendLimitRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
