using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserClickTargetTest : TestBase
{
    [Fact]
    public void CoordinateValidationWorks()
    {
        BetaBrowserClickTarget value = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 };
        value.Validate();
    }

    [Fact]
    public void RefValidationWorks()
    {
        BetaBrowserClickTarget value = new BetaBrowserRefTarget("ref");
        value.Validate();
    }

    [Fact]
    public void CoordinateSerializationRoundtripWorks()
    {
        BetaBrowserClickTarget value = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserClickTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefSerializationRoundtripWorks()
    {
        BetaBrowserClickTarget value = new BetaBrowserRefTarget("ref");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserClickTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaBrowserClickTarget value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "coordinate"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("coordinate");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaBrowserClickTarget emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
