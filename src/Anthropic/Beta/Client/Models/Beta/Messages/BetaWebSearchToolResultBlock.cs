using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaWebSearchToolResultBlock>))]
public sealed record class BetaWebSearchToolResultBlock
    : ModelBase,
        IFromRaw<BetaWebSearchToolResultBlock>
{
    public required BetaWebSearchToolResultBlockContent Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new ArgumentOutOfRangeException("content", "Missing required argument");

            return JsonSerializer.Deserialize<BetaWebSearchToolResultBlockContent>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("content");
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
    }

    public BetaWebSearchToolResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebSearchToolResultBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaWebSearchToolResultBlock FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
