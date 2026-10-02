using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Plugins.Versions;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins.Versions;

public class VersionDownloadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionDownloadParams
        {
            PluginID = "plugin_id",
            Version = "version",
            OrganizationID = "organization_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedPluginID = "plugin_id";
        string expectedVersion = "version";
        string expectedOrganizationID = "organization_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedPluginID, parameters.PluginID);
        Assert.Equal(expectedVersion, parameters.Version);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
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
        var parameters = new VersionDownloadParams
        {
            PluginID = "plugin_id",
            Version = "version",
            OrganizationID = "organization_id",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VersionDownloadParams
        {
            PluginID = "plugin_id",
            Version = "version",
            OrganizationID = "organization_id",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VersionDownloadParams
        {
            PluginID = "plugin_id",
            Version = "version",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new VersionDownloadParams
        {
            PluginID = "plugin_id",
            Version = "version",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            OrganizationID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
    }

    [Fact]
    public void Url_Works()
    {
        VersionDownloadParams parameters = new()
        {
            PluginID = "plugin_id",
            Version = "version",
            OrganizationID = "organization_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/plugins/plugin_id/versions/version/content?beta=true&organization_id=organization_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        VersionDownloadParams parameters = new()
        {
            PluginID = "plugin_id",
            Version = "version",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,ce-plugins-2026-09-01"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionDownloadParams
        {
            PluginID = "plugin_id",
            Version = "version",
            OrganizationID = "organization_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        VersionDownloadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
