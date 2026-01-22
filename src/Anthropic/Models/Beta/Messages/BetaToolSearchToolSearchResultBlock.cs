using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaToolReferenceBlock>>(
                "tool_references"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaToolReferenceBlock>>(
                "tool_references",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
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
                JsonSerializer.SerializeToElement("tool_search_tool_search_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaToolSearchToolSearchResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaToolSearchToolSearchResultBlock(
        BetaToolSearchToolSearchResultBlock betaToolSearchToolSearchResultBlock
    )
        : base(betaToolSearchToolSearchResultBlock) { }
#pragma warning restore CS8618

    public BetaToolSearchToolSearchResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolSearchResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
    public BetaToolSearchToolSearchResultBlock(IReadOnlyList<BetaToolReferenceBlock> toolReferences)
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
