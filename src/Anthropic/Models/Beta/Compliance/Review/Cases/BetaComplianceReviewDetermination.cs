using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// A conclusion on flagged messages: `violation` or `no_violation`.
/// </summary>
[JsonConverter(typeof(BetaComplianceReviewDeterminationConverter))]
public enum BetaComplianceReviewDetermination
{
    /// <summary>
    /// The messages violated a policy.
    /// </summary>
    Violation = 572662914,

    /// <summary>
    /// The messages violated no policy.
    /// </summary>
    NoViolation = 1791738098,
}

sealed class BetaComplianceReviewDeterminationConverter
    : JsonConverter<BetaComplianceReviewDetermination>
{
    public override BetaComplianceReviewDetermination Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "violation" => BetaComplianceReviewDetermination.Violation,
            "no_violation" => BetaComplianceReviewDetermination.NoViolation,
            _ => (BetaComplianceReviewDetermination)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewDetermination value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewDetermination.Violation => "violation",
                BetaComplianceReviewDetermination.NoViolation => "no_violation",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
