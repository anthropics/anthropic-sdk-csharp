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
        BinaryContent files = Encoding.UTF8.GetBytes("text");

        var parameters = new VersionCreateParams
        {
            SkillID = "skill_id",
            Files = [files],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedSkillID = "skill_id";
        List<BinaryContent> expectedFiles = [files];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

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
        BinaryContent files = Encoding.UTF8.GetBytes("text");

        var parameters = new VersionCreateParams { SkillID = "skill_id", Files = [files] };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("text");

        var parameters = new VersionCreateParams
        {
            SkillID = "skill_id",
            Files = [files],

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VersionCreateParams
        {
            SkillID = "skill_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Files);
        Assert.False(parameters.RawBodyData.ContainsKey("files"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new VersionCreateParams
        {
            SkillID = "skill_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

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
        VersionCreateParams parameters = new()
        {
            SkillID = "skill_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["skills-2025-10-02", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionCreateParams
        {
            SkillID = "skill_id",
            Files = [Encoding.UTF8.GetBytes("text")],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        VersionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
