using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSendSessionEventsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSendSessionEvents
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
            ],
        };

        List<Data> expectedData =
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
        ];

        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSendSessionEvents
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
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSendSessionEvents>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSendSessionEvents
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
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSendSessionEvents>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Data> expectedData =
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
        ];

        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSendSessionEvents
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSendSessionEvents { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSendSessionEvents { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSendSessionEvents
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSendSessionEvents
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSendSessionEvents
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
            ],
        };

        BetaManagedAgentsSendSessionEvents copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsUserMessageEventValidationWorks()
    {
        Data value = new BetaManagedAgentsUserMessageEvent()
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
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUserInterruptEventValidationWorks()
    {
        Data value = new BetaManagedAgentsUserInterruptEvent()
        {
            ID = "id",
            Type = BetaManagedAgentsUserInterruptEventType.UserInterrupt,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUserToolConfirmationEventValidationWorks()
    {
        Data value = new BetaManagedAgentsUserToolConfirmationEvent()
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUserCustomToolResultEventValidationWorks()
    {
        Data value = new BetaManagedAgentsUserCustomToolResultEvent()
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUserMessageEventSerializationRoundtripWorks()
    {
        Data value = new BetaManagedAgentsUserMessageEvent()
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUserInterruptEventSerializationRoundtripWorks()
    {
        Data value = new BetaManagedAgentsUserInterruptEvent()
        {
            ID = "id",
            Type = BetaManagedAgentsUserInterruptEventType.UserInterrupt,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUserToolConfirmationEventSerializationRoundtripWorks()
    {
        Data value = new BetaManagedAgentsUserToolConfirmationEvent()
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUserCustomToolResultEventSerializationRoundtripWorks()
    {
        Data value = new BetaManagedAgentsUserCustomToolResultEvent()
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
