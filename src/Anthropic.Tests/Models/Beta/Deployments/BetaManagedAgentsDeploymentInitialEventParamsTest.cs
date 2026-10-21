using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentInitialEventParamsTest : TestBase
{
    [Fact]
    public void UserMessageValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsUserMessageEventParams(
                [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
            );
        value.Validate();
    }

    [Fact]
    public void UserDefineOutcomeValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsUserDefineOutcomeEventParams()
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
    public void SystemMessageValidationWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsSystemMessageEventParams([new("Where is my order #1234?")]);
        value.Validate();
    }

    [Fact]
    public void UserMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsUserMessageEventParams(
                [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
            );
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
                Rubric = new BetaManagedAgentsTextRubricParams(
                    "Must cover all five sections; cite sources inline."
                ),
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
            new BetaManagedAgentsSystemMessageEventParams([new("Where is my order #1234?")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsDeploymentInitialEventParams>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserMessageTypeWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsUserMessageEventParams(
                [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
            );
        Assert.Equal(
            BetaManagedAgentsDeploymentInitialEventParamsType.UserMessage,
            value.Type.Value()
        );
    }

    [Fact]
    public void UserDefineOutcomeTypeWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsUserDefineOutcomeEventParams()
            {
                Description = "Produce a 2-page summary as summary.md",
                Rubric = new BetaManagedAgentsTextRubricParams(
                    "Must cover all five sections; cite sources inline."
                ),
                MaxIterations = 3,
            };
        Assert.Equal(
            BetaManagedAgentsDeploymentInitialEventParamsType.UserDefineOutcome,
            value.Type.Value()
        );
    }

    [Fact]
    public void SystemMessageTypeWorks()
    {
        BetaManagedAgentsDeploymentInitialEventParams value =
            new BetaManagedAgentsSystemMessageEventParams([new("Where is my order #1234?")]);
        Assert.Equal(
            BetaManagedAgentsDeploymentInitialEventParamsType.SystemMessage,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsDeploymentInitialEventParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user.message"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsDeploymentInitialEventParamsType> expectedType =
            BetaManagedAgentsDeploymentInitialEventParamsType.UserMessage;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsDeploymentInitialEventParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsDeploymentInitialEventParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeploymentInitialEventParamsType.UserMessage)]
    [InlineData(BetaManagedAgentsDeploymentInitialEventParamsType.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsDeploymentInitialEventParamsType.SystemMessage)]
    public void Validation_Works(BetaManagedAgentsDeploymentInitialEventParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentInitialEventParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentInitialEventParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeploymentInitialEventParamsType.UserMessage)]
    [InlineData(BetaManagedAgentsDeploymentInitialEventParamsType.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsDeploymentInitialEventParamsType.SystemMessage)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsDeploymentInitialEventParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentInitialEventParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentInitialEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentInitialEventParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentInitialEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
