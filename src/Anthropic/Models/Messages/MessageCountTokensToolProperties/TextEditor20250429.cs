using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Messages = Anthropic.Models.Messages;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages.MessageCountTokensToolProperties;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<TextEditor20250429>))]
public sealed record class TextEditor20250429
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<TextEditor20250429>
{
    /// <summary>
    /// Name of the tool.
    ///
    /// This is how the tool will be called by the model and in `tool_use` blocks.
    /// </summary>
    public Json::JsonElement Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
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
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public Messages::CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Messages::CacheControlEphemeral?>(element);
        }
        set { this.Properties["cache_control"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        if (
            !this.Name.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>(
                    "\"str_replace_based_edit_tool\""
                )
            )
        )
        {
            throw new System::Exception();
        }
        if (
            !this.Type.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>("\"text_editor_20250429\"")
            )
        )
        {
            throw new System::Exception();
        }
        this.CacheControl?.Validate();
    }

    public TextEditor20250429()
    {
        this.Name = Json::JsonSerializer.Deserialize<Json::JsonElement>(
            "\"str_replace_based_edit_tool\""
        );
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"text_editor_20250429\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TextEditor20250429(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TextEditor20250429 FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
