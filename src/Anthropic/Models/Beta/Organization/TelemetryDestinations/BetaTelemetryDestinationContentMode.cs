using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// What the spans that the API exports to a telemetry destination contain.
///
/// <para>See the [OpenTelemetry export guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#choose-a-content-mode)
/// to learn what the spans contain in each content mode.</para>
/// </summary>
[JsonConverter(typeof(BetaTelemetryDestinationContentModeConverter))]
public enum BetaTelemetryDestinationContentMode
{
    /// <summary>
    /// The spans contain identifiers, timing, status, token counts, and similar
    /// metadata. They don't contain prompt text, completion text, or tool inputs
    /// and outputs.
    /// </summary>
    MetadataOnly,

    /// <summary>
    /// The spans contain the same metadata as `metadata_only`, plus message and tool content.
    ///
    /// <para>An organization with a data-handling restriction, such as under HIPAA,
    /// can't choose this mode. The API exports only metadata for such an organization,
    /// even to a destination that already has `content`.</para>
    /// </summary>
    Content,
}

sealed class BetaTelemetryDestinationContentModeConverter
    : JsonConverter<BetaTelemetryDestinationContentMode>
{
    public override BetaTelemetryDestinationContentMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "metadata_only" => BetaTelemetryDestinationContentMode.MetadataOnly,
            "content" => BetaTelemetryDestinationContentMode.Content,
            _ => (BetaTelemetryDestinationContentMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTelemetryDestinationContentMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaTelemetryDestinationContentMode.MetadataOnly => "metadata_only",
                BetaTelemetryDestinationContentMode.Content => "content",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
