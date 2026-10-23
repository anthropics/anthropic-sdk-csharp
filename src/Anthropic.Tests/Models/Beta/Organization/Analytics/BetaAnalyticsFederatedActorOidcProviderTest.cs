using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsFederatedActorOidcProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsFederatedActorOidcProvider { Issuer = "issuer" };

        string expectedIssuer = "issuer";
        JsonElement expectedType = JsonSerializer.SerializeToElement("oidc");

        Assert.Equal(expectedIssuer, model.Issuer);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsFederatedActorOidcProvider { Issuer = "issuer" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorOidcProvider>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsFederatedActorOidcProvider { Issuer = "issuer" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorOidcProvider>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedIssuer = "issuer";
        JsonElement expectedType = JsonSerializer.SerializeToElement("oidc");

        Assert.Equal(expectedIssuer, deserialized.Issuer);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsFederatedActorOidcProvider { Issuer = "issuer" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsFederatedActorOidcProvider { Issuer = "issuer" };

        BetaAnalyticsFederatedActorOidcProvider copied = new(model);

        Assert.Equal(model, copied);
    }
}
