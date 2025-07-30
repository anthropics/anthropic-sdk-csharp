using Beta = Anthropic.Models.Beta;
using BetaCacheControlEphemeralProperties = Anthropic.Models.Beta.Messages.BetaCacheControlEphemeralProperties;
using BetaMessageParamProperties = Anthropic.Models.Beta.Messages.BetaMessageParamProperties;
using BetaToolProperties = Anthropic.Models.Beta.Messages.BetaToolProperties;
using Json = System.Text.Json;
using Messages = Anthropic.Models.Messages;
using Messages1 = Anthropic.Models.Beta.Messages;
using ParamsProperties = Anthropic.Models.Beta.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties;
using Tasks = System.Threading.Tasks;
using Tests = Anthropic.Tests;

namespace Anthropic.Tests.Service.Beta.Messages.Batches;

public class BatchServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
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
                            Messages =
                            [
                                new()
                                {
                                    Content = "Hello, world",
                                    Role = BetaMessageParamProperties::Role.User,
                                },
                            ],
                            Model = Messages::Model.Claude3_7SonnetLatest,
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
                            ServiceTier = ParamsProperties::ServiceTier.Auto,
                            StopSequences = ["string"],
                            Stream = true,
                            System =
                            [
                                new Messages1::BetaTextBlockParam()
                                {
                                    Text = "Today's date is 2024-06-01.",
                                    CacheControl = new()
                                    {
                                        TTL = BetaCacheControlEphemeralProperties::TTL.TTL5m,
                                    },
                                    Citations =
                                    [
                                        new Messages1::BetaCitationCharLocationParam()
                                        {
                                            CitedText = "cited_text",
                                            DocumentIndex = 0,
                                            DocumentTitle = "x",
                                            EndCharIndex = 0,
                                            StartCharIndex = 0,
                                        },
                                    ],
                                },
                            ],
                            Temperature = 1,
                            Thinking = new Messages1::BetaThinkingConfigEnabled()
                            {
                                BudgetTokens = 1024,
                            },
                            ToolChoice = new Messages1::BetaToolChoiceAuto()
                            {
                                DisableParallelToolUse = true,
                            },
                            Tools =
                            [
                                new Messages1::BetaTool()
                                {
                                    InputSchema = new()
                                    {
                                        Properties1 =
                                            Json::JsonSerializer.Deserialize<Json::JsonElement>(
                                                "{\"location\":{\"description\":\"The city and state, e.g. San Francisco, CA\",\"type\":\"string\"},\"unit\":{\"description\":\"Unit for the output - one of (celsius, fahrenheit)\",\"type\":\"string\"}}"
                                            ),
                                        Required = ["location"],
                                    },
                                    Name = "name",
                                    CacheControl = new()
                                    {
                                        TTL = BetaCacheControlEphemeralProperties::TTL.TTL5m,
                                    },
                                    Description = "Get the current weather in a given location",
                                    Type = BetaToolProperties::Type.Custom,
                                },
                            ],
                            TopK = 5,
                            TopP = 0.7,
                        },
                    },
                ],
                Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaMessageBatch.Validate();
    }

    [Fact]
    public async Tasks::Task Retrieve_Works()
    {
        var betaMessageBatch = await this.client.Beta.Messages.Batches.Retrieve(
            new()
            {
                MessageBatchID = "message_batch_id",
                Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaMessageBatch.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Beta.Messages.Batches.List(
            new()
            {
                AfterID = "after_id",
                BeforeID = "before_id",
                Limit = 1,
                Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task Delete_Works()
    {
        var betaDeletedMessageBatch = await this.client.Beta.Messages.Batches.Delete(
            new()
            {
                MessageBatchID = "message_batch_id",
                Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaDeletedMessageBatch.Validate();
    }

    [Fact]
    public async Tasks::Task Cancel_Works()
    {
        var betaMessageBatch = await this.client.Beta.Messages.Batches.Cancel(
            new()
            {
                MessageBatchID = "message_batch_id",
                Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaMessageBatch.Validate();
    }

    [Fact]
    public async Tasks::Task Results_Works()
    {
        var betaMessageBatchIndividualResponse = await this.client.Beta.Messages.Batches.Results(
            new()
            {
                MessageBatchID = "message_batch_id",
                Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        betaMessageBatchIndividualResponse.Validate();
    }
}
