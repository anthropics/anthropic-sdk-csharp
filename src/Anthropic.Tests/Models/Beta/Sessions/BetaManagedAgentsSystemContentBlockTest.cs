using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSystemContentBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSystemContentBlock
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsSystemContentBlockType.Text,
        };

        string expectedText = "Where is my order #1234?";
        ApiEnum<string, BetaManagedAgentsSystemContentBlockType> expectedType =
            BetaManagedAgentsSystemContentBlockType.Text;

        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSystemContentBlock
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsSystemContentBlockType.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSystemContentBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSystemContentBlock
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsSystemContentBlockType.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSystemContentBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "Where is my order #1234?";
        ApiEnum<string, BetaManagedAgentsSystemContentBlockType> expectedType =
            BetaManagedAgentsSystemContentBlockType.Text;

        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSystemContentBlock
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsSystemContentBlockType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSystemContentBlock
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsSystemContentBlockType.Text,
        };

        BetaManagedAgentsSystemContentBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSystemContentBlockTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSystemContentBlockType.Text)]
    public void Validation_Works(BetaManagedAgentsSystemContentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSystemContentBlockType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemContentBlockType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSystemContentBlockType.Text)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSystemContentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSystemContentBlockType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemContentBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemContentBlockType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemContentBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
