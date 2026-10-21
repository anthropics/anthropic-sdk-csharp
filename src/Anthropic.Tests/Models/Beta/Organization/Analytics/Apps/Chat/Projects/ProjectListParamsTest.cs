using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics.Apps.Chat.Projects;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Apps.Chat.Projects;

public class ProjectListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProjectListParams
        {
            Date = "2019-12-27",
            EndingDate = "2019-12-27",
            Filter = ["string"],
            GroupBy = [GroupBy.RbacGroupID],
            Limit = 1,
            Order = Order.Asc,
            OrderBy = "order_by",
            Page = "page",
            StartingDate = "2019-12-27",
        };

        string expectedDate = "2019-12-27";
        string expectedEndingDate = "2019-12-27";
        List<string> expectedFilter = ["string"];
        List<ApiEnum<string, GroupBy>> expectedGroupBy = [GroupBy.RbacGroupID];
        long expectedLimit = 1;
        ApiEnum<string, Order> expectedOrder = Order.Asc;
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
        var parameters = new ProjectListParams { };

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
        var parameters = new ProjectListParams
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
        ProjectListParams parameters = new()
        {
            Date = "2019-12-27",
            EndingDate = "2019-12-27",
            Filter = ["string"],
            GroupBy = [GroupBy.RbacGroupID],
            Limit = 1,
            Order = Order.Asc,
            OrderBy = "order_by",
            Page = "page",
            StartingDate = "2019-12-27",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/analytics/apps/chat/projects?beta=true&date=2019-12-27&ending_date=2019-12-27&filter%5b%5d=string&group_by%5b%5d=rbac_group_id&limit=1&order=asc&order_by=order_by&page=page&starting_date=2019-12-27"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProjectListParams
        {
            Date = "2019-12-27",
            EndingDate = "2019-12-27",
            Filter = ["string"],
            GroupBy = [GroupBy.RbacGroupID],
            Limit = 1,
            Order = Order.Asc,
            OrderBy = "order_by",
            Page = "page",
            StartingDate = "2019-12-27",
        };

        ProjectListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class GroupByTest : TestBase
{
    [Theory]
    [InlineData(GroupBy.RbacGroupID)]
    [InlineData(GroupBy.UserID)]
    public void Validation_Works(GroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GroupBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GroupBy.RbacGroupID)]
    [InlineData(GroupBy.UserID)]
    public void SerializationRoundtrip_Works(GroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GroupBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OrderTest : TestBase
{
    [Theory]
    [InlineData(Order.Asc)]
    [InlineData(Order.Desc)]
    public void Validation_Works(Order rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Order> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Order.Asc)]
    [InlineData(Order.Desc)]
    public void SerializationRoundtrip_Works(Order rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Order> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
