using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// Tool reference block that can be included in tool_result content.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ToolReferenceBlockParam, ToolReferenceBlockParamFromRaw>))]
public sealed record class ToolReferenceBlockParam : JsonModel
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
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
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

    public ToolReferenceBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolReferenceBlockParam(ToolReferenceBlockParam toolReferenceBlockParam)
        : base(toolReferenceBlockParam) { }
#pragma warning restore CS8618

    public ToolReferenceBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolReferenceBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolReferenceBlockParamFromRaw.FromRawUnchecked"/>
    public static ToolReferenceBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolReferenceBlockParam(string toolName)
        : this()
    {
        this.ToolName = toolName;
    }
}

class ToolReferenceBlockParamFromRaw : IFromRawJson<ToolReferenceBlockParam>
{
    /// <inheritdoc/>
    public ToolReferenceBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolReferenceBlockParam.FromRawUnchecked(rawData);
}
