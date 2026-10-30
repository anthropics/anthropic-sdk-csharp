using System;
using System.Collections.Generic;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;
using Anthropic.Models.Organization.Analytics.Plugins;

namespace Anthropic.Tests.Models.Organization.Analytics.Plugins;

public class PluginListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PluginListParams
        {
            Date = "2019-12-27",
            EndingDate = "2019-12-27",
            Filter = ["string"],
            GroupBy = [AnalyticsPluginGroupBy.Product],
            Limit = 1,
            Order = AnalyticsOrder.Asc,
            OrderBy = "order_by",
            Page = "page",
            StartingDate = "2019-12-27",
        };

        string expectedDate = "2019-12-27";
        string expectedEndingDate = "2019-12-27";
        List<string> expectedFilter = ["string"];
        List<ApiEnum<string, AnalyticsPluginGroupBy>> expectedGroupBy =
        [
            AnalyticsPluginGroupBy.Product,
        ];
        long expectedLimit = 1;
        ApiEnum<string, AnalyticsOrder> expectedOrder = AnalyticsOrder.Asc;
        string expectedOrderBy = "order_by";
        string expectedPage = "page";
        string expectedStartingDate = "2019-12-27";

        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedEndingDate, parameters.EndingDate);
        Assert.NotNull(parameters.Filter);
        Assert.Equal(expectedFilter.Count, parameters.Filter.Count);
        for (int i = 0; i < expectedFilter.Count; i++)
        {
            Assert.Equal(expectedFilter[i], parameters.Filter[i]);
        }
        Assert.NotNull(parameters.GroupBy);
        Assert.Equal(expectedGroupBy.Count, parameters.GroupBy.Count);
        for (int i = 0; i < expectedGroupBy.Count; i++)
        {
            Assert.Equal(expectedGroupBy[i], parameters.GroupBy[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedStartingDate, parameters.StartingDate);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PluginListParams { };

        Assert.Null(parameters.Date);
        Assert.False(parameters.RawQueryData.ContainsKey("date"));
        Assert.Null(parameters.EndingDate);
        Assert.False(parameters.RawQueryData.ContainsKey("ending_date"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawQueryData.ContainsKey("filter"));
        Assert.Null(parameters.GroupBy);
        Assert.False(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.StartingDate);
        Assert.False(parameters.RawQueryData.ContainsKey("starting_date"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PluginListParams
        {
            Date = null,
            EndingDate = null,
            Filter = null,
            GroupBy = null,
            Limit = null,
            Order = null,
            OrderBy = null,
            Page = null,
            StartingDate = null,
        };

        Assert.Null(parameters.Date);
        Assert.True(parameters.RawQueryData.ContainsKey("date"));
        Assert.Null(parameters.EndingDate);
        Assert.True(parameters.RawQueryData.ContainsKey("ending_date"));
        Assert.Null(parameters.Filter);
        Assert.True(parameters.RawQueryData.ContainsKey("filter"));
        Assert.Null(parameters.GroupBy);
        Assert.True(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.True(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.OrderBy);
        Assert.True(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.StartingDate);
        Assert.True(parameters.RawQueryData.ContainsKey("starting_date"));
    }

    [Fact]
    public void Url_Works()
    {
        PluginListParams parameters = new()
        {
            Date = "2019-12-27",
            EndingDate = "2019-12-27",
            Filter = ["string"],
            GroupBy = [AnalyticsPluginGroupBy.Product],
            Limit = 1,
            Order = AnalyticsOrder.Asc,
            OrderBy = "order_by",
            Page = "page",
            StartingDate = "2019-12-27",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/analytics/plugins?date=2019-12-27&ending_date=2019-12-27&filter%5b%5d=string&group_by%5b%5d=product&limit=1&order=asc&order_by=order_by&page=page&starting_date=2019-12-27"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PluginListParams
        {
            Date = "2019-12-27",
            EndingDate = "2019-12-27",
            Filter = ["string"],
            GroupBy = [AnalyticsPluginGroupBy.Product],
            Limit = 1,
            Order = AnalyticsOrder.Asc,
            OrderBy = "order_by",
            Page = "page",
            StartingDate = "2019-12-27",
        };

        PluginListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
