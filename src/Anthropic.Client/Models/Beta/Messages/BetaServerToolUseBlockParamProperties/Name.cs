using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaServerToolUseBlockParamProperties;

[JsonConverter(typeof(NameConverter))]
public enum Name
{
    WebSearch,
    WebFetch,
    CodeExecution,
    BashCodeExecution,
    TextEditorCodeExecution,
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
            "web_fetch" => Name.WebFetch,
            "code_execution" => Name.CodeExecution,
            "bash_code_execution" => Name.BashCodeExecution,
            "text_editor_code_execution" => Name.TextEditorCodeExecution,
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
                Name.WebFetch => "web_fetch",
                Name.CodeExecution => "code_execution",
                Name.BashCodeExecution => "bash_code_execution",
                Name.TextEditorCodeExecution => "text_editor_code_execution",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
