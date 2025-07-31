using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

/// <summary>
/// The model will use the specified tool with `tool_choice.name`.
/// </summary>
[JsonConverter(typeof(ModelConverter<ToolChoiceTool>))]
public sealed record class ToolChoiceTool : ModelBase, IFromRaw<ToolChoiceTool>
{
    /// <summary>
    /// The name of the tool to use.
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

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Whether to disable parallel tool use.
    ///
    /// Defaults to `false`. If set to `true`, the model will output exactly one tool use.
    /// </summary>
    public bool? DisableParallelToolUse
    {
        get
        {
            if (!this.Properties.TryGetValue("disable_parallel_tool_use", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["disable_parallel_tool_use"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.Name;
        _ = this.DisableParallelToolUse;
    }

    public ToolChoiceTool()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolChoiceTool(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ToolChoiceTool FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
