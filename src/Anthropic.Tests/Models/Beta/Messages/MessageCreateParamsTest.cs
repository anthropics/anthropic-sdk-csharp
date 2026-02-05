using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class MessageCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageCreateParams
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
                    ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
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
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
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
            TopK = 5,
            TopP = 0.7,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        long expectedMaxTokens = 1024;
        List<BetaMessageParam> expectedMessages =
        [
            new() { Content = "Hello, world", Role = Role.User },
        ];
        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus4_6;
        Container expectedContainer = new BetaContainerParams()
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
        };
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
        string expectedInferenceGeo = "inference_geo";
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
        BetaMetadata expectedMetadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" };
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
        ApiEnum<string, ServiceTier> expectedServiceTier = ServiceTier.Auto;
        List<string> expectedStopSequences = ["string"];
        MessageCreateParamsSystem expectedSystem = new(
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
        double expectedTemperature = 1;
        BetaThinkingConfigParam expectedThinking = new BetaThinkingConfigEnabled(1024);
        BetaToolChoice expectedToolChoice = new BetaToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        List<BetaToolUnion> expectedTools =
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
        long expectedTopK = 5;
        double expectedTopP = 0.7;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedMaxTokens, parameters.MaxTokens);
        Assert.Equal(expectedMessages.Count, parameters.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], parameters.Messages[i]);
        }
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedContainer, parameters.Container);
        Assert.Equal(expectedContextManagement, parameters.ContextManagement);
        Assert.Equal(expectedInferenceGeo, parameters.InferenceGeo);
        Assert.NotNull(parameters.McpServers);
        Assert.Equal(expectedMcpServers.Count, parameters.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], parameters.McpServers[i]);
        }
        Assert.Equal(expectedMetadata, parameters.Metadata);
        Assert.Equal(expectedOutputConfig, parameters.OutputConfig);
        Assert.Equal(expectedOutputFormat, parameters.OutputFormat);
        Assert.Equal(expectedServiceTier, parameters.ServiceTier);
        Assert.NotNull(parameters.StopSequences);
        Assert.Equal(expectedStopSequences.Count, parameters.StopSequences.Count);
        for (int i = 0; i < expectedStopSequences.Count; i++)
        {
            Assert.Equal(expectedStopSequences[i], parameters.StopSequences[i]);
        }
        Assert.Equal(expectedSystem, parameters.System);
        Assert.Equal(expectedTemperature, parameters.Temperature);
        Assert.Equal(expectedThinking, parameters.Thinking);
        Assert.Equal(expectedToolChoice, parameters.ToolChoice);
        Assert.NotNull(parameters.Tools);
        Assert.Equal(expectedTools.Count, parameters.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], parameters.Tools[i]);
        }
        Assert.Equal(expectedTopK, parameters.TopK);
        Assert.Equal(expectedTopP, parameters.TopP);
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
        var parameters = new MessageCreateParams
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
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.OutputConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("output_config"));
        Assert.Null(parameters.ServiceTier);
        Assert.False(parameters.RawBodyData.ContainsKey("service_tier"));
        Assert.Null(parameters.StopSequences);
        Assert.False(parameters.RawBodyData.ContainsKey("stop_sequences"));
        Assert.Null(parameters.System);
        Assert.False(parameters.RawBodyData.ContainsKey("system"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.Thinking);
        Assert.False(parameters.RawBodyData.ContainsKey("thinking"));
        Assert.Null(parameters.ToolChoice);
        Assert.False(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.TopK);
        Assert.False(parameters.RawBodyData.ContainsKey("top_k"));
        Assert.Null(parameters.TopP);
        Assert.False(parameters.RawBodyData.ContainsKey("top_p"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MessageCreateParams
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
            OutputFormat = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },

            // Null should be interpreted as omitted for these properties
            McpServers = null,
            Metadata = null,
            OutputConfig = null,
            ServiceTier = null,
            StopSequences = null,
            System = null,
            Temperature = null,
            Thinking = null,
            ToolChoice = null,
            Tools = null,
            TopK = null,
            TopP = null,
            Betas = null,
        };

        Assert.Null(parameters.McpServers);
        Assert.False(parameters.RawBodyData.ContainsKey("mcp_servers"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.OutputConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("output_config"));
        Assert.Null(parameters.ServiceTier);
        Assert.False(parameters.RawBodyData.ContainsKey("service_tier"));
        Assert.Null(parameters.StopSequences);
        Assert.False(parameters.RawBodyData.ContainsKey("stop_sequences"));
        Assert.Null(parameters.System);
        Assert.False(parameters.RawBodyData.ContainsKey("system"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.Thinking);
        Assert.False(parameters.RawBodyData.ContainsKey("thinking"));
        Assert.Null(parameters.ToolChoice);
        Assert.False(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.TopK);
        Assert.False(parameters.RawBodyData.ContainsKey("top_k"));
        Assert.Null(parameters.TopP);
        Assert.False(parameters.RawBodyData.ContainsKey("top_p"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageCreateParams
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Role.User }],
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
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
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
            TopK = 5,
            TopP = 0.7,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Container);
        Assert.False(parameters.RawBodyData.ContainsKey("container"));
        Assert.Null(parameters.ContextManagement);
        Assert.False(parameters.RawBodyData.ContainsKey("context_management"));
        Assert.Null(parameters.InferenceGeo);
        Assert.False(parameters.RawBodyData.ContainsKey("inference_geo"));
        Assert.Null(parameters.OutputFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("output_format"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MessageCreateParams
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Role.User }],
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
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
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
            TopK = 5,
            TopP = 0.7,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Container = null,
            ContextManagement = null,
            InferenceGeo = null,
            OutputFormat = null,
        };

        Assert.Null(parameters.Container);
        Assert.True(parameters.RawBodyData.ContainsKey("container"));
        Assert.Null(parameters.ContextManagement);
        Assert.True(parameters.RawBodyData.ContainsKey("context_management"));
        Assert.Null(parameters.InferenceGeo);
        Assert.True(parameters.RawBodyData.ContainsKey("inference_geo"));
        Assert.Null(parameters.OutputFormat);
        Assert.True(parameters.RawBodyData.ContainsKey("output_format"));
    }

    [Fact]
    public void Url_Works()
    {
        MessageCreateParams parameters = new()
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(new Uri("https://api.anthropic.com/v1/messages"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MessageCreateParams parameters = new()
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Role.User }],
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
        var parameters = new MessageCreateParams
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
                    ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
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
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
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
            TopK = 5,
            TopP = 0.7,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        MessageCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ContainerTest : TestBase
{
    [Fact]
    public void BetaContainerParamsValidationWorks()
    {
        Container value = new BetaContainerParams()
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
        };
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Container value = "string";
        value.Validate();
    }

    [Fact]
    public void BetaContainerParamsSerializationRoundtripWorks()
    {
        Container value = new BetaContainerParams()
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Container>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Container value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Container>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ServiceTierTest : TestBase
{
    [Theory]
    [InlineData(ServiceTier.Auto)]
    [InlineData(ServiceTier.StandardOnly)]
    public void Validation_Works(ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ServiceTier.Auto)]
    [InlineData(ServiceTier.StandardOnly)]
    public void SerializationRoundtrip_Works(ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MessageCreateParamsSystemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MessageCreateParamsSystem value = "string";
        value.Validate();
    }

    [Fact]
    public void BetaTextBlockParamsValidationWorks()
    {
        MessageCreateParamsSystem value = new(
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
        MessageCreateParamsSystem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCreateParamsSystem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextBlockParamsSerializationRoundtripWorks()
    {
        MessageCreateParamsSystem value = new(
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
        var deserialized = JsonSerializer.Deserialize<MessageCreateParamsSystem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
