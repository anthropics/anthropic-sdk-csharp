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
            return JsonModel.GetNotNullClass<List<BetaToolReferenceBlockParam>>(
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

    public BetaToolSearchToolSearchResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_search_result\"");
    }

    public BetaToolSearchToolSearchResultBlockParam(
        BetaToolSearchToolSearchResultBlockParam betaToolSearchToolSearchResultBlockParam
    )
        : base(betaToolSearchToolSearchResultBlockParam) { }

    public BetaToolSearchToolSearchResultBlockParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_search_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolSearchResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        List<BetaToolReferenceBlockParam> toolReferences
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
