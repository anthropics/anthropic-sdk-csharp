using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// The kind of mutation a `memory_version` records. Every non-no-op mutation to a
/// memory appends exactly one version row with one of these values.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsMemoryVersionOperationConverter))]
public enum BetaManagedAgentsMemoryVersionOperation
{
    /// <summary>
    /// The memory was created. The first version in any memory's lineage.
    /// </summary>
    Created,

    /// <summary>
    /// The memory's `content`, `path`, or both were changed via update. Writes the
    /// agent makes through the filesystem mount also appear as `modified`.
    /// </summary>
    Modified,

    /// <summary>
    /// The memory was deleted. The `content`, `content_size_bytes`, and `content_sha256`
    /// fields are `null` on this version. The preceding version, while it is retained,
    /// records the deleted content's size and hash.
    /// </summary>
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
