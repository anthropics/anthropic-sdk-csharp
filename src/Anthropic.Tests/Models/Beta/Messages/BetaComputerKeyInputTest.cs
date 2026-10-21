using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaComputerKeyInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComputerKeyInput { Text = "text", Repeat = 1 };

        string expectedText = "text";
        long expectedRepeat = 1;

        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedRepeat, model.Repeat);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComputerKeyInput { Text = "text", Repeat = 1 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerKeyInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComputerKeyInput { Text = "text", Repeat = 1 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerKeyInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        long expectedRepeat = 1;

        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedRepeat, deserialized.Repeat);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComputerKeyInput { Text = "text", Repeat = 1 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaComputerKeyInput { Text = "text" };

        Assert.Null(model.Repeat);
        Assert.False(model.RawData.ContainsKey("repeat"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaComputerKeyInput { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaComputerKeyInput
        {
            Text = "text",

            Repeat = null,
        };

        Assert.Null(model.Repeat);
        Assert.True(model.RawData.ContainsKey("repeat"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaComputerKeyInput
        {
            Text = "text",

            Repeat = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComputerKeyInput { Text = "text", Repeat = 1 };

        BetaComputerKeyInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
