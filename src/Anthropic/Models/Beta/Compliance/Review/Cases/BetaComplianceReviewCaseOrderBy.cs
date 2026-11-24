using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// The field that a list of review cases is sorted by: `created_at` or `updated_at`.
/// </summary>
[JsonConverter(typeof(BetaComplianceReviewCaseOrderByConverter))]
public enum BetaComplianceReviewCaseOrderBy
{
    /// <summary>
    /// Sort by when Anthropic sent the case.
    /// </summary>
    CreatedAt = 1607052486,

    /// <summary>
    /// Sort by when the case last changed.
    /// </summary>
    UpdatedAt = 1777428345,
}

sealed class BetaComplianceReviewCaseOrderByConverter
    : JsonConverter<BetaComplianceReviewCaseOrderBy>
{
    public override BetaComplianceReviewCaseOrderBy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at" => BetaComplianceReviewCaseOrderBy.CreatedAt,
            "updated_at" => BetaComplianceReviewCaseOrderBy.UpdatedAt,
            _ => (BetaComplianceReviewCaseOrderBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewCaseOrderBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewCaseOrderBy.CreatedAt => "created_at",
                BetaComplianceReviewCaseOrderBy.UpdatedAt => "updated_at",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
