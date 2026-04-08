using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Vaults;

namespace Anthropic.Tests.Models.Beta.Vaults;

public class VaultArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultArchiveParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedVaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedVaultID, parameters.VaultID);
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
        var parameters = new VaultArchiveParams { VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VaultArchiveParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        VaultArchiveParams parameters = new() { VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri(
                "https://api.anthropic.com/v1/vaults/vlt_011CZkZDLs7fYzm1hXNPeRjv/archive?beta=true"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        VaultArchiveParams parameters = new()
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["managed-agents-2026-04-01", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VaultArchiveParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        VaultArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
