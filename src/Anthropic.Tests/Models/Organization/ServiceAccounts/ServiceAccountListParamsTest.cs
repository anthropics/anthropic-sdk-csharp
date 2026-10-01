using System;
using Anthropic.Models.Organization.ServiceAccounts;

namespace Anthropic.Tests.Models.Organization.ServiceAccounts;

public class ServiceAccountListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ServiceAccountListParams
        {
            IncludeArchived = true,
            Limit = 1,
            Page = "page",
        };

        bool expectedIncludeArchived = true;
        long expectedLimit = 1;
        string expectedPage = "page";

        Assert.Equal(expectedIncludeArchived, parameters.IncludeArchived);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ServiceAccountListParams { Page = "page" };

        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ServiceAccountListParams
        {
            Page = "page",

            // Null should be interpreted as omitted for these properties
            IncludeArchived = null,
            Limit = null,
        };

        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ServiceAccountListParams { IncludeArchived = true, Limit = 1 };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ServiceAccountListParams
        {
            IncludeArchived = true,
            Limit = 1,

            Page = null,
        };

        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        ServiceAccountListParams parameters = new()
        {
            IncludeArchived = true,
            Limit = 1,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/service_accounts?include_archived=true&limit=1&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ServiceAccountListParams
        {
            IncludeArchived = true,
            Limit = 1,
            Page = "page",
        };

        ServiceAccountListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
