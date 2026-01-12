using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaToolSearchToolSearchResultBlock,
        BetaToolSearchToolSearchResultBlockFromRaw
    >)
)]
public sealed record class BetaToolSearchToolSearchResultBlock : JsonModel
{
    public required IReadOnlyList<BetaToolReferenceBlock> ToolReferences
    {
        get
        {
            return JsonModel.GetNotNullClass<List<BetaToolReferenceBlock>>(
                this.RawData,
                "tool_references"
            );
        }
        init { JsonModel.Set(this._rawData, "tool_references", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ToolReferences)
        {
            item.Validate();
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_search_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaToolSearchToolSearchResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_search_result\"");
    }

    public BetaToolSearchToolSearchResultBlock(
        BetaToolSearchToolSearchResultBlock betaToolSearchToolSearchResultBlock
    )
        : base(betaToolSearchToolSearchResultBlock) { }

    public BetaToolSearchToolSearchResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_search_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolSearchResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolSearchToolSearchResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaToolSearchToolSearchResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolSearchToolSearchResultBlock(List<BetaToolReferenceBlock> toolReferences)
        : this()
    {
        this.ToolReferences = toolReferences;
    }
}

class BetaToolSearchToolSearchResultBlockFromRaw : IFromRawJson<BetaToolSearchToolSearchResultBlock>
{
    /// <inheritdoc/>
    public BetaToolSearchToolSearchResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolSearchToolSearchResultBlock.FromRawUnchecked(rawData);
}
