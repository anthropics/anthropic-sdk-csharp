using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// MemoryView enum
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsMemoryViewConverter))]
public enum BetaManagedAgentsMemoryView
{
    Basic,
    Full,
}

sealed class BetaManagedAgentsMemoryViewConverter : JsonConverter<BetaManagedAgentsMemoryView>
{
    public override BetaManagedAgentsMemoryView Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "basic" => BetaManagedAgentsMemoryView.Basic,
            "full" => BetaManagedAgentsMemoryView.Full,
            _ => (BetaManagedAgentsMemoryView)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryView value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMemoryView.Basic => "basic",
                BetaManagedAgentsMemoryView.Full => "full",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
