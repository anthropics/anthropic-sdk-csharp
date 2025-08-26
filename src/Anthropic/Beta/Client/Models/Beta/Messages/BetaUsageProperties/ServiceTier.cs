using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaUsageProperties;

/// <summary>
/// If the request used the priority, standard, or batch tier.
/// </summary>
[JsonConverter(typeof(ServiceTierConverter))]
public enum ServiceTier
{
    Standard,
    Priority,
    Batch,
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
            "standard" => ServiceTier.Standard,
            "priority" => ServiceTier.Priority,
            "batch" => ServiceTier.Batch,
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
                ServiceTier.Standard => "standard",
                ServiceTier.Priority => "priority",
                ServiceTier.Batch => "batch",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
