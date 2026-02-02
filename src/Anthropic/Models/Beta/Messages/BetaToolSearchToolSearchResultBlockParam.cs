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
        BetaToolSearchToolSearchResultBlockParam,
        BetaToolSearchToolSearchResultBlockParamFromRaw
    >)
)]
public sealed record class BetaToolSearchToolSearchResultBlockParam : JsonModel
{
    public required IReadOnlyList<BetaToolReferenceBlockParam> ToolReferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaToolReferenceBlockParam>>(
                "tool_references"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaToolReferenceBlockParam>>(
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

    public BetaToolSearchToolSearchResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaToolSearchToolSearchResultBlockParam(
        BetaToolSearchToolSearchResultBlockParam betaToolSearchToolSearchResultBlockParam
    )
        : base(betaToolSearchToolSearchResultBlockParam) { }
#pragma warning restore CS8618

    public BetaToolSearchToolSearchResultBlockParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolSearchResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolSearchToolSearchResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaToolSearchToolSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolSearchToolSearchResultBlockParam(
        IReadOnlyList<BetaToolReferenceBlockParam> toolReferences
    )
        : this()
    {
        this.ToolReferences = toolReferences;
    }
}

class BetaToolSearchToolSearchResultBlockParamFromRaw
    : IFromRawJson<BetaToolSearchToolSearchResultBlockParam>
{
    /// <inheritdoc/>
    public BetaToolSearchToolSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolSearchToolSearchResultBlockParam.FromRawUnchecked(rawData);
}
