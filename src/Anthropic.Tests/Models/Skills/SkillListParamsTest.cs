using System;
using Anthropic.Models.Skills;

namespace Anthropic.Tests.Models.Skills;

public class SkillListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SkillListParams
        {
            Limit = 1,
            Page = "page",
            Source = "source",
        };

        long expectedLimit = 1;
        string expectedPage = "page";
        string expectedSource = "source";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedSource, parameters.Source);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SkillListParams { Page = "page", Source = "source" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SkillListParams
        {
            Page = "page",
            Source = "source",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SkillListParams { Limit = 1 };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Source);
        Assert.False(parameters.RawQueryData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SkillListParams
        {
            Limit = 1,

            Page = null,
            Source = null,
        };

        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Source);
        Assert.True(parameters.RawQueryData.ContainsKey("source"));
    }

    [Fact]
    public void Url_Works()
    {
        SkillListParams parameters = new()
        {
            Limit = 1,
            Page = "page",
            Source = "source",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/skills?limit=1&page=page&source=source"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SkillListParams
        {
            Limit = 1,
            Page = "page",
            Source = "source",
        };

        SkillListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
