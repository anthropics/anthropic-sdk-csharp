using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ToolUseBlockParam, ToolUseBlockParamFromRaw>))]
public sealed record class ToolUseBlockParam : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Input
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "input"
            );
        }
        init { JsonModel.Set(this._rawData, "input", value); }
    }

    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return JsonModel.GetNullableClass<CacheControlEphemeral>(this.RawData, "cache_control");
        }
        init { JsonModel.Set(this._rawData, "cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Input;
        _ = this.Name;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"tool_use\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public ToolUseBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_use\"");
    }

    public ToolUseBlockParam(ToolUseBlockParam toolUseBlockParam)
        : base(toolUseBlockParam) { }

    public ToolUseBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_use\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolUseBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolUseBlockParamFromRaw.FromRawUnchecked"/>
    public static ToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolUseBlockParamFromRaw : IFromRawJson<ToolUseBlockParam>
{
    /// <inheritdoc/>
    public ToolUseBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolUseBlockParam.FromRawUnchecked(rawData);
}
