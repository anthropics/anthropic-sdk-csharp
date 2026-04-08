using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class CredentialListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CredentialListParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            IncludeArchived = true,
            Limit = 0,
            Page = "page",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedVaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        bool expectedIncludeArchived = true;
        int expectedLimit = 0;
        string expectedPage = "page";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedVaultID, parameters.VaultID);
        Assert.Equal(expectedIncludeArchived, parameters.IncludeArchived);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
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
        var parameters = new CredentialListParams { VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" };

        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CredentialListParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",

            // Null should be interpreted as omitted for these properties
            IncludeArchived = null,
            Limit = null,
            Page = null,
            Betas = null,
        };

        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        CredentialListParams parameters = new()
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            IncludeArchived = true,
            Limit = 0,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri(
                "https://api.anthropic.com/v1/vaults/vlt_011CZkZDLs7fYzm1hXNPeRjv/credentials?beta=true&include_archived=true&limit=0&page=page"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CredentialListParams parameters = new()
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
        var parameters = new CredentialListParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            IncludeArchived = true,
            Limit = 0,
            Page = "page",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        CredentialListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
