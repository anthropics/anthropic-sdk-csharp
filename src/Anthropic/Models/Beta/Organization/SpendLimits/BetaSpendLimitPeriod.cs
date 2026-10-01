using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

[JsonConverter(typeof(BetaSpendLimitPeriodConverter))]
public enum BetaSpendLimitPeriod
{
    Daily,
    Monthly,
    Weekly,
}

sealed class BetaSpendLimitPeriodConverter : JsonConverter<BetaSpendLimitPeriod>
{
    public override BetaSpendLimitPeriod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daily" => BetaSpendLimitPeriod.Daily,
            "monthly" => BetaSpendLimitPeriod.Monthly,
            "weekly" => BetaSpendLimitPeriod.Weekly,
            _ => (BetaSpendLimitPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaSpendLimitPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaSpendLimitPeriod.Daily => "daily",
                BetaSpendLimitPeriod.Monthly => "monthly",
                BetaSpendLimitPeriod.Weekly => "weekly",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
