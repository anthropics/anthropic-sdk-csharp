using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages.Batches;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BatchCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BatchCreateParams
        {
            Requests =
            [
                new()
                {
                    CustomID = "my-custom-id-1",
                    Params = new()
                    {
                        MaxTokens = 1024,
                        Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                        Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
                        OutputConfig = new() { Effort = Messages::Effort.Low },
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
                                new Messages::BetaTextBlockParam()
                                {
                                    Text = "Today's date is 2024-06-01.",
                                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                    Properties = new Dictionary<string, JsonElement>()
                                    {
                                        { "location", JsonSerializer.SerializeToElement("bar") },
                                        { "unit", JsonSerializer.SerializeToElement("bar") },
                                    },
                                    Required = ["location"],
                                },
                                Name = "name",
                                AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                Type = Messages::BetaToolType.Custom,
                            },
                        ],
                        TopK = 5,
                        TopP = 0.7,
                    },
                },
            ],
            Betas = ["string"],
        };

        List<Request> expectedRequests =
        [
            new()
            {
                CustomID = "my-custom-id-1",
                Params = new()
                {
                    MaxTokens = 1024,
                    Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                    Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
                    OutputConfig = new() { Effort = Messages::Effort.Low },
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
                            new Messages::BetaTextBlockParam()
                            {
                                Text = "Today's date is 2024-06-01.",
                                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                Properties = new Dictionary<string, JsonElement>()
                                {
                                    { "location", JsonSerializer.SerializeToElement("bar") },
                                    { "unit", JsonSerializer.SerializeToElement("bar") },
                                },
                                Required = ["location"],
                            },
                            Name = "name",
                            AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                            Type = Messages::BetaToolType.Custom,
                        },
                    ],
                    TopK = 5,
                    TopP = 0.7,
                },
            },
        ];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = ["string"];

        Assert.Equal(expectedRequests.Count, parameters.Requests.Count);
        for (int i = 0; i < expectedRequests.Count; i++)
        {
            Assert.Equal(expectedRequests[i], parameters.Requests[i]);
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
        var parameters = new BatchCreateParams
        {
            Requests =
            [
                new()
                {
                    CustomID = "my-custom-id-1",
                    Params = new()
                    {
                        MaxTokens = 1024,
                        Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                        Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
                        OutputConfig = new() { Effort = Messages::Effort.Low },
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
                                new Messages::BetaTextBlockParam()
                                {
                                    Text = "Today's date is 2024-06-01.",
                                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                    Properties = new Dictionary<string, JsonElement>()
                                    {
                                        { "location", JsonSerializer.SerializeToElement("bar") },
                                        { "unit", JsonSerializer.SerializeToElement("bar") },
                                    },
                                    Required = ["location"],
                                },
                                Name = "name",
                                AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                Type = Messages::BetaToolType.Custom,
                            },
                        ],
                        TopK = 5,
                        TopP = 0.7,
                    },
                },
            ],
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BatchCreateParams
        {
            Requests =
            [
                new()
                {
                    CustomID = "my-custom-id-1",
                    Params = new()
                    {
                        MaxTokens = 1024,
                        Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                        Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
                        OutputConfig = new() { Effort = Messages::Effort.Low },
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
                                new Messages::BetaTextBlockParam()
                                {
                                    Text = "Today's date is 2024-06-01.",
                                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                    Properties = new Dictionary<string, JsonElement>()
                                    {
                                        { "location", JsonSerializer.SerializeToElement("bar") },
                                        { "unit", JsonSerializer.SerializeToElement("bar") },
                                    },
                                    Required = ["location"],
                                },
                                Name = "name",
                                AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                Type = Messages::BetaToolType.Custom,
                            },
                        ],
                        TopK = 5,
                        TopP = 0.7,
                    },
                },
            ],

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        BatchCreateParams parameters = new()
        {
            Requests =
            [
                new()
                {
                    CustomID = "my-custom-id-1",
                    Params = new()
                    {
                        MaxTokens = 1024,
                        Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                        Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
                        OutputConfig = new() { Effort = Messages::Effort.Low },
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
                                new Messages::BetaTextBlockParam()
                                {
                                    Text = "Today's date is 2024-06-01.",
                                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                    Properties = new Dictionary<string, JsonElement>()
                                    {
                                        { "location", JsonSerializer.SerializeToElement("bar") },
                                        { "unit", JsonSerializer.SerializeToElement("bar") },
                                    },
                                    Required = ["location"],
                                },
                                Name = "name",
                                AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                Type = Messages::BetaToolType.Custom,
                            },
                        ],
                        TopK = 5,
                        TopP = 0.7,
                    },
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(new Uri("https://api.anthropic.com/v1/messages/batches"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        BatchCreateParams parameters = new()
        {
            Requests =
            [
                new()
                {
                    CustomID = "my-custom-id-1",
                    Params = new()
                    {
                        MaxTokens = 1024,
                        Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                        Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
                        OutputConfig = new() { Effort = Messages::Effort.Low },
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
                                new Messages::BetaTextBlockParam()
                                {
                                    Text = "Today's date is 2024-06-01.",
                                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                    Properties = new Dictionary<string, JsonElement>()
                                    {
                                        { "location", JsonSerializer.SerializeToElement("bar") },
                                        { "unit", JsonSerializer.SerializeToElement("bar") },
                                    },
                                    Required = ["location"],
                                },
                                Name = "name",
                                AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                                Type = Messages::BetaToolType.Custom,
                            },
                        ],
                        TopK = 5,
                        TopP = 0.7,
                    },
                },
            ],
            Betas = ["string"],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24", "string"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }
}

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
                Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
                OutputConfig = new() { Effort = Messages::Effort.Low },
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
                        new Messages::BetaTextBlockParam()
                        {
                            Text = "Today's date is 2024-06-01.",
                            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::BetaTool()
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
                        AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                        Type = Messages::BetaToolType.Custom,
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
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputConfig = new() { Effort = Messages::Effort.Low },
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
                    new Messages::BetaTextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
            ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::BetaTool()
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
                    AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    Type = Messages::BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        Assert.Equal(expectedCustomID, model.CustomID);
        Assert.Equal(expectedParams, model.Params);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Request
        {
            CustomID = "my-custom-id-1",
            Params = new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
                OutputConfig = new() { Effort = Messages::Effort.Low },
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
                        new Messages::BetaTextBlockParam()
                        {
                            Text = "Today's date is 2024-06-01.",
                            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::BetaTool()
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
                        AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                        Type = Messages::BetaToolType.Custom,
                    },
                ],
                TopK = 5,
                TopP = 0.7,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Request>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Request
        {
            CustomID = "my-custom-id-1",
            Params = new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
                OutputConfig = new() { Effort = Messages::Effort.Low },
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
                        new Messages::BetaTextBlockParam()
                        {
                            Text = "Today's date is 2024-06-01.",
                            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::BetaTool()
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
                        AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                        Type = Messages::BetaToolType.Custom,
                    },
                ],
                TopK = 5,
                TopP = 0.7,
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Request>(element);
        Assert.NotNull(deserialized);

        string expectedCustomID = "my-custom-id-1";
        Params expectedParams = new()
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputConfig = new() { Effort = Messages::Effort.Low },
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
                    new Messages::BetaTextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
            ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::BetaTool()
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
                    AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    Type = Messages::BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        Assert.Equal(expectedCustomID, deserialized.CustomID);
        Assert.Equal(expectedParams, deserialized.Params);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Request
        {
            CustomID = "my-custom-id-1",
            Params = new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
                OutputConfig = new() { Effort = Messages::Effort.Low },
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
                        new Messages::BetaTextBlockParam()
                        {
                            Text = "Today's date is 2024-06-01.",
                            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::BetaTool()
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
                        AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                        Type = Messages::BetaToolType.Custom,
                    },
                ],
                TopK = 5,
                TopP = 0.7,
            },
        };

        model.Validate();
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
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputConfig = new() { Effort = Messages::Effort.Low },
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
                    new Messages::BetaTextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
            ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::BetaTool()
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
                    AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    Type = Messages::BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        long expectedMaxTokens = 1024;
        List<Messages::BetaMessageParam> expectedMessages =
        [
            new() { Content = "Hello, world", Role = Messages::Role.User },
        ];
        ApiEnum<string, global::Anthropic.Models.Messages.Model> expectedModel = global::Anthropic
            .Models
            .Messages
            .Model
            .ClaudeSonnet4_5_20250929;
        Container expectedContainer = new Messages::BetaContainerParams()
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
        };
        Messages::BetaContextManagementConfig expectedContextManagement = new()
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
        };
        List<Messages::BetaRequestMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "name",
                Url = "url",
                AuthorizationToken = "authorization_token",
                ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
            },
        ];
        Messages::BetaMetadata expectedMetadata = new()
        {
            UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b",
        };
        Messages::BetaOutputConfig expectedOutputConfig = new() { Effort = Messages::Effort.Low };
        Messages::BetaJsonOutputFormat expectedOutputFormat = new()
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
                new Messages::BetaTextBlockParam()
                {
                    Text = "Today's date is 2024-06-01.",
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
        );
        double expectedTemperature = 1;
        Messages::BetaThinkingConfigParam expectedThinking =
            new Messages::BetaThinkingConfigEnabled(1024);
        Messages::BetaToolChoice expectedToolChoice = new Messages::BetaToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        List<Messages::BetaToolUnion> expectedTools =
        [
            new Messages::BetaTool()
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
                AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                Type = Messages::BetaToolType.Custom,
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
        Assert.NotNull(model.McpServers);
        Assert.Equal(expectedMcpServers.Count, model.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], model.McpServers[i]);
        }
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedOutputConfig, model.OutputConfig);
        Assert.Equal(expectedOutputFormat, model.OutputFormat);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.NotNull(model.StopSequences);
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
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.Equal(expectedTopK, model.TopK);
        Assert.Equal(expectedTopP, model.TopP);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputConfig = new() { Effort = Messages::Effort.Low },
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
                    new Messages::BetaTextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
            ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::BetaTool()
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
                    AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    Type = Messages::BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Params>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputConfig = new() { Effort = Messages::Effort.Low },
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
                    new Messages::BetaTextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
            ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::BetaTool()
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
                    AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    Type = Messages::BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Params>(element);
        Assert.NotNull(deserialized);

        long expectedMaxTokens = 1024;
        List<Messages::BetaMessageParam> expectedMessages =
        [
            new() { Content = "Hello, world", Role = Messages::Role.User },
        ];
        ApiEnum<string, global::Anthropic.Models.Messages.Model> expectedModel = global::Anthropic
            .Models
            .Messages
            .Model
            .ClaudeSonnet4_5_20250929;
        Container expectedContainer = new Messages::BetaContainerParams()
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
        };
        Messages::BetaContextManagementConfig expectedContextManagement = new()
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
        };
        List<Messages::BetaRequestMcpServerUrlDefinition> expectedMcpServers =
        [
            new()
            {
                Name = "name",
                Url = "url",
                AuthorizationToken = "authorization_token",
                ToolConfiguration = new() { AllowedTools = ["string"], Enabled = true },
            },
        ];
        Messages::BetaMetadata expectedMetadata = new()
        {
            UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b",
        };
        Messages::BetaOutputConfig expectedOutputConfig = new() { Effort = Messages::Effort.Low };
        Messages::BetaJsonOutputFormat expectedOutputFormat = new()
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
                new Messages::BetaTextBlockParam()
                {
                    Text = "Today's date is 2024-06-01.",
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
        );
        double expectedTemperature = 1;
        Messages::BetaThinkingConfigParam expectedThinking =
            new Messages::BetaThinkingConfigEnabled(1024);
        Messages::BetaToolChoice expectedToolChoice = new Messages::BetaToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        List<Messages::BetaToolUnion> expectedTools =
        [
            new Messages::BetaTool()
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
                AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                Type = Messages::BetaToolType.Custom,
            },
        ];
        long expectedTopK = 5;
        double expectedTopP = 0.7;

        Assert.Equal(expectedMaxTokens, deserialized.MaxTokens);
        Assert.Equal(expectedMessages.Count, deserialized.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], deserialized.Messages[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedContainer, deserialized.Container);
        Assert.Equal(expectedContextManagement, deserialized.ContextManagement);
        Assert.NotNull(deserialized.McpServers);
        Assert.Equal(expectedMcpServers.Count, deserialized.McpServers.Count);
        for (int i = 0; i < expectedMcpServers.Count; i++)
        {
            Assert.Equal(expectedMcpServers[i], deserialized.McpServers[i]);
        }
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedOutputConfig, deserialized.OutputConfig);
        Assert.Equal(expectedOutputFormat, deserialized.OutputFormat);
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.NotNull(deserialized.StopSequences);
        Assert.Equal(expectedStopSequences.Count, deserialized.StopSequences.Count);
        for (int i = 0; i < expectedStopSequences.Count; i++)
        {
            Assert.Equal(expectedStopSequences[i], deserialized.StopSequences[i]);
        }
        Assert.Equal(expectedStream, deserialized.Stream);
        Assert.Equal(expectedSystem, deserialized.System);
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.Equal(expectedThinking, deserialized.Thinking);
        Assert.Equal(expectedToolChoice, deserialized.ToolChoice);
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.Equal(expectedTopK, deserialized.TopK);
        Assert.Equal(expectedTopP, deserialized.TopP);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputConfig = new() { Effort = Messages::Effort.Low },
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
                    new Messages::BetaTextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
            ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::BetaTool()
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
                    AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    Type = Messages::BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputFormat = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        Assert.Null(model.McpServers);
        Assert.False(model.RawData.ContainsKey("mcp_servers"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.OutputConfig);
        Assert.False(model.RawData.ContainsKey("output_config"));
        Assert.Null(model.ServiceTier);
        Assert.False(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.StopSequences);
        Assert.False(model.RawData.ContainsKey("stop_sequences"));
        Assert.Null(model.Stream);
        Assert.False(model.RawData.ContainsKey("stream"));
        Assert.Null(model.System);
        Assert.False(model.RawData.ContainsKey("system"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Thinking);
        Assert.False(model.RawData.ContainsKey("thinking"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("top_k"));
        Assert.Null(model.TopP);
        Assert.False(model.RawData.ContainsKey("top_p"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputFormat = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            Stream = null,
            System = null,
            Temperature = null,
            Thinking = null,
            ToolChoice = null,
            Tools = null,
            TopK = null,
            TopP = null,
        };

        Assert.Null(model.McpServers);
        Assert.False(model.RawData.ContainsKey("mcp_servers"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.OutputConfig);
        Assert.False(model.RawData.ContainsKey("output_config"));
        Assert.Null(model.ServiceTier);
        Assert.False(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.StopSequences);
        Assert.False(model.RawData.ContainsKey("stop_sequences"));
        Assert.Null(model.Stream);
        Assert.False(model.RawData.ContainsKey("stream"));
        Assert.Null(model.System);
        Assert.False(model.RawData.ContainsKey("system"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Thinking);
        Assert.False(model.RawData.ContainsKey("thinking"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("top_k"));
        Assert.Null(model.TopP);
        Assert.False(model.RawData.ContainsKey("top_p"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            Stream = null,
            System = null,
            Temperature = null,
            Thinking = null,
            ToolChoice = null,
            Tools = null,
            TopK = null,
            TopP = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputConfig = new() { Effort = Messages::Effort.Low },
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
            Stream = true,
            System = new(
                [
                    new Messages::BetaTextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
            ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::BetaTool()
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
                    AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    Type = Messages::BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        Assert.Null(model.Container);
        Assert.False(model.RawData.ContainsKey("container"));
        Assert.Null(model.ContextManagement);
        Assert.False(model.RawData.ContainsKey("context_management"));
        Assert.Null(model.OutputFormat);
        Assert.False(model.RawData.ContainsKey("output_format"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputConfig = new() { Effort = Messages::Effort.Low },
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
            Stream = true,
            System = new(
                [
                    new Messages::BetaTextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
            ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::BetaTool()
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
                    AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    Type = Messages::BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputConfig = new() { Effort = Messages::Effort.Low },
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
            Stream = true,
            System = new(
                [
                    new Messages::BetaTextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
            ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::BetaTool()
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
                    AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    Type = Messages::BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,

            Container = null,
            ContextManagement = null,
            OutputFormat = null,
        };

        Assert.Null(model.Container);
        Assert.True(model.RawData.ContainsKey("container"));
        Assert.Null(model.ContextManagement);
        Assert.True(model.RawData.ContainsKey("context_management"));
        Assert.Null(model.OutputFormat);
        Assert.True(model.RawData.ContainsKey("output_format"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = global::Anthropic.Models.Messages.Model.ClaudeSonnet4_5_20250929,
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
            OutputConfig = new() { Effort = Messages::Effort.Low },
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
            Stream = true,
            System = new(
                [
                    new Messages::BetaTextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
            ToolChoice = new Messages::BetaToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::BetaTool()
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
                    AllowedCallers = [Messages::BetaToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    Type = Messages::BetaToolType.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,

            Container = null,
            ContextManagement = null,
            OutputFormat = null,
        };

        model.Validate();
    }
}

public class ContainerTest : TestBase
{
    [Fact]
    public void BetaContainerParamsValidationWorks()
    {
        Container value = new(
            new Messages::BetaContainerParams()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Container value = new("string");
        value.Validate();
    }

    [Fact]
    public void BetaContainerParamsSerializationRoundtripWorks()
    {
        Container value = new(
            new Messages::BetaContainerParams()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Container>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Container value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Container>(element);

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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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

public class ParamsSystemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ParamsSystem value = new("string");
        value.Validate();
    }

    [Fact]
    public void BetaTextBlockParamsValidationWorks()
    {
        ParamsSystem value = new(
            [
                new Messages::BetaTextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ParamsSystem value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ParamsSystem>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextBlockParamsSerializationRoundtripWorks()
    {
        ParamsSystem value = new(
            [
                new Messages::BetaTextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ParamsSystem>(element);

        Assert.Equal(value, deserialized);
    }
}
