using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class SessionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SessionUpdateParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Title = "Order #1234 inquiry",
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedSessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedTitle = "Order #1234 inquiry";
        List<string> expectedVaultIds = ["string"];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedSessionID, parameters.SessionID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.NotNull(parameters.VaultIds);
        Assert.Equal(expectedVaultIds.Count, parameters.VaultIds.Count);
        for (int i = 0; i < expectedVaultIds.Count; i++)
        {
            Assert.Equal(expectedVaultIds[i], parameters.VaultIds[i]);
        }
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
        var parameters = new SessionUpdateParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Title = "Order #1234 inquiry",
        };

        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_ids"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SessionUpdateParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Title = "Order #1234 inquiry",

            // Null should be interpreted as omitted for these properties
            VaultIds = null,
            Betas = null,
        };

        Assert.Null(parameters.VaultIds);
        Assert.False(parameters.RawBodyData.ContainsKey("vault_ids"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SessionUpdateParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SessionUpdateParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Metadata = null,
            Title = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Title);
        Assert.True(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void Url_Works()
    {
        SessionUpdateParams parameters = new() { SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri(
                "https://api.anthropic.com/v1/sessions/sesn_011CZkZAtmR3yMPDzynEDxu7?beta=true"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SessionUpdateParams parameters = new()
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
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
        var parameters = new SessionUpdateParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Title = "Order #1234 inquiry",
            VaultIds = ["string"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        SessionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
