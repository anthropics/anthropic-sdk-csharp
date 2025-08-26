using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaServerToolUseBlockParamProperties;

[JsonConverter(typeof(NameConverter))]
public enum Name
{
    WebSearch,
    CodeExecution,
}

sealed class NameConverter : JsonConverter<Name>
{
    public override Name Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "web_search" => Name.WebSearch,
            "code_execution" => Name.CodeExecution,
            _ => (Name)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Name value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Name.WebSearch => "web_search",
                Name.CodeExecution => "code_execution",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
