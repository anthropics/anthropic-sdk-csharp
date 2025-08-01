using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties;
using Anthropic.Models.Beta.Messages.BetaCacheControlEphemeralProperties;
using Anthropic.Models.Beta.Messages.BetaMessageParamProperties;
using Anthropic.Models.Beta.Messages.BetaToolProperties;
using Anthropic.Models.Messages;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Services.Beta.Messages.Batches;

public class BatchServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaMessageBatch = await this.client.Beta.Messages.Batches.Create(
            new()
            {
                Requests =
                [
                    new()
                    {
                        CustomID = "my-custom-id-1",
                        Params = new()
                        {
                            MaxTokens = 1024,
                            Messages = [new() { Content = "Hello, world", Role = Role.User }],
                            Model = Model.Claude3_7SonnetLatest,
                            Container = "container",
                            MCPServers =
                            [
                                new()
                                {
                                    Name = "name",
                                    URL = "url",
                                    AuthorizationToken = "authorization_token",
                                    ToolConfiguration = new()
                                    {
                                        AllowedTools = ["string"],
                                        Enabled = true,
                                    },
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
                            ToolChoice = new Messages::BetaToolChoiceAuto()
                            {
                                DisableParallelToolUse = true,
                            },
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
                        },
                    },
                ],
                Betas = [AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaMessageBatch.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaMessageBatch = await this.client.Beta.Messages.Batches.Retrieve(
            new()
            {
                MessageBatchID = "message_batch_id",
                Betas = [AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaMessageBatch.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Messages.Batches.List(
            new()
            {
                AfterID = "after_id",
                BeforeID = "before_id",
                Limit = 1,
                Betas = [AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaDeletedMessageBatch = await this.client.Beta.Messages.Batches.Delete(
            new()
            {
                MessageBatchID = "message_batch_id",
                Betas = [AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaDeletedMessageBatch.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var betaMessageBatch = await this.client.Beta.Messages.Batches.Cancel(
            new()
            {
                MessageBatchID = "message_batch_id",
                Betas = [AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaMessageBatch.Validate();
    }

    [Fact]
    public async Task Results_Works()
    {
        var betaMessageBatchIndividualResponse = await this.client.Beta.Messages.Batches.Results(
            new()
            {
                MessageBatchID = "message_batch_id",
                Betas = [AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaMessageBatchIndividualResponse.Validate();
    }
}
