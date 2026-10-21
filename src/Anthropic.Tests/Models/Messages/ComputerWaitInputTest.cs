using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ComputerWaitInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComputerWaitInput { Duration = 300 };

        long expectedDuration = 300;

        Assert.Equal(expectedDuration, model.Duration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComputerWaitInput { Duration = 300 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerWaitInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComputerWaitInput { Duration = 300 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerWaitInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDuration = 300;

        Assert.Equal(expectedDuration, deserialized.Duration);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComputerWaitInput { Duration = 300 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComputerWaitInput { Duration = 300 };

        ComputerWaitInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
