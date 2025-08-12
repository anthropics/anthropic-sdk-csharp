using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using BetaServerToolUseBlockParamProperties = Anthropic.Models.Beta.Messages.BetaServerToolUseBlockParamProperties;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaServerToolUseBlockParam>))]
public sealed record class BetaServerToolUseBlockParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaServerToolUseBlockParam>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required JsonElement Input
    {
        get
        {
            if (!this.Properties.TryGetValue("input", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "input",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["input"] = JsonSerializer.SerializeToElement(value); }
    }

    public required BetaServerToolUseBlockParamProperties::Name Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "name",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BetaServerToolUseBlockParamProperties::Name>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("name");
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

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Input;
        this.Name.Validate();
        this.CacheControl?.Validate();
    }

    public BetaServerToolUseBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolUseBlockParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaServerToolUseBlockParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
