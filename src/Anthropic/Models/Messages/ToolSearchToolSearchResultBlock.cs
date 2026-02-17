using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        ToolSearchToolSearchResultBlock,
        ToolSearchToolSearchResultBlockFromRaw
    >)
)]
public sealed record class ToolSearchToolSearchResultBlock : JsonModel
{
    public required IReadOnlyList<ToolReferenceBlock> ToolReferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ToolReferenceBlock>>(
                "tool_references"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ToolReferenceBlock>>(
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

    public ToolSearchToolSearchResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolSearchToolSearchResultBlock(
        ToolSearchToolSearchResultBlock toolSearchToolSearchResultBlock
    )
        : base(toolSearchToolSearchResultBlock) { }
#pragma warning restore CS8618

    public ToolSearchToolSearchResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolSearchToolSearchResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolSearchToolSearchResultBlockFromRaw.FromRawUnchecked"/>
    public static ToolSearchToolSearchResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolSearchToolSearchResultBlock(IReadOnlyList<ToolReferenceBlock> toolReferences)
        : this()
    {
        this.ToolReferences = toolReferences;
    }
}

class ToolSearchToolSearchResultBlockFromRaw : IFromRawJson<ToolSearchToolSearchResultBlock>
{
    /// <inheritdoc/>
    public ToolSearchToolSearchResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolSearchToolSearchResultBlock.FromRawUnchecked(rawData);
}
