using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserNewTabInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserNewTabInput { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserNewTabInput { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserNewTabInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserNewTabInput { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserNewTabInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserNewTabInput { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserNewTabInput { };

        BetaBrowserNewTabInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
