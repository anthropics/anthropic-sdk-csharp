using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

[JsonConverter(typeof(WorkspacePolicyFieldConverter))]
public enum WorkspacePolicyField
{
    ExternalKeyID,
}

sealed class WorkspacePolicyFieldConverter : JsonConverter<WorkspacePolicyField>
{
    public override WorkspacePolicyField Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "external_key_id" => WorkspacePolicyField.ExternalKeyID,
            _ => (WorkspacePolicyField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WorkspacePolicyField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WorkspacePolicyField.ExternalKeyID => "external_key_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
