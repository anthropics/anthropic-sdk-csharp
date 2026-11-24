using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class BetaComplianceReviewVerdictParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceReviewVerdictParam
        {
            Determination = BetaComplianceReviewDetermination.Violation,
            ItemID = "item_id",
            PolicyCategory = BetaComplianceReviewViolatedPolicyCategory.Cyber,
        };

        ApiEnum<string, BetaComplianceReviewDetermination> expectedDetermination =
            BetaComplianceReviewDetermination.Violation;
        string expectedItemID = "item_id";
        ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory> expectedPolicyCategory =
            BetaComplianceReviewViolatedPolicyCategory.Cyber;

        Assert.Equal(expectedDetermination, model.Determination);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedPolicyCategory, model.PolicyCategory);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceReviewVerdictParam
        {
            Determination = BetaComplianceReviewDetermination.Violation,
            ItemID = "item_id",
            PolicyCategory = BetaComplianceReviewViolatedPolicyCategory.Cyber,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewVerdictParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComplianceReviewVerdictParam
        {
            Determination = BetaComplianceReviewDetermination.Violation,
            ItemID = "item_id",
            PolicyCategory = BetaComplianceReviewViolatedPolicyCategory.Cyber,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewVerdictParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaComplianceReviewDetermination> expectedDetermination =
            BetaComplianceReviewDetermination.Violation;
        string expectedItemID = "item_id";
        ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory> expectedPolicyCategory =
            BetaComplianceReviewViolatedPolicyCategory.Cyber;

        Assert.Equal(expectedDetermination, deserialized.Determination);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedPolicyCategory, deserialized.PolicyCategory);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceReviewVerdictParam
        {
            Determination = BetaComplianceReviewDetermination.Violation,
            ItemID = "item_id",
            PolicyCategory = BetaComplianceReviewViolatedPolicyCategory.Cyber,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaComplianceReviewVerdictParam
        {
            Determination = BetaComplianceReviewDetermination.Violation,
            ItemID = "item_id",
        };

        Assert.Null(model.PolicyCategory);
        Assert.False(model.RawData.ContainsKey("policy_category"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaComplianceReviewVerdictParam
        {
            Determination = BetaComplianceReviewDetermination.Violation,
            ItemID = "item_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaComplianceReviewVerdictParam
        {
            Determination = BetaComplianceReviewDetermination.Violation,
            ItemID = "item_id",

            PolicyCategory = null,
        };

        Assert.Null(model.PolicyCategory);
        Assert.True(model.RawData.ContainsKey("policy_category"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaComplianceReviewVerdictParam
        {
            Determination = BetaComplianceReviewDetermination.Violation,
            ItemID = "item_id",

            PolicyCategory = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceReviewVerdictParam
        {
            Determination = BetaComplianceReviewDetermination.Violation,
            ItemID = "item_id",
            PolicyCategory = BetaComplianceReviewViolatedPolicyCategory.Cyber,
        };

        BetaComplianceReviewVerdictParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
