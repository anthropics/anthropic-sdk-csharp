using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaInferenceDataPrivacyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaInferenceDataPrivacy
        {
            HumanReview = new(Type.Disabled),
            SafeguardsStorage = new BetaInternalStorage(),
            TranscriptsStorage = new BetaInternalStorage(),
        };

        BetaAnthropicHumanReview expectedHumanReview = new(Type.Disabled);
        BetaStorageMember expectedSafeguardsStorage = new BetaInternalStorage();
        BetaStorageMember expectedTranscriptsStorage = new BetaInternalStorage();

        Assert.Equal(expectedHumanReview, model.HumanReview);
        Assert.Equal(expectedSafeguardsStorage, model.SafeguardsStorage);
        Assert.Equal(expectedTranscriptsStorage, model.TranscriptsStorage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaInferenceDataPrivacy
        {
            HumanReview = new(Type.Disabled),
            SafeguardsStorage = new BetaInternalStorage(),
            TranscriptsStorage = new BetaInternalStorage(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaInferenceDataPrivacy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaInferenceDataPrivacy
        {
            HumanReview = new(Type.Disabled),
            SafeguardsStorage = new BetaInternalStorage(),
            TranscriptsStorage = new BetaInternalStorage(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaInferenceDataPrivacy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnthropicHumanReview expectedHumanReview = new(Type.Disabled);
        BetaStorageMember expectedSafeguardsStorage = new BetaInternalStorage();
        BetaStorageMember expectedTranscriptsStorage = new BetaInternalStorage();

        Assert.Equal(expectedHumanReview, deserialized.HumanReview);
        Assert.Equal(expectedSafeguardsStorage, deserialized.SafeguardsStorage);
        Assert.Equal(expectedTranscriptsStorage, deserialized.TranscriptsStorage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaInferenceDataPrivacy
        {
            HumanReview = new(Type.Disabled),
            SafeguardsStorage = new BetaInternalStorage(),
            TranscriptsStorage = new BetaInternalStorage(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaInferenceDataPrivacy { };

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
        var model = new BetaInferenceDataPrivacy { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaInferenceDataPrivacy
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
        var model = new BetaInferenceDataPrivacy
        {
            HumanReview = new(Type.Disabled),
            SafeguardsStorage = new BetaInternalStorage(),
            TranscriptsStorage = new BetaInternalStorage(),
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
        var model = new BetaInferenceDataPrivacy
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
        var model = new BetaInferenceDataPrivacy
        {
            HumanReview = new(Type.Disabled),
            SafeguardsStorage = new BetaInternalStorage(),
            TranscriptsStorage = new BetaInternalStorage(),
        };

        BetaInferenceDataPrivacy copied = new(model);

        Assert.Equal(model, copied);
    }
}
