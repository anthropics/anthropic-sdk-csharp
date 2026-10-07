using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserCoordinateTargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserCoordinateTarget { X = 0, Y = 0 };

        JsonElement expectedType = JsonSerializer.SerializeToElement("coordinate");
        long expectedX = 0;
        long expectedY = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedX, model.X);
        Assert.Equal(expectedY, model.Y);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserCoordinateTarget { X = 0, Y = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserCoordinateTarget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserCoordinateTarget { X = 0, Y = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserCoordinateTarget>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("coordinate");
        long expectedX = 0;
        long expectedY = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedX, deserialized.X);
        Assert.Equal(expectedY, deserialized.Y);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserCoordinateTarget { X = 0, Y = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserCoordinateTarget { X = 0, Y = 0 };

        BetaBrowserCoordinateTarget copied = new(model);

        Assert.Equal(model, copied);
    }
}
