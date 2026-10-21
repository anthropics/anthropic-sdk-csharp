using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ComputerLeftMouseDownInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComputerLeftMouseDownInput { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComputerLeftMouseDownInput { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerLeftMouseDownInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComputerLeftMouseDownInput { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerLeftMouseDownInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComputerLeftMouseDownInput { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComputerLeftMouseDownInput { };

        ComputerLeftMouseDownInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
