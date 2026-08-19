using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaComputerScreenshotConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComputerScreenshotConfig { DeferLoading = true, Enabled = true };

        bool expectedDeferLoading = true;
        bool expectedEnabled = true;

        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedEnabled, model.Enabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComputerScreenshotConfig { DeferLoading = true, Enabled = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerScreenshotConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComputerScreenshotConfig { DeferLoading = true, Enabled = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerScreenshotConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedDeferLoading = true;
        bool expectedEnabled = true;

        Assert.Equal(expectedDeferLoading, deserialized.DeferLoading);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComputerScreenshotConfig { DeferLoading = true, Enabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaComputerScreenshotConfig { };

        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaComputerScreenshotConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaComputerScreenshotConfig { DeferLoading = null, Enabled = null };

        Assert.Null(model.DeferLoading);
        Assert.True(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Enabled);
        Assert.True(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaComputerScreenshotConfig { DeferLoading = null, Enabled = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComputerScreenshotConfig { DeferLoading = true, Enabled = true };

        BetaComputerScreenshotConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
