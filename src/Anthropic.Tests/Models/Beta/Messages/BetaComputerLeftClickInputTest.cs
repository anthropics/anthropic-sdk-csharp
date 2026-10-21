using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaComputerLeftClickInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComputerLeftClickInput { Coordinate = [0, 0], Text = "text" };

        List<long> expectedCoordinate = [0, 0];
        string expectedText = "text";

        Assert.NotNull(model.Coordinate);
        Assert.Equal(expectedCoordinate.Count, model.Coordinate.Count);
        for (int i = 0; i < expectedCoordinate.Count; i++)
        {
            Assert.Equal(expectedCoordinate[i], model.Coordinate[i]);
        }
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComputerLeftClickInput { Coordinate = [0, 0], Text = "text" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerLeftClickInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComputerLeftClickInput { Coordinate = [0, 0], Text = "text" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerLeftClickInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<long> expectedCoordinate = [0, 0];
        string expectedText = "text";

        Assert.NotNull(deserialized.Coordinate);
        Assert.Equal(expectedCoordinate.Count, deserialized.Coordinate.Count);
        for (int i = 0; i < expectedCoordinate.Count; i++)
        {
            Assert.Equal(expectedCoordinate[i], deserialized.Coordinate[i]);
        }
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComputerLeftClickInput { Coordinate = [0, 0], Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaComputerLeftClickInput { };

        Assert.Null(model.Coordinate);
        Assert.False(model.RawData.ContainsKey("coordinate"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaComputerLeftClickInput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaComputerLeftClickInput { Coordinate = null, Text = null };

        Assert.Null(model.Coordinate);
        Assert.True(model.RawData.ContainsKey("coordinate"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaComputerLeftClickInput { Coordinate = null, Text = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComputerLeftClickInput { Coordinate = [0, 0], Text = "text" };

        BetaComputerLeftClickInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
