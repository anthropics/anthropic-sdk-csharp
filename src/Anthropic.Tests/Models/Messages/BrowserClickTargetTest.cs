using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserClickTargetTest : TestBase
{
    [Fact]
    public void CoordinateValidationWorks()
    {
        BrowserClickTarget value = new BrowserCoordinateTarget() { X = 0, Y = 0 };
        value.Validate();
    }

    [Fact]
    public void RefValidationWorks()
    {
        BrowserClickTarget value = new BrowserRefTarget("ref");
        value.Validate();
    }

    [Fact]
    public void CoordinateSerializationRoundtripWorks()
    {
        BrowserClickTarget value = new BrowserCoordinateTarget() { X = 0, Y = 0 };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserClickTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefSerializationRoundtripWorks()
    {
        BrowserClickTarget value = new BrowserRefTarget("ref");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserClickTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BrowserClickTarget value = new(
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

        BrowserClickTarget emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
