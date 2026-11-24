using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class BetaComplianceReviewPolicyCategoryTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceReviewPolicyCategory.Cyber)]
    [InlineData(BetaComplianceReviewPolicyCategory.Bio)]
    [InlineData(BetaComplianceReviewPolicyCategory.Chem)]
    [InlineData(BetaComplianceReviewPolicyCategory.Radnuc)]
    [InlineData(BetaComplianceReviewPolicyCategory.Cgw)]
    [InlineData(BetaComplianceReviewPolicyCategory.Mgw)]
    [InlineData(BetaComplianceReviewPolicyCategory.Io)]
    [InlineData(BetaComplianceReviewPolicyCategory.Fraud)]
    [InlineData(BetaComplianceReviewPolicyCategory.ViolentExtremism)]
    [InlineData(BetaComplianceReviewPolicyCategory.Surveillance)]
    [InlineData(BetaComplianceReviewPolicyCategory.HumanExploitation)]
    [InlineData(BetaComplianceReviewPolicyCategory.SelfHarm)]
    [InlineData(BetaComplianceReviewPolicyCategory.AdultContent)]
    [InlineData(BetaComplianceReviewPolicyCategory.ReasoningExtraction)]
    [InlineData(BetaComplianceReviewPolicyCategory.FrontierLlm)]
    [InlineData(BetaComplianceReviewPolicyCategory.CompromisedKey)]
    [InlineData(BetaComplianceReviewPolicyCategory.Benign)]
    [InlineData(BetaComplianceReviewPolicyCategory.Other)]
    [InlineData(BetaComplianceReviewPolicyCategory.Undetermined)]
    public void Validation_Works(BetaComplianceReviewPolicyCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewPolicyCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewPolicyCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComplianceReviewPolicyCategory.Cyber, 69748264, "cyber")]
    [InlineData(BetaComplianceReviewPolicyCategory.Bio, 269985387, "bio")]
    [InlineData(BetaComplianceReviewPolicyCategory.Chem, 1665960315, "chem")]
    [InlineData(BetaComplianceReviewPolicyCategory.Radnuc, 1212584113, "radnuc")]
    [InlineData(BetaComplianceReviewPolicyCategory.Cgw, 1689001157, "cgw")]
    [InlineData(BetaComplianceReviewPolicyCategory.Mgw, 1545055640, "mgw")]
    [InlineData(BetaComplianceReviewPolicyCategory.Io, 1971956090, "io")]
    [InlineData(BetaComplianceReviewPolicyCategory.Fraud, 1655215541, "fraud")]
    [InlineData(
        BetaComplianceReviewPolicyCategory.ViolentExtremism,
        413317147,
        "violent_extremism"
    )]
    [InlineData(BetaComplianceReviewPolicyCategory.Surveillance, 648234425, "surveillance")]
    [InlineData(
        BetaComplianceReviewPolicyCategory.HumanExploitation,
        1488871256,
        "human_exploitation"
    )]
    [InlineData(BetaComplianceReviewPolicyCategory.SelfHarm, 1177775033, "self_harm")]
    [InlineData(BetaComplianceReviewPolicyCategory.AdultContent, 117393452, "adult_content")]
    [InlineData(
        BetaComplianceReviewPolicyCategory.ReasoningExtraction,
        1610126045,
        "reasoning_extraction"
    )]
    [InlineData(BetaComplianceReviewPolicyCategory.FrontierLlm, 393455878, "frontier_llm")]
    [InlineData(BetaComplianceReviewPolicyCategory.CompromisedKey, 2121086737, "compromised_key")]
    [InlineData(BetaComplianceReviewPolicyCategory.Benign, 154781493, "benign")]
    [InlineData(BetaComplianceReviewPolicyCategory.Other, 1780768880, "other")]
    [InlineData(BetaComplianceReviewPolicyCategory.Undetermined, 904819229, "undetermined")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaComplianceReviewPolicyCategory rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewPolicyCategory> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewPolicyCategory>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComplianceReviewPolicyCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewPolicyCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
