using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<
        BetaToolSearchToolSearchResultBlock,
        BetaToolSearchToolSearchResultBlockFromRaw
    >)
)]
public sealed record class BetaToolSearchToolSearchResultBlock : ModelBase
{
    public required List<BetaToolReferenceBlock> ToolReferences
    {
        get
        {
            if (!this._rawData.TryGetValue("tool_references", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'tool_references' cannot be null",
                    new ArgumentOutOfRangeException("tool_references", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<BetaToolReferenceBlock>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'tool_references' cannot be null",
                    new ArgumentNullException("tool_references")
                );
        }
        init
        {
            this._rawData["tool_references"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

class BetaToolSearchToolSearchResultBlockFromRaw : IFromRaw<BetaToolSearchToolSearchResultBlock>
{
    public BetaToolSearchToolSearchResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolSearchToolSearchResultBlock.FromRawUnchecked(rawData);
}
