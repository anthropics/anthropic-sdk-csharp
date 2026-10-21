using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// String form of a url_sources value that has no field other than its type: "all"
/// means {"type": "all"} and "none" means {"type": "none"}.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsWebFetchUrlSourceShorthandConverter))]
public enum BetaManagedAgentsWebFetchUrlSourceShorthand
{
    All,
    None,
}

sealed class BetaManagedAgentsWebFetchUrlSourceShorthandConverter
    : JsonConverter<BetaManagedAgentsWebFetchUrlSourceShorthand>
{
    public override BetaManagedAgentsWebFetchUrlSourceShorthand Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => BetaManagedAgentsWebFetchUrlSourceShorthand.All,
            "none" => BetaManagedAgentsWebFetchUrlSourceShorthand.None,
            _ => (BetaManagedAgentsWebFetchUrlSourceShorthand)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsWebFetchUrlSourceShorthand value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsWebFetchUrlSourceShorthand.All => "all",
                BetaManagedAgentsWebFetchUrlSourceShorthand.None => "none",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
