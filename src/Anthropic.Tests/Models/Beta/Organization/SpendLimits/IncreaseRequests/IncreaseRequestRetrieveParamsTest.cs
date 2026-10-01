using System;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.IncreaseRequests;

public class IncreaseRequestRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IncreaseRequestRetrieveParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
        };

        string expectedSpendLimitIncreaseRequestID = "spend_limit_increase_request_id";

        Assert.Equal(expectedSpendLimitIncreaseRequestID, parameters.SpendLimitIncreaseRequestID);
    }

    [Fact]
    public void Url_Works()
    {
        IncreaseRequestRetrieveParams parameters = new()
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/spend_limit_increase_requests/spend_limit_increase_request_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IncreaseRequestRetrieveParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
        };

        IncreaseRequestRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
