using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaToolComputerUse20250124>))]
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
            if (!this.Properties.TryGetValue("display_height_px", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "display_height_px",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["display_height_px"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The width of the display in pixels.
    /// </summary>
    public required long DisplayWidthPx
    {
        get
        {
            if (!this.Properties.TryGetValue("display_width_px", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "display_width_px",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["display_width_px"] = JsonSerializer.SerializeToElement(value); }
    }

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
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["cache_control"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The X11 display number (e.g. 0, 1) for the display.
    /// </summary>
    public long? DisplayNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("display_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["display_number"] = JsonSerializer.SerializeToElement(value); }
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
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"computer\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"computer_20250124\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolComputerUse20250124(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaToolComputerUse20250124 FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
