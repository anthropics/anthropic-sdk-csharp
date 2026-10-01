using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// Selects which projection of a `memory` or `memory_version` the server returns.
/// `basic` returns the object with `content` set to `null`; `full` populates `content`.
/// When omitted, the default is endpoint-specific: retrieve operations default to
/// `full`; list, create, and update operations default to `basic`. Listing with
/// `view=full` caps `limit` at 20.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsMemoryViewConverter))]
public enum BetaManagedAgentsMemoryView
{
    /// <summary>
    /// Return the object with `content` set to `null`. The `content_size_bytes`
    /// and `content_sha256` fields remain populated, so sync clients can diff without
    /// fetching content.
    /// </summary>
    Basic,

    /// <summary>
    /// Return the object with `content` populated. On list endpoints, `view=full`
    /// caps `limit` at 20.
    /// </summary>
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
