using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Messages;
using Batches = Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Services.Messages;

public class BatchServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var messageBatch = await this.client.Messages.Batches.Create(
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
                            Model = Model.ClaudeOpus4_6,
                            Container = "container",
                            InferenceGeo = "inference_geo",
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
                            ServiceTier = Batches::ServiceTier.Auto,
                            StopSequences = ["string"],
                            Stream = true,
                            System = new(
                                [
                                    new TextBlockParam()
                                    {
                                        Text = "Today's date is 2024-06-01.",
                                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                                        Citations =
                                        [
                                            new CitationCharLocationParam()
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
                            Thinking = new ThinkingConfigEnabled(1024),
                            ToolChoice = new ToolChoiceAuto() { DisableParallelToolUse = true },
                            Tools =
                            [
                                new Tool()
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
                                    AllowedCallers = [ToolAllowedCaller.Direct],
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
                                    Type = Type.Custom,
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
        messageBatch.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var messageBatch = await this.client.Messages.Batches.Retrieve(
            "message_batch_id",
            new(),
            TestContext.Current.CancellationToken
        );
        messageBatch.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Messages.Batches.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var deletedMessageBatch = await this.client.Messages.Batches.Delete(
            "message_batch_id",
            new(),
            TestContext.Current.CancellationToken
        );
        deletedMessageBatch.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var messageBatch = await this.client.Messages.Batches.Cancel(
            "message_batch_id",
            new(),
            TestContext.Current.CancellationToken
        );
        messageBatch.Validate();
    }

    [Fact(Skip = "Prism doesn't support application/x-jsonl responses")]
    public async Task ResultsStreaming_Works()
    {
        var stream = this.client.Messages.Batches.ResultsStreaming(
            "message_batch_id",
            new(),
            TestContext.Current.CancellationToken
        );

        await foreach (var messageBatchIndividualResponse in stream)
        {
            messageBatchIndividualResponse.Validate();
        }
    }
}
