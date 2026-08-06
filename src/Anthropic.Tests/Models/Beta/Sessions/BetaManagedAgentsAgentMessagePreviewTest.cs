using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsAgentMessagePreviewTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentMessagePreview
        {
            ID = "id",
            Type = BetaManagedAgentsAgentMessagePreviewType.AgentMessage,
        };

        string expectedID = "id";
        ApiEnum<string, BetaManagedAgentsAgentMessagePreviewType> expectedType =
            BetaManagedAgentsAgentMessagePreviewType.AgentMessage;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentMessagePreview
        {
            ID = "id",
            Type = BetaManagedAgentsAgentMessagePreviewType.AgentMessage,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentMessagePreview>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentMessagePreview
        {
            ID = "id",
            Type = BetaManagedAgentsAgentMessagePreviewType.AgentMessage,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentMessagePreview>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, BetaManagedAgentsAgentMessagePreviewType> expectedType =
            BetaManagedAgentsAgentMessagePreviewType.AgentMessage;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentMessagePreview
        {
            ID = "id",
            Type = BetaManagedAgentsAgentMessagePreviewType.AgentMessage,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentMessagePreview
        {
            ID = "id",
            Type = BetaManagedAgentsAgentMessagePreviewType.AgentMessage,
        };

        BetaManagedAgentsAgentMessagePreview copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentMessagePreviewTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentMessagePreviewType.AgentMessage)]
    public void Validation_Works(BetaManagedAgentsAgentMessagePreviewType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentMessagePreviewType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessagePreviewType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentMessagePreviewType.AgentMessage)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentMessagePreviewType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentMessagePreviewType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessagePreviewType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessagePreviewType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessagePreviewType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
