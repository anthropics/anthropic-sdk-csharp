using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Messages;
using Anthropic.Models.Messages.MessageCreateParamsProperties;
using Anthropic.Models.Messages.MessageParamProperties;
using Anthropic.Models.Messages.ToolProperties;

namespace Anthropic.Tests.Services.Messages;

public class MessageServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var message = await this.client.Messages.Create(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "string", Role = Role.User }],
                Model = Model.Claude3_7SonnetLatest,
                Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
                ServiceTier = ServiceTier.Auto,
                StopSequences = ["string"],
                Stream = true,
                System = new List<TextBlockParam>()
                {
                    new()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new(),
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
                },
                Temperature = 1,
                Thinking = new ThinkingConfigEnabled() { BudgetTokens = 1024 },
                ToolChoice = new ToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Tool()
                    {
                        InputSchema = new()
                        {
                            Properties1 = JsonSerializer.Deserialize<JsonElement>(
                                "{\"location\":{\"description\":\"The city and state, e.g. San Francisco, CA\",\"type\":\"string\"},\"unit\":{\"description\":\"Unit for the output - one of (celsius, fahrenheit)\",\"type\":\"string\"}}"
                            ),
                            Required = ["location"],
                        },
                        Name = "name",
                        CacheControl = new(),
                        Description = "Get the current weather in a given location",
                        Type = Type.Custom,
                    },
                ],
                TopK = 5,
                TopP = 0.7,
            }
        );
        message.Validate();
    }

    [Fact]
    public async Task CountTokens_Works()
    {
        var messageTokensCount = await this.client.Messages.CountTokens(
            new()
            {
                Messages = [new() { Content = "string", Role = Role.User }],
                Model = Model.Claude3_7SonnetLatest,
                System = new List<TextBlockParam>()
                {
                    new()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new(),
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
                },
                Thinking = new ThinkingConfigEnabled() { BudgetTokens = 1024 },
                ToolChoice = new ToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Tool()
                    {
                        InputSchema = new()
                        {
                            Properties1 = JsonSerializer.Deserialize<JsonElement>(
                                "{\"location\":{\"description\":\"The city and state, e.g. San Francisco, CA\",\"type\":\"string\"},\"unit\":{\"description\":\"Unit for the output - one of (celsius, fahrenheit)\",\"type\":\"string\"}}"
                            ),
                            Required = ["location"],
                        },
                        Name = "name",
                        CacheControl = new(),
                        Description = "Get the current weather in a given location",
                        Type = Type.Custom,
                    },
                ],
            }
        );
        messageTokensCount.Validate();
    }
}
