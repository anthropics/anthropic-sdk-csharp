using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class BetaComplianceReviewEnforcementActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceReviewEnforcementAction { Type = "type" };

        string expectedType = "type";

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceReviewEnforcementAction { Type = "type" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewEnforcementAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComplianceReviewEnforcementAction { Type = "type" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewEnforcementAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedType = "type";

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceReviewEnforcementAction { Type = "type" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceReviewEnforcementAction { Type = "type" };

        BetaComplianceReviewEnforcementAction copied = new(model);

        Assert.Equal(model, copied);
    }
}
