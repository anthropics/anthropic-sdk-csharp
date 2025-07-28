using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The model will automatically decide whether to use tools.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaToolChoiceAuto>))]
public sealed record class BetaToolChoiceAuto
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaToolChoiceAuto>
{
    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
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
            if (
                !this.Properties.TryGetValue(
                    "disable_parallel_tool_use",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.Properties["disable_parallel_tool_use"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override void Validate()
    {
        if (!this.Type.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"auto\"")))
        {
            throw new System::Exception();
        }
        _ = this.DisableParallelToolUse;
    }

    public BetaToolChoiceAuto()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"auto\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaToolChoiceAuto(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaToolChoiceAuto FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
