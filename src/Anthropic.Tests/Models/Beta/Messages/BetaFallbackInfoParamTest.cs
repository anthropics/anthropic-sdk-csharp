using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaFallbackInfoParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFallbackInfoParam { Model = Model.ClaudeSonnet5 };

        ApiEnum<string, Model> expectedModel = Model.ClaudeSonnet5;

        Assert.Equal(expectedModel, model.Model);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFallbackInfoParam { Model = Model.ClaudeSonnet5 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackInfoParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFallbackInfoParam { Model = Model.ClaudeSonnet5 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackInfoParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Model> expectedModel = Model.ClaudeSonnet5;

        Assert.Equal(expectedModel, deserialized.Model);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFallbackInfoParam { Model = Model.ClaudeSonnet5 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFallbackInfoParam { Model = Model.ClaudeSonnet5 };

        BetaFallbackInfoParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
