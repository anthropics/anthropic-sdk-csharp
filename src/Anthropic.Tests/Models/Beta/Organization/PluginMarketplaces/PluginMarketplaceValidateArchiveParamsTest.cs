using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;

namespace Anthropic.Tests.Models.Beta.Organization.PluginMarketplaces;

public class PluginMarketplaceValidateArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent archive = Encoding.UTF8.GetBytes("Example data");

        var parameters = new PluginMarketplaceValidateArchiveParams
        {
            Archive = archive,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        BinaryContent expectedArchive = archive;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedArchive, parameters.Archive);
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
        BinaryContent archive = Encoding.UTF8.GetBytes("Example data");

        var parameters = new PluginMarketplaceValidateArchiveParams { Archive = archive };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent archive = Encoding.UTF8.GetBytes("Example data");

        var parameters = new PluginMarketplaceValidateArchiveParams
        {
            Archive = archive,

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        BinaryContent archive = Encoding.UTF8.GetBytes("Example data");

        var parameters = new PluginMarketplaceValidateArchiveParams
        {
            Archive = archive,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        PluginMarketplaceValidateArchiveParams parameters = new()
        {
            Archive = Encoding.UTF8.GetBytes("Example data"),
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/plugin_marketplaces/validate_archive"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        PluginMarketplaceValidateArchiveParams parameters = new()
        {
            Archive = Encoding.UTF8.GetBytes("Example data"),
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,ce-plugins-2026-09-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void IsBodyRepeatable_Works()
    {
        BinaryContent archive = Encoding.UTF8.GetBytes("Example data");

        var parameters = new PluginMarketplaceValidateArchiveParams
        {
            Archive = archive,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        Assert.True(parameters.IsBodyRepeatable());
    }

    [Fact]
    public void IsBodyRepeatableFromStream_Works()
    {
        BinaryContent archive = new BinaryContent
        {
            Stream = new MemoryStream(Encoding.UTF8.GetBytes("Example data")),
        };

        var parameters = new PluginMarketplaceValidateArchiveParams
        {
            Archive = archive,
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        Assert.False(parameters.IsBodyRepeatable());
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PluginMarketplaceValidateArchiveParams
        {
            Archive = Encoding.UTF8.GetBytes("Example data"),
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        PluginMarketplaceValidateArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
