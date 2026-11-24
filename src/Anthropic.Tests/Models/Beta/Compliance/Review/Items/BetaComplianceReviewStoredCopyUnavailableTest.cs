using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Items;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Items;

public class BetaComplianceReviewStoredCopyUnavailableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceReviewStoredCopyUnavailable { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("stored_copy_unavailable");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceReviewStoredCopyUnavailable { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewStoredCopyUnavailable>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComplianceReviewStoredCopyUnavailable { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewStoredCopyUnavailable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("stored_copy_unavailable");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceReviewStoredCopyUnavailable { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceReviewStoredCopyUnavailable { };

        BetaComplianceReviewStoredCopyUnavailable copied = new(model);

        Assert.Equal(model, copied);
    }
}
