using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Threads.Events;
using Events = Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Threads.Events;

public class EventListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventListPageResponse
        {
            Data =
            [
                new Events::BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new Events::BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = Events::BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
            ],
            NextPage = "next_page",
        };

        List<Events::BetaManagedAgentsSessionEvent> expectedData =
        [
            new Events::BetaManagedAgentsUserMessageEvent()
            {
                ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            },
        ];
        string expectedNextPage = "next_page";

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
                new Events::BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new Events::BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = Events::BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
            ],
            NextPage = "next_page",
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
                new Events::BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new Events::BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = Events::BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Events::BetaManagedAgentsSessionEvent> expectedData =
        [
            new Events::BetaManagedAgentsUserMessageEvent()
            {
                ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                Content =
                [
                    new Events::BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = Events::BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            },
        ];
        string expectedNextPage = "next_page";

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
                new Events::BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new Events::BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = Events::BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventListPageResponse { NextPage = "next_page" };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventListPageResponse { NextPage = "next_page" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EventListPageResponse
        {
            NextPage = "next_page",

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
            NextPage = "next_page",

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
                new Events::BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new Events::BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = Events::BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
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
                new Events::BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new Events::BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = Events::BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
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
                new Events::BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new Events::BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = Events::BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
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
                new Events::BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new Events::BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = Events::BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
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
                new Events::BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGOp0iBcp4kaQSihUmy",
                    Content =
                    [
                        new Events::BetaManagedAgentsTextBlock()
                        {
                            Text = "Where is my order #1234?",
                            Type = Events::BetaManagedAgentsTextBlockType.Text,
                        },
                    ],
                    Type = Events::BetaManagedAgentsUserMessageEventType.UserMessage,
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
            ],
            NextPage = "next_page",
        };

        EventListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
