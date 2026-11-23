using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaInferenceDataPrivacyCreateParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaInferenceDataPrivacyCreateParam
        {
            HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
            SafeguardsStorage = new BetaInternalStorageParam(),
            TranscriptsStorage = new BetaInternalStorageParam(),
        };

        BetaAnthropicHumanReviewParam expectedHumanReview = new(
            BetaAnthropicHumanReviewParamType.Disabled
        );
        BetaStorageMemberParam expectedSafeguardsStorage = new BetaInternalStorageParam();
        BetaStorageMemberParam expectedTranscriptsStorage = new BetaInternalStorageParam();

        Assert.Equal(expectedHumanReview, model.HumanReview);
        Assert.Equal(expectedSafeguardsStorage, model.SafeguardsStorage);
        Assert.Equal(expectedTranscriptsStorage, model.TranscriptsStorage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaInferenceDataPrivacyCreateParam
        {
            HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
            SafeguardsStorage = new BetaInternalStorageParam(),
            TranscriptsStorage = new BetaInternalStorageParam(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaInferenceDataPrivacyCreateParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaInferenceDataPrivacyCreateParam
        {
            HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
            SafeguardsStorage = new BetaInternalStorageParam(),
            TranscriptsStorage = new BetaInternalStorageParam(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaInferenceDataPrivacyCreateParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnthropicHumanReviewParam expectedHumanReview = new(
            BetaAnthropicHumanReviewParamType.Disabled
        );
        BetaStorageMemberParam expectedSafeguardsStorage = new BetaInternalStorageParam();
        BetaStorageMemberParam expectedTranscriptsStorage = new BetaInternalStorageParam();

        Assert.Equal(expectedHumanReview, deserialized.HumanReview);
        Assert.Equal(expectedSafeguardsStorage, deserialized.SafeguardsStorage);
        Assert.Equal(expectedTranscriptsStorage, deserialized.TranscriptsStorage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaInferenceDataPrivacyCreateParam
        {
            HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
            SafeguardsStorage = new BetaInternalStorageParam(),
            TranscriptsStorage = new BetaInternalStorageParam(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaInferenceDataPrivacyCreateParam { };

        Assert.Null(model.HumanReview);
        Assert.False(model.RawData.ContainsKey("human_review"));
        Assert.Null(model.SafeguardsStorage);
        Assert.False(model.RawData.ContainsKey("safeguards_storage"));
        Assert.Null(model.TranscriptsStorage);
        Assert.False(model.RawData.ContainsKey("transcripts_storage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaInferenceDataPrivacyCreateParam { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaInferenceDataPrivacyCreateParam
        {
            // Null should be interpreted as omitted for these properties
            HumanReview = null,
            SafeguardsStorage = null,
            TranscriptsStorage = null,
        };

        Assert.Null(model.HumanReview);
        Assert.False(model.RawData.ContainsKey("human_review"));
        Assert.Null(model.SafeguardsStorage);
        Assert.False(model.RawData.ContainsKey("safeguards_storage"));
        Assert.Null(model.TranscriptsStorage);
        Assert.False(model.RawData.ContainsKey("transcripts_storage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaInferenceDataPrivacyCreateParam
        {
            HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
            SafeguardsStorage = new BetaInternalStorageParam(),
            TranscriptsStorage = new BetaInternalStorageParam(),
        } with
        {
            // Null should be interpreted as omitted for these properties
            HumanReview = null,
            SafeguardsStorage = null,
            TranscriptsStorage = null,
        };

        Assert.Null(model.HumanReview);
        Assert.False(model.RawData.ContainsKey("human_review"));
        Assert.Null(model.SafeguardsStorage);
        Assert.False(model.RawData.ContainsKey("safeguards_storage"));
        Assert.Null(model.TranscriptsStorage);
        Assert.False(model.RawData.ContainsKey("transcripts_storage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaInferenceDataPrivacyCreateParam
        {
            // Null should be interpreted as omitted for these properties
            HumanReview = null,
            SafeguardsStorage = null,
            TranscriptsStorage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaInferenceDataPrivacyCreateParam
        {
            HumanReview = new(BetaAnthropicHumanReviewParamType.Disabled),
            SafeguardsStorage = new BetaInternalStorageParam(),
            TranscriptsStorage = new BetaInternalStorageParam(),
        };

        BetaInferenceDataPrivacyCreateParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
