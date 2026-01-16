using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Skills.Versions;

namespace Anthropic.Tests.Models.Beta.Skills.Versions;

public class VersionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionListParams
        {
            SkillID = "skill_id",
            Limit = 0,
            Page = "page",
            Betas = ["string"],
        };

        string expectedSkillID = "skill_id";
        long expectedLimit = 0;
        string expectedPage = "page";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = ["string"];

        Assert.Equal(expectedSkillID, parameters.SkillID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VersionListParams
        {
            SkillID = "skill_id",
            Limit = 0,
            Page = "page",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VersionListParams
        {
            SkillID = "skill_id",
            Limit = 0,
            Page = "page",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VersionListParams { SkillID = "skill_id", Betas = ["string"] };

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
            Betas = ["string"],

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
            Limit = 0,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri("https://api.anthropic.com/v1/skills/skill_id/versions?limit=0&page=page"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        VersionListParams parameters = new() { SkillID = "skill_id", Betas = ["string"] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["skills-2025-10-02", "string"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionListParams
        {
            SkillID = "skill_id",
            Limit = 0,
            Page = "page",
            Betas = ["string"],
        };

        VersionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
