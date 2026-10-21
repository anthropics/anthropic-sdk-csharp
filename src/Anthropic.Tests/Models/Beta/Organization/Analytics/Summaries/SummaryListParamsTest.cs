using System;
using System.Collections.Generic;
using Anthropic.Models.Beta.Organization.Analytics.Summaries;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Summaries;

public class SummaryListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SummaryListParams
        {
            StartingDate = "2019-12-27",
            EndingDate = "2019-12-27",
            Filter = ["string"],
            Limit = 1,
            Page = "page",
        };

        string expectedStartingDate = "2019-12-27";
        string expectedEndingDate = "2019-12-27";
        List<string> expectedFilter = ["string"];
        long expectedLimit = 1;
        string expectedPage = "page";

        Assert.Equal(expectedStartingDate, parameters.StartingDate);
        Assert.Equal(expectedEndingDate, parameters.EndingDate);
        Assert.NotNull(parameters.Filter);
        Assert.Equal(expectedFilter.Count, parameters.Filter.Count);
        for (int i = 0; i < expectedFilter.Count; i++)
        {
            Assert.Equal(expectedFilter[i], parameters.Filter[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SummaryListParams { StartingDate = "2019-12-27" };

        Assert.Null(parameters.EndingDate);
        Assert.False(parameters.RawQueryData.ContainsKey("ending_date"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawQueryData.ContainsKey("filter"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SummaryListParams
        {
            StartingDate = "2019-12-27",

            EndingDate = null,
            Filter = null,
            Limit = null,
            Page = null,
        };

        Assert.Null(parameters.EndingDate);
        Assert.True(parameters.RawQueryData.ContainsKey("ending_date"));
        Assert.Null(parameters.Filter);
        Assert.True(parameters.RawQueryData.ContainsKey("filter"));
        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        SummaryListParams parameters = new()
        {
            StartingDate = "2019-12-27",
            EndingDate = "2019-12-27",
            Filter = ["string"],
            Limit = 1,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/analytics/summaries?beta=true&starting_date=2019-12-27&ending_date=2019-12-27&filter%5b%5d=string&limit=1&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SummaryListParams
        {
            StartingDate = "2019-12-27",
            EndingDate = "2019-12-27",
            Filter = ["string"],
            Limit = 1,
            Page = "page",
        };

        SummaryListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
