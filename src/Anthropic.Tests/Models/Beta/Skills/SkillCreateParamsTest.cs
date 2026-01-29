using System;
using System.Net.Http;
using System.Text;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Skills;

namespace Anthropic.Tests.Models.Beta.Skills;

public class SkillCreateParamsTest : TestBase
{
    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SkillCreateParams
        {
            DisplayTitle = "display_title",
            Files = [Encoding.UTF8.GetBytes("text")],
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SkillCreateParams
        {
            DisplayTitle = "display_title",
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
        var parameters = new SkillCreateParams { Betas = [AnthropicBeta.MessageBatches2024_09_24] };

        Assert.Null(parameters.DisplayTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("display_title"));
        Assert.Null(parameters.Files);
        Assert.False(parameters.RawBodyData.ContainsKey("files"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SkillCreateParams
        {
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            DisplayTitle = null,
            Files = null,
        };

        Assert.Null(parameters.DisplayTitle);
        Assert.True(parameters.RawBodyData.ContainsKey("display_title"));
        Assert.Null(parameters.Files);
        Assert.True(parameters.RawBodyData.ContainsKey("files"));
    }

    [Fact]
    public void Url_Works()
    {
        SkillCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(new Uri("https://api.anthropic.com/v1/skills"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SkillCreateParams parameters = new() { Betas = [AnthropicBeta.MessageBatches2024_09_24] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["skills-2025-10-02", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }
}
