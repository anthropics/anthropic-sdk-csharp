using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaToolComputerUse20250124>))]
public sealed record class BetaToolComputerUse20250124
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaToolComputerUse20250124>
{
    /// <summary>
    /// The height of the display in pixels.
    /// </summary>
    public required long DisplayHeightPx
    {
        get
        {
            if (!this.Properties.TryGetValue("display_height_px", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "display_height_px",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set
        {
            this.Properties["display_height_px"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The width of the display in pixels.
    /// </summary>
    public required long DisplayWidthPx
    {
        get
        {
            if (!this.Properties.TryGetValue("display_width_px", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "display_width_px",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set
        {
            this.Properties["display_width_px"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

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
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(element);
        }
        set { this.Properties["cache_control"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The X11 display number (e.g. 0, 1) for the display.
    /// </summary>
    public long? DisplayNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("display_number", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["display_number"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.DisplayHeightPx;
        _ = this.DisplayWidthPx;
        this.CacheControl?.Validate();
        _ = this.DisplayNumber;
    }

    public BetaToolComputerUse20250124()
    {
        this.Name = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"computer\"");
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"computer_20250124\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaToolComputerUse20250124(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaToolComputerUse20250124 FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
