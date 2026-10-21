using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(BrowserReadPageFilterConverter))]
public enum BrowserReadPageFilter
{
    All,
    Interactive,
}

sealed class BrowserReadPageFilterConverter : JsonConverter<BrowserReadPageFilter>
{
    public override BrowserReadPageFilter Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => BrowserReadPageFilter.All,
            "interactive" => BrowserReadPageFilter.Interactive,
            _ => (BrowserReadPageFilter)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrowserReadPageFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BrowserReadPageFilter.All => "all",
                BrowserReadPageFilter.Interactive => "interactive",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
