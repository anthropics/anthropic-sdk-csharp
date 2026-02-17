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
        ToolSearchToolSearchResultBlockParam,
        ToolSearchToolSearchResultBlockParamFromRaw
    >)
)]
public sealed record class ToolSearchToolSearchResultBlockParam : JsonModel
{
    public required IReadOnlyList<ToolReferenceBlockParam> ToolReferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ToolReferenceBlockParam>>(
                "tool_references"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ToolReferenceBlockParam>>(
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

    public ToolSearchToolSearchResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolSearchToolSearchResultBlockParam(
        ToolSearchToolSearchResultBlockParam toolSearchToolSearchResultBlockParam
    )
        : base(toolSearchToolSearchResultBlockParam) { }
#pragma warning restore CS8618

    public ToolSearchToolSearchResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolSearchToolSearchResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolSearchToolSearchResultBlockParamFromRaw.FromRawUnchecked"/>
    public static ToolSearchToolSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolSearchToolSearchResultBlockParam(
        IReadOnlyList<ToolReferenceBlockParam> toolReferences
    )
        : this()
    {
        this.ToolReferences = toolReferences;
    }
}

class ToolSearchToolSearchResultBlockParamFromRaw
    : IFromRawJson<ToolSearchToolSearchResultBlockParam>
{
    /// <inheritdoc/>
    public ToolSearchToolSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolSearchToolSearchResultBlockParam.FromRawUnchecked(rawData);
}
