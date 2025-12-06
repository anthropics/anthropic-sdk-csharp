using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Tool reference block that can be included in tool_result content.
/// </summary>
[JsonConverter(
    typeof(ModelConverter<BetaToolReferenceBlockParam, BetaToolReferenceBlockParamFromRaw>)
)]
public sealed record class BetaToolReferenceBlockParam : ModelBase
{
    public required string ToolName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tool_name"); }
        init { ModelBase.Set(this._rawData, "tool_name", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ToolName;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"tool_reference\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaToolReferenceBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_reference\"");
    }

    public BetaToolReferenceBlockParam(BetaToolReferenceBlockParam betaToolReferenceBlockParam)
        : base(betaToolReferenceBlockParam) { }

    public BetaToolReferenceBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_reference\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolReferenceBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolReferenceBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaToolReferenceBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolReferenceBlockParam(string toolName)
        : this()
    {
        this.ToolName = toolName;
    }
}

class BetaToolReferenceBlockParamFromRaw : IFromRaw<BetaToolReferenceBlockParam>
{
    /// <inheritdoc/>
    public BetaToolReferenceBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolReferenceBlockParam.FromRawUnchecked(rawData);
}
