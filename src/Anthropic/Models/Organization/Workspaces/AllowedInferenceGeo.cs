using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

[JsonConverter(typeof(AllowedInferenceGeoConverter))]
public enum AllowedInferenceGeo
{
    Global,
    Us,
}

sealed class AllowedInferenceGeoConverter : JsonConverter<AllowedInferenceGeo>
{
    public override AllowedInferenceGeo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "global" => AllowedInferenceGeo.Global,
            "us" => AllowedInferenceGeo.Us,
            _ => (AllowedInferenceGeo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AllowedInferenceGeo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AllowedInferenceGeo.Global => "global",
                AllowedInferenceGeo.Us => "us",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
