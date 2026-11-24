using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Compliance.Review;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class CaseListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CaseListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            Order = BetaComplianceReviewOrder.Asc,
            OrderBy = BetaComplianceReviewCaseOrderBy.CreatedAt,
            Page = "page",
            Status = BetaComplianceReviewCaseStatusFilter.Open,
            UpdatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserProfileID = "user_profile_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        DateTimeOffset expectedCreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedLimit = 0;
        ApiEnum<string, BetaComplianceReviewOrder> expectedOrder = BetaComplianceReviewOrder.Asc;
        ApiEnum<string, BetaComplianceReviewCaseOrderBy> expectedOrderBy =
            BetaComplianceReviewCaseOrderBy.CreatedAt;
        string expectedPage = "page";
        ApiEnum<string, BetaComplianceReviewCaseStatusFilter> expectedStatus =
            BetaComplianceReviewCaseStatusFilter.Open;
        DateTimeOffset expectedUpdatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUserProfileID = "user_profile_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedCreatedAtGt, parameters.CreatedAtGt);
        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLt, parameters.CreatedAtLt);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedUpdatedAtGt, parameters.UpdatedAtGt);
        Assert.Equal(expectedUpdatedAtGte, parameters.UpdatedAtGte);
        Assert.Equal(expectedUpdatedAtLt, parameters.UpdatedAtLt);
        Assert.Equal(expectedUpdatedAtLte, parameters.UpdatedAtLte);
        Assert.Equal(expectedUserProfileID, parameters.UserProfileID);
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
        var parameters = new CaseListParams { };

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
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.UpdatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[gt]"));
        Assert.Null(parameters.UpdatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[gte]"));
        Assert.Null(parameters.UpdatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[lt]"));
        Assert.Null(parameters.UpdatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[lte]"));
        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawQueryData.ContainsKey("user_profile_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CaseListParams
        {
            // Null should be interpreted as omitted for these properties
            CreatedAtGt = null,
            CreatedAtGte = null,
            CreatedAtLt = null,
            CreatedAtLte = null,
            Limit = null,
            Order = null,
            OrderBy = null,
            Page = null,
            Status = null,
            UpdatedAtGt = null,
            UpdatedAtGte = null,
            UpdatedAtLt = null,
            UpdatedAtLte = null,
            UserProfileID = null,
            Betas = null,
        };

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
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.UpdatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[gt]"));
        Assert.Null(parameters.UpdatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[gte]"));
        Assert.Null(parameters.UpdatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[lt]"));
        Assert.Null(parameters.UpdatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[lte]"));
        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawQueryData.ContainsKey("user_profile_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new CaseListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            Order = BetaComplianceReviewOrder.Asc,
            OrderBy = BetaComplianceReviewCaseOrderBy.CreatedAt,
            Page = "page",
            Status = BetaComplianceReviewCaseStatusFilter.Open,
            UpdatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserProfileID = "user_profile_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            CreatedAtGt = null,
            CreatedAtGte = null,
            CreatedAtLt = null,
            CreatedAtLte = null,
            Limit = null,
            Order = null,
            OrderBy = null,
            Page = null,
            Status = null,
            UpdatedAtGt = null,
            UpdatedAtGte = null,
            UpdatedAtLt = null,
            UpdatedAtLte = null,
            UserProfileID = null,
            Betas = null,
        };

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
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.UpdatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[gt]"));
        Assert.Null(parameters.UpdatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[gte]"));
        Assert.Null(parameters.UpdatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[lt]"));
        Assert.Null(parameters.UpdatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("updated_at[lte]"));
        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawQueryData.ContainsKey("user_profile_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        CaseListParams parameters = new()
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Limit = 0,
            Order = BetaComplianceReviewOrder.Asc,
            OrderBy = BetaComplianceReviewCaseOrderBy.CreatedAt,
            Page = "page",
            Status = BetaComplianceReviewCaseStatusFilter.Open,
            UpdatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            UpdatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            UpdatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            UpdatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            UserProfileID = "user_profile_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/compliance/review/cases?created_at%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&limit=0&order=asc&order_by=created_at&page=page&status=open&updated_at%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&updated_at%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&updated_at%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&updated_at%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&user_profile_id=user_profile_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CaseListParams parameters = new() { Betas = [AnthropicBeta.ComputerUse2024_10_22] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CaseListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            Order = BetaComplianceReviewOrder.Asc,
            OrderBy = BetaComplianceReviewCaseOrderBy.CreatedAt,
            Page = "page",
            Status = BetaComplianceReviewCaseStatusFilter.Open,
            UpdatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserProfileID = "user_profile_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        CaseListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
