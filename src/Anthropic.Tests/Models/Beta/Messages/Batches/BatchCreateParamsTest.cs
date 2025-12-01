using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages.Batches;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class RequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Request
        {
            CustomID = "my-custom-id-1",
            Params = new()
            {
                MaxTokens = 1024,
                Messages =
                [
                    new()
                    {
                        Content = "Hello, world",
                        Role = global::Anthropic.Models.Beta.Messages.Role.User,
                    },
                ],
                Model = Messages::Model.ClaudeOpus4_5_20251101,
                Container = new global::Anthropic.Models.Beta.Messages.BetaContainerParams()
                {
                    ID = "id",
                    Skills =
                    [
                        new()
                        {
                            SkillID = "x",
                            Type = global::Anthropic
                                .Models
                                .Beta
                                .Messages
                                .BetaSkillParamsType
                                .Anthropic,
                            Version = "x",
                        },
                    ],
                },
                ContextManagement = new()
                {
                    Edits =
                    [
                        new global::Anthropic.Models.Beta.Messages.BetaClearToolUses20250919Edit()
                        {
                            ClearAtLeast = new(0),
                            ClearToolInputs = true,
                            ExcludeTools = ["string"],
                            Keep = new(0),
                            Trigger =
                                new global::Anthropic.Models.Beta.Messages.BetaInputTokensTrigger(
                                    1
                                ),
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
                        ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
                    },
                ],
                Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
                OutputConfig = new() { Effort = global::Anthropic.Models.Beta.Messages.Effort.Low },
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
                        new()
                        {
                            Text = "Today's date is 2024-06-01.",
                            CacheControl = new()
                            {
                                TTL = global::Anthropic.Models.Beta.Messages.TTL.TTL5m,
                            },
                            Citations =
                            [
                                new global::Anthropic.Models.Beta.Messages.BetaCitationCharLocationParam()
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
                Thinking = new global::Anthropic.Models.Beta.Messages.BetaThinkingConfigEnabled(
                    1024
                ),
                ToolChoice = new global::Anthropic.Models.Beta.Messages.BetaToolChoiceAuto()
                {
                    DisableParallelToolUse = true,
                },
                Tools =
                [
                    new global::Anthropic.Models.Beta.Messages.BetaTool()
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
                        AllowedCallers =
                        [
                            global::Anthropic.Models.Beta.Messages.AllowedCaller2.Direct,
                        ],
                        CacheControl = new()
                        {
                            TTL = global::Anthropic.Models.Beta.Messages.TTL.TTL5m,
                        },
                        DeferLoading = true,
                        Description = "Get the current weather in a given location",
                        InputExamples =
                        [
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                        ],
                        Strict = true,
                        Type = global::Anthropic.Models.Beta.Messages.BetaToolType.Custom,
                    },
                ],
                TopK = 5,
                TopP = 0.7,
            },
        };

        string expectedCustomID = "my-custom-id-1";
        Params expectedParams = new()
        {
            MaxTokens = 1024,
            Messages =
            [
                new()
                {
                    Content = "Hello, world",
                    Role = global::Anthropic.Models.Beta.Messages.Role.User,
                },
            ],
            Model = Messages::Model.ClaudeOpus4_5_20251101,
            Container = new global::Anthropic.Models.Beta.Messages.BetaContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "x",
                        Type = global::Anthropic.Models.Beta.Messages.BetaSkillParamsType.Anthropic,
                        Version = "x",
                    },
                ],
            },
            ContextManagement = new()
            {
                Edits =
                [
                    new global::Anthropic.Models.Beta.Messages.BetaClearToolUses20250919Edit()
                    {
                        ClearAtLeast = new(0),
                        ClearToolInputs = true,
                        ExcludeTools = ["string"],
                        Keep = new(0),
                        Trigger = new global::Anthropic.Models.Beta.Messages.BetaInputTokensTrigger(
                            1
                        ),
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
                    ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
                },
            ],
            Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
            OutputConfig = new() { Effort = global::Anthropic.Models.Beta.Messages.Effort.Low },
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
                    new()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new()
                        {
                            TTL = global::Anthropic.Models.Beta.Messages.TTL.TTL5m,
                        },
                        Citations =
                        [
                            new global::Anthropic.Models.Beta.Messages.BetaCitationCharLocationParam()
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
            Thinking = new global::Anthropic.Models.Beta.Messages.BetaThinkingConfigEnabled(1024),
            ToolChoice = new global::Anthropic.Models.Beta.Messages.BetaToolChoiceAuto()
            {
                DisableParallelToolUse = true,
            },
            Tools =
            [
                new global::Anthropic.Models.Beta.Messages.BetaTool()
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
                    AllowedCallers = [global::Anthropic.Models.Beta.Messages.AllowedCaller2.Direct],
                    CacheControl = new() { TTL = global::Anthropic.Models.Beta.Messages.TTL.TTL5m },
                    DeferLoading = true,
                    Description = "Get the current weather in a given location",
                    InputExamples =
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ],
                    Strict = true,
                    Type = global::Anthropic.Models.Beta.Messages.BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        Assert.Equal(expectedCustomID, model.CustomID);
        Assert.Equal(expectedParams, model.Params);
    }
}

