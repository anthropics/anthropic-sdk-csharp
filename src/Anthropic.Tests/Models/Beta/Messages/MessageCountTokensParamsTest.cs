using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class MessageCountTokensParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageCountTokensParams
        {
            Messages = [new() { Content = "string", Role = Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
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
            McpServers =
            [
                new()
                {
                    Name = "name",
                    Url = "url",
                    AuthorizationToken = "authorization_token",
                    ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
                },
            ],
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
                            { "location", JsonSerializer.SerializeToElement("bar") },
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        List<BetaMessageParam> expectedMessages = [new() { Content = "string", Role = Role.User }];
        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus4_6;
        BetaContextManagementConfig expectedContextManagement = new()
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
        };
        List<BetaRequestMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "name",
                Url = "url",
                AuthorizationToken = "authorization_token",
                ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
            },
        ];
        BetaOutputConfig expectedOutputConfig = new()
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };
        BetaJsonOutputFormat expectedOutputFormat = new()
        {
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        MessageCountTokensParamsSystem expectedSystem = new(
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
        );
        BetaThinkingConfigParam expectedThinking = new BetaThinkingConfigEnabled(1024);
        BetaToolChoice expectedToolChoice = new BetaToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        List<Tool> expectedTools =
        [
            new BetaTool()
            {
                InputSchema = new()
                {
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "location", JsonSerializer.SerializeToElement("bar") },
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
        ];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedMessages.Count, parameters.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], parameters.Messages[i]);
        }
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedContextManagement, parameters.ContextManagement);
        Assert.NotNull(parameters.McpServers);
        Assert.Equal(expectedMcpServers.Count, parameters.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], parameters.McpServers[i]);
        }
        Assert.Equal(expectedOutputConfig, parameters.OutputConfig);
        Assert.Equal(expectedOutputFormat, parameters.OutputFormat);
        Assert.Equal(expectedSystem, parameters.System);
        Assert.Equal(expectedThinking, parameters.Thinking);
        Assert.Equal(expectedToolChoice, parameters.ToolChoice);
        Assert.NotNull(parameters.Tools);
        Assert.Equal(expectedTools.Count, parameters.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], parameters.Tools[i]);
        }
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageCountTokensParams
        {
            Messages = [new() { Content = "string", Role = Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
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
            OutputFormat = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        Assert.Null(parameters.McpServers);
        Assert.False(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.OutputConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("output_config"));
        Assert.Null(parameters.System);
        Assert.False(parameters.RawBodyData.ContainsKey("system"));
        Assert.Null(parameters.Thinking);
        Assert.False(parameters.RawBodyData.ContainsKey("thinking"));
        Assert.Null(parameters.ToolChoice);
        Assert.False(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MessageCountTokensParams
        {
            Messages = [new() { Content = "string", Role = Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
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
            OutputFormat = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },

            // Null should be interpreted as omitted for these properties
            McpServers = null,
            OutputConfig = null,
            System = null,
            Thinking = null,
            ToolChoice = null,
            Tools = null,
            Betas = null,
        };

        Assert.Null(parameters.McpServers);
        Assert.False(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.OutputConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("output_config"));
        Assert.Null(parameters.System);
        Assert.False(parameters.RawBodyData.ContainsKey("system"));
        Assert.Null(parameters.Thinking);
        Assert.False(parameters.RawBodyData.ContainsKey("thinking"));
        Assert.Null(parameters.ToolChoice);
        Assert.False(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageCountTokensParams
        {
            Messages = [new() { Content = "string", Role = Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            McpServers =
            [
                new()
                {
                    Name = "name",
                    Url = "url",
                    AuthorizationToken = "authorization_token",
                    ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
                },
            ],
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
                            { "location", JsonSerializer.SerializeToElement("bar") },
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.ContextManagement);
        Assert.False(parameters.RawBodyData.ContainsKey("context_management"));
        Assert.Null(parameters.OutputFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("output_format"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MessageCountTokensParams
        {
            Messages = [new() { Content = "string", Role = Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            McpServers =
            [
                new()
                {
                    Name = "name",
                    Url = "url",
                    AuthorizationToken = "authorization_token",
                    ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
                },
            ],
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
                            { "location", JsonSerializer.SerializeToElement("bar") },
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            ContextManagement = null,
            OutputFormat = null,
        };

        Assert.Null(parameters.ContextManagement);
        Assert.True(parameters.RawBodyData.ContainsKey("context_management"));
        Assert.Null(parameters.OutputFormat);
        Assert.True(parameters.RawBodyData.ContainsKey("output_format"));
    }

    [Fact]
    public void Url_Works()
    {
        MessageCountTokensParams parameters = new()
        {
            Messages = [new() { Content = "string", Role = Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(new Uri("https://api.anthropic.com/v1/messages/count_tokens"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MessageCountTokensParams parameters = new()
        {
            Messages = [new() { Content = "string", Role = Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageCountTokensParams
        {
            Messages = [new() { Content = "string", Role = Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
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
            McpServers =
            [
                new()
                {
                    Name = "name",
                    Url = "url",
                    AuthorizationToken = "authorization_token",
                    ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
                },
            ],
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
                            { "location", JsonSerializer.SerializeToElement("bar") },
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        MessageCountTokensParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MessageCountTokensParamsSystemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MessageCountTokensParamsSystem value = "string";
        value.Validate();
    }

    [Fact]
    public void BetaTextBlockParamsValidationWorks()
    {
        MessageCountTokensParamsSystem value = new(
            [
                new BetaTextBlockParam()
                {
                    Text = "x",
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
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MessageCountTokensParamsSystem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensParamsSystem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextBlockParamsSerializationRoundtripWorks()
    {
        MessageCountTokensParamsSystem value = new(
            [
                new BetaTextBlockParam()
                {
                    Text = "x",
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
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensParamsSystem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ToolTest : TestBase
{
    [Fact]
    public void BetaValidationWorks()
    {
        Tool value = new BetaTool()
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
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
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolBash20241022ValidationWorks()
    {
        Tool value = new BetaToolBash20241022()
        {
            AllowedCallers = [BetaToolBash20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolBash20250124ValidationWorks()
    {
        Tool value = new BetaToolBash20250124()
        {
            AllowedCallers = [BetaToolBash20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaCodeExecutionTool20250522ValidationWorks()
    {
        Tool value = new BetaCodeExecutionTool20250522()
        {
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaCodeExecutionTool20250825ValidationWorks()
    {
        Tool value = new BetaCodeExecutionTool20250825()
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolComputerUse20241022ValidationWorks()
    {
        Tool value = new BetaToolComputerUse20241022()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaMemoryTool20250818ValidationWorks()
    {
        Tool value = new BetaMemoryTool20250818()
        {
            AllowedCallers = [BetaMemoryTool20250818AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolComputerUse20250124ValidationWorks()
    {
        Tool value = new BetaToolComputerUse20250124()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolTextEditor20241022ValidationWorks()
    {
        Tool value = new BetaToolTextEditor20241022()
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolComputerUse20251124ValidationWorks()
    {
        Tool value = new BetaToolComputerUse20251124()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20251124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            EnableZoom = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolTextEditor20250124ValidationWorks()
    {
        Tool value = new BetaToolTextEditor20250124()
        {
            AllowedCallers = [BetaToolTextEditor20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolTextEditor20250429ValidationWorks()
    {
        Tool value = new BetaToolTextEditor20250429()
        {
            AllowedCallers = [BetaToolTextEditor20250429AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolTextEditor20250728ValidationWorks()
    {
        Tool value = new BetaToolTextEditor20250728()
        {
            AllowedCallers = [BetaToolTextEditor20250728AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            MaxCharacters = 1,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaWebSearchTool20250305ValidationWorks()
    {
        Tool value = new BetaWebSearchTool20250305()
        {
            AllowedCallers = [BetaWebSearchTool20250305AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchTool20250910ValidationWorks()
    {
        Tool value = new BetaWebFetchTool20250910()
        {
            AllowedCallers = [BetaWebFetchTool20250910AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolSearchToolBm25_20251119ValidationWorks()
    {
        Tool value = new BetaToolSearchToolBm25_20251119()
        {
            Type = BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
            AllowedCallers = [BetaToolSearchToolBm25_20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolSearchToolRegex20251119ValidationWorks()
    {
        Tool value = new BetaToolSearchToolRegex20251119()
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void BetaMcpToolsetValidationWorks()
    {
        Tool value = new BetaMcpToolset()
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };
        value.Validate();
    }

    [Fact]
    public void BetaSerializationRoundtripWorks()
    {
        Tool value = new BetaTool()
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolBash20241022SerializationRoundtripWorks()
    {
        Tool value = new BetaToolBash20241022()
        {
            AllowedCallers = [BetaToolBash20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolBash20250124SerializationRoundtripWorks()
    {
        Tool value = new BetaToolBash20250124()
        {
            AllowedCallers = [BetaToolBash20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCodeExecutionTool20250522SerializationRoundtripWorks()
    {
        Tool value = new BetaCodeExecutionTool20250522()
        {
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCodeExecutionTool20250825SerializationRoundtripWorks()
    {
        Tool value = new BetaCodeExecutionTool20250825()
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolComputerUse20241022SerializationRoundtripWorks()
    {
        Tool value = new BetaToolComputerUse20241022()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaMemoryTool20250818SerializationRoundtripWorks()
    {
        Tool value = new BetaMemoryTool20250818()
        {
            AllowedCallers = [BetaMemoryTool20250818AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolComputerUse20250124SerializationRoundtripWorks()
    {
        Tool value = new BetaToolComputerUse20250124()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolTextEditor20241022SerializationRoundtripWorks()
    {
        Tool value = new BetaToolTextEditor20241022()
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolComputerUse20251124SerializationRoundtripWorks()
    {
        Tool value = new BetaToolComputerUse20251124()
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20251124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            EnableZoom = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolTextEditor20250124SerializationRoundtripWorks()
    {
        Tool value = new BetaToolTextEditor20250124()
        {
            AllowedCallers = [BetaToolTextEditor20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolTextEditor20250429SerializationRoundtripWorks()
    {
        Tool value = new BetaToolTextEditor20250429()
        {
            AllowedCallers = [BetaToolTextEditor20250429AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolTextEditor20250728SerializationRoundtripWorks()
    {
        Tool value = new BetaToolTextEditor20250728()
        {
            AllowedCallers = [BetaToolTextEditor20250728AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            MaxCharacters = 1,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebSearchTool20250305SerializationRoundtripWorks()
    {
        Tool value = new BetaWebSearchTool20250305()
        {
            AllowedCallers = [BetaWebSearchTool20250305AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchTool20250910SerializationRoundtripWorks()
    {
        Tool value = new BetaWebFetchTool20250910()
        {
            AllowedCallers = [BetaWebFetchTool20250910AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolSearchToolBm25_20251119SerializationRoundtripWorks()
    {
        Tool value = new BetaToolSearchToolBm25_20251119()
        {
            Type = BetaToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
            AllowedCallers = [BetaToolSearchToolBm25_20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolSearchToolRegex20251119SerializationRoundtripWorks()
    {
        Tool value = new BetaToolSearchToolRegex20251119()
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaMcpToolsetSerializationRoundtripWorks()
    {
        Tool value = new BetaMcpToolset()
        {
            McpServerName = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Configs = new Dictionary<string, BetaMcpToolConfig>()
            {
                {
                    "foo",
                    new() { DeferLoading = true, Enabled = true }
                },
            },
            DefaultConfig = new() { DeferLoading = true, Enabled = true },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
