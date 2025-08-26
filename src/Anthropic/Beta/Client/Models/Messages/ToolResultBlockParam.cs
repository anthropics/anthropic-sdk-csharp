using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Beta.Client.Models.Messages.ToolResultBlockParamProperties;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<ToolResultBlockParam>))]
public sealed record class ToolResultBlockParam : ModelBase, IFromRaw<ToolResultBlockParam>
{
    public required string ToolUseID
    {
        get
        {
            if (!this.Properties.TryGetValue("tool_use_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("tool_use_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("tool_use_id");
        }
        set
        {
            this.Properties["tool_use_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Content? Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Content?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? IsError
    {
        get
        {
            if (!this.Properties.TryGetValue("is_error", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["is_error"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ToolUseID;
        this.CacheControl?.Validate();
        this.Content?.Validate();
        _ = this.IsError;
    }

    public ToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolResultBlockParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ToolResultBlockParam FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ToolResultBlockParam(string toolUseID)
        : this()
    {
        this.ToolUseID = toolUseID;
    }
}
