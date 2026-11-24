using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Items;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Items;

public class BetaComplianceReviewServiceAccountActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceReviewServiceAccountActor
        {
            ServiceAccountID = "service_account_id",
        };

        string expectedServiceAccountID = "service_account_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("service_account_actor");

        Assert.Equal(expectedServiceAccountID, model.ServiceAccountID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceReviewServiceAccountActor
        {
            ServiceAccountID = "service_account_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewServiceAccountActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComplianceReviewServiceAccountActor
        {
            ServiceAccountID = "service_account_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewServiceAccountActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedServiceAccountID = "service_account_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("service_account_actor");

        Assert.Equal(expectedServiceAccountID, deserialized.ServiceAccountID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceReviewServiceAccountActor
        {
            ServiceAccountID = "service_account_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceReviewServiceAccountActor
        {
            ServiceAccountID = "service_account_id",
        };

        BetaComplianceReviewServiceAccountActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
