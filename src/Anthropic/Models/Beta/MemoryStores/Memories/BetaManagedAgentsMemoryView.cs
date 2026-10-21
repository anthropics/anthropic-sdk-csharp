using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// Whether a `memory` or `memory_version` in the response includes its `content`.
/// Defaults to `full` on retrieve operations and to `basic` on list, create, and
/// update operations.
///
/// <para>With `full`, list operations return at most 20 items per page.</para>
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
        Type typeToConvert,
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
