using System;
using Anthropic.Models.Skills.Versions;

namespace Anthropic.Tests.Models.Skills.Versions;

public class VersionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionListParams
        {
            SkillID = "skill_id",
            Limit = 1,
            Page = "page",
        };

        string expectedSkillID = "skill_id";
        long expectedLimit = 1;
        string expectedPage = "page";

        Assert.Equal(expectedSkillID, parameters.SkillID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VersionListParams { SkillID = "skill_id" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new VersionListParams
        {
            SkillID = "skill_id",

            Limit = null,
            Page = null,
        };

        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        VersionListParams parameters = new()
        {
            SkillID = "skill_id",
            Limit = 1,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/skills/skill_id/versions?limit=1&page=page"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionListParams
        {
            SkillID = "skill_id",
            Limit = 1,
            Page = "page",
        };

        VersionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
