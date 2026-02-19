using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Beta.Messages;
using Batches = Anthropic.Models.Beta.Messages.Batches;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Services.Beta.Messages;

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
                            Messages = [new() { Content = "Hello, world", Role = Role.User }],
                            Model = Messages::Model.ClaudeOpus4_6,
                            Container = new BetaContainerParams()
                            {
                                ID = "id",
                                Skills =
                                [
                                    new()
                                    {
                                        SkillID = "x",
                                        Type = BetaSkillParamsType.Anthropic,
                                        Version = "x",
                                    },
                                ],
                            },
                            ContextManagement = new()
                            {
                                Edits =
                                [
                                    new BetaClearToolUses20250919Edit()
                                    {
                                        ClearAtLeast = new(0),
                                        ClearToolInputs = true,
                                        ExcludeTools = ["string"],
                                        Keep = new(0),
                                        Trigger = new BetaInputTokensTrigger(1),
                                    },
                                ],
                            },
                            InferenceGeo = "inference_geo",
                            McpServers =
                            [
                                new()
                                {
                                    Name = "name",
                                    Url = "url",
                                    AuthorizationToken = "authorization_token",
                                    ToolConfiguration = new()
                                    {
                                        AllowedTools = ["string"],
                                        Enabled = true,
                                    },
                                },
                            ],
                            Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
                            OutputConfig = new()
                            {
                                Effort = Effort.Low,
                                Format = new()
                                {
                                    Schema = new Dictionary<string, JsonElement>()
                                    {
                                        { "foo", JsonSerializer.SerializeToElement("bar") },
                                    },
                                },
                            },
                            OutputFormat = new()
                            {
                                Schema = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                            },
                            ServiceTier = Batches::ServiceTier.Auto,
                            Speed = Batches::Speed.Standard,
                            StopSequences = ["string"],
                            Stream = true,
                            System = new(
                                [
                                    new BetaTextBlockParam()
                                    {
                                        Text = "Today's date is 2024-06-01.",
                                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                                        Citations =
                                        [
                                            new BetaCitationCharLocationParam()
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
                            Thinking = new BetaThinkingConfigEnabled(1024),
                            ToolChoice = new BetaToolChoiceAuto() { DisableParallelToolUse = true },
                            Tools =
                            [
                                new BetaTool()
                                {
                                    InputSchema = new()
                                    {
                                        Properties = new Dictionary<string, JsonElement>()
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
                                    AllowedCallers = [BetaToolAllowedCaller.Direct],
                                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                                    DeferLoading = true,
                                    Description = "Get the current weather in a given location",
                                    EagerInputStreaming = true,
                                    InputExamples =
                                    [
                                        new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        },
                                    ],
                                    Strict = true,
                                    Type = BetaToolType.Custom,
                                },
                            ],
                            TopK = 5,
                            TopP = 0.7,
                        },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        betaMessageBatch.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaMessageBatch = await this.client.Beta.Messages.Batches.Retrieve(
            "message_batch_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaMessageBatch.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Messages.Batches.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaDeletedMessageBatch = await this.client.Beta.Messages.Batches.Delete(
            "message_batch_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaDeletedMessageBatch.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var betaMessageBatch = await this.client.Beta.Messages.Batches.Cancel(
            "message_batch_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaMessageBatch.Validate();
    }

    [Fact(Skip = "Mock server doesn't support application/x-jsonl responses")]
    public async Task ResultsStreaming_Works()
    {
        var stream = this.client.Beta.Messages.Batches.ResultsStreaming(
            "message_batch_id",
            new(),
            TestContext.Current.CancellationToken
        );

        await foreach (var betaMessageBatchIndividualResponse in stream)
        {
            betaMessageBatchIndividualResponse.Validate();
        }
    }
}
