using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Skills;

namespace Anthropic.Tests.Models.Beta.Skills;

public class SkillCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new SkillCreateParams
        {
            Files = [files],
            DisplayTitle = "display_title",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        List<BinaryContent> expectedFiles = [files];
        string expectedDisplayTitle = "display_title";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedFiles.Count, parameters.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], parameters.Files[i]);
        }
        Assert.Equal(expectedDisplayTitle, parameters.DisplayTitle);
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
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new SkillCreateParams { Files = [files], DisplayTitle = "display_title" };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new SkillCreateParams
        {
            Files = [files],
            DisplayTitle = "display_title",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new SkillCreateParams
        {
            Files = [files],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.DisplayTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("display_title"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new SkillCreateParams
        {
            Files = [files],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            DisplayTitle = null,
        };

        Assert.Null(parameters.DisplayTitle);
        Assert.True(parameters.RawBodyData.ContainsKey("display_title"));
    }

    [Fact]
    public void Url_Works()
    {
        SkillCreateParams parameters = new() { Files = [Encoding.UTF8.GetBytes("Example data")] };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/skills?beta=true"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SkillCreateParams parameters = new()
        {
            Files = [Encoding.UTF8.GetBytes("Example data")],
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
        var parameters = new SkillCreateParams
        {
            Files = [Encoding.UTF8.GetBytes("Example data")],
            DisplayTitle = "display_title",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        SkillCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
