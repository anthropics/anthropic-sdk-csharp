using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Files;

namespace Anthropic.Tests.Models.Beta.Files;

public class FileUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("text");

        var parameters = new FileUploadParams
        {
            File = file,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        BinaryContent expectedFile = file;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedFile, parameters.File);
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
        BinaryContent file = Encoding.UTF8.GetBytes("text");

        var parameters = new FileUploadParams { File = file };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("text");

        var parameters = new FileUploadParams
        {
            File = file,

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        FileUploadParams parameters = new() { File = Encoding.UTF8.GetBytes("text") };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(new Uri("https://api.anthropic.com/v1/files"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        FileUploadParams parameters = new()
        {
            File = Encoding.UTF8.GetBytes("text"),
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["files-api-2025-04-14", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileUploadParams
        {
            File = Encoding.UTF8.GetBytes("text"),
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        FileUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
