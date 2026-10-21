using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ComputerMouseMoveInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComputerMouseMoveInput { Coordinate = [0, 0] };

        List<long> expectedCoordinate = [0, 0];

        Assert.Equal(expectedCoordinate.Count, model.Coordinate.Count);
        for (int i = 0; i < expectedCoordinate.Count; i++)
        {
            Assert.Equal(expectedCoordinate[i], model.Coordinate[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComputerMouseMoveInput { Coordinate = [0, 0] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerMouseMoveInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComputerMouseMoveInput { Coordinate = [0, 0] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerMouseMoveInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<long> expectedCoordinate = [0, 0];

        Assert.Equal(expectedCoordinate.Count, deserialized.Coordinate.Count);
        for (int i = 0; i < expectedCoordinate.Count; i++)
        {
            Assert.Equal(expectedCoordinate[i], deserialized.Coordinate[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComputerMouseMoveInput { Coordinate = [0, 0] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComputerMouseMoveInput { Coordinate = [0, 0] };

        ComputerMouseMoveInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
