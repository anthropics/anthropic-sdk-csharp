using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// The model will use the specified tool with `tool_choice.name`.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<ToolChoiceTool>))]
public sealed record class ToolChoiceTool
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<ToolChoiceTool>
{
    /// <summary>
    /// The name of the tool to use.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.Properties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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
    /// Defaults to `false`. If set to `true`, the model will output exactly one tool use.
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
        _ = this.Name;
        _ = this.DisableParallelToolUse;
    }

    public ToolChoiceTool()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"tool\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ToolChoiceTool(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ToolChoiceTool FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
