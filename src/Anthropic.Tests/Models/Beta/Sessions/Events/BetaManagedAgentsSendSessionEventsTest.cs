using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
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
                    ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
                    Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
            ],
        };

        List<Data> expectedData =
        [
            new BetaManagedAgentsUserMessageEvent()
            {
                ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
                Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
                    ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
                    Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
                    ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
                    Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
                ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
                Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
                    ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
                    Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsSendSessionEvents
        {
            Data =
            [
                new BetaManagedAgentsUserMessageEvent()
                {
                    ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
                    Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
                    ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                },
            ],
        } with
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
                    ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
                    Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
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
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUserDefineOutcomeEventValidationWorks()
    {
        Data value = new BetaManagedAgentsUserDefineOutcomeEvent()
        {
            ID = "sevt_011CZkZSTx3mFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric(
                "Must cover all five sections; cite sources inline."
            ),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUserToolResultEventValidationWorks()
    {
        Data value = new BetaManagedAgentsUserToolResultEvent()
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSystemMessageEventValidationWorks()
    {
        Data value = new BetaManagedAgentsSystemMessageEvent()
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUserMessageEventSerializationRoundtripWorks()
    {
        Data value = new BetaManagedAgentsUserMessageEvent()
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
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
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUserDefineOutcomeEventSerializationRoundtripWorks()
    {
        Data value = new BetaManagedAgentsUserDefineOutcomeEvent()
        {
            ID = "sevt_011CZkZSTx3mFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric(
                "Must cover all five sections; cite sources inline."
            ),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUserToolResultEventSerializationRoundtripWorks()
    {
        Data value = new BetaManagedAgentsUserToolResultEvent()
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSystemMessageEventSerializationRoundtripWorks()
    {
        Data value = new BetaManagedAgentsSystemMessageEvent()
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUserMessageEventTypeWorks()
    {
        Data value = new BetaManagedAgentsUserMessageEvent()
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };
        Assert.Equal(DataType.UserMessage, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsUserInterruptEventTypeWorks()
    {
        Data value = new BetaManagedAgentsUserInterruptEvent()
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(DataType.UserInterrupt, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsUserToolConfirmationEventTypeWorks()
    {
        Data value = new BetaManagedAgentsUserToolConfirmationEvent()
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(DataType.UserToolConfirmation, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsUserCustomToolResultEventTypeWorks()
    {
        Data value = new BetaManagedAgentsUserCustomToolResultEvent()
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(DataType.UserCustomToolResult, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsUserDefineOutcomeEventTypeWorks()
    {
        Data value = new BetaManagedAgentsUserDefineOutcomeEvent()
        {
            ID = "sevt_011CZkZSTx3mFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric(
                "Must cover all five sections; cite sources inline."
            ),
        };
        Assert.Equal(DataType.UserDefineOutcome, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsUserToolResultEventTypeWorks()
    {
        Data value = new BetaManagedAgentsUserToolResultEvent()
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(DataType.UserToolResult, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsSystemMessageEventTypeWorks()
    {
        Data value = new BetaManagedAgentsSystemMessageEvent()
        {
            ID = "id",
            Content = [new("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Assert.Equal(DataType.SystemMessage, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Data value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "sevt_011CZkZGPp1iBcp4kaQSihUm",
                  "type": "user.message",
                  "processed_at": "2026-03-15T10:00:00Z",
                  "session_thread_id": "session_thread_id",
                  "tool_use_id": "tool_use_id",
                  "is_error": true
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "sevt_011CZkZGPp1iBcp4kaQSihUm";
        ApiEnum<string, DataType> expectedType = DataType.UserMessage;
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionThreadID = "session_thread_id";
        string expectedToolUseID = "tool_use_id";
        bool expectedIsError = true;

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedProcessedAt, value.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, value.SessionThreadID);
        Assert.Equal(expectedToolUseID, value.ToolUseID);
        Assert.Equal(expectedIsError, value.IsError);

        Data emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ProcessedAt);
        Assert.Null(emptyValue.SessionThreadID);
        Assert.Null(emptyValue.ToolUseID);
        Assert.Null(emptyValue.IsError);

        Data mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": [
                    "invalid"
                  ],
                  "processed_at": [
                    "invalid"
                  ],
                  "session_thread_id": [
                    "invalid"
                  ],
                  "tool_use_id": [
                    "invalid"
                  ],
                  "is_error": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.ID);
        Assert.Null(mismatchedValue.ProcessedAt);
        Assert.Null(mismatchedValue.SessionThreadID);
        Assert.Null(mismatchedValue.ToolUseID);
        Assert.Null(mismatchedValue.IsError);
    }
}

public class DataTypeTest : TestBase
{
    [Theory]
    [InlineData(DataType.UserMessage)]
    [InlineData(DataType.UserInterrupt)]
    [InlineData(DataType.UserToolConfirmation)]
    [InlineData(DataType.UserCustomToolResult)]
    [InlineData(DataType.UserDefineOutcome)]
    [InlineData(DataType.UserToolResult)]
    [InlineData(DataType.SystemMessage)]
    public void Validation_Works(DataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataType.UserMessage)]
    [InlineData(DataType.UserInterrupt)]
    [InlineData(DataType.UserToolConfirmation)]
    [InlineData(DataType.UserCustomToolResult)]
    [InlineData(DataType.UserDefineOutcome)]
    [InlineData(DataType.UserToolResult)]
    [InlineData(DataType.SystemMessage)]
    public void SerializationRoundtrip_Works(DataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
