using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// A review case status to filter by: `open` or `closed`.
/// </summary>
[JsonConverter(typeof(BetaComplianceReviewCaseStatusFilterConverter))]
public enum BetaComplianceReviewCaseStatusFilter
{
    /// <summary>
    /// Cases that Anthropic is waiting for a response to.
    /// </summary>
    Open = 452966999,

    /// <summary>
    /// Cases that Anthropic has stopped waiting on.
    /// </summary>
    Closed = 24219560,
}

sealed class BetaComplianceReviewCaseStatusFilterConverter
    : JsonConverter<BetaComplianceReviewCaseStatusFilter>
{
    public override BetaComplianceReviewCaseStatusFilter Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "open" => BetaComplianceReviewCaseStatusFilter.Open,
            "closed" => BetaComplianceReviewCaseStatusFilter.Closed,
            _ => (BetaComplianceReviewCaseStatusFilter)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewCaseStatusFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewCaseStatusFilter.Open => "open",
                BetaComplianceReviewCaseStatusFilter.Closed => "closed",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
