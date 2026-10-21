using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages.Batches;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages.Batches;

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
                        Messages = [new Messages::UserMessageParam("Hello, world")],
                        Model = Messages::Model.ClaudeOpus5_5,
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                        Container = new Messages::ContainerParams()
                        {
                            ID = "id",
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::SkillParamsType.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                        ServiceTier = ServiceTier.Auto,
                        Speed = Speed.Standard,
                        StopSequences = ["string"],
                        Stream = false,
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
                                            CitedText = "The grass is green. The sky is blue.",
                                            DocumentIndex = 0,
                                            DocumentTitle = "x",
                                            EndCharIndex = 0,
                                            StartCharIndex = 0,
                                        },
                                    ],
                                },
                            ]
                        ),
                        Thinking = new Messages::ThinkingConfigAdaptive()
                        {
                            Display = Messages::Display.Summarized,
                        },
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
                                        { "location", JsonSerializer.SerializeToElement("bar") },
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
                    },
                },
            ],
            UserProfileID = "anthropic-user-profile-id",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        List<Request> expectedRequests =
        [
            new()
            {
                CustomID = "my-custom-id-1",
                Params = new()
                {
                    MaxTokens = 1024,
                    Messages = [new Messages::UserMessageParam("Hello, world")],
                    Model = Messages::Model.ClaudeOpus5_5,
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                    Container = new Messages::ContainerParams()
                    {
                        ID = "id",
                        Skills =
                        [
                            new()
                            {
                                SkillID = "pdf",
                                Type = Messages::SkillParamsType.Anthropic,
                                Version = "latest",
                            },
                        ],
                    },
                    Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                    ServiceTier = ServiceTier.Auto,
                    Speed = Speed.Standard,
                    StopSequences = ["string"],
                    Stream = false,
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
                                        CitedText = "The grass is green. The sky is blue.",
                                        DocumentIndex = 0,
                                        DocumentTitle = "x",
                                        EndCharIndex = 0,
                                        StartCharIndex = 0,
                                    },
                                ],
                            },
                        ]
                    ),
                    Thinking = new Messages::ThinkingConfigAdaptive()
                    {
                        Display = Messages::Display.Summarized,
                    },
                    ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
                    Tools =
                    [
                        new Messages::Tool()
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
                },
            },
        ];
        string expectedUserProfileID = "anthropic-user-profile-id";
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedRequests.Count, parameters.Requests.Count);
        for (int i = 0; i < expectedRequests.Count; i++)
        {
            Assert.Equal(expectedRequests[i], parameters.Requests[i]);
        }
        Assert.Equal(expectedUserProfileID, parameters.UserProfileID);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
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
                        Messages = [new Messages::UserMessageParam("Hello, world")],
                        Model = Messages::Model.ClaudeOpus5_5,
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                        Container = new Messages::ContainerParams()
                        {
                            ID = "id",
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::SkillParamsType.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                        ServiceTier = ServiceTier.Auto,
                        Speed = Speed.Standard,
                        StopSequences = ["string"],
                        Stream = false,
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
                                            CitedText = "The grass is green. The sky is blue.",
                                            DocumentIndex = 0,
                                            DocumentTitle = "x",
                                            EndCharIndex = 0,
                                            StartCharIndex = 0,
                                        },
                                    ],
                                },
                            ]
                        ),
                        Thinking = new Messages::ThinkingConfigAdaptive()
                        {
                            Display = Messages::Display.Summarized,
                        },
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
                                        { "location", JsonSerializer.SerializeToElement("bar") },
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
                    },
                },
            ],
        };

        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-user-profile-id"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
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
                        Messages = [new Messages::UserMessageParam("Hello, world")],
                        Model = Messages::Model.ClaudeOpus5_5,
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                        Container = new Messages::ContainerParams()
                        {
                            ID = "id",
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::SkillParamsType.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                        ServiceTier = ServiceTier.Auto,
                        Speed = Speed.Standard,
                        StopSequences = ["string"],
                        Stream = false,
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
                                            CitedText = "The grass is green. The sky is blue.",
                                            DocumentIndex = 0,
                                            DocumentTitle = "x",
                                            EndCharIndex = 0,
                                            StartCharIndex = 0,
                                        },
                                    ],
                                },
                            ]
                        ),
                        Thinking = new Messages::ThinkingConfigAdaptive()
                        {
                            Display = Messages::Display.Summarized,
                        },
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
                                        { "location", JsonSerializer.SerializeToElement("bar") },
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
                    },
                },
            ],

            // Null should be interpreted as omitted for these properties
            UserProfileID = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-user-profile-id"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
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
                        Messages = [new Messages::UserMessageParam("Hello, world")],
                        Model = Messages::Model.ClaudeOpus5_5,
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                        Container = new Messages::ContainerParams()
                        {
                            ID = "id",
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::SkillParamsType.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                        ServiceTier = ServiceTier.Auto,
                        Speed = Speed.Standard,
                        StopSequences = ["string"],
                        Stream = false,
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
                                            CitedText = "The grass is green. The sky is blue.",
                                            DocumentIndex = 0,
                                            DocumentTitle = "x",
                                            EndCharIndex = 0,
                                            StartCharIndex = 0,
                                        },
                                    ],
                                },
                            ]
                        ),
                        Thinking = new Messages::ThinkingConfigAdaptive()
                        {
                            Display = Messages::Display.Summarized,
                        },
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
                                        { "location", JsonSerializer.SerializeToElement("bar") },
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
                    },
                },
            ],
            UserProfileID = "anthropic-user-profile-id",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        } with
        {
            // Null should be interpreted as omitted for these properties
            UserProfileID = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.UserProfileID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-user-profile-id"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
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
                        Messages = [new Messages::UserMessageParam("Hello, world")],
                        Model = Messages::Model.ClaudeOpus5_5,
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                        Container = new Messages::ContainerParams()
                        {
                            ID = "id",
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::SkillParamsType.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                        ServiceTier = ServiceTier.Auto,
                        Speed = Speed.Standard,
                        StopSequences = ["string"],
                        Stream = false,
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
                                            CitedText = "The grass is green. The sky is blue.",
                                            DocumentIndex = 0,
                                            DocumentTitle = "x",
                                            EndCharIndex = 0,
                                            StartCharIndex = 0,
                                        },
                                    ],
                                },
                            ]
                        ),
                        Thinking = new Messages::ThinkingConfigAdaptive()
                        {
                            Display = Messages::Display.Summarized,
                        },
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
                                        { "location", JsonSerializer.SerializeToElement("bar") },
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
                    },
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/messages/batches"), url)
        );
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
                        Messages = [new Messages::UserMessageParam("Hello, world")],
                        Model = Messages::Model.ClaudeOpus5_5,
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                        Container = new Messages::ContainerParams()
                        {
                            ID = "id",
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::SkillParamsType.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                        ServiceTier = ServiceTier.Auto,
                        Speed = Speed.Standard,
                        StopSequences = ["string"],
                        Stream = false,
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
                                            CitedText = "The grass is green. The sky is blue.",
                                            DocumentIndex = 0,
                                            DocumentTitle = "x",
                                            EndCharIndex = 0,
                                            StartCharIndex = 0,
                                        },
                                    ],
                                },
                            ]
                        ),
                        Thinking = new Messages::ThinkingConfigAdaptive()
                        {
                            Display = Messages::Display.Summarized,
                        },
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
                                        { "location", JsonSerializer.SerializeToElement("bar") },
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
                    },
                },
            ],
            UserProfileID = "anthropic-user-profile-id",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["anthropic-user-profile-id"],
            requestMessage.Headers.GetValues("anthropic-user-profile-id")
        );
        Assert.Equal(
            ["wrkspc_011CZkZaBF1tNoB5wlCeusgy"],
            requestMessage.Headers.GetValues("anthropic-workspace-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
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
                        Messages = [new Messages::UserMessageParam("Hello, world")],
                        Model = Messages::Model.ClaudeOpus5_5,
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                        Container = new Messages::ContainerParams()
                        {
                            ID = "id",
                            Skills =
                            [
                                new()
                                {
                                    SkillID = "pdf",
                                    Type = Messages::SkillParamsType.Anthropic,
                                    Version = "latest",
                                },
                            ],
                        },
                        Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                        ServiceTier = ServiceTier.Auto,
                        Speed = Speed.Standard,
                        StopSequences = ["string"],
                        Stream = false,
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
                                            CitedText = "The grass is green. The sky is blue.",
                                            DocumentIndex = 0,
                                            DocumentTitle = "x",
                                            EndCharIndex = 0,
                                            StartCharIndex = 0,
                                        },
                                    ],
                                },
                            ]
                        ),
                        Thinking = new Messages::ThinkingConfigAdaptive()
                        {
                            Display = Messages::Display.Summarized,
                        },
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
                                        { "location", JsonSerializer.SerializeToElement("bar") },
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
                    },
                },
            ],
            UserProfileID = "anthropic-user-profile-id",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        BatchCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
                Messages = [new Messages::UserMessageParam("Hello, world")],
                Model = Messages::Model.ClaudeOpus5_5,
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                Container = new Messages::ContainerParams()
                {
                    ID = "id",
                    Skills =
                    [
                        new()
                        {
                            SkillID = "pdf",
                            Type = Messages::SkillParamsType.Anthropic,
                            Version = "latest",
                        },
                    ],
                },
                Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                ServiceTier = ServiceTier.Auto,
                Speed = Speed.Standard,
                StopSequences = ["string"],
                Stream = false,
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
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        },
                    ]
                ),
                Thinking = new Messages::ThinkingConfigAdaptive()
                {
                    Display = Messages::Display.Summarized,
                },
                ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::Tool()
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
            },
        };

        string expectedCustomID = "my-custom-id-1";
        Params expectedParams = new()
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
            ServiceTier = ServiceTier.Auto,
            Speed = Speed.Standard,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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
                Messages = [new Messages::UserMessageParam("Hello, world")],
                Model = Messages::Model.ClaudeOpus5_5,
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                Container = new Messages::ContainerParams()
                {
                    ID = "id",
                    Skills =
                    [
                        new()
                        {
                            SkillID = "pdf",
                            Type = Messages::SkillParamsType.Anthropic,
                            Version = "latest",
                        },
                    ],
                },
                Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                ServiceTier = ServiceTier.Auto,
                Speed = Speed.Standard,
                StopSequences = ["string"],
                Stream = false,
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
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        },
                    ]
                ),
                Thinking = new Messages::ThinkingConfigAdaptive()
                {
                    Display = Messages::Display.Summarized,
                },
                ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::Tool()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Request>(json, ModelBase.SerializerOptions);

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
                Messages = [new Messages::UserMessageParam("Hello, world")],
                Model = Messages::Model.ClaudeOpus5_5,
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                Container = new Messages::ContainerParams()
                {
                    ID = "id",
                    Skills =
                    [
                        new()
                        {
                            SkillID = "pdf",
                            Type = Messages::SkillParamsType.Anthropic,
                            Version = "latest",
                        },
                    ],
                },
                Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                ServiceTier = ServiceTier.Auto,
                Speed = Speed.Standard,
                StopSequences = ["string"],
                Stream = false,
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
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        },
                    ]
                ),
                Thinking = new Messages::ThinkingConfigAdaptive()
                {
                    Display = Messages::Display.Summarized,
                },
                ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::Tool()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Request>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCustomID = "my-custom-id-1";
        Params expectedParams = new()
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
            ServiceTier = ServiceTier.Auto,
            Speed = Speed.Standard,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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
                Messages = [new Messages::UserMessageParam("Hello, world")],
                Model = Messages::Model.ClaudeOpus5_5,
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                Container = new Messages::ContainerParams()
                {
                    ID = "id",
                    Skills =
                    [
                        new()
                        {
                            SkillID = "pdf",
                            Type = Messages::SkillParamsType.Anthropic,
                            Version = "latest",
                        },
                    ],
                },
                Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                ServiceTier = ServiceTier.Auto,
                Speed = Speed.Standard,
                StopSequences = ["string"],
                Stream = false,
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
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        },
                    ]
                ),
                Thinking = new Messages::ThinkingConfigAdaptive()
                {
                    Display = Messages::Display.Summarized,
                },
                ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::Tool()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Request
        {
            CustomID = "my-custom-id-1",
            Params = new()
            {
                MaxTokens = 1024,
                Messages = [new Messages::UserMessageParam("Hello, world")],
                Model = Messages::Model.ClaudeOpus5_5,
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                Container = new Messages::ContainerParams()
                {
                    ID = "id",
                    Skills =
                    [
                        new()
                        {
                            SkillID = "pdf",
                            Type = Messages::SkillParamsType.Anthropic,
                            Version = "latest",
                        },
                    ],
                },
                Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
                ServiceTier = ServiceTier.Auto,
                Speed = Speed.Standard,
                StopSequences = ["string"],
                Stream = false,
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
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        },
                    ]
                ),
                Thinking = new Messages::ThinkingConfigAdaptive()
                {
                    Display = Messages::Display.Summarized,
                },
                ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::Tool()
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
            },
        };

        Request copied = new(model);

        Assert.Equal(model, copied);
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
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
            ServiceTier = ServiceTier.Auto,
            Speed = Speed.Standard,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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
        };

        long expectedMaxTokens = 1024;
        List<Messages::MessageParam> expectedMessages =
        [
            new Messages::UserMessageParam("Hello, world"),
        ];
        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus5_5;
        Messages::CacheControlEphemeral expectedCacheControl = new() { Ttl = Messages::Ttl.Ttl5m };
        Messages::MessageCreateParamsContainer expectedContainer = new Messages::ContainerParams()
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = Messages::SkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };
        Messages::DiagnosticsParam expectedDiagnostics = new()
        {
            PreviousMessageID = "previous_message_id",
        };
        string expectedInferenceGeo = "inference_geo";
        Messages::Metadata expectedMetadata = new()
        {
            UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b",
        };
        Messages::OutputConfig expectedOutputConfig = new()
        {
            Effort = Messages::Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };
        ApiEnum<string, ServiceTier> expectedServiceTier = ServiceTier.Auto;
        ApiEnum<string, Speed> expectedSpeed = Speed.Standard;
        List<string> expectedStopSequences = ["string"];
        bool expectedStream = false;
        ParamsSystem expectedSystem = new(
            [
                new Messages::TextBlockParam()
                {
                    Text = "Today's date is 2024-06-01.",
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                    Citations =
                    [
                        new Messages::CitationCharLocationParam()
                        {
                            CitedText = "The grass is green. The sky is blue.",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ]
        );
        Messages::ThinkingConfigParam expectedThinking = new Messages::ThinkingConfigAdaptive()
        {
            Display = Messages::Display.Summarized,
        };
        Messages::ToolChoice expectedToolChoice = new Messages::ToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        List<Messages::ToolUnion> expectedTools =
        [
            new Messages::Tool()
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
        ];

        Assert.Equal(expectedMaxTokens, model.MaxTokens);
        Assert.Equal(expectedMessages.Count, model.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], model.Messages[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedContainer, model.Container);
        Assert.Equal(expectedDiagnostics, model.Diagnostics);
        Assert.Equal(expectedInferenceGeo, model.InferenceGeo);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedOutputConfig, model.OutputConfig);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedSpeed, model.Speed);
        Assert.NotNull(model.StopSequences);
        Assert.Equal(expectedStopSequences.Count, model.StopSequences.Count);
        for (int i = 0; i < expectedStopSequences.Count; i++)
        {
            Assert.Equal(expectedStopSequences[i], model.StopSequences[i]);
        }
        Assert.Equal(expectedStream, model.Stream);
        Assert.Equal(expectedSystem, model.System);
        Assert.Equal(expectedThinking, model.Thinking);
        Assert.Equal(expectedToolChoice, model.ToolChoice);
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
            ServiceTier = ServiceTier.Auto,
            Speed = Speed.Standard,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Params>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
            ServiceTier = ServiceTier.Auto,
            Speed = Speed.Standard,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Params>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedMaxTokens = 1024;
        List<Messages::MessageParam> expectedMessages =
        [
            new Messages::UserMessageParam("Hello, world"),
        ];
        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus5_5;
        Messages::CacheControlEphemeral expectedCacheControl = new() { Ttl = Messages::Ttl.Ttl5m };
        Messages::MessageCreateParamsContainer expectedContainer = new Messages::ContainerParams()
        {
            ID = "id",
            Skills =
            [
                new()
                {
                    SkillID = "pdf",
                    Type = Messages::SkillParamsType.Anthropic,
                    Version = "latest",
                },
            ],
        };
        Messages::DiagnosticsParam expectedDiagnostics = new()
        {
            PreviousMessageID = "previous_message_id",
        };
        string expectedInferenceGeo = "inference_geo";
        Messages::Metadata expectedMetadata = new()
        {
            UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b",
        };
        Messages::OutputConfig expectedOutputConfig = new()
        {
            Effort = Messages::Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };
        ApiEnum<string, ServiceTier> expectedServiceTier = ServiceTier.Auto;
        ApiEnum<string, Speed> expectedSpeed = Speed.Standard;
        List<string> expectedStopSequences = ["string"];
        bool expectedStream = false;
        ParamsSystem expectedSystem = new(
            [
                new Messages::TextBlockParam()
                {
                    Text = "Today's date is 2024-06-01.",
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                    Citations =
                    [
                        new Messages::CitationCharLocationParam()
                        {
                            CitedText = "The grass is green. The sky is blue.",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ]
        );
        Messages::ThinkingConfigParam expectedThinking = new Messages::ThinkingConfigAdaptive()
        {
            Display = Messages::Display.Summarized,
        };
        Messages::ToolChoice expectedToolChoice = new Messages::ToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        List<Messages::ToolUnion> expectedTools =
        [
            new Messages::Tool()
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
        ];

        Assert.Equal(expectedMaxTokens, deserialized.MaxTokens);
        Assert.Equal(expectedMessages.Count, deserialized.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], deserialized.Messages[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedContainer, deserialized.Container);
        Assert.Equal(expectedDiagnostics, deserialized.Diagnostics);
        Assert.Equal(expectedInferenceGeo, deserialized.InferenceGeo);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedOutputConfig, deserialized.OutputConfig);
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.Equal(expectedSpeed, deserialized.Speed);
        Assert.NotNull(deserialized.StopSequences);
        Assert.Equal(expectedStopSequences.Count, deserialized.StopSequences.Count);
        for (int i = 0; i < expectedStopSequences.Count; i++)
        {
            Assert.Equal(expectedStopSequences[i], deserialized.StopSequences[i]);
        }
        Assert.Equal(expectedStream, deserialized.Stream);
        Assert.Equal(expectedSystem, deserialized.System);
        Assert.Equal(expectedThinking, deserialized.Thinking);
        Assert.Equal(expectedToolChoice, deserialized.ToolChoice);
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
            ServiceTier = ServiceTier.Auto,
            Speed = Speed.Standard,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };

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
        Assert.Null(model.Thinking);
        Assert.False(model.RawData.ContainsKey("thinking"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            OutputConfig = null,
            ServiceTier = null,
            StopSequences = null,
            Stream = null,
            System = null,
            Thinking = null,
            ToolChoice = null,
            Tools = null,
        };

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
        Assert.Null(model.Thinking);
        Assert.False(model.RawData.ContainsKey("thinking"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
            ServiceTier = ServiceTier.Auto,
            Speed = Speed.Standard,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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
        } with
        {
            // Null should be interpreted as omitted for these properties
            Metadata = null,
            OutputConfig = null,
            ServiceTier = null,
            StopSequences = null,
            Stream = null,
            System = null,
            Thinking = null,
            ToolChoice = null,
            Tools = null,
        };

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
        Assert.Null(model.Thinking);
        Assert.False(model.RawData.ContainsKey("thinking"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            OutputConfig = null,
            ServiceTier = null,
            StopSequences = null,
            Stream = null,
            System = null,
            Thinking = null,
            ToolChoice = null,
            Tools = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
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
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Container);
        Assert.False(model.RawData.ContainsKey("container"));
        Assert.Null(model.Diagnostics);
        Assert.False(model.RawData.ContainsKey("diagnostics"));
        Assert.Null(model.InferenceGeo);
        Assert.False(model.RawData.ContainsKey("inference_geo"));
        Assert.Null(model.Speed);
        Assert.False(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
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
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
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
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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

            CacheControl = null,
            Container = null,
            Diagnostics = null,
            InferenceGeo = null,
            Speed = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Container);
        Assert.True(model.RawData.ContainsKey("container"));
        Assert.Null(model.Diagnostics);
        Assert.True(model.RawData.ContainsKey("diagnostics"));
        Assert.Null(model.InferenceGeo);
        Assert.True(model.RawData.ContainsKey("inference_geo"));
        Assert.Null(model.Speed);
        Assert.True(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
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
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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

            CacheControl = null,
            Container = null,
            Diagnostics = null,
            InferenceGeo = null,
            Speed = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new Messages::UserMessageParam("Hello, world")],
            Model = Messages::Model.ClaudeOpus5_5,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = new Messages::ContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::SkillParamsType.Anthropic,
                        Version = "latest",
                    },
                ],
            },
            Diagnostics = new() { PreviousMessageID = "previous_message_id" },
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
            ServiceTier = ServiceTier.Auto,
            Speed = Speed.Standard,
            StopSequences = ["string"],
            Stream = false,
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Thinking = new Messages::ThinkingConfigAdaptive()
            {
                Display = Messages::Display.Summarized,
            },
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
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
        };

        Params copied = new(model);

        Assert.Equal(model, copied);
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

public class SpeedTest : TestBase
{
    [Theory]
    [InlineData(Speed.Standard)]
    [InlineData(Speed.Fast)]
    public void Validation_Works(Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Speed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Speed.Standard)]
    [InlineData(Speed.Fast)]
    public void SerializationRoundtrip_Works(Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Speed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
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
        ParamsSystem value = "string";
        value.Validate();
    }

    [Fact]
    public void TextBlockParamsValidationWorks()
    {
        ParamsSystem value = new(
            [
                new Messages::TextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                    Citations =
                    [
                        new Messages::CitationCharLocationParam()
                        {
                            CitedText = "The grass is green. The sky is blue.",
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
        ParamsSystem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParamsSystem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextBlockParamsSerializationRoundtripWorks()
    {
        ParamsSystem value = new(
            [
                new Messages::TextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                    Citations =
                    [
                        new Messages::CitationCharLocationParam()
                        {
                            CitedText = "The grass is green. The sky is blue.",
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
        var deserialized = JsonSerializer.Deserialize<ParamsSystem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
