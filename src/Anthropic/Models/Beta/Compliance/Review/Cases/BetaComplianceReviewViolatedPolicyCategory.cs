using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

[JsonConverter(typeof(BetaComplianceReviewViolatedPolicyCategoryConverter))]
public enum BetaComplianceReviewViolatedPolicyCategory
{
    Cyber = 69748264,
    Bio = 269985387,
    Chem = 1665960315,
    Radnuc = 1212584113,
    Cgw = 1689001157,
    Mgw = 1545055640,
    Io = 1971956090,
    Fraud = 1655215541,
    ViolentExtremism = 413317147,
    Surveillance = 648234425,
    HumanExploitation = 1488871256,
    SelfHarm = 1177775033,
    AdultContent = 117393452,
    ReasoningExtraction = 1610126045,
    FrontierLlm = 393455878,
    CompromisedKey = 2121086737,
    Other = 1780768880,
}

sealed class BetaComplianceReviewViolatedPolicyCategoryConverter
    : JsonConverter<BetaComplianceReviewViolatedPolicyCategory>
{
    public override BetaComplianceReviewViolatedPolicyCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cyber" => BetaComplianceReviewViolatedPolicyCategory.Cyber,
            "bio" => BetaComplianceReviewViolatedPolicyCategory.Bio,
            "chem" => BetaComplianceReviewViolatedPolicyCategory.Chem,
            "radnuc" => BetaComplianceReviewViolatedPolicyCategory.Radnuc,
            "cgw" => BetaComplianceReviewViolatedPolicyCategory.Cgw,
            "mgw" => BetaComplianceReviewViolatedPolicyCategory.Mgw,
            "io" => BetaComplianceReviewViolatedPolicyCategory.Io,
            "fraud" => BetaComplianceReviewViolatedPolicyCategory.Fraud,
            "violent_extremism" => BetaComplianceReviewViolatedPolicyCategory.ViolentExtremism,
            "surveillance" => BetaComplianceReviewViolatedPolicyCategory.Surveillance,
            "human_exploitation" => BetaComplianceReviewViolatedPolicyCategory.HumanExploitation,
            "self_harm" => BetaComplianceReviewViolatedPolicyCategory.SelfHarm,
            "adult_content" => BetaComplianceReviewViolatedPolicyCategory.AdultContent,
            "reasoning_extraction" =>
                BetaComplianceReviewViolatedPolicyCategory.ReasoningExtraction,
            "frontier_llm" => BetaComplianceReviewViolatedPolicyCategory.FrontierLlm,
            "compromised_key" => BetaComplianceReviewViolatedPolicyCategory.CompromisedKey,
            "other" => BetaComplianceReviewViolatedPolicyCategory.Other,
            _ => (BetaComplianceReviewViolatedPolicyCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewViolatedPolicyCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewViolatedPolicyCategory.Cyber => "cyber",
                BetaComplianceReviewViolatedPolicyCategory.Bio => "bio",
                BetaComplianceReviewViolatedPolicyCategory.Chem => "chem",
                BetaComplianceReviewViolatedPolicyCategory.Radnuc => "radnuc",
                BetaComplianceReviewViolatedPolicyCategory.Cgw => "cgw",
                BetaComplianceReviewViolatedPolicyCategory.Mgw => "mgw",
                BetaComplianceReviewViolatedPolicyCategory.Io => "io",
                BetaComplianceReviewViolatedPolicyCategory.Fraud => "fraud",
                BetaComplianceReviewViolatedPolicyCategory.ViolentExtremism => "violent_extremism",
                BetaComplianceReviewViolatedPolicyCategory.Surveillance => "surveillance",
                BetaComplianceReviewViolatedPolicyCategory.HumanExploitation =>
                    "human_exploitation",
                BetaComplianceReviewViolatedPolicyCategory.SelfHarm => "self_harm",
                BetaComplianceReviewViolatedPolicyCategory.AdultContent => "adult_content",
                BetaComplianceReviewViolatedPolicyCategory.ReasoningExtraction =>
                    "reasoning_extraction",
                BetaComplianceReviewViolatedPolicyCategory.FrontierLlm => "frontier_llm",
                BetaComplianceReviewViolatedPolicyCategory.CompromisedKey => "compromised_key",
                BetaComplianceReviewViolatedPolicyCategory.Other => "other",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
