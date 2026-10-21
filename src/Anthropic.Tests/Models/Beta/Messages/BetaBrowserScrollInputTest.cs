using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserScrollInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserScrollInput
        {
            ScrollDirection = BetaBrowserScrollDirection.Up,
            Target = new() { X = 0, Y = 0 },
            ScrollAmount = 1,
            TabID = "tab_id",
        };

        ApiEnum<string, BetaBrowserScrollDirection> expectedScrollDirection =
            BetaBrowserScrollDirection.Up;
        BetaBrowserCoordinateTarget expectedTarget = new() { X = 0, Y = 0 };
        long expectedScrollAmount = 1;
        string expectedTabID = "tab_id";

        Assert.Equal(expectedScrollDirection, model.ScrollDirection);
        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedScrollAmount, model.ScrollAmount);
        Assert.Equal(expectedTabID, model.TabID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserScrollInput
        {
            ScrollDirection = BetaBrowserScrollDirection.Up,
            Target = new() { X = 0, Y = 0 },
            ScrollAmount = 1,
            TabID = "tab_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserScrollInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserScrollInput
        {
            ScrollDirection = BetaBrowserScrollDirection.Up,
            Target = new() { X = 0, Y = 0 },
            ScrollAmount = 1,
            TabID = "tab_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserScrollInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaBrowserScrollDirection> expectedScrollDirection =
            BetaBrowserScrollDirection.Up;
        BetaBrowserCoordinateTarget expectedTarget = new() { X = 0, Y = 0 };
        long expectedScrollAmount = 1;
        string expectedTabID = "tab_id";

        Assert.Equal(expectedScrollDirection, deserialized.ScrollDirection);
        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedScrollAmount, deserialized.ScrollAmount);
        Assert.Equal(expectedTabID, deserialized.TabID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserScrollInput
        {
            ScrollDirection = BetaBrowserScrollDirection.Up,
            Target = new() { X = 0, Y = 0 },
            ScrollAmount = 1,
            TabID = "tab_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserScrollInput
        {
            ScrollDirection = BetaBrowserScrollDirection.Up,
            Target = new() { X = 0, Y = 0 },
        };

        Assert.Null(model.ScrollAmount);
        Assert.False(model.RawData.ContainsKey("scroll_amount"));
        Assert.Null(model.TabID);
        Assert.False(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserScrollInput
        {
            ScrollDirection = BetaBrowserScrollDirection.Up,
            Target = new() { X = 0, Y = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserScrollInput
        {
            ScrollDirection = BetaBrowserScrollDirection.Up,
            Target = new() { X = 0, Y = 0 },

            ScrollAmount = null,
            TabID = null,
        };

        Assert.Null(model.ScrollAmount);
        Assert.True(model.RawData.ContainsKey("scroll_amount"));
        Assert.Null(model.TabID);
        Assert.True(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserScrollInput
        {
            ScrollDirection = BetaBrowserScrollDirection.Up,
            Target = new() { X = 0, Y = 0 },

            ScrollAmount = null,
            TabID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserScrollInput
        {
            ScrollDirection = BetaBrowserScrollDirection.Up,
            Target = new() { X = 0, Y = 0 },
            ScrollAmount = 1,
            TabID = "tab_id",
        };

        BetaBrowserScrollInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
