using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Deployments;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentInitialEventTest : TestBase
{
    [Fact]
    public void UserMessageValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentUserMessageEvent()
            {
                Content =
                [
                    new BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
            };
        value.Validate();
    }

    [Fact]
    public void UserDefineOutcomeValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentUserDefineOutcomeEvent()
            {
                Description = "description",
                Rubric = new BetaManagedAgentsFileRubric()
                {
                    FileID = "file_id",
                    Type = BetaManagedAgentsFileRubricType.File,
                },
                Type = BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,
                MaxIterations = 0,
            };
        value.Validate();
    }

    [Fact]
    public void SystemMessageValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentSystemMessageEvent()
            {
                Content =
                [
                    new()
                    {
                        Text = "Where is my order #1234?",
                        Type = BetaManagedAgentsSystemContentBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage,
            };
        value.Validate();
    }

    [Fact]
    public void UserMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentUserMessageEvent()
            {
                Content =
                [
                    new BetaManagedAgentsTextBlock()
                    {
                        Text = "Where is my order #1234?",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentInitialEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserDefineOutcomeSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentUserDefineOutcomeEvent()
            {
                Description = "description",
                Rubric = new BetaManagedAgentsFileRubric()
                {
                    FileID = "file_id",
                    Type = BetaManagedAgentsFileRubricType.File,
                },
                Type = BetaManagedAgentsDeploymentUserDefineOutcomeEventType.UserDefineOutcome,
                MaxIterations = 0,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentInitialEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SystemMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentSystemMessageEvent()
            {
                Content =
                [
                    new()
                    {
                        Text = "Where is my order #1234?",
                        Type = BetaManagedAgentsSystemContentBlockType.Text,
                    },
                ],
                Type = BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentInitialEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
