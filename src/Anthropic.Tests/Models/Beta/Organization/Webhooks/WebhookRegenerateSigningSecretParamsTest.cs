using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Webhooks;

namespace Anthropic.Tests.Models.Beta.Organization.Webhooks;

public class WebhookRegenerateSigningSecretParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookRegenerateSigningSecretParams
        {
            WebhookEndpointID = "webhook_endpoint_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedWebhookEndpointID = "webhook_endpoint_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedWebhookEndpointID, parameters.WebhookEndpointID);
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
        var parameters = new WebhookRegenerateSigningSecretParams
        {
            WebhookEndpointID = "webhook_endpoint_id",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookRegenerateSigningSecretParams
        {
            WebhookEndpointID = "webhook_endpoint_id",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new WebhookRegenerateSigningSecretParams
        {
            WebhookEndpointID = "webhook_endpoint_id",
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
    public void Url_Works()
    {
        WebhookRegenerateSigningSecretParams parameters = new()
        {
            WebhookEndpointID = "webhook_endpoint_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/webhooks/webhook_endpoint_id/regenerate_signing_secret"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookRegenerateSigningSecretParams parameters = new()
        {
            WebhookEndpointID = "webhook_endpoint_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,webhooks-2026-10-07"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookRegenerateSigningSecretParams
        {
            WebhookEndpointID = "webhook_endpoint_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        WebhookRegenerateSigningSecretParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
