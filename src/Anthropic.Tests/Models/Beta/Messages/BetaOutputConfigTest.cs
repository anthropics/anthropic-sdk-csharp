using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOutputConfig { Effort = Effort.Low };

        ApiEnum<string, Effort> expectedEffort = Effort.Low;

        Assert.Equal(expectedEffort, model.Effort);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOutputConfig { Effort = Effort.Low };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaOutputConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOutputConfig { Effort = Effort.Low };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaOutputConfig>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Effort> expectedEffort = Effort.Low;

        Assert.Equal(expectedEffort, deserialized.Effort);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOutputConfig { Effort = Effort.Low };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaOutputConfig { };

        Assert.Null(model.Effort);
        Assert.False(model.RawData.ContainsKey("effort"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaOutputConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaOutputConfig { Effort = null };

        Assert.Null(model.Effort);
        Assert.True(model.RawData.ContainsKey("effort"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaOutputConfig { Effort = null };

        model.Validate();
    }
}
