using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Client.Models.Beta.Messages;
using Anthropic.Client.Models.Beta.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties;
using Anthropic.Client.Models.Beta.Messages.BetaCacheControlEphemeralProperties;
using Anthropic.Client.Models.Beta.Messages.BetaMessageParamProperties;
using Anthropic.Client.Models.Beta.Messages.BetaSkillParamsProperties;
using BetaToolProperties = Anthropic.Client.Models.Beta.Messages.BetaToolProperties;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Tests.Services.Beta.Messages.Batches;

public class BatchServiceTest : TestBase
{
    [Fact(Skip = "prism validates based on the non-beta endpoint")]
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
                            Messages = [new() { Content = new("Hello, world"), Role = Role.User }],
                            Model = Messages::Model.Claude3_7SonnetLatest,
                            Container = new(
                                new BetaContainerParams()
                                {
                                    ID = "id",
                                    Skills =
                                    [
                                        new()
                                        {
                                            SkillID = "x",
                                            Type = Type.Anthropic,
                                            Version = "x",
                                        },
                                    ],
                                }
                            ),
                            ContextManagement = new()
                            {
                                Edits =
                                [
                                    new(
                                        new BetaClearToolUses20250919Edit()
                                        {
                                            ClearAtLeast = new(0),
                                            ClearToolInputs = new(true),
                                            ExcludeTools = ["string"],
                                            Keep = new(0),
                                            Trigger = new(new BetaInputTokensTrigger(1)),
                                        }
                                    ),
                                ],
                            },
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
                            System = new(
                                [
                                    new()
                                    {
                                        Text = "Today's date is 2024-06-01.",
                                        CacheControl = new() { TTL = TTL.TTL5m },
                                        Citations =
                                        [
                                            new(
                                                new BetaCitationCharLocationParam()
                                                {
                                                    CitedText = "cited_text",
                                                    DocumentIndex = 0,
                                                    DocumentTitle = "x",
                                                    EndCharIndex = 0,
                                                    StartCharIndex = 0,
                                                }
                                            ),
                                        ],
                                    },
                                ]
                            ),
                            Temperature = 1,
                            Thinking = new(new BetaThinkingConfigEnabled(1024)),
                            ToolChoice = new(
                                new BetaToolChoiceAuto() { DisableParallelToolUse = true }
                            ),
                            Tools =
                            [
                                new(
                                    new BetaTool()
                                    {
                                        InputSchema = new()
                                        {
                                            Properties1 = new Dictionary<string, JsonElement>()
                                            {
                                                {
                                                    "location",
                                                    JsonSerializer.SerializeToElement("bar")
                                                },
                                                {
                                                    "unit",
                                                    JsonSerializer.SerializeToElement("bar")
                                                },
                                            },
                                            Required = ["location"],
                                        },
                                        Name = "name",
                                        CacheControl = new() { TTL = TTL.TTL5m },
                                        Description = "Get the current weather in a given location",
                                        Type = BetaToolProperties::Type.Custom,
                                    }
                                ),
                            ],
                            TopK = 5,
                            TopP = 0.7,
                        },
                    },
                ],
            }
        );
        betaMessageBatch.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaMessageBatch = await this.client.Beta.Messages.Batches.Retrieve(
            new() { MessageBatchID = "message_batch_id" }
        );
        betaMessageBatch.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Messages.Batches.List();
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaDeletedMessageBatch = await this.client.Beta.Messages.Batches.Delete(
            new() { MessageBatchID = "message_batch_id" }
        );
        betaDeletedMessageBatch.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var betaMessageBatch = await this.client.Beta.Messages.Batches.Cancel(
            new() { MessageBatchID = "message_batch_id" }
        );
        betaMessageBatch.Validate();
    }

    [Fact(Skip = "Prism doesn't support application/x-jsonl responses")]
    public async Task ResultsStreaming_Works()
    {
        var stream = this.client.Beta.Messages.Batches.ResultsStreaming(
            new() { MessageBatchID = "message_batch_id" }
        );

        await foreach (var betaMessageBatchIndividualResponse in stream)
        {
            betaMessageBatchIndividualResponse.Validate();
        }
    }
}
