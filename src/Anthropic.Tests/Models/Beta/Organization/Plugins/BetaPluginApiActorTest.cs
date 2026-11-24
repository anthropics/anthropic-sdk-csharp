using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class BetaPluginApiActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginApiActor { ApiKeyID = "apikey_01BcDeFgHjKmNpQrStUvWxYz" };

        string expectedApiKeyID = "apikey_01BcDeFgHjKmNpQrStUvWxYz";
        JsonElement expectedType = JsonSerializer.SerializeToElement("api_actor");

        Assert.Equal(expectedApiKeyID, model.ApiKeyID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginApiActor { ApiKeyID = "apikey_01BcDeFgHjKmNpQrStUvWxYz" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginApiActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginApiActor { ApiKeyID = "apikey_01BcDeFgHjKmNpQrStUvWxYz" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginApiActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedApiKeyID = "apikey_01BcDeFgHjKmNpQrStUvWxYz";
        JsonElement expectedType = JsonSerializer.SerializeToElement("api_actor");

        Assert.Equal(expectedApiKeyID, deserialized.ApiKeyID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginApiActor { ApiKeyID = "apikey_01BcDeFgHjKmNpQrStUvWxYz" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginApiActor { ApiKeyID = "apikey_01BcDeFgHjKmNpQrStUvWxYz" };

        BetaPluginApiActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
