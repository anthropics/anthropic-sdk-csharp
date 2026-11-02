using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits.IncreaseRequests;

[JsonConverter(typeof(SpendLimitIncreaseRequestStatusConverter))]
public enum SpendLimitIncreaseRequestStatus
{
    Approved,
    Denied,
    Pending,
}

sealed class SpendLimitIncreaseRequestStatusConverter
    : JsonConverter<SpendLimitIncreaseRequestStatus>
{
    public override SpendLimitIncreaseRequestStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approved" => SpendLimitIncreaseRequestStatus.Approved,
            "denied" => SpendLimitIncreaseRequestStatus.Denied,
            "pending" => SpendLimitIncreaseRequestStatus.Pending,
            _ => (SpendLimitIncreaseRequestStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SpendLimitIncreaseRequestStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SpendLimitIncreaseRequestStatus.Approved => "approved",
                SpendLimitIncreaseRequestStatus.Denied => "denied",
                SpendLimitIncreaseRequestStatus.Pending => "pending",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
