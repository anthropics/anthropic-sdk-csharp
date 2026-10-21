using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ComputerZoomInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComputerZoomInput { Region = [0, 0, 0, 0] };

        List<long> expectedRegion = [0, 0, 0, 0];

        Assert.Equal(expectedRegion.Count, model.Region.Count);
        for (int i = 0; i < expectedRegion.Count; i++)
        {
            Assert.Equal(expectedRegion[i], model.Region[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComputerZoomInput { Region = [0, 0, 0, 0] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerZoomInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComputerZoomInput { Region = [0, 0, 0, 0] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerZoomInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<long> expectedRegion = [0, 0, 0, 0];

        Assert.Equal(expectedRegion.Count, deserialized.Region.Count);
        for (int i = 0; i < expectedRegion.Count; i++)
        {
            Assert.Equal(expectedRegion[i], deserialized.Region[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComputerZoomInput { Region = [0, 0, 0, 0] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComputerZoomInput { Region = [0, 0, 0, 0] };

        ComputerZoomInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
