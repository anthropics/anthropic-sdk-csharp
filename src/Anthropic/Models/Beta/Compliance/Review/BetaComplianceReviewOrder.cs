using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review;

/// <summary>
/// A sort direction: `asc` or `desc`.
/// </summary>
[JsonConverter(typeof(BetaComplianceReviewOrderConverter))]
public enum BetaComplianceReviewOrder
{
    /// <summary>
    /// Oldest first.
    /// </summary>
    Asc = 755640198,

    /// <summary>
    /// Newest first.
    /// </summary>
    Desc = 1005339449,
}

sealed class BetaComplianceReviewOrderConverter : JsonConverter<BetaComplianceReviewOrder>
{
    public override BetaComplianceReviewOrder Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => BetaComplianceReviewOrder.Asc,
            "desc" => BetaComplianceReviewOrder.Desc,
            _ => (BetaComplianceReviewOrder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewOrder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewOrder.Asc => "asc",
                BetaComplianceReviewOrder.Desc => "desc",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
