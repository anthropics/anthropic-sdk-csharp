using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsAgentThinkingPreviewTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentThinkingPreview
        {
            ID = "id",
            Type = BetaManagedAgentsAgentThinkingPreviewType.AgentThinking,
        };

        string expectedID = "id";
        ApiEnum<string, BetaManagedAgentsAgentThinkingPreviewType> expectedType =
            BetaManagedAgentsAgentThinkingPreviewType.AgentThinking;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentThinkingPreview
        {
            ID = "id",
            Type = BetaManagedAgentsAgentThinkingPreviewType.AgentThinking,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentThinkingPreview>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentThinkingPreview
        {
            ID = "id",
            Type = BetaManagedAgentsAgentThinkingPreviewType.AgentThinking,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentThinkingPreview>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, BetaManagedAgentsAgentThinkingPreviewType> expectedType =
            BetaManagedAgentsAgentThinkingPreviewType.AgentThinking;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentThinkingPreview
        {
            ID = "id",
            Type = BetaManagedAgentsAgentThinkingPreviewType.AgentThinking,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentThinkingPreview
        {
            ID = "id",
            Type = BetaManagedAgentsAgentThinkingPreviewType.AgentThinking,
        };

        BetaManagedAgentsAgentThinkingPreview copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentThinkingPreviewTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentThinkingPreviewType.AgentThinking)]
    public void Validation_Works(BetaManagedAgentsAgentThinkingPreviewType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentThinkingPreviewType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThinkingPreviewType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentThinkingPreviewType.AgentThinking)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentThinkingPreviewType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentThinkingPreviewType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThinkingPreviewType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThinkingPreviewType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThinkingPreviewType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
