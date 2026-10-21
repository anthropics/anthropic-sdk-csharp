using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsStartEventPreviewTest : TestBase
{
    [Fact]
    public void AgentMessageValidationWorks()
    {
        BetaManagedAgentsStartEventPreview value = new BetaManagedAgentsAgentMessagePreview("id");
        value.Validate();
    }

    [Fact]
    public void AgentThinkingValidationWorks()
    {
        BetaManagedAgentsStartEventPreview value = new BetaManagedAgentsAgentThinkingPreview("id");
        value.Validate();
    }

    [Fact]
    public void AgentMessageSerializationRoundtripWorks()
    {
        BetaManagedAgentsStartEventPreview value = new BetaManagedAgentsAgentMessagePreview("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStartEventPreview>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentThinkingSerializationRoundtripWorks()
    {
        BetaManagedAgentsStartEventPreview value = new BetaManagedAgentsAgentThinkingPreview("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStartEventPreview>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentMessageTypeWorks()
    {
        BetaManagedAgentsStartEventPreview value = new BetaManagedAgentsAgentMessagePreview("id");
        Assert.Equal(BetaManagedAgentsStartEventPreviewType.AgentMessage, value.Type.Value());
    }

    [Fact]
    public void AgentThinkingTypeWorks()
    {
        BetaManagedAgentsStartEventPreview value = new BetaManagedAgentsAgentThinkingPreview("id");
        Assert.Equal(BetaManagedAgentsStartEventPreviewType.AgentThinking, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsStartEventPreview value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "id",
                  "type": "agent.message"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "id";
        ApiEnum<string, BetaManagedAgentsStartEventPreviewType> expectedType =
            BetaManagedAgentsStartEventPreviewType.AgentMessage;

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsStartEventPreview emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaManagedAgentsStartEventPreview mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.ID);
    }
}

public class BetaManagedAgentsStartEventPreviewTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsStartEventPreviewType.AgentMessage)]
    [InlineData(BetaManagedAgentsStartEventPreviewType.AgentThinking)]
    public void Validation_Works(BetaManagedAgentsStartEventPreviewType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsStartEventPreviewType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStartEventPreviewType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsStartEventPreviewType.AgentMessage)]
    [InlineData(BetaManagedAgentsStartEventPreviewType.AgentThinking)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsStartEventPreviewType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsStartEventPreviewType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStartEventPreviewType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStartEventPreviewType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStartEventPreviewType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
