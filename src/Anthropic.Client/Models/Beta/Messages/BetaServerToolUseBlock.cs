using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaServerToolUseBlock>))]
public sealed record class BetaServerToolUseBlock : ModelBase, IFromRaw<BetaServerToolUseBlock>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Dictionary<string, JsonElement> Input
    {
        get
        {
            if (!this.Properties.TryGetValue("input", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'input' cannot be null",
                    new System::ArgumentOutOfRangeException("input", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'input' cannot be null",
                    new System::ArgumentNullException("input")
                );
        }
        set
        {
            this.Properties["input"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Name> Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Name>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Input;
        this.Name.Validate();
        _ = this.Type;
    }

    public BetaServerToolUseBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolUseBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaServerToolUseBlock FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

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
        System::Type typeToConvert,
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
