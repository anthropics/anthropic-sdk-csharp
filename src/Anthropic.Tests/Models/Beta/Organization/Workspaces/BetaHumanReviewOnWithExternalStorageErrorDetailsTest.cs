using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaHumanReviewOnWithExternalStorageErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaHumanReviewOnWithExternalStorageErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "human_review_on_with_external_storage"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaHumanReviewOnWithExternalStorageErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaHumanReviewOnWithExternalStorageErrorDetails>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaHumanReviewOnWithExternalStorageErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaHumanReviewOnWithExternalStorageErrorDetails>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "human_review_on_with_external_storage"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaHumanReviewOnWithExternalStorageErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaHumanReviewOnWithExternalStorageErrorDetails { };

        BetaHumanReviewOnWithExternalStorageErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