public class ParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages =
            [
                new()
                {
                    Content = "Hello, world",
                    Role = global::Anthropic.Models.Beta.Messages.Role.User,
                },
            ],
            Model = Messages::Model.ClaudeOpus4_5_20251101,
            Container = new global::Anthropic.Models.Beta.Messages.BetaContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "x",
                        Type = global::Anthropic.Models.Beta.Messages.BetaSkillParamsType.Anthropic,
                        Version = "x",
                    },
                ],
            },
            ContextManagement = new()
            {
                Edits =
                [
                    new global::Anthropic.Models.Beta.Messages.BetaClearToolUses20250919Edit()
                    {
                        ClearAtLeast = new(0),
                        ClearToolInputs = true,
                        ExcludeTools = ["string"],
                        Keep = new(0),
                        Trigger = new global::Anthropic.Models.Beta.Messages.BetaInputTokensTrigger(
                            1
                        ),
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
                    ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
                },
            ],
            Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
            OutputConfig = new() { Effort = global::Anthropic.Models.Beta.Messages.Effort.Low },
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
                    new()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new()
                        {
                            TTL = global::Anthropic.Models.Beta.Messages.TTL.TTL5m,
                        },
                        Citations =
                        [
                            new global::Anthropic.Models.Beta.Messages.BetaCitationCharLocationParam()
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
            Thinking = new global::Anthropic.Models.Beta.Messages.BetaThinkingConfigEnabled(1024),
            ToolChoice = new global::Anthropic.Models.Beta.Messages.BetaToolChoiceAuto()
            {
                DisableParallelToolUse = true,
            },
            Tools =
            [
                new global::Anthropic.Models.Beta.Messages.BetaTool()
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
                    AllowedCallers = [global::Anthropic.Models.Beta.Messages.AllowedCaller2.Direct],
                    CacheControl = new() { TTL = global::Anthropic.Models.Beta.Messages.TTL.TTL5m },
                    DeferLoading = true,
                    Description = "Get the current weather in a given location",
                    InputExamples =
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ],
                    Strict = true,
                    Type = global::Anthropic.Models.Beta.Messages.BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        long expectedMaxTokens = 1024;
        List<global::Anthropic.Models.Beta.Messages.BetaMessageParam> expectedMessages =
        [
            new()
            {
                Content = "Hello, world",
                Role = global::Anthropic.Models.Beta.Messages.Role.User,
            },
        ];
        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus4_5_20251101;
        Container expectedContainer =
            new global::Anthropic.Models.Beta.Messages.BetaContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "x",
                        Type = global::Anthropic.Models.Beta.Messages.BetaSkillParamsType.Anthropic,
                        Version = "x",
                    },
                ],
            };
        global::Anthropic.Models.Beta.Messages.BetaContextManagementConfig expectedContextManagement =
            new()
            {
                Edits =
                [
                    new global::Anthropic.Models.Beta.Messages.BetaClearToolUses20250919Edit()
                    {
                        ClearAtLeast = new(0),
                        ClearToolInputs = true,
                        ExcludeTools = ["string"],
                        Keep = new(0),
                        Trigger = new global::Anthropic.Models.Beta.Messages.BetaInputTokensTrigger(
                            1
                        ),
                    },
                ],
            };
        List<global::Anthropic.Models.Beta.Messages.BetaRequestMCPServerURLDefinition> expectedMCPServers =
        [
            new()
            {
                Name = "name",
                URL = "url",
                AuthorizationToken = "authorization_token",
                ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
            },
        ];
        global::Anthropic.Models.Beta.Messages.BetaMetadata expectedMetadata = new()
        {
            UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b",
        };
        global::Anthropic.Models.Beta.Messages.BetaOutputConfig expectedOutputConfig = new()
        {
            Effort = global::Anthropic.Models.Beta.Messages.Effort.Low,
        };
        global::Anthropic.Models.Beta.Messages.BetaJSONOutputFormat expectedOutputFormat = new()
        {
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        ApiEnum<string, ServiceTier> expectedServiceTier = ServiceTier.Auto;
        List<string> expectedStopSequences = ["string"];
        bool expectedStream = true;
        ParamsSystem expectedSystem = new(
            [
                new()
                {
                    Text = "Today's date is 2024-06-01.",
                    CacheControl = new() { TTL = global::Anthropic.Models.Beta.Messages.TTL.TTL5m },
                    Citations =
                    [
                        new global::Anthropic.Models.Beta.Messages.BetaCitationCharLocationParam()
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
        global::Anthropic.Models.Beta.Messages.BetaThinkingConfigParam expectedThinking =
            new global::Anthropic.Models.Beta.Messages.BetaThinkingConfigEnabled(1024);
        global::Anthropic.Models.Beta.Messages.BetaToolChoice expectedToolChoice =
            new global::Anthropic.Models.Beta.Messages.BetaToolChoiceAuto()
            {
                DisableParallelToolUse = true,
            };
        List<global::Anthropic.Models.Beta.Messages.BetaToolUnion> expectedTools =
        [
            new global::Anthropic.Models.Beta.Messages.BetaTool()
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
                AllowedCallers = [global::Anthropic.Models.Beta.Messages.AllowedCaller2.Direct],
                CacheControl = new() { TTL = global::Anthropic.Models.Beta.Messages.TTL.TTL5m },
                DeferLoading = true,
                Description = "Get the current weather in a given location",
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
                Type = global::Anthropic.Models.Beta.Messages.BetaToolType.Custom,
            },
        ];
        long expectedTopK = 5;
        double expectedTopP = 0.7;

        Assert.Equal(expectedMaxTokens, model.MaxTokens);
        Assert.Equal(expectedMessages.Count, model.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], model.Messages[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedContainer, model.Container);
        Assert.Equal(expectedContextManagement, model.ContextManagement);
        Assert.Equal(expectedMCPServers.Count, model.MCPServers.Count);
        for (int i = 0; i < expectedMCPServers.Count; i++)
        {
            Assert.Equal(expectedMCPServers[i], model.MCPServers[i]);
        }
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedOutputConfig, model.OutputConfig);
        Assert.Equal(expectedOutputFormat, model.OutputFormat);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedStopSequences.Count, model.StopSequences.Count);
        for (int i = 0; i < expectedStopSequences.Count; i++)
        {
            Assert.Equal(expectedStopSequences[i], model.StopSequences[i]);
        }
        Assert.Equal(expectedStream, model.Stream);
        Assert.Equal(expectedSystem, model.System);
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.Equal(expectedThinking, model.Thinking);
        Assert.Equal(expectedToolChoice, model.ToolChoice);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.Equal(expectedTopK, model.TopK);
        Assert.Equal(expectedTopP, model.TopP);
    }
}
