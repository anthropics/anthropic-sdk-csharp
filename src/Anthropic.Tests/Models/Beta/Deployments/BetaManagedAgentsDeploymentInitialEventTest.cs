using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentInitialEventTest : TestBase
{
    [Fact]
    public void UserMessageValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentUserMessageEvent(
                [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
            );
        value.Validate();
    }

    [Fact]
    public void UserDefineOutcomeValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentUserDefineOutcomeEvent()
            {
                Description = "description",
                Rubric = new BetaManagedAgentsFileRubric("file_id"),
                MaxIterations = 0,
            };
        value.Validate();
    }

    [Fact]
    public void SystemMessageValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentSystemMessageEvent([new("Where is my order #1234?")]);
        value.Validate();
    }

    [Fact]
    public void UserMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentUserMessageEvent(
                [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
            );
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
                Rubric = new BetaManagedAgentsFileRubric("file_id"),
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
            new BetaManagedAgentsDeploymentSystemMessageEvent([new("Where is my order #1234?")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentInitialEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserMessageTypeWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentUserMessageEvent(
                [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
            );
        Assert.Equal(BetaManagedAgentsDeploymentInitialEventType.UserMessage, value.Type.Value());
    }

    [Fact]
    public void UserDefineOutcomeTypeWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentUserDefineOutcomeEvent()
            {
                Description = "description",
                Rubric = new BetaManagedAgentsFileRubric("file_id"),
                MaxIterations = 0,
            };
        Assert.Equal(
            BetaManagedAgentsDeploymentInitialEventType.UserDefineOutcome,
            value.Type.Value()
        );
    }

    [Fact]
    public void SystemMessageTypeWorks()
    {
        BetaManagedAgentsDeploymentInitialEvent value =
            new BetaManagedAgentsDeploymentSystemMessageEvent([new("Where is my order #1234?")]);
        Assert.Equal(BetaManagedAgentsDeploymentInitialEventType.SystemMessage, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsDeploymentInitialEvent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user.message"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsDeploymentInitialEventType> expectedType =
            BetaManagedAgentsDeploymentInitialEventType.UserMessage;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsDeploymentInitialEvent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsDeploymentInitialEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeploymentInitialEventType.UserMessage)]
    [InlineData(BetaManagedAgentsDeploymentInitialEventType.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsDeploymentInitialEventType.SystemMessage)]
    public void Validation_Works(BetaManagedAgentsDeploymentInitialEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentInitialEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentInitialEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeploymentInitialEventType.UserMessage)]
    [InlineData(BetaManagedAgentsDeploymentInitialEventType.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsDeploymentInitialEventType.SystemMessage)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsDeploymentInitialEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentInitialEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentInitialEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentInitialEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentInitialEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
