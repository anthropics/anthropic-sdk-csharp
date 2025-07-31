using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ToolProperties = Anthropic.Models.Messages.ToolProperties;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<Tool>))]
public sealed record class Tool : ModelBase, IFromRaw<Tool>
{
    /// <summary>
    /// [JSON schema](https://json-schema.org/draft/2020-12) for this tool's input.
    ///
    /// This defines the shape of the `input` that your tool accepts and that the model
    /// will produce.
    /// </summary>
    public required ToolProperties::InputSchema InputSchema
    {
        get
        {
            if (!this.Properties.TryGetValue("input_schema", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "input_schema",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ToolProperties::InputSchema>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("input_schema");
        }
        set { this.Properties["input_schema"] = JsonSerializer.SerializeToElement(value); }
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
                throw new global::System.ArgumentOutOfRangeException(
                    "name",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new global::System.ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
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
        set { this.Properties["cache_control"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Description of what this tool does.
    ///
    /// Tool descriptions should be as detailed as possible. The more information that
    /// the model has about what the tool is and how to use it, the better it will
    /// perform. You can use natural language descriptions to reinforce important aspects
    /// of the tool input JSON schema.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    public ToolProperties::Type? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ToolProperties::Type?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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
