using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaBrowserReadPageFilterConverter))]
public enum BetaBrowserReadPageFilter
{
    All,
    Interactive,
}

sealed class BetaBrowserReadPageFilterConverter : JsonConverter<BetaBrowserReadPageFilter>
{
    public override BetaBrowserReadPageFilter Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => BetaBrowserReadPageFilter.All,
            "interactive" => BetaBrowserReadPageFilter.Interactive,
            _ => (BetaBrowserReadPageFilter)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaBrowserReadPageFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaBrowserReadPageFilter.All => "all",
                BetaBrowserReadPageFilter.Interactive => "interactive",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
