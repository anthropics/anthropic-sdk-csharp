using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Messages.Batches;
using Anthropic.Tests;
using Batches = Anthropic.Models.Messages.Batches;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Services.Messages;

public class BatchServiceTest
{
    [Theory]
    [AnthropicTestClients(TestSupportTypes.All & ~TestSupportTypes.Bedrock)]
    [AnthropicTestData(TestSupportTypes.Anthropic, "Claude3_7SonnetLatest")]
    [AnthropicTestData(TestSupportTypes.Foundry, "claude-sonnet-4-5")]
    public async Task Create_Works(IAnthropicClient client, string modelName)
    {
        var messageBatch = await client.Messages.Batches.Create(
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
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Container = "container",
                            Messages =
                            [
                                new() { Content = "Hello, world", Role = Messages::Role.User },
                            ],
                            Model = modelName,
                            InferenceGeo = "inference_geo",
                            Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
                            OutputConfig = new()
                            {
                                Effort = Messages::Effort.Low,
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
                                    new Messages::TextBlockParam()
                                    {
                                        Text = "Today's date is 2024-06-01.",
                                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                    AllowedCallers = [Messages::ToolAllowedCaller.Direct],
                                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                    Type = Messages::Type.Custom,
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

    [Theory]
    [AnthropicTestClients(TestSupportTypes.All & ~TestSupportTypes.Bedrock)]
    public async Task Retrieve_Works(IAnthropicClient client)
    {
        var messageBatch = await client.Messages.Batches.Retrieve(
            "message_batch_id",
            new(),
            TestContext.Current.CancellationToken
        );
        messageBatch.Validate();
    }

    [Theory]
    [AnthropicTestClients(TestSupportTypes.All & ~TestSupportTypes.Bedrock)]
    public async Task List_Works(IAnthropicClient client)
    {
        var page = await client.Messages.Batches.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Theory]
    [AnthropicTestClients(TestSupportTypes.All & ~TestSupportTypes.Bedrock)]
    public async Task Delete_Works(IAnthropicClient client)
    {
        var deletedMessageBatch = await client.Messages.Batches.Delete(
            "message_batch_id",
            new(),
            TestContext.Current.CancellationToken
        );
        deletedMessageBatch.Validate();
    }

    [Theory]
    [AnthropicTestClients(TestSupportTypes.All & ~TestSupportTypes.Bedrock)]
    public async Task Cancel_Works(IAnthropicClient client)
    {
        var messageBatch = await client.Messages.Batches.Cancel(
            "message_batch_id",
            new(),
            TestContext.Current.CancellationToken
        );
        messageBatch.Validate();
    }

    [Theory(Skip = "Prism doesn't support application/x-jsonl responses")]
    [AnthropicTestClients(TestSupportTypes.All & ~TestSupportTypes.Bedrock)]
    public async Task ResultsStreaming_Works(IAnthropicClient client)
    {
        var stream = client.Messages.Batches.ResultsStreaming(
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
