using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// MemoryVersionOperation enum
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsMemoryVersionOperationConverter))]
public enum BetaManagedAgentsMemoryVersionOperation
{
    Created,
    Modified,
    Deleted,
}

sealed class BetaManagedAgentsMemoryVersionOperationConverter
    : JsonConverter<BetaManagedAgentsMemoryVersionOperation>
{
    public override BetaManagedAgentsMemoryVersionOperation Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created" => BetaManagedAgentsMemoryVersionOperation.Created,
            "modified" => BetaManagedAgentsMemoryVersionOperation.Modified,
            "deleted" => BetaManagedAgentsMemoryVersionOperation.Deleted,
            _ => (BetaManagedAgentsMemoryVersionOperation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryVersionOperation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMemoryVersionOperation.Created => "created",
                BetaManagedAgentsMemoryVersionOperation.Modified => "modified",
                BetaManagedAgentsMemoryVersionOperation.Deleted => "deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
