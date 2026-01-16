using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Skills;

namespace Anthropic.Tests.Models.Beta.Skills;

public class SkillListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SkillListParams
        {
            Limit = 0,
            Page = "page",
            Source = "source",
            Betas = ["string"],
        };

        long expectedLimit = 0;
        string expectedPage = "page";
        string expectedSource = "source";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = ["string"];

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedSource, parameters.Source);
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
        var parameters = new SkillListParams { Page = "page", Source = "source" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
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
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SkillListParams { Limit = 0, Betas = ["string"] };

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
            Limit = 0,
            Betas = ["string"],

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
            Limit = 0,
            Page = "page",
            Source = "source",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri("https://api.anthropic.com/v1/skills?limit=0&page=page&source=source"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SkillListParams parameters = new() { Betas = ["string"] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["skills-2025-10-02", "string"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SkillListParams
        {
            Limit = 0,
            Page = "page",
            Source = "source",
            Betas = ["string"],
        };

        SkillListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
