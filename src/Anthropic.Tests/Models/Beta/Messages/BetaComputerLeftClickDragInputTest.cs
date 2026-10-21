using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaComputerLeftClickDragInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComputerLeftClickDragInput
        {
            Coordinate = [0, 0],
            StartCoordinate = [0, 0],
            Text = "text",
        };

        List<long> expectedCoordinate = [0, 0];
        List<long> expectedStartCoordinate = [0, 0];
        string expectedText = "text";

        Assert.Equal(expectedCoordinate.Count, model.Coordinate.Count);
        for (int i = 0; i < expectedCoordinate.Count; i++)
        {
            Assert.Equal(expectedCoordinate[i], model.Coordinate[i]);
        }
        Assert.Equal(expectedStartCoordinate.Count, model.StartCoordinate.Count);
        for (int i = 0; i < expectedStartCoordinate.Count; i++)
        {
            Assert.Equal(expectedStartCoordinate[i], model.StartCoordinate[i]);
        }
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComputerLeftClickDragInput
        {
            Coordinate = [0, 0],
            StartCoordinate = [0, 0],
            Text = "text",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerLeftClickDragInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComputerLeftClickDragInput
        {
            Coordinate = [0, 0],
            StartCoordinate = [0, 0],
            Text = "text",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerLeftClickDragInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<long> expectedCoordinate = [0, 0];
        List<long> expectedStartCoordinate = [0, 0];
        string expectedText = "text";

        Assert.Equal(expectedCoordinate.Count, deserialized.Coordinate.Count);
        for (int i = 0; i < expectedCoordinate.Count; i++)
        {
            Assert.Equal(expectedCoordinate[i], deserialized.Coordinate[i]);
        }
        Assert.Equal(expectedStartCoordinate.Count, deserialized.StartCoordinate.Count);
        for (int i = 0; i < expectedStartCoordinate.Count; i++)
        {
            Assert.Equal(expectedStartCoordinate[i], deserialized.StartCoordinate[i]);
        }
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComputerLeftClickDragInput
        {
            Coordinate = [0, 0],
            StartCoordinate = [0, 0],
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaComputerLeftClickDragInput
        {
            Coordinate = [0, 0],
            StartCoordinate = [0, 0],
        };

        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaComputerLeftClickDragInput
        {
            Coordinate = [0, 0],
            StartCoordinate = [0, 0],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaComputerLeftClickDragInput
        {
            Coordinate = [0, 0],
            StartCoordinate = [0, 0],

            Text = null,
        };

        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaComputerLeftClickDragInput
        {
            Coordinate = [0, 0],
            StartCoordinate = [0, 0],

            Text = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComputerLeftClickDragInput
        {
            Coordinate = [0, 0],
            StartCoordinate = [0, 0],
            Text = "text",
        };

        BetaComputerLeftClickDragInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
