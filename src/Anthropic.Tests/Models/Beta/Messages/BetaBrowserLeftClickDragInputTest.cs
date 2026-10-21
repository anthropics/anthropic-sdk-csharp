using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserLeftClickDragInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserLeftClickDragInput
        {
            From = new() { X = 0, Y = 0 },
            Target = new() { X = 0, Y = 0 },
            TabID = "tab_id",
        };

        BetaBrowserCoordinateTarget expectedFrom = new() { X = 0, Y = 0 };
        BetaBrowserCoordinateTarget expectedTarget = new() { X = 0, Y = 0 };
        string expectedTabID = "tab_id";

        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedTabID, model.TabID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserLeftClickDragInput
        {
            From = new() { X = 0, Y = 0 },
            Target = new() { X = 0, Y = 0 },
            TabID = "tab_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserLeftClickDragInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserLeftClickDragInput
        {
            From = new() { X = 0, Y = 0 },
            Target = new() { X = 0, Y = 0 },
            TabID = "tab_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserLeftClickDragInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaBrowserCoordinateTarget expectedFrom = new() { X = 0, Y = 0 };
        BetaBrowserCoordinateTarget expectedTarget = new() { X = 0, Y = 0 };
        string expectedTabID = "tab_id";

        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedTabID, deserialized.TabID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserLeftClickDragInput
        {
            From = new() { X = 0, Y = 0 },
            Target = new() { X = 0, Y = 0 },
            TabID = "tab_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserLeftClickDragInput
        {
            From = new() { X = 0, Y = 0 },
            Target = new() { X = 0, Y = 0 },
        };

        Assert.Null(model.TabID);
        Assert.False(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserLeftClickDragInput
        {
            From = new() { X = 0, Y = 0 },
            Target = new() { X = 0, Y = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserLeftClickDragInput
        {
            From = new() { X = 0, Y = 0 },
            Target = new() { X = 0, Y = 0 },

            TabID = null,
        };

        Assert.Null(model.TabID);
        Assert.True(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserLeftClickDragInput
        {
            From = new() { X = 0, Y = 0 },
            Target = new() { X = 0, Y = 0 },

            TabID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserLeftClickDragInput
        {
            From = new() { X = 0, Y = 0 },
            Target = new() { X = 0, Y = 0 },
            TabID = "tab_id",
        };

        BetaBrowserLeftClickDragInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
