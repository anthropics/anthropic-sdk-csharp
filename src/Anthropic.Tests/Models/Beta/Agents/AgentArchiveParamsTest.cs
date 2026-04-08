using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class AgentArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentArchiveParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedAgentID = "agent_011CZkYpogX7uDKUyvBTophP";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedAgentID, parameters.AgentID);
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
        var parameters = new AgentArchiveParams { AgentID = "agent_011CZkYpogX7uDKUyvBTophP" };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentArchiveParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentArchiveParams parameters = new() { AgentID = "agent_011CZkYpogX7uDKUyvBTophP" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri(
                "https://api.anthropic.com/v1/agents/agent_011CZkYpogX7uDKUyvBTophP/archive?beta=true"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AgentArchiveParams parameters = new()
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
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
        var parameters = new AgentArchiveParams
        {
            AgentID = "agent_011CZkYpogX7uDKUyvBTophP",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        AgentArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
