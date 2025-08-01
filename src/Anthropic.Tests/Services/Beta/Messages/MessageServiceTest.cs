using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages.BetaCacheControlEphemeralProperties;
using Anthropic.Models.Beta.Messages.BetaMessageParamProperties;
using Anthropic.Models.Beta.Messages.BetaToolProperties;
using Anthropic.Models.Beta.Messages.MessageCreateParamsProperties;
using Anthropic.Models.Messages;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Services.Beta.Messages;

public class MessageServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaMessage = await this.client.Beta.Messages.Create(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "string", Role = Role.User }],
                Model = Model.Claude3_7SonnetLatest,
                Container = "container",
                MCPServers =
                [
                    new()
                    {
                        Name = "name",
                        URL = "url",
                        AuthorizationToken = "authorization_token",
                        ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
                    },
                ],
                Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
                ServiceTier = ServiceTier.Auto,
                StopSequences = ["string"],
                Stream = true,
                System = new List<Messages::BetaTextBlockParam>()
                {
                    new()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { TTL = TTL.TTL5m },
                        Citations =
                        [
                            new Messages::BetaCitationCharLocationParam()
                            {
                                CitedText = "cited_text",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                },
                Temperature = 1,
                Thinking = new Messages::BetaThinkingConfigEnabled(1024),
                ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::BetaTool()
                    {
                        InputSchema = new()
                        {
                            Properties1 = JsonSerializer.Deserialize<JsonElement>(
                                "{\"location\":{\"description\":\"The city and state, e.g. San Francisco, CA\",\"type\":\"string\"},\"unit\":{\"description\":\"Unit for the output - one of (celsius, fahrenheit)\",\"type\":\"string\"}}"
                            ),
                            Required = ["location"],
                        },
                        Name = "name",
                        CacheControl = new() { TTL = TTL.TTL5m },
                        Description = "Get the current weather in a given location",
                        Type = Type.Custom,
                    },
                ],
                TopK = 5,
                TopP = 0.7,
                Betas = [AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaMessage.Validate();
    }

    [Fact]
    public async Task CountTokens_Works()
    {
        var betaMessageTokensCount = await this.client.Beta.Messages.CountTokens(
            new()
            {
                Messages = [new() { Content = "string", Role = Role.User }],
                Model = Model.Claude3_7SonnetLatest,
                MCPServers =
                [
                    new()
                    {
                        Name = "name",
                        URL = "url",
                        AuthorizationToken = "authorization_token",
                        ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
                    },
                ],
                System = new List<Messages::BetaTextBlockParam>()
                {
                    new()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { TTL = TTL.TTL5m },
                        Citations =
                        [
                            new Messages::BetaCitationCharLocationParam()
                            {
                                CitedText = "cited_text",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                },
                Thinking = new Messages::BetaThinkingConfigEnabled(1024),
                ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::BetaTool()
                    {
                        InputSchema = new()
                        {
                            Properties1 = JsonSerializer.Deserialize<JsonElement>(
                                "{\"location\":{\"description\":\"The city and state, e.g. San Francisco, CA\",\"type\":\"string\"},\"unit\":{\"description\":\"Unit for the output - one of (celsius, fahrenheit)\",\"type\":\"string\"}}"
                            ),
                            Required = ["location"],
                        },
                        Name = "name",
                        CacheControl = new() { TTL = TTL.TTL5m },
                        Description = "Get the current weather in a given location",
                        Type = Type.Custom,
                    },
                ],
                Betas = [AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaMessageTokensCount.Validate();
    }
}
