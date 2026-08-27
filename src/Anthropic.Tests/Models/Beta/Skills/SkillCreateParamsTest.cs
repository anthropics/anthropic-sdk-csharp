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
            DisplayName = "display_name",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        List<BinaryContent> expectedFiles = [files];
        string expectedDisplayName = "display_name";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedFiles.Count, parameters.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], parameters.Files[i]);
        }
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
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

        var parameters = new SkillCreateParams { Files = [files], DisplayName = "display_name" };

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
            DisplayName = "display_name",

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

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new SkillCreateParams
        {
            Files = [files],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            DisplayName = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
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
            ["message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SkillCreateParams
        {
            Files = [Encoding.UTF8.GetBytes("Example data")],
            DisplayName = "display_name",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        SkillCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
