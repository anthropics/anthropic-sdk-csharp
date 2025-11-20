using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Beta.Messages.Batches;
using Anthropic.Tests;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Services.Beta.Messages;

public class BatchServiceTest
{
    [Theory(Skip = "prism validates based on the non-beta endpoint")]
    [AnthropicTestClients]
    public async Task Create_Works(IAnthropicClient client)
    {
        var betaMessageBatch = await client.Beta.Messages.Batches.Create(
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
                                new() { Content = "Hello, world", Role = Messages::Role.User },
                            ],
                            Model = global::Anthropic.Models.Messages.Model.Claude3_7SonnetLatest,
                            Container = new Messages::BetaContainerParams()
                            {
                                ID = "id",
                                Skills =
                                [
                                    new()
                                    {
                                        SkillID = "x",
                                        Type = Messages::BetaSkillParamsType.Anthropic,
                                        Version = "x",
                                    },
                                ],
                            },
                            ContextManagement = new()
                            {
                                Edits =
                                [
                                    new Messages::BetaClearToolUses20250919Edit()
                                    {
                                        ClearAtLeast = new(0),
                                        ClearToolInputs = true,
                                        ExcludeTools = ["string"],
                                        Keep = new(0),
                                        Trigger = new Messages::BetaInputTokensTrigger(1),
                                    },
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
                            OutputFormat = new()
                            {
                                Schema = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                            },
                            ServiceTier = ServiceTier.Auto,
                            StopSequences = ["string"],
                            Stream = true,
                            System = new(
                                [
                                    new Models.Beta.Messages.BetaTextBlockParam()
                                    {
                                        Text = "Today's date is 2024-06-01.",
                                        CacheControl = new() { TTL = Messages::TTL.TTL5m },
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
                                ]
                            ),
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
                                        Properties1 = new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "location",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            { "unit", JsonSerializer.SerializeToElement("bar") },
                                        },
                                        Required = ["location"],
                                    },
                                    Name = "name",
                                    CacheControl = new() { TTL = Messages::TTL.TTL5m },
                                    Description = "Get the current weather in a given location",
                                    Strict = true,
                                    Type = Messages::BetaToolType.Custom,
                                },
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

    [Theory]
    [AnthropicTestClients]
    public async Task Retrieve_Works(IAnthropicClient client)
    {
        var betaMessageBatch = await client.Beta.Messages.Batches.Retrieve("message_batch_id");
        betaMessageBatch.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task List_Works(IAnthropicClient client)
    {
        var page = await client.Beta.Messages.Batches.List();
        page.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task Delete_Works(IAnthropicClient client)
    {
        var betaDeletedMessageBatch = await client.Beta.Messages.Batches.Delete("message_batch_id");
        betaDeletedMessageBatch.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task Cancel_Works(IAnthropicClient client)
    {
        var betaMessageBatch = await client.Beta.Messages.Batches.Cancel("message_batch_id");
        betaMessageBatch.Validate();
    }

    [Theory(Skip = "Prism doesn't support application/x-jsonl responses")]
    [AnthropicTestClients]
    public async Task ResultsStreaming_Works(IAnthropicClient client)
    {
        var stream = client.Beta.Messages.Batches.ResultsStreaming("message_batch_id");

        await foreach (var betaMessageBatchIndividualResponse in stream)
        {
            betaMessageBatchIndividualResponse.Validate();
        }
    }
}
