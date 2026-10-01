using System;
using System.Collections.Generic;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.IncreaseRequests;

public class IncreaseRequestListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IncreaseRequestListParams
        {
            ActorIds = ["string"],
            Limit = 1,
            Page = "page",
            Status = [BetaSpendLimitIncreaseRequestStatus.Approved],
        };

        List<string> expectedActorIds = ["string"];
        long expectedLimit = 1;
        string expectedPage = "page";
        List<ApiEnum<string, BetaSpendLimitIncreaseRequestStatus>> expectedStatus =
        [
            BetaSpendLimitIncreaseRequestStatus.Approved,
        ];

        Assert.NotNull(parameters.ActorIds);
        Assert.Equal(expectedActorIds.Count, parameters.ActorIds.Count);
        for (int i = 0; i < expectedActorIds.Count; i++)
        {
            Assert.Equal(expectedActorIds[i], parameters.ActorIds[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.NotNull(parameters.Status);
        Assert.Equal(expectedStatus.Count, parameters.Status.Count);
        for (int i = 0; i < expectedStatus.Count; i++)
        {
            Assert.Equal(expectedStatus[i], parameters.Status[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IncreaseRequestListParams
        {
            ActorIds = ["string"],
            Page = "page",
            Status = [BetaSpendLimitIncreaseRequestStatus.Approved],
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IncreaseRequestListParams
        {
            ActorIds = ["string"],
            Page = "page",
            Status = [BetaSpendLimitIncreaseRequestStatus.Approved],

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IncreaseRequestListParams { Limit = 1 };

        Assert.Null(parameters.ActorIds);
        Assert.False(parameters.RawQueryData.ContainsKey("actor_ids"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new IncreaseRequestListParams
        {
            Limit = 1,

            ActorIds = null,
            Page = null,
            Status = null,
        };

        Assert.Null(parameters.ActorIds);
        Assert.True(parameters.RawQueryData.ContainsKey("actor_ids"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        IncreaseRequestListParams parameters = new()
        {
            ActorIds = ["string"],
            Limit = 1,
            Page = "page",
            Status = [BetaSpendLimitIncreaseRequestStatus.Approved],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/spend_limit_increase_requests?beta=true&actor_ids%5b%5d=string&limit=1&page=page&status%5b%5d=approved"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IncreaseRequestListParams
        {
            ActorIds = ["string"],
            Limit = 1,
            Page = "page",
            Status = [BetaSpendLimitIncreaseRequestStatus.Approved],
        };

        IncreaseRequestListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
