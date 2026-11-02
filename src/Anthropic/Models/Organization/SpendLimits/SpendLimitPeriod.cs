using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits;

[JsonConverter(typeof(SpendLimitPeriodConverter))]
public enum SpendLimitPeriod
{
    Daily,
    Monthly,
    Weekly,
}

sealed class SpendLimitPeriodConverter : JsonConverter<SpendLimitPeriod>
{
    public override SpendLimitPeriod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daily" => SpendLimitPeriod.Daily,
            "monthly" => SpendLimitPeriod.Monthly,
            "weekly" => SpendLimitPeriod.Weekly,
            _ => (SpendLimitPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SpendLimitPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SpendLimitPeriod.Daily => "daily",
                SpendLimitPeriod.Monthly => "monthly",
                SpendLimitPeriod.Weekly => "weekly",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
