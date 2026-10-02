using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class PluginCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new PluginCreateParams
        {
            Files = [files],
            MarketplaceID = "marketplace_id",
            ReleaseNotes = "release_notes",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        List<BinaryContent> expectedFiles = [files];
        string expectedMarketplaceID = "marketplace_id";
        string expectedReleaseNotes = "release_notes";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedFiles.Count, parameters.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], parameters.Files[i]);
        }
        Assert.Equal(expectedMarketplaceID, parameters.MarketplaceID);
        Assert.Equal(expectedReleaseNotes, parameters.ReleaseNotes);
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

        var parameters = new PluginCreateParams { Files = [files] };

        Assert.Null(parameters.MarketplaceID);
        Assert.False(parameters.RawBodyData.ContainsKey("marketplace_id"));
        Assert.Null(parameters.ReleaseNotes);
        Assert.False(parameters.RawBodyData.ContainsKey("release_notes"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new PluginCreateParams
        {
            Files = [files],

            // Null should be interpreted as omitted for these properties
            MarketplaceID = null,
            ReleaseNotes = null,
            Betas = null,
        };

        Assert.Null(parameters.MarketplaceID);
        Assert.False(parameters.RawBodyData.ContainsKey("marketplace_id"));
        Assert.Null(parameters.ReleaseNotes);
        Assert.False(parameters.RawBodyData.ContainsKey("release_notes"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        PluginCreateParams parameters = new() { Files = [Encoding.UTF8.GetBytes("Example data")] };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/plugins?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        PluginCreateParams parameters = new()
        {
            Files = [Encoding.UTF8.GetBytes("Example data")],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,ce-plugins-2026-09-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void IsBodyRepeatable_Works()
    {
        BinaryContent files = Encoding.UTF8.GetBytes("Example data");

        var parameters = new PluginCreateParams
        {
            Files = [files],
            MarketplaceID = "marketplace_id",
            ReleaseNotes = "release_notes",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.True(parameters.IsBodyRepeatable());
    }

    [Fact]
    public void IsBodyRepeatableFromStream_Works()
    {
        BinaryContent files = new BinaryContent
        {
            Stream = new MemoryStream(Encoding.UTF8.GetBytes("Example data")),
        };

        var parameters = new PluginCreateParams
        {
            Files = [files],
            MarketplaceID = "marketplace_id",
            ReleaseNotes = "release_notes",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.False(parameters.IsBodyRepeatable());
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PluginCreateParams
        {
            Files = [Encoding.UTF8.GetBytes("Example data")],
            MarketplaceID = "marketplace_id",
            ReleaseNotes = "release_notes",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        PluginCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
