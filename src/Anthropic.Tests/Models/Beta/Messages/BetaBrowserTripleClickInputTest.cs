using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserTripleClickInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserTripleClickInput
        {
            Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
            Modifiers = "modifiers",
            TabID = "tab_id",
        };

        BetaBrowserClickTarget expectedTarget = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 };
        string expectedModifiers = "modifiers";
        string expectedTabID = "tab_id";

        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedModifiers, model.Modifiers);
        Assert.Equal(expectedTabID, model.TabID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserTripleClickInput
        {
            Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
            Modifiers = "modifiers",
            TabID = "tab_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserTripleClickInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserTripleClickInput
        {
            Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
            Modifiers = "modifiers",
            TabID = "tab_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserTripleClickInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaBrowserClickTarget expectedTarget = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 };
        string expectedModifiers = "modifiers";
        string expectedTabID = "tab_id";

        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedModifiers, deserialized.Modifiers);
        Assert.Equal(expectedTabID, deserialized.TabID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserTripleClickInput
        {
            Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
            Modifiers = "modifiers",
            TabID = "tab_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserTripleClickInput
        {
            Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
        };

        Assert.Null(model.Modifiers);
        Assert.False(model.RawData.ContainsKey("modifiers"));
        Assert.Null(model.TabID);
        Assert.False(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserTripleClickInput
        {
            Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserTripleClickInput
        {
            Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },

            Modifiers = null,
            TabID = null,
        };

        Assert.Null(model.Modifiers);
        Assert.True(model.RawData.ContainsKey("modifiers"));
        Assert.Null(model.TabID);
        Assert.True(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserTripleClickInput
        {
            Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },

            Modifiers = null,
            TabID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserTripleClickInput
        {
            Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
            Modifiers = "modifiers",
            TabID = "tab_id",
        };

        BetaBrowserTripleClickInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
