using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<WebSearchToolResultBlock>))]
public sealed record class WebSearchToolResultBlock
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<WebSearchToolResultBlock>
{
    public required WebSearchToolResultBlockContent Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "content",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<WebSearchToolResultBlockContent>(element)
                ?? throw new System::ArgumentNullException("content");
        }
        set { this.Properties["content"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string ToolUseID
    {
        get
        {
            if (!this.Properties.TryGetValue("tool_use_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tool_use_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("tool_use_id");
        }
        set { this.Properties["tool_use_id"] = Json::JsonSerializer.SerializeToElement(value); }
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

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !this.Type.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>("\"web_search_tool_result\"")
            )
        )
        {
            throw new System::Exception();
        }
    }

    public WebSearchToolResultBlock()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>(
            "\"web_search_tool_result\""
        );
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    WebSearchToolResultBlock(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebSearchToolResultBlock FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
