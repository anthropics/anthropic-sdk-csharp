using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

/// <summary>
/// The model will automatically decide whether to use tools.
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaToolChoiceAuto>))]
public sealed record class BetaToolChoiceAuto : ModelBase, IFromRaw<BetaToolChoiceAuto>
{
    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

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

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["disable_parallel_tool_use"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.DisableParallelToolUse;
    }

    public BetaToolChoiceAuto()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"auto\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChoiceAuto(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaToolChoiceAuto FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
