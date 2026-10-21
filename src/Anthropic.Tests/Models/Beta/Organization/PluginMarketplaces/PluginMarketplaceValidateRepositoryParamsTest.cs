using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;

namespace Anthropic.Tests.Models.Beta.Organization.PluginMarketplaces;

public class PluginMarketplaceValidateRepositoryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PluginMarketplaceValidateRepositoryParams
        {
            RepositoryUrl = "https://github.com/example-org/example-marketplace",
            Ref = "main",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedRepositoryUrl = "https://github.com/example-org/example-marketplace";
        string expectedRef = "main";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedRepositoryUrl, parameters.RepositoryUrl);
        Assert.Equal(expectedRef, parameters.Ref);
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
        var parameters = new PluginMarketplaceValidateRepositoryParams
        {
            RepositoryUrl = "https://github.com/example-org/example-marketplace",
            Ref = "main",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PluginMarketplaceValidateRepositoryParams
        {
            RepositoryUrl = "https://github.com/example-org/example-marketplace",
            Ref = "main",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new PluginMarketplaceValidateRepositoryParams
        {
            RepositoryUrl = "https://github.com/example-org/example-marketplace",
            Ref = "main",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PluginMarketplaceValidateRepositoryParams
        {
            RepositoryUrl = "https://github.com/example-org/example-marketplace",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Ref);
        Assert.False(parameters.RawBodyData.ContainsKey("ref"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PluginMarketplaceValidateRepositoryParams
        {
            RepositoryUrl = "https://github.com/example-org/example-marketplace",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Ref = null,
        };

        Assert.Null(parameters.Ref);
        Assert.True(parameters.RawBodyData.ContainsKey("ref"));
    }

    [Fact]
    public void Url_Works()
    {
        PluginMarketplaceValidateRepositoryParams parameters = new()
        {
            RepositoryUrl = "https://github.com/example-org/example-marketplace",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/plugin_marketplaces/validate_repository?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        PluginMarketplaceValidateRepositoryParams parameters = new()
        {
            RepositoryUrl = "https://github.com/example-org/example-marketplace",
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
        var parameters = new PluginMarketplaceValidateRepositoryParams
        {
            RepositoryUrl = "https://github.com/example-org/example-marketplace",
            Ref = "main",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        PluginMarketplaceValidateRepositoryParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
