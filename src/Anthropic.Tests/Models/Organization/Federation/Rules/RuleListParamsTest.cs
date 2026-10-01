using System;
using Anthropic.Models.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Organization.Federation.Rules;

public class RuleListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RuleListParams
        {
            IncludeArchived = true,
            IssuerID = "issuer_id",
            Limit = 1,
            Page = "page",
        };

        bool expectedIncludeArchived = true;
        string expectedIssuerID = "issuer_id";
        long expectedLimit = 1;
        string expectedPage = "page";

        Assert.Equal(expectedIncludeArchived, parameters.IncludeArchived);
        Assert.Equal(expectedIssuerID, parameters.IssuerID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RuleListParams { IssuerID = "issuer_id", Page = "page" };

        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RuleListParams
        {
            IssuerID = "issuer_id",
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
        var parameters = new RuleListParams { IncludeArchived = true, Limit = 1 };

        Assert.Null(parameters.IssuerID);
        Assert.False(parameters.RawQueryData.ContainsKey("issuer_id"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RuleListParams
        {
            IncludeArchived = true,
            Limit = 1,

            IssuerID = null,
            Page = null,
        };

        Assert.Null(parameters.IssuerID);
        Assert.True(parameters.RawQueryData.ContainsKey("issuer_id"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        RuleListParams parameters = new()
        {
            IncludeArchived = true,
            IssuerID = "issuer_id",
            Limit = 1,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/federation_rules?include_archived=true&issuer_id=issuer_id&limit=1&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RuleListParams
        {
            IncludeArchived = true,
            IssuerID = "issuer_id",
            Limit = 1,
            Page = "page",
        };

        RuleListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
