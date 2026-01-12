using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Skills.Versions;

namespace Anthropic.Tests.Models.Beta.Skills.Versions;

public class VersionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionCreateParams
        {
            SkillID = "skill_id",
            Files = [Encoding.UTF8.GetBytes("text")],
            Betas = ["string"],
        };

        string expectedSkillID = "skill_id";
        List<BinaryContent> expectedFiles = [Encoding.UTF8.GetBytes("text")];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = ["string"];

        Assert.Equal(expectedSkillID, parameters.SkillID);
        Assert.NotNull(parameters.Files);
        Assert.Equal(expectedFiles.Count, parameters.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], parameters.Files[i]);
        }
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
        var parameters = new VersionCreateParams
        {
            SkillID = "skill_id",
            Files = [Encoding.UTF8.GetBytes("text")],
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VersionCreateParams
        {
            SkillID = "skill_id",
            Files = [Encoding.UTF8.GetBytes("text")],

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VersionCreateParams { SkillID = "skill_id", Betas = ["string"] };

        Assert.Null(parameters.Files);
        Assert.False(parameters.RawBodyData.ContainsKey("files"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new VersionCreateParams
        {
            SkillID = "skill_id",
            Betas = ["string"],

            Files = null,
        };

        Assert.Null(parameters.Files);
        Assert.True(parameters.RawBodyData.ContainsKey("files"));
    }

    [Fact]
    public void Url_Works()
    {
        VersionCreateParams parameters = new() { SkillID = "skill_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(new Uri("https://api.anthropic.com/v1/skills/skill_id/versions"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        VersionCreateParams parameters = new() { SkillID = "skill_id", Betas = ["string"] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["skills-2025-10-02", "string"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }
}
