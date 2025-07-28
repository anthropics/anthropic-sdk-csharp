using Json = System.Text.Json;
using MessageCountTokensParamsProperties = Anthropic.Models.Messages.MessageCountTokensParamsProperties;
using MessageCreateParamsProperties = Anthropic.Models.Messages.MessageCreateParamsProperties;
using MessageParamProperties = Anthropic.Models.Messages.MessageParamProperties;
using Messages = Anthropic.Models.Messages;
using Tasks = System.Threading.Tasks;
using Tests = Anthropic.Tests;
using ToolProperties = Anthropic.Models.Messages.ToolProperties;

namespace Anthropic.Tests.Service.Messages;

public class MessageServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var message = await this.client.Messages.Create(
            new Messages::MessageCreateParams()
            {
                MaxTokens = 1024,
                Messages =
                [
                    new Messages::MessageParam()
                    {
                        Content = MessageParamProperties::Content.Create("string"),
                        Role = MessageParamProperties::Role.User,
                    },
                ],
                Model = Messages::Model.Claude3_7SonnetLatest,
                Metadata = new Messages::Metadata()
                {
                    UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b",
                },
                ServiceTier = MessageCreateParamsProperties::ServiceTier.Auto,
                StopSequences = ["string"],
                Stream = true,
                System = MessageCreateParamsProperties::System.Create(
                    [
                        new Messages::TextBlockParam()
                        {
                            Text = "Today's date is 2024-06-01.",
                            CacheControl = new Messages::CacheControlEphemeral() { },
                            Citations =
                            [
                                Messages::TextCitationParam.Create(
                                    new Messages::CitationCharLocationParam()
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
                Thinking = Messages::ThinkingConfigParam.Create(
                    new Messages::ThinkingConfigEnabled() { BudgetTokens = 1024 }
                ),
                ToolChoice = Messages::ToolChoice.Create(
                    new Messages::ToolChoiceAuto() { DisableParallelToolUse = true }
                ),
                Tools =
                [
                    Messages::ToolUnion.Create(
                        new Messages::Tool()
                        {
                            InputSchema = new ToolProperties::InputSchema()
                            {
                                Properties1 = Json::JsonSerializer.Deserialize<Json::JsonElement>(
                                    "{\"location\":{\"description\":\"The city and state, e.g. San Francisco, CA\",\"type\":\"string\"},\"unit\":{\"description\":\"Unit for the output - one of (celsius, fahrenheit)\",\"type\":\"string\"}}"
                                ),
                                Required = ["location"],
                            },
                            Name = "name",
                            CacheControl = new Messages::CacheControlEphemeral() { },
                            Description = "Get the current weather in a given location",
                            Type = ToolProperties::Type.Custom,
                        }
                    ),
                ],
                TopK = 5,
                TopP = 0.7,
            }
        );
        message.Validate();
    }

    [Fact]
    public async Tasks::Task CountTokens_Works()
    {
        var messageTokensCount = await this.client.Messages.CountTokens(
            new Messages::MessageCountTokensParams()
            {
                Messages =
                [
                    new Messages::MessageParam()
                    {
                        Content = MessageParamProperties::Content.Create("string"),
                        Role = MessageParamProperties::Role.User,
                    },
                ],
                Model = Messages::Model.Claude3_7SonnetLatest,
                System = MessageCountTokensParamsProperties::System.Create(
                    [
                        new Messages::TextBlockParam()
                        {
                            Text = "Today's date is 2024-06-01.",
                            CacheControl = new Messages::CacheControlEphemeral() { },
                            Citations =
                            [
                                Messages::TextCitationParam.Create(
                                    new Messages::CitationCharLocationParam()
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
                Thinking = Messages::ThinkingConfigParam.Create(
                    new Messages::ThinkingConfigEnabled() { BudgetTokens = 1024 }
                ),
                ToolChoice = Messages::ToolChoice.Create(
                    new Messages::ToolChoiceAuto() { DisableParallelToolUse = true }
                ),
                Tools =
                [
                    Messages::MessageCountTokensTool.Create(
                        new Messages::Tool()
                        {
                            InputSchema = new ToolProperties::InputSchema()
                            {
                                Properties1 = Json::JsonSerializer.Deserialize<Json::JsonElement>(
                                    "{\"location\":{\"description\":\"The city and state, e.g. San Francisco, CA\",\"type\":\"string\"},\"unit\":{\"description\":\"Unit for the output - one of (celsius, fahrenheit)\",\"type\":\"string\"}}"
                                ),
                                Required = ["location"],
                            },
                            Name = "name",
                            CacheControl = new Messages::CacheControlEphemeral() { },
                            Description = "Get the current weather in a given location",
                            Type = ToolProperties::Type.Custom,
                        }
                    ),
                ],
            }
        );
        messageTokensCount.Validate();
    }
}
