using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<Tool>))]
public sealed record class Tool : ModelBase, IFromRaw<Tool>
{
    /// <summary>
    /// [JSON schema](https://json-schema.org/draft/2020-12) for this tool's input.
    ///
    /// This defines the shape of the `input` that your tool accepts and that the
    /// model will produce.
    /// </summary>
    public required InputSchema InputSchema
    {
        get
        {
            if (!this.Properties.TryGetValue("input_schema", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'input_schema' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "input_schema",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<InputSchema>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'input_schema' cannot be null",
                    new System::ArgumentNullException("input_schema")
                );
        }
        set
        {
            this.Properties["input_schema"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the tool.
    ///
    /// This is how the tool will be called by the model and in `tool_use` blocks.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Description of what this tool does.
    ///
    /// Tool descriptions should be as detailed as possible. The more information
    /// that the model has about what the tool is and how to use it, the better it
    /// will perform. You can use natural language descriptions to reinforce important
    /// aspects of the tool input JSON schema.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, global::Anthropic.Client.Models.Messages.Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                global::Anthropic.Client.Models.Messages.Type
            >?>(element, ModelBase.SerializerOptions);
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
        this.InputSchema.Validate();
        _ = this.Name;
        this.CacheControl?.Validate();
        _ = this.Description;
        this.Type?.Validate();
    }

    public Tool() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tool(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Tool FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// [JSON schema](https://json-schema.org/draft/2020-12) for this tool's input.
///
/// This defines the shape of the `input` that your tool accepts and that the model
/// will produce.
/// </summary>
[JsonConverter(typeof(ModelConverter<InputSchema>))]
public sealed record class InputSchema : ModelBase, IFromRaw<InputSchema>
{
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

    public Dictionary<string, JsonElement>? Properties1
    {
        get
        {
            if (!this.Properties.TryGetValue("properties", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["properties"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<string>? Required
    {
        get
        {
            if (!this.Properties.TryGetValue("required", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["required"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Type;
        _ = this.Properties1;
        _ = this.Required;
    }

    public InputSchema()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"object\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InputSchema(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InputSchema FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Custom,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Client.Models.Messages.Type>
{
    public override global::Anthropic.Client.Models.Messages.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom" => global::Anthropic.Client.Models.Messages.Type.Custom,
            _ => (global::Anthropic.Client.Models.Messages.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Client.Models.Messages.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Client.Models.Messages.Type.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
