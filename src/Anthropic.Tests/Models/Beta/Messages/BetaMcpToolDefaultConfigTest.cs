using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMcpToolDefaultConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMcpToolDefaultConfig { DeferLoading = true, Enabled = true };

        bool expectedDeferLoading = true;
        bool expectedEnabled = true;

        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedEnabled, model.Enabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMcpToolDefaultConfig { DeferLoading = true, Enabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolDefaultConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMcpToolDefaultConfig { DeferLoading = true, Enabled = true };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolDefaultConfig>(element);
        Assert.NotNull(deserialized);

        bool expectedDeferLoading = true;
        bool expectedEnabled = true;

        Assert.Equal(expectedDeferLoading, deserialized.DeferLoading);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMcpToolDefaultConfig { DeferLoading = true, Enabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaMcpToolDefaultConfig { };

        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaMcpToolDefaultConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaMcpToolDefaultConfig
        {
            // Null should be interpreted as omitted for these properties
            DeferLoading = null,
            Enabled = null,
        };

        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaMcpToolDefaultConfig
        {
            // Null should be interpreted as omitted for these properties
            DeferLoading = null,
            Enabled = null,
        };

        model.Validate();
    }
}
