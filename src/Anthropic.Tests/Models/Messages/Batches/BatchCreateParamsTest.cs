using System;
using System.Collections.Generic;
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
                        Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                        Model = Messages::Model.ClaudeOpus4_6,
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                        Container = "container",
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
                        TopK = 5,
                        TopP = 0.7,
                    },
                },
            ],
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
                    Model = Messages::Model.ClaudeOpus4_6,
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                    Container = "container",
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
                    TopK = 5,
                    TopP = 0.7,
                },
            },
        ];

        Assert.Equal(expectedRequests.Count, parameters.Requests.Count);
        for (int i = 0; i < expectedRequests.Count; i++)
        {
            Assert.Equal(expectedRequests[i], parameters.Requests[i]);
        }
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
                        Model = Messages::Model.ClaudeOpus4_6,
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                        Container = "container",
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
                        Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                        Model = Messages::Model.ClaudeOpus4_6,
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                        Container = "container",
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
                        TopK = 5,
                        TopP = 0.7,
                    },
                },
            ],
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
                Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                Model = Messages::Model.ClaudeOpus4_6,
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                Container = "container",
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
                TopK = 5,
                TopP = 0.7,
            },
        };

        string expectedCustomID = "my-custom-id-1";
        Params expectedParams = new()
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = "container",
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
                Model = Messages::Model.ClaudeOpus4_6,
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                Container = "container",
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
                TopK = 5,
                TopP = 0.7,
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
                Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                Model = Messages::Model.ClaudeOpus4_6,
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                Container = "container",
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
                TopK = 5,
                TopP = 0.7,
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
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = "container",
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
                Model = Messages::Model.ClaudeOpus4_6,
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                Container = "container",
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
                TopK = 5,
                TopP = 0.7,
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
                Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                Model = Messages::Model.ClaudeOpus4_6,
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                Container = "container",
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
                TopK = 5,
                TopP = 0.7,
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
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = "container",
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
            TopK = 5,
            TopP = 0.7,
        };

        long expectedMaxTokens = 1024;
        List<Messages::MessageParam> expectedMessages =
        [
            new() { Content = "Hello, world", Role = Messages::Role.User },
        ];
        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus4_6;
        Messages::CacheControlEphemeral expectedCacheControl = new() { Ttl = Messages::Ttl.Ttl5m };
        string expectedContainer = "container";
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
        List<string> expectedStopSequences = ["string"];
        bool expectedStream = true;
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
        Messages::ThinkingConfigParam expectedThinking = new Messages::ThinkingConfigEnabled(1024);
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
        long expectedTopK = 5;
        double expectedTopP = 0.7;

        Assert.Equal(expectedMaxTokens, model.MaxTokens);
        Assert.Equal(expectedMessages.Count, model.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], model.Messages[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedContainer, model.Container);
        Assert.Equal(expectedInferenceGeo, model.InferenceGeo);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedOutputConfig, model.OutputConfig);
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
            Model = Messages::Model.ClaudeOpus4_6,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = "container",
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
            TopK = 5,
            TopP = 0.7,
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
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = "container",
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
            TopK = 5,
            TopP = 0.7,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Params>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedMaxTokens = 1024;
        List<Messages::MessageParam> expectedMessages =
        [
            new() { Content = "Hello, world", Role = Messages::Role.User },
        ];
        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus4_6;
        Messages::CacheControlEphemeral expectedCacheControl = new() { Ttl = Messages::Ttl.Ttl5m };
        string expectedContainer = "container";
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
        List<string> expectedStopSequences = ["string"];
        bool expectedStream = true;
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
        Messages::ThinkingConfigParam expectedThinking = new Messages::ThinkingConfigEnabled(1024);
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
        long expectedTopK = 5;
        double expectedTopP = 0.7;

        Assert.Equal(expectedMaxTokens, deserialized.MaxTokens);
        Assert.Equal(expectedMessages.Count, deserialized.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], deserialized.Messages[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedContainer, deserialized.Container);
        Assert.Equal(expectedInferenceGeo, deserialized.InferenceGeo);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedOutputConfig, deserialized.OutputConfig);
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
            Model = Messages::Model.ClaudeOpus4_6,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = "container",
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
            Model = Messages::Model.ClaudeOpus4_6,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = "container",
            InferenceGeo = "inference_geo",
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
            Model = Messages::Model.ClaudeOpus4_6,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = "container",
            InferenceGeo = "inference_geo",
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
            Model = Messages::Model.ClaudeOpus4_6,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = "container",
            InferenceGeo = "inference_geo",

            // Null should be interpreted as omitted for these properties
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
            Model = Messages::Model.ClaudeOpus4_6,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = "container",
            InferenceGeo = "inference_geo",

            // Null should be interpreted as omitted for these properties
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
            Model = Messages::Model.ClaudeOpus4_6,
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
            TopK = 5,
            TopP = 0.7,
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Container);
        Assert.False(model.RawData.ContainsKey("container"));
        Assert.Null(model.InferenceGeo);
        Assert.False(model.RawData.ContainsKey("inference_geo"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
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
            Model = Messages::Model.ClaudeOpus4_6,
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
            TopK = 5,
            TopP = 0.7,

            CacheControl = null,
            Container = null,
            InferenceGeo = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Container);
        Assert.True(model.RawData.ContainsKey("container"));
        Assert.Null(model.InferenceGeo);
        Assert.True(model.RawData.ContainsKey("inference_geo"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
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
            TopK = 5,
            TopP = 0.7,

            CacheControl = null,
            Container = null,
            InferenceGeo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
            Container = "container",
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
            TopK = 5,
            TopP = 0.7,
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
        var deserialized = JsonSerializer.Deserialize<ParamsSystem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
