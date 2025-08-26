using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages.MessageCreateParamsProperties;

/// <summary>
/// Determines whether to use priority capacity (if available) or standard capacity
/// for this request.
///
/// Anthropic offers different levels of service for your API requests. See [service-tiers](https://docs.anthropic.com/en/api/service-tiers)
/// for details.
/// </summary>
[JsonConverter(typeof(ServiceTierConverter))]
public enum ServiceTier
{
    Auto,
    StandardOnly,
}

sealed class ServiceTierConverter : JsonConverter<ServiceTier>
{
    public override ServiceTier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => ServiceTier.Auto,
            "standard_only" => ServiceTier.StandardOnly,
            _ => (ServiceTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ServiceTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ServiceTier.Auto => "auto",
                ServiceTier.StandardOnly => "standard_only",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
