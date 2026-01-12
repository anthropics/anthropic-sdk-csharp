using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<WebSearchToolResultBlock, WebSearchToolResultBlockFromRaw>)
)]
public sealed record class WebSearchToolResultBlock : JsonModel
{
    public required WebSearchToolResultBlockContent Content
    {
        get
        {
            return JsonModel.GetNotNullClass<WebSearchToolResultBlockContent>(
                this.RawData,
                "content"
            );
        }
        init { JsonModel.Set(this._rawData, "content", value); }
    }

    public required string ToolUseID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "tool_use_id"); }
        init { JsonModel.Set(this._rawData, "tool_use_id", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WebSearchToolResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result\"");
    }

    public WebSearchToolResultBlock(WebSearchToolResultBlock webSearchToolResultBlock)
        : base(webSearchToolResultBlock) { }

    public WebSearchToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebSearchToolResultBlockFromRaw.FromRawUnchecked"/>
    public static WebSearchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebSearchToolResultBlockFromRaw : IFromRawJson<WebSearchToolResultBlock>
{
    /// <inheritdoc/>
    public WebSearchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebSearchToolResultBlock.FromRawUnchecked(rawData);
}
