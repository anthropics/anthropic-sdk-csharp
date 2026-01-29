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
    typeof(JsonModelConverter<BetaToolReferenceBlockParam, BetaToolReferenceBlockParamFromRaw>)
)]
public sealed record class BetaToolReferenceBlockParam : JsonModel
{
    public required string ToolName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_name");
        }
        init { this._rawData.Set("tool_name", value); }
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ToolName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_reference")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaToolReferenceBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaToolReferenceBlockParam(BetaToolReferenceBlockParam betaToolReferenceBlockParam)
        : base(betaToolReferenceBlockParam) { }
#pragma warning restore CS8618

    public BetaToolReferenceBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolReferenceBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class BetaToolReferenceBlockParamFromRaw : IFromRawJson<BetaToolReferenceBlockParam>
{
    /// <inheritdoc/>
    public BetaToolReferenceBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolReferenceBlockParam.FromRawUnchecked(rawData);
}
