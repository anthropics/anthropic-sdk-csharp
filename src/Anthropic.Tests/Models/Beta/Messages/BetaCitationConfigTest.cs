using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationConfig { Enabled = true };

        bool expectedEnabled = true;

        Assert.Equal(expectedEnabled, model.Enabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCitationConfig { Enabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCitationConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCitationConfig { Enabled = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCitationConfig>(json);
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;

        Assert.Equal(expectedEnabled, deserialized.Enabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCitationConfig { Enabled = true };

        model.Validate();
    }
}
