using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

/// <summary>
/// The model will use any available tools.
/// </summary>
[JsonConverter(typeof(ModelConverter<ToolChoiceAny>))]
public sealed record class ToolChoiceAny : ModelBase, IFromRaw<ToolChoiceAny>
{
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
        _ = this.DisableParallelToolUse;
    }

    public ToolChoiceAny()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"any\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolChoiceAny(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ToolChoiceAny FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
