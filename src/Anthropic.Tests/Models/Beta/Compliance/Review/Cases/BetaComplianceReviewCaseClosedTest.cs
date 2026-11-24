using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class BetaComplianceReviewCaseClosedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceReviewCaseClosed { Reason = new(Type.Responded) };

        BetaComplianceReviewCaseCloseReason expectedReason = new(Type.Responded);
        JsonElement expectedType = JsonSerializer.SerializeToElement("closed");

        Assert.Equal(expectedReason, model.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceReviewCaseClosed { Reason = new(Type.Responded) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewCaseClosed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComplianceReviewCaseClosed { Reason = new(Type.Responded) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewCaseClosed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaComplianceReviewCaseCloseReason expectedReason = new(Type.Responded);
        JsonElement expectedType = JsonSerializer.SerializeToElement("closed");

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceReviewCaseClosed { Reason = new(Type.Responded) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceReviewCaseClosed { Reason = new(Type.Responded) };

        BetaComplianceReviewCaseClosed copied = new(model);

        Assert.Equal(model, copied);
    }
}
