using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

[JsonConverter(typeof(BetaSpendLimitIncreaseRequestStatusConverter))]
public enum BetaSpendLimitIncreaseRequestStatus
{
    Approved,
    Denied,
    Pending,
}

sealed class BetaSpendLimitIncreaseRequestStatusConverter
    : JsonConverter<BetaSpendLimitIncreaseRequestStatus>
{
    public override BetaSpendLimitIncreaseRequestStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approved" => BetaSpendLimitIncreaseRequestStatus.Approved,
            "denied" => BetaSpendLimitIncreaseRequestStatus.Denied,
            "pending" => BetaSpendLimitIncreaseRequestStatus.Pending,
            _ => (BetaSpendLimitIncreaseRequestStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaSpendLimitIncreaseRequestStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaSpendLimitIncreaseRequestStatus.Approved => "approved",
                BetaSpendLimitIncreaseRequestStatus.Denied => "denied",
                BetaSpendLimitIncreaseRequestStatus.Pending => "pending",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
