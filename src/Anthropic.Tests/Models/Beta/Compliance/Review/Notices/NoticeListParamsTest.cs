using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Compliance.Review;
using Anthropic.Models.Beta.Compliance.Review.Notices;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Notices;

public class NoticeListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NoticeListParams
        {
            CaseID = "case_id",
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            Order = BetaComplianceReviewOrder.Asc,
            Page = "page",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedCaseID = "case_id";
        DateTimeOffset expectedCreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedLimit = 0;
        ApiEnum<string, BetaComplianceReviewOrder> expectedOrder = BetaComplianceReviewOrder.Asc;
        string expectedPage = "page";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedCaseID, parameters.CaseID);
        Assert.Equal(expectedCreatedAtGt, parameters.CreatedAtGt);
        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLt, parameters.CreatedAtLt);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NoticeListParams { };

        Assert.Null(parameters.CaseID);
        Assert.False(parameters.RawQueryData.ContainsKey("case_id"));
        Assert.Null(parameters.CreatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NoticeListParams
        {
            // Null should be interpreted as omitted for these properties
            CaseID = null,
            CreatedAtGt = null,
            CreatedAtGte = null,
            CreatedAtLt = null,
            CreatedAtLte = null,
            Limit = null,
            Order = null,
            Page = null,
            Betas = null,
        };

        Assert.Null(parameters.CaseID);
        Assert.False(parameters.RawQueryData.ContainsKey("case_id"));
        Assert.Null(parameters.CreatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new NoticeListParams
        {
            CaseID = "case_id",
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            Order = BetaComplianceReviewOrder.Asc,
            Page = "page",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            CaseID = null,
            CreatedAtGt = null,
            CreatedAtGte = null,
            CreatedAtLt = null,
            CreatedAtLte = null,
            Limit = null,
            Order = null,
            Page = null,
            Betas = null,
        };

        Assert.Null(parameters.CaseID);
        Assert.False(parameters.RawQueryData.ContainsKey("case_id"));
        Assert.Null(parameters.CreatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        NoticeListParams parameters = new()
        {
            CaseID = "case_id",
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Limit = 0,
            Order = BetaComplianceReviewOrder.Asc,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/compliance/review/notices?case_id=case_id&created_at%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&limit=0&order=asc&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        NoticeListParams parameters = new() { Betas = [AnthropicBeta.ComputerUse2024_10_22] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NoticeListParams
        {
            CaseID = "case_id",
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            Order = BetaComplianceReviewOrder.Asc,
            Page = "page",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        NoticeListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
