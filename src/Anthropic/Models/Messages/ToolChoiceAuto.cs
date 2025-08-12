using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

/// <summary>
/// The model will automatically decide whether to use tools.
/// </summary>
[JsonConverter(typeof(Anthropic::ModelConverter<ToolChoiceAuto>))]
public sealed record class ToolChoiceAuto
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<ToolChoiceAuto>
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

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Whether to disable parallel tool use.
    ///
    /// Defaults to `false`. If set to `true`, the model will output at most one tool use.
    /// </summary>
    public bool? DisableParallelToolUse
    {
        get
        {
            if (!this.Properties.TryGetValue("disable_parallel_tool_use", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
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

    public ToolChoiceAuto()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"auto\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolChoiceAuto(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ToolChoiceAuto FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
