using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsFederatedActorAzureProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsFederatedActorAzureProvider
        {
            SubscriptionID = "subscription_id",
        };

        string expectedSubscriptionID = "subscription_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("azure");

        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsFederatedActorAzureProvider
        {
            SubscriptionID = "subscription_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorAzureProvider>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsFederatedActorAzureProvider
        {
            SubscriptionID = "subscription_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorAzureProvider>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSubscriptionID = "subscription_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("azure");

        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsFederatedActorAzureProvider
        {
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsFederatedActorAzureProvider
        {
            SubscriptionID = "subscription_id",
        };

        BetaAnalyticsFederatedActorAzureProvider copied = new(model);

        Assert.Equal(model, copied);
    }
}
