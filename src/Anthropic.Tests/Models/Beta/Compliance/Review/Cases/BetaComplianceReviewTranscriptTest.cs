using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class BetaComplianceReviewTranscriptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceReviewTranscript
        {
            ItemID = "item_id",
            UserProfileID = "user_profile_id",
        };

        string expectedItemID = "item_id";
        string expectedUserProfileID = "user_profile_id";

        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedUserProfileID, model.UserProfileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceReviewTranscript
        {
            ItemID = "item_id",
            UserProfileID = "user_profile_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewTranscript>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComplianceReviewTranscript
        {
            ItemID = "item_id",
            UserProfileID = "user_profile_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewTranscript>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedItemID = "item_id";
        string expectedUserProfileID = "user_profile_id";

        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedUserProfileID, deserialized.UserProfileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceReviewTranscript
        {
            ItemID = "item_id",
            UserProfileID = "user_profile_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceReviewTranscript
        {
            ItemID = "item_id",
            UserProfileID = "user_profile_id",
        };

        BetaComplianceReviewTranscript copied = new(model);

        Assert.Equal(model, copied);
    }
}
