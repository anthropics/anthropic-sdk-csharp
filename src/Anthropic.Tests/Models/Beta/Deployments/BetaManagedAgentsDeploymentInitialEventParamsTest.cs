using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Deployments;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentInitialEventParamsTest : TestBase
{
    [Fact]
    public void UserMessageValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsUserMessageEventParams()
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
    public void UserDefineOutcomeValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsUserDefineOutcomeEventParams()
            {
                Description = "Produce a 2-page summary as summary.md",
                Rubric = new BetaManagedAgentsTextRubricParams()
                {
                    Content = "Must cover all five sections; cite sources inline.",
                    Type = BetaManagedAgentsTextRubricParamsType.Text,
                },
                Type = BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,
                MaxIterations = 3,
            };
        value.Validate();
    }

    [Fact]
    public void SystemMessageValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsSystemMessageEventParams()
            {
                Content =
                [
                    new()
                    {
                        Text = "Where is my order #1234?",
                        Type = BetaManagedAgentsSystemContentBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsSystemMessageEventParamsType.SystemMessage,
            };
        value.Validate();
    }

    [Fact]
    public void UserMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsUserMessageEventParams()
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
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsDeploymentInitialEventParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserDefineOutcomeSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsUserDefineOutcomeEventParams()
            {
                Description = "Produce a 2-page summary as summary.md",
                Rubric = new BetaManagedAgentsTextRubricParams()
                {
                    Content = "Must cover all five sections; cite sources inline.",
                    Type = BetaManagedAgentsTextRubricParamsType.Text,
                },
                Type = BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,
                MaxIterations = 3,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsDeploymentInitialEventParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SystemMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsSystemMessageEventParams()
            {
                Content =
                [
                    new()
                    {
                        Text = "Where is my order #1234?",
                        Type = BetaManagedAgentsSystemContentBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsSystemMessageEventParamsType.SystemMessage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsDeploymentInitialEventParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
