using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsEventParamsTest : TestBase
{
    [Fact]
    public void UserMessageValidationWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserMessageEventParams(
            [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
        );
        value.Validate();
    }

    [Fact]
    public void UserInterruptValidationWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserInterruptEventParams()
        {
            SessionThreadID = "session_thread_id",
        };
        value.Validate();
    }

    [Fact]
    public void UserToolConfirmationValidationWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserToolConfirmationEventParams()
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            DenyMessage = "deny_message",
        };
        value.Validate();
    }

    [Fact]
    public void UserCustomToolResultValidationWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserCustomToolResultEventParams()
        {
            CustomToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        value.Validate();
    }

    [Fact]
    public void UserDefineOutcomeValidationWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserDefineOutcomeEventParams()
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams(
                "Must cover all five sections; cite sources inline."
            ),
            MaxIterations = 3,
        };
        value.Validate();
    }

    [Fact]
    public void UserToolResultValidationWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserToolResultEventParams()
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        value.Validate();
    }

    [Fact]
    public void SystemMessageValidationWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsSystemMessageEventParams(
            [new("Where is my order #1234?")]
        );
        value.Validate();
    }

    [Fact]
    public void UserMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserMessageEventParams(
            [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEventParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserInterruptSerializationRoundtripWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserInterruptEventParams()
        {
            SessionThreadID = "session_thread_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEventParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserToolConfirmationSerializationRoundtripWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserToolConfirmationEventParams()
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            DenyMessage = "deny_message",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEventParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserCustomToolResultSerializationRoundtripWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserCustomToolResultEventParams()
        {
            CustomToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEventParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserDefineOutcomeSerializationRoundtripWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserDefineOutcomeEventParams()
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams(
                "Must cover all five sections; cite sources inline."
            ),
            MaxIterations = 3,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEventParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserToolResultSerializationRoundtripWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserToolResultEventParams()
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEventParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SystemMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsSystemMessageEventParams(
            [new("Where is my order #1234?")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEventParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserMessageTypeWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserMessageEventParams(
            [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
        );
        Assert.Equal(BetaManagedAgentsEventParamsType.UserMessage, value.Type.Value());
    }

    [Fact]
    public void UserInterruptTypeWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserInterruptEventParams()
        {
            SessionThreadID = "session_thread_id",
        };
        Assert.Equal(BetaManagedAgentsEventParamsType.UserInterrupt, value.Type.Value());
    }

    [Fact]
    public void UserToolConfirmationTypeWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserToolConfirmationEventParams()
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            DenyMessage = "deny_message",
        };
        Assert.Equal(BetaManagedAgentsEventParamsType.UserToolConfirmation, value.Type.Value());
    }

    [Fact]
    public void UserCustomToolResultTypeWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserCustomToolResultEventParams()
        {
            CustomToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        Assert.Equal(BetaManagedAgentsEventParamsType.UserCustomToolResult, value.Type.Value());
    }

    [Fact]
    public void UserDefineOutcomeTypeWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserDefineOutcomeEventParams()
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams(
                "Must cover all five sections; cite sources inline."
            ),
            MaxIterations = 3,
        };
        Assert.Equal(BetaManagedAgentsEventParamsType.UserDefineOutcome, value.Type.Value());
    }

    [Fact]
    public void UserToolResultTypeWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserToolResultEventParams()
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };
        Assert.Equal(BetaManagedAgentsEventParamsType.UserToolResult, value.Type.Value());
    }

    [Fact]
    public void SystemMessageTypeWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsSystemMessageEventParams(
            [new("Where is my order #1234?")]
        );
        Assert.Equal(BetaManagedAgentsEventParamsType.SystemMessage, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsEventParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user.message",
                  "tool_use_id": "x",
                  "is_error": true
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsEventParamsType> expectedType =
            BetaManagedAgentsEventParamsType.UserMessage;
        string expectedToolUseID = "x";
        bool expectedIsError = true;

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedToolUseID, value.ToolUseID);
        Assert.Equal(expectedIsError, value.IsError);

        BetaManagedAgentsEventParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ToolUseID);
        Assert.Null(emptyValue.IsError);

        BetaManagedAgentsEventParams mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
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

        Assert.Null(mismatchedValue.ToolUseID);
        Assert.Null(mismatchedValue.IsError);
    }
}

public class BetaManagedAgentsEventParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsEventParamsType.UserMessage)]
    [InlineData(BetaManagedAgentsEventParamsType.UserInterrupt)]
    [InlineData(BetaManagedAgentsEventParamsType.UserToolConfirmation)]
    [InlineData(BetaManagedAgentsEventParamsType.UserCustomToolResult)]
    [InlineData(BetaManagedAgentsEventParamsType.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsEventParamsType.UserToolResult)]
    [InlineData(BetaManagedAgentsEventParamsType.SystemMessage)]
    public void Validation_Works(BetaManagedAgentsEventParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEventParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsEventParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsEventParamsType.UserMessage)]
    [InlineData(BetaManagedAgentsEventParamsType.UserInterrupt)]
    [InlineData(BetaManagedAgentsEventParamsType.UserToolConfirmation)]
    [InlineData(BetaManagedAgentsEventParamsType.UserCustomToolResult)]
    [InlineData(BetaManagedAgentsEventParamsType.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsEventParamsType.UserToolResult)]
    [InlineData(BetaManagedAgentsEventParamsType.SystemMessage)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsEventParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEventParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsEventParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
