using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaSignatureDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSignatureDelta { Signature = "signature" };

        string expectedSignature = "signature";
        JsonElement expectedType = JsonSerializer.SerializeToElement("signature_delta");

        Assert.Equal(expectedSignature, model.Signature);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSignatureDelta { Signature = "signature" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSignatureDelta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSignatureDelta { Signature = "signature" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSignatureDelta>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSignature = "signature";
        JsonElement expectedType = JsonSerializer.SerializeToElement("signature_delta");

        Assert.Equal(expectedSignature, deserialized.Signature);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSignatureDelta { Signature = "signature" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSignatureDelta { Signature = "signature" };

        BetaSignatureDelta copied = new(model);

        Assert.Equal(model, copied);
    }
}
