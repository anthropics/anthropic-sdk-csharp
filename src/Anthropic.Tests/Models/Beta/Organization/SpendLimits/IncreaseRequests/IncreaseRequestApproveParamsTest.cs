using System;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.IncreaseRequests;

public class IncreaseRequestApproveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IncreaseRequestApproveParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
            Amount = "50000",
            Period = BetaSpendLimitPeriod.Monthly,
            SuppressNotification = true,
        };

        string expectedSpendLimitIncreaseRequestID = "spend_limit_increase_request_id";
        string expectedAmount = "50000";
        ApiEnum<string, BetaSpendLimitPeriod> expectedPeriod = BetaSpendLimitPeriod.Monthly;
        bool expectedSuppressNotification = true;

        Assert.Equal(expectedSpendLimitIncreaseRequestID, parameters.SpendLimitIncreaseRequestID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedPeriod, parameters.Period);
        Assert.Equal(expectedSuppressNotification, parameters.SuppressNotification);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IncreaseRequestApproveParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
            Amount = "50000",
            Period = BetaSpendLimitPeriod.Monthly,
        };

        Assert.Null(parameters.SuppressNotification);
        Assert.False(parameters.RawBodyData.ContainsKey("suppress_notification"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IncreaseRequestApproveParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
            Amount = "50000",
            Period = BetaSpendLimitPeriod.Monthly,

            // Null should be interpreted as omitted for these properties
            SuppressNotification = null,
        };

        Assert.Null(parameters.SuppressNotification);
        Assert.False(parameters.RawBodyData.ContainsKey("suppress_notification"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new IncreaseRequestApproveParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
            Amount = "50000",
            Period = BetaSpendLimitPeriod.Monthly,
            SuppressNotification = true,
        } with
        {
            // Null should be interpreted as omitted for these properties
            SuppressNotification = null,
        };

        Assert.Null(parameters.SuppressNotification);
        Assert.False(parameters.RawBodyData.ContainsKey("suppress_notification"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IncreaseRequestApproveParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
            Amount = "50000",
            SuppressNotification = true,
        };

        Assert.Null(parameters.Period);
        Assert.False(parameters.RawBodyData.ContainsKey("period"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new IncreaseRequestApproveParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
            Amount = "50000",
            SuppressNotification = true,

            Period = null,
        };

        Assert.Null(parameters.Period);
        Assert.True(parameters.RawBodyData.ContainsKey("period"));
    }

    [Fact]
    public void Url_Works()
    {
        IncreaseRequestApproveParams parameters = new()
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
            Amount = "50000",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/spend_limit_increase_requests/spend_limit_increase_request_id/approve?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IncreaseRequestApproveParams
        {
            SpendLimitIncreaseRequestID = "spend_limit_increase_request_id",
            Amount = "50000",
            Period = BetaSpendLimitPeriod.Monthly,
            SuppressNotification = true,
        };

        IncreaseRequestApproveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
