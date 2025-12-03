using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ServerToolUseBlockParam, ServerToolUseBlockParamFromRaw>))]
public sealed record class ServerToolUseBlockParam : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Input
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "input"
            );
        }
        init { ModelBase.Set(this._rawData, "input", value); }
    }

    public JsonElement Name
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<CacheControlEphemeral>(this.RawData, "cache_control");
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Input;
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.Deserialize<JsonElement>("\"web_search\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public ServerToolUseBlockParam()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");
    }

    public ServerToolUseBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServerToolUseBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServerToolUseBlockParamFromRaw.FromRawUnchecked"/>
    public static ServerToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ServerToolUseBlockParamFromRaw : IFromRaw<ServerToolUseBlockParam>
{
    /// <inheritdoc/>
    public ServerToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ServerToolUseBlockParam.FromRawUnchecked(rawData);
}
