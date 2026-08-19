using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserKeyConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserKeyConfig { DeferLoading = true, Enabled = true };

        bool expectedDeferLoading = true;
        bool expectedEnabled = true;

        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedEnabled, model.Enabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserKeyConfig { DeferLoading = true, Enabled = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserKeyConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserKeyConfig { DeferLoading = true, Enabled = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserKeyConfig>(
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
        var model = new BetaBrowserKeyConfig { DeferLoading = true, Enabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserKeyConfig { };

        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserKeyConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserKeyConfig { DeferLoading = null, Enabled = null };

        Assert.Null(model.DeferLoading);
        Assert.True(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Enabled);
        Assert.True(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserKeyConfig { DeferLoading = null, Enabled = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserKeyConfig { DeferLoading = true, Enabled = true };

        BetaBrowserKeyConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
