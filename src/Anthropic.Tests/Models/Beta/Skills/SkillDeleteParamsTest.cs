using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Skills;

namespace Anthropic.Tests.Models.Beta.Skills;

public class SkillDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SkillDeleteParams { SkillID = "skill_id", Betas = ["string"] };

        string expectedSkillID = "skill_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = ["string"];

        Assert.Equal(expectedSkillID, parameters.SkillID);
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
        var parameters = new SkillDeleteParams { SkillID = "skill_id" };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SkillDeleteParams
        {
            SkillID = "skill_id",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        SkillDeleteParams parameters = new() { SkillID = "skill_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(new Uri("https://api.anthropic.com/v1/skills/skill_id"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SkillDeleteParams parameters = new() { SkillID = "skill_id", Betas = ["string"] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["skills-2025-10-02", "string"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SkillDeleteParams { SkillID = "skill_id", Betas = ["string"] };

        SkillDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
