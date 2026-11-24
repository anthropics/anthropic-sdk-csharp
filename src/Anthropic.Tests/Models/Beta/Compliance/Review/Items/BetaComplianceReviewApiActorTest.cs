using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Items;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Items;

public class BetaComplianceReviewApiActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceReviewApiActor { ApiKeyID = "api_key_id" };

        string expectedApiKeyID = "api_key_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("api_actor");

        Assert.Equal(expectedApiKeyID, model.ApiKeyID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceReviewApiActor { ApiKeyID = "api_key_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewApiActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComplianceReviewApiActor { ApiKeyID = "api_key_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewApiActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedApiKeyID = "api_key_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("api_actor");

        Assert.Equal(expectedApiKeyID, deserialized.ApiKeyID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceReviewApiActor { ApiKeyID = "api_key_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceReviewApiActor { ApiKeyID = "api_key_id" };

        BetaComplianceReviewApiActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
