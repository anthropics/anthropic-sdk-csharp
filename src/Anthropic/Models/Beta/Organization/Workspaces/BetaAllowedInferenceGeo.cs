using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

[JsonConverter(typeof(BetaAllowedInferenceGeoConverter))]
public enum BetaAllowedInferenceGeo
{
    Global,
    Us,
}

sealed class BetaAllowedInferenceGeoConverter : JsonConverter<BetaAllowedInferenceGeo>
{
    public override BetaAllowedInferenceGeo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "global" => BetaAllowedInferenceGeo.Global,
            "us" => BetaAllowedInferenceGeo.Us,
            _ => (BetaAllowedInferenceGeo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAllowedInferenceGeo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAllowedInferenceGeo.Global => "global",
                BetaAllowedInferenceGeo.Us => "us",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
