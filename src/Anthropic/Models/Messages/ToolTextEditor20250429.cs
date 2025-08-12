using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<ToolTextEditor20250429>))]
public sealed record class ToolTextEditor20250429
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<ToolTextEditor20250429>
{
    /// <summary>
    /// Name of the tool.
    ///
    /// This is how the tool will be called by the model and in `tool_use` blocks.
    /// </summary>
    public JsonElement Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "name",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["cache_control"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.CacheControl?.Validate();
    }

    public ToolTextEditor20250429()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"str_replace_based_edit_tool\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text_editor_20250429\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolTextEditor20250429(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ToolTextEditor20250429 FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
