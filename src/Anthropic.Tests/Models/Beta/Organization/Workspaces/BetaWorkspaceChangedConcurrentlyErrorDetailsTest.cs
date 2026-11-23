using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaWorkspaceChangedConcurrentlyErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWorkspaceChangedConcurrentlyErrorDetails
        {
            Field = BetaWorkspaceChangedConcurrentlyField.InferenceDataPrivacyHumanReview,
        };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "workspace_changed_concurrently"
        );
        ApiEnum<string, BetaWorkspaceChangedConcurrentlyField> expectedField =
            BetaWorkspaceChangedConcurrentlyField.InferenceDataPrivacyHumanReview;

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWorkspaceChangedConcurrentlyErrorDetails
        {
            Field = BetaWorkspaceChangedConcurrentlyField.InferenceDataPrivacyHumanReview,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspaceChangedConcurrentlyErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWorkspaceChangedConcurrentlyErrorDetails
        {
            Field = BetaWorkspaceChangedConcurrentlyField.InferenceDataPrivacyHumanReview,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspaceChangedConcurrentlyErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "workspace_changed_concurrently"
        );
        ApiEnum<string, BetaWorkspaceChangedConcurrentlyField> expectedField =
            BetaWorkspaceChangedConcurrentlyField.InferenceDataPrivacyHumanReview;

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWorkspaceChangedConcurrentlyErrorDetails
        {
            Field = BetaWorkspaceChangedConcurrentlyField.InferenceDataPrivacyHumanReview,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWorkspaceChangedConcurrentlyErrorDetails
        {
            Field = BetaWorkspaceChangedConcurrentlyField.InferenceDataPrivacyHumanReview,
        };

        BetaWorkspaceChangedConcurrentlyErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
