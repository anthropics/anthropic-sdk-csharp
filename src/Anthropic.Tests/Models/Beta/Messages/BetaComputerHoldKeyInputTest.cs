using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaComputerHoldKeyInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComputerHoldKeyInput { Duration = 300, Text = "text" };

        long expectedDuration = 300;
        string expectedText = "text";

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComputerHoldKeyInput { Duration = 300, Text = "text" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerHoldKeyInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComputerHoldKeyInput { Duration = 300, Text = "text" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerHoldKeyInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDuration = 300;
        string expectedText = "text";

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComputerHoldKeyInput { Duration = 300, Text = "text" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComputerHoldKeyInput { Duration = 300, Text = "text" };

        BetaComputerHoldKeyInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
