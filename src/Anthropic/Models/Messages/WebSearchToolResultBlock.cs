using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<WebSearchToolResultBlock>))]
public sealed record class WebSearchToolResultBlock
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<WebSearchToolResultBlock>
{
    public required WebSearchToolResultBlockContent Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "content",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<WebSearchToolResultBlockContent>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("content");
        }
        set { this.Properties["content"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string ToolUseID
    {
        get
        {
            if (!this.Properties.TryGetValue("tool_use_id", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "tool_use_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("tool_use_id");
        }
        set { this.Properties["tool_use_id"] = JsonSerializer.SerializeToElement(value); }
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

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
    }

    public WebSearchToolResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchToolResultBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebSearchToolResultBlock FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
