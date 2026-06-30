using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class EventStreamParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventStreamParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            EventDeltas = [BetaManagedAgentsDeltaType.AgentMessage],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedSessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        List<ApiEnum<string, BetaManagedAgentsDeltaType>> expectedEventDeltas =
        [
            BetaManagedAgentsDeltaType.AgentMessage,
        ];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedSessionID, parameters.SessionID);
        Assert.NotNull(parameters.EventDeltas);
        Assert.Equal(expectedEventDeltas.Count, parameters.EventDeltas.Count);
        for (int i = 0; i < expectedEventDeltas.Count; i++)
        {
            Assert.Equal(expectedEventDeltas[i], parameters.EventDeltas[i]);
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
        var parameters = new EventStreamParams { SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7" };

        Assert.Null(parameters.EventDeltas);
        Assert.False(parameters.RawQueryData.ContainsKey("event_deltas"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventStreamParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",

            // Null should be interpreted as omitted for these properties
            EventDeltas = null,
            Betas = null,
        };

        Assert.Null(parameters.EventDeltas);
        Assert.False(parameters.RawQueryData.ContainsKey("event_deltas"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        EventStreamParams parameters = new()
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            EventDeltas = [BetaManagedAgentsDeltaType.AgentMessage],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/sessions/sesn_011CZkZAtmR3yMPDzynEDxu7/events/stream?beta=true&event_deltas%5b%5d=agent.message"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        EventStreamParams parameters = new()
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
        var parameters = new EventStreamParams
        {
            SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            EventDeltas = [BetaManagedAgentsDeltaType.AgentMessage],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        EventStreamParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
