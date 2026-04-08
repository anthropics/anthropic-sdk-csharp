using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsEventParamsTest : TestBase
{
    [Fact]
    public void UserMessageValidationWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserMessageEventParams()
        {
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
        };
        value.Validate();
    }

    [Fact]
    public void UserInterruptValidationWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserInterruptEventParams(
            BetaManagedAgentsUserInterruptEventParamsType.UserInterrupt
        );
        value.Validate();
    }

    [Fact]
    public void UserToolConfirmationValidationWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserToolConfirmationEventParams()
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            Type = BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,
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
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
        };
        value.Validate();
    }

    [Fact]
    public void UserMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserMessageEventParams()
        {
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
        };
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
        BetaManagedAgentsEventParams value = new BetaManagedAgentsUserInterruptEventParams(
            BetaManagedAgentsUserInterruptEventParamsType.UserInterrupt
        );
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
            Type = BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,
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
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsEventParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
