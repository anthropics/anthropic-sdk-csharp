using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Tests.Models.Beta.Environments;

public class BetaSelfHostedConfigParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSelfHostedConfigParams { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("self_hosted");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSelfHostedConfigParams { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedConfigParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSelfHostedConfigParams { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedConfigParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("self_hosted");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSelfHostedConfigParams { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSelfHostedConfigParams { };

        BetaSelfHostedConfigParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
