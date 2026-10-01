using System;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.IncreaseRequests;

public class IncreaseRequestDenyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IncreaseRequestDenyParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
            SuppressNotification = true,
        };

        string expectedSpendLimitIncreaseRequestID = "spend_limit_increase_request_id";
        bool expectedSuppressNotification = true;

        Assert.Equal(expectedSpendLimitIncreaseRequestID, parameters.SpendLimitIncreaseRequestID);
        Assert.Equal(expectedSuppressNotification, parameters.SuppressNotification);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IncreaseRequestDenyParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
        };

        Assert.Null(parameters.SuppressNotification);
        Assert.False(parameters.RawBodyData.ContainsKey("suppress_notification"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IncreaseRequestDenyParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",

            // Null should be interpreted as omitted for these properties
            SuppressNotification = null,
        };

        Assert.Null(parameters.SuppressNotification);
        Assert.False(parameters.RawBodyData.ContainsKey("suppress_notification"));
    }

    [Fact]
    public void Url_Works()
    {
        IncreaseRequestDenyParams parameters = new()
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/spend_limit_increase_requests/spend_limit_increase_request_id/deny?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IncreaseRequestDenyParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
            SuppressNotification = true,
        };

        IncreaseRequestDenyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
