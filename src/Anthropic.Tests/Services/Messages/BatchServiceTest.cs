using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Messages.Batches;
using Messages = Anthropic.Models.Messages;

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
                            Messages =
                            [
                                new() { Content = "Hello, world", Role = Messages::Role.User },
                            ],
                            Model = Messages::Model.Claude3_7SonnetLatest,
                            Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
                            ServiceTier = ServiceTier.Auto,
                            StopSequences = ["string"],
                            Stream = true,
                            System = new(
                                [
                                    new()
                                    {
                                        Text = "Today's date is 2024-06-01.",
                                        CacheControl = new() { TTL = Messages::TTL.TTL5m },
                                        Citations =
                                        [
                                            new Messages::CitationCharLocationParam()
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
                            Thinking = new Messages::ThinkingConfigEnabled(1024),
                            ToolChoice = new Messages::ToolChoiceAuto()
                            {
                                DisableParallelToolUse = true,
                            },
                            Tools =
                            [
                                new Messages::Tool()
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
                                    Type = Messages::Type.Custom,
                                },
                            ],
                            TopK = 5,
                            TopP = 0.7,
                        },
                    },
                ],
            }
        );
        messageBatch.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var messageBatch = await this.client.Messages.Batches.Retrieve(
            new() { MessageBatchID = "message_batch_id" }
        );
        messageBatch.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Messages.Batches.List();
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var deletedMessageBatch = await this.client.Messages.Batches.Delete(
            new() { MessageBatchID = "message_batch_id" }
        );
        deletedMessageBatch.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var messageBatch = await this.client.Messages.Batches.Cancel(
            new() { MessageBatchID = "message_batch_id" }
        );
        messageBatch.Validate();
    }

    [Fact(Skip = "Prism doesn't support application/x-jsonl responses")]
    public async Task ResultsStreaming_Works()
    {
        var stream = this.client.Messages.Batches.ResultsStreaming(
            new() { MessageBatchID = "message_batch_id" }
        );

        await foreach (var messageBatchIndividualResponse in stream)
        {
            messageBatchIndividualResponse.Validate();
        }
    }
}
