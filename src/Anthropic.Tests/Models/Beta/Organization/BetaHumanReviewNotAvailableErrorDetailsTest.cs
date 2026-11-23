using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization;

namespace Anthropic.Tests.Models.Beta.Organization;

public class BetaHumanReviewNotAvailableErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaHumanReviewNotAvailableErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "human_review_not_available"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaHumanReviewNotAvailableErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaHumanReviewNotAvailableErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaHumanReviewNotAvailableErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaHumanReviewNotAvailableErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "human_review_not_available"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaHumanReviewNotAvailableErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaHumanReviewNotAvailableErrorDetails { };

        BetaHumanReviewNotAvailableErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
