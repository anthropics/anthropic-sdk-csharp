using System;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Tests.Models.UserProfiles;

public class UserProfileListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserProfileListParams
        {
            Limit = 0,
            Order = UserProfileListOrder.Asc,
            OrderBy = UserProfileListOrderBy.CreatedAt,
            Page = "page",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        int expectedLimit = 0;
        ApiEnum<string, UserProfileListOrder> expectedOrder = UserProfileListOrder.Asc;
        ApiEnum<string, UserProfileListOrderBy> expectedOrderBy = UserProfileListOrderBy.CreatedAt;
        string expectedPage = "page";
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserProfileListParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserProfileListParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Order = null,
            OrderBy = null,
            Page = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new UserProfileListParams
        {
            Limit = 0,
            Order = UserProfileListOrder.Asc,
            OrderBy = UserProfileListOrderBy.CreatedAt,
            Page = "page",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        } with
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Order = null,
            OrderBy = null,
            Page = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void Url_Works()
    {
        UserProfileListParams parameters = new()
        {
            Limit = 0,
            Order = UserProfileListOrder.Asc,
            OrderBy = UserProfileListOrderBy.CreatedAt,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/user_profiles?limit=0&order=asc&order_by=created_at&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserProfileListParams parameters = new()
        {
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["wrkspc_011CZkZaBF1tNoB5wlCeusgy"],
            requestMessage.Headers.GetValues("anthropic-workspace-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserProfileListParams
        {
            Limit = 0,
            Order = UserProfileListOrder.Asc,
            OrderBy = UserProfileListOrderBy.CreatedAt,
            Page = "page",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        UserProfileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
