using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics.Artifacts;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Artifacts;

public class ArtifactListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ArtifactListParams
        {
            Date = "2019-12-27",
            Filter = ["string"],
            GroupBy = [GroupBy.Product],
            Limit = 1,
            Page = "page",
        };

        string expectedDate = "2019-12-27";
        List<string> expectedFilter = ["string"];
        List<ApiEnum<string, GroupBy>> expectedGroupBy = [GroupBy.Product];
        long expectedLimit = 1;
        string expectedPage = "page";

        Assert.Equal(expectedDate, parameters.Date);
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
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ArtifactListParams { Date = "2019-12-27" };

        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawQueryData.ContainsKey("filter"));
        Assert.Null(parameters.GroupBy);
        Assert.False(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ArtifactListParams
        {
            Date = "2019-12-27",

            Filter = null,
            GroupBy = null,
            Limit = null,
            Page = null,
        };

        Assert.Null(parameters.Filter);
        Assert.True(parameters.RawQueryData.ContainsKey("filter"));
        Assert.Null(parameters.GroupBy);
        Assert.True(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        ArtifactListParams parameters = new()
        {
            Date = "2019-12-27",
            Filter = ["string"],
            GroupBy = [GroupBy.Product],
            Limit = 1,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/analytics/artifacts?beta=true&date=2019-12-27&filter%5b%5d=string&group_by%5b%5d=product&limit=1&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ArtifactListParams
        {
            Date = "2019-12-27",
            Filter = ["string"],
            GroupBy = [GroupBy.Product],
            Limit = 1,
            Page = "page",
        };

        ArtifactListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class GroupByTest : TestBase
{
    [Theory]
    [InlineData(GroupBy.Product)]
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
    [InlineData(GroupBy.Product)]
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
