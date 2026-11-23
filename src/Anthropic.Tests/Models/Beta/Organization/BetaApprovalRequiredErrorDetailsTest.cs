using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization;

namespace Anthropic.Tests.Models.Beta.Organization;

public class BetaApprovalRequiredErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaApprovalRequiredErrorDetails
        {
            Field = "inference_data_privacy.human_review",
        };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("approval_required");
        string expectedField = "inference_data_privacy.human_review";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaApprovalRequiredErrorDetails
        {
            Field = "inference_data_privacy.human_review",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaApprovalRequiredErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaApprovalRequiredErrorDetails
        {
            Field = "inference_data_privacy.human_review",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaApprovalRequiredErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("approval_required");
        string expectedField = "inference_data_privacy.human_review";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaApprovalRequiredErrorDetails
        {
            Field = "inference_data_privacy.human_review",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaApprovalRequiredErrorDetails
        {
            Field = "inference_data_privacy.human_review",
        };

        BetaApprovalRequiredErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
