using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Cases;

public class BetaComplianceReviewViolatedPolicyCategoryTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Cyber)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Bio)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Chem)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Radnuc)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Cgw)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Mgw)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Io)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Fraud)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.ViolentExtremism)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Surveillance)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.HumanExploitation)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.SelfHarm)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.AdultContent)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.ReasoningExtraction)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.FrontierLlm)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.CompromisedKey)]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Other)]
    public void Validation_Works(BetaComplianceReviewViolatedPolicyCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Cyber, 69748264, "cyber")]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Bio, 269985387, "bio")]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Chem, 1665960315, "chem")]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Radnuc, 1212584113, "radnuc")]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Cgw, 1689001157, "cgw")]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Mgw, 1545055640, "mgw")]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Io, 1971956090, "io")]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Fraud, 1655215541, "fraud")]
    [InlineData(
        BetaComplianceReviewViolatedPolicyCategory.ViolentExtremism,
        413317147,
        "violent_extremism"
    )]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Surveillance, 648234425, "surveillance")]
    [InlineData(
        BetaComplianceReviewViolatedPolicyCategory.HumanExploitation,
        1488871256,
        "human_exploitation"
    )]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.SelfHarm, 1177775033, "self_harm")]
    [InlineData(
        BetaComplianceReviewViolatedPolicyCategory.AdultContent,
        117393452,
        "adult_content"
    )]
    [InlineData(
        BetaComplianceReviewViolatedPolicyCategory.ReasoningExtraction,
        1610126045,
        "reasoning_extraction"
    )]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.FrontierLlm, 393455878, "frontier_llm")]
    [InlineData(
        BetaComplianceReviewViolatedPolicyCategory.CompromisedKey,
        2121086737,
        "compromised_key"
    )]
    [InlineData(BetaComplianceReviewViolatedPolicyCategory.Other, 1780768880, "other")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaComplianceReviewViolatedPolicyCategory rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
