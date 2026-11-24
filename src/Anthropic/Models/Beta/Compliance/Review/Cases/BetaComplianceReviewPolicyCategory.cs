using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

[JsonConverter(typeof(BetaComplianceReviewPolicyCategoryConverter))]
public enum BetaComplianceReviewPolicyCategory
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
    Benign = 154781493,
    Other = 1780768880,
    Undetermined = 904819229,
}

sealed class BetaComplianceReviewPolicyCategoryConverter
    : JsonConverter<BetaComplianceReviewPolicyCategory>
{
    public override BetaComplianceReviewPolicyCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cyber" => BetaComplianceReviewPolicyCategory.Cyber,
            "bio" => BetaComplianceReviewPolicyCategory.Bio,
            "chem" => BetaComplianceReviewPolicyCategory.Chem,
            "radnuc" => BetaComplianceReviewPolicyCategory.Radnuc,
            "cgw" => BetaComplianceReviewPolicyCategory.Cgw,
            "mgw" => BetaComplianceReviewPolicyCategory.Mgw,
            "io" => BetaComplianceReviewPolicyCategory.Io,
            "fraud" => BetaComplianceReviewPolicyCategory.Fraud,
            "violent_extremism" => BetaComplianceReviewPolicyCategory.ViolentExtremism,
            "surveillance" => BetaComplianceReviewPolicyCategory.Surveillance,
            "human_exploitation" => BetaComplianceReviewPolicyCategory.HumanExploitation,
            "self_harm" => BetaComplianceReviewPolicyCategory.SelfHarm,
            "adult_content" => BetaComplianceReviewPolicyCategory.AdultContent,
            "reasoning_extraction" => BetaComplianceReviewPolicyCategory.ReasoningExtraction,
            "frontier_llm" => BetaComplianceReviewPolicyCategory.FrontierLlm,
            "compromised_key" => BetaComplianceReviewPolicyCategory.CompromisedKey,
            "benign" => BetaComplianceReviewPolicyCategory.Benign,
            "other" => BetaComplianceReviewPolicyCategory.Other,
            "undetermined" => BetaComplianceReviewPolicyCategory.Undetermined,
            _ => (BetaComplianceReviewPolicyCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewPolicyCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewPolicyCategory.Cyber => "cyber",
                BetaComplianceReviewPolicyCategory.Bio => "bio",
                BetaComplianceReviewPolicyCategory.Chem => "chem",
                BetaComplianceReviewPolicyCategory.Radnuc => "radnuc",
                BetaComplianceReviewPolicyCategory.Cgw => "cgw",
                BetaComplianceReviewPolicyCategory.Mgw => "mgw",
                BetaComplianceReviewPolicyCategory.Io => "io",
                BetaComplianceReviewPolicyCategory.Fraud => "fraud",
                BetaComplianceReviewPolicyCategory.ViolentExtremism => "violent_extremism",
                BetaComplianceReviewPolicyCategory.Surveillance => "surveillance",
                BetaComplianceReviewPolicyCategory.HumanExploitation => "human_exploitation",
                BetaComplianceReviewPolicyCategory.SelfHarm => "self_harm",
                BetaComplianceReviewPolicyCategory.AdultContent => "adult_content",
                BetaComplianceReviewPolicyCategory.ReasoningExtraction => "reasoning_extraction",
                BetaComplianceReviewPolicyCategory.FrontierLlm => "frontier_llm",
                BetaComplianceReviewPolicyCategory.CompromisedKey => "compromised_key",
                BetaComplianceReviewPolicyCategory.Benign => "benign",
                BetaComplianceReviewPolicyCategory.Other => "other",
                BetaComplianceReviewPolicyCategory.Undetermined => "undetermined",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
