using System;
using Anthropic.Models.Organization.ServiceAccounts.Workspaces;

namespace Anthropic.Tests.Models.Organization.ServiceAccounts.Workspaces;

public class WorkspaceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceListParams
        {
            ServiceAccountID = "service_account_id",
            Limit = 1,
            Page = "page",
        };

        string expectedServiceAccountID = "service_account_id";
        long expectedLimit = 1;
        string expectedPage = "page";

        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspaceListParams
        {
            ServiceAccountID = "service_account_id",
            Page = "page",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkspaceListParams
        {
            ServiceAccountID = "service_account_id",
            Page = "page",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspaceListParams
        {
            ServiceAccountID = "service_account_id",
            Limit = 1,
        };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkspaceListParams
        {
            ServiceAccountID = "service_account_id",
            Limit = 1,

            Page = null,
        };

        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkspaceListParams parameters = new()
        {
            ServiceAccountID = "service_account_id",
            Limit = 1,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/service_accounts/service_account_id/workspaces?limit=1&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspaceListParams
        {
            ServiceAccountID = "service_account_id",
            Limit = 1,
            Page = "page",
        };

        WorkspaceListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
