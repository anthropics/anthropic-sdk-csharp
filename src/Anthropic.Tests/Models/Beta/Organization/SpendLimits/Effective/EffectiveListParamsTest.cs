using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits.Effective;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits.Effective;

public class EffectiveListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EffectiveListParams
        {
            Limit = 1,
            Page = "page",
            Period = [Period.Daily],
            UserIds = ["string"],
        };

        long expectedLimit = 1;
        string expectedPage = "page";
        List<ApiEnum<string, Period>> expectedPeriod = [Period.Daily];
        List<string> expectedUserIds = ["string"];

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.NotNull(parameters.Period);
        Assert.Equal(expectedPeriod.Count, parameters.Period.Count);
        for (int i = 0; i < expectedPeriod.Count; i++)
        {
            Assert.Equal(expectedPeriod[i], parameters.Period[i]);
        }
        Assert.NotNull(parameters.UserIds);
        Assert.Equal(expectedUserIds.Count, parameters.UserIds.Count);
        for (int i = 0; i < expectedUserIds.Count; i++)
        {
            Assert.Equal(expectedUserIds[i], parameters.UserIds[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EffectiveListParams
        {
            Page = "page",
            Period = [Period.Daily],
            UserIds = ["string"],
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EffectiveListParams
        {
            Page = "page",
            Period = [Period.Daily],
            UserIds = ["string"],

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EffectiveListParams { Limit = 1 };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Period);
        Assert.False(parameters.RawQueryData.ContainsKey("period"));
        Assert.Null(parameters.UserIds);
        Assert.False(parameters.RawQueryData.ContainsKey("user_ids"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EffectiveListParams
        {
            Limit = 1,

            Page = null,
            Period = null,
            UserIds = null,
        };

        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Period);
        Assert.True(parameters.RawQueryData.ContainsKey("period"));
        Assert.Null(parameters.UserIds);
        Assert.True(parameters.RawQueryData.ContainsKey("user_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        EffectiveListParams parameters = new()
        {
            Limit = 1,
            Page = "page",
            Period = [Period.Daily],
            UserIds = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/spend_limits/effective?beta=true&limit=1&page=page&period%5b%5d=daily&user_ids%5b%5d=string"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EffectiveListParams
        {
            Limit = 1,
            Page = "page",
            Period = [Period.Daily],
            UserIds = ["string"],
        };

        EffectiveListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PeriodTest : TestBase
{
    [Theory]
    [InlineData(Period.Daily)]
    [InlineData(Period.Monthly)]
    [InlineData(Period.Weekly)]
    public void Validation_Works(Period rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Period> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Period.Daily)]
    [InlineData(Period.Monthly)]
    [InlineData(Period.Weekly)]
    public void SerializationRoundtrip_Works(Period rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Period> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
