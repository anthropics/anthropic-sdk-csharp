using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.RateLimits;

namespace Anthropic.Tests.Models.Beta.Organization.RateLimits;

public class RateLimitListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RateLimitListParams
        {
            GroupType = GroupType.Batch,
            Limit = 1,
            Model = "model",
            Page = "page",
        };

        ApiEnum<string, GroupType> expectedGroupType = GroupType.Batch;
        long expectedLimit = 1;
        string expectedModel = "model";
        string expectedPage = "page";

        Assert.Equal(expectedGroupType, parameters.GroupType);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RateLimitListParams { };

        Assert.Null(parameters.GroupType);
        Assert.False(parameters.RawQueryData.ContainsKey("group_type"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Model);
        Assert.False(parameters.RawQueryData.ContainsKey("model"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RateLimitListParams
        {
            GroupType = null,
            Limit = null,
            Model = null,
            Page = null,
        };

        Assert.Null(parameters.GroupType);
        Assert.True(parameters.RawQueryData.ContainsKey("group_type"));
        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Model);
        Assert.True(parameters.RawQueryData.ContainsKey("model"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        RateLimitListParams parameters = new()
        {
            GroupType = GroupType.Batch,
            Limit = 1,
            Model = "model",
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/rate_limits?beta=true&group_type=batch&limit=1&model=model&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RateLimitListParams
        {
            GroupType = GroupType.Batch,
            Limit = 1,
            Model = "model",
            Page = "page",
        };

        RateLimitListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class GroupTypeTest : TestBase
{
    [Theory]
    [InlineData(GroupType.Batch)]
    [InlineData(GroupType.Files)]
    [InlineData(GroupType.ModelGroup)]
    [InlineData(GroupType.Skills)]
    [InlineData(GroupType.TokenCount)]
    [InlineData(GroupType.WebSearch)]
    public void Validation_Works(GroupType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GroupType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GroupType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GroupType.Batch)]
    [InlineData(GroupType.Files)]
    [InlineData(GroupType.ModelGroup)]
    [InlineData(GroupType.Skills)]
    [InlineData(GroupType.TokenCount)]
    [InlineData(GroupType.WebSearch)]
    public void SerializationRoundtrip_Works(GroupType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GroupType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GroupType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GroupType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GroupType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
