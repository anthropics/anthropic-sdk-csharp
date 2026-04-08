using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class EventListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsAgentMessageEvent()
                {
                    ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                    Content =
                    [
                        new()
                        {
                            Text = "Let me look up order #1234 for you.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<BetaManagedAgentsSessionEvent> expectedData =
        [
            new BetaManagedAgentsUserMessageEvent()
            {
                ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                Content =
                [
                    new BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsUserMessageEventType.UserMessage,
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            },
            new BetaManagedAgentsAgentMessageEvent()
            {
                ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                Content =
                [
                    new()
                    {
                        Text = "Let me look up order #1234 for you.",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsAgentMessageEvent()
                {
                    ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                    Content =
                    [
                        new()
                        {
                            Text = "Let me look up order #1234 for you.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsAgentMessageEvent()
                {
                    ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                    Content =
                    [
                        new()
                        {
                            Text = "Let me look up order #1234 for you.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsSessionEvent> expectedData =
        [
            new BetaManagedAgentsUserMessageEvent()
            {
                ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                Content =
                [
                    new BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsUserMessageEventType.UserMessage,
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            },
            new BetaManagedAgentsAgentMessageEvent()
            {
                ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                Content =
                [
                    new()
                    {
                        Text = "Let me look up order #1234 for you.",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsAgentMessageEvent()
                {
                    ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                    Content =
                    [
                        new()
                        {
                            Text = "Let me look up order #1234 for you.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventListPageResponse { NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=" };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventListPageResponse { NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EventListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",

            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventListPageResponse
        {
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",

            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsAgentMessageEvent()
                {
                    ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                    Content =
                    [
                        new()
                        {
                            Text = "Let me look up order #1234 for you.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
                },
            ],
        };

        Assert.Null(model.NextPage);
        Assert.False(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsAgentMessageEvent()
                {
                    ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                    Content =
                    [
                        new()
                        {
                            Text = "Let me look up order #1234 for you.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EventListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsAgentMessageEvent()
                {
                    ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                    Content =
                    [
                        new()
                        {
                            Text = "Let me look up order #1234 for you.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
                },
            ],

            NextPage = null,
        };

        Assert.Null(model.NextPage);
        Assert.True(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsAgentMessageEvent()
                {
                    ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                    Content =
                    [
                        new()
                        {
                            Text = "Let me look up order #1234 for you.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
                },
            ],

            NextPage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventListPageResponse
        {
            Data =
            [
                new BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
                new BetaManagedAgentsAgentMessageEvent()
                {
                    ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
                    Content =
                    [
                        new()
                        {
                            Text = "Let me look up order #1234 for you.",
                            Type = BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        EventListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
