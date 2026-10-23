using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsApiActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsApiActor { ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT" };

        string expectedApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT";
        JsonElement expectedType = JsonSerializer.SerializeToElement("api_actor");

        Assert.Equal(expectedApiKeyID, model.ApiKeyID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsApiActor { ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsApiActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsApiActor { ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsApiActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT";
        JsonElement expectedType = JsonSerializer.SerializeToElement("api_actor");

        Assert.Equal(expectedApiKeyID, deserialized.ApiKeyID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsApiActor { ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsApiActor { ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT" };

        BetaAnalyticsApiActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
