using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.Workspaces;

[JsonConverter(typeof(BetaWorkspaceChangedConcurrentlyFieldConverter))]
public enum BetaWorkspaceChangedConcurrentlyField
{
    InferenceDataPrivacyHumanReview = 1973071699,
}

sealed class BetaWorkspaceChangedConcurrentlyFieldConverter
    : JsonConverter<BetaWorkspaceChangedConcurrentlyField>
{
    public override BetaWorkspaceChangedConcurrentlyField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inference_data_privacy.human_review" =>
                BetaWorkspaceChangedConcurrentlyField.InferenceDataPrivacyHumanReview,
            _ => (BetaWorkspaceChangedConcurrentlyField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWorkspaceChangedConcurrentlyField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWorkspaceChangedConcurrentlyField.InferenceDataPrivacyHumanReview =>
                    "inference_data_privacy.human_review",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
