using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ServerToolUseBlockParam, ServerToolUseBlockParamFromRaw>))]
public sealed record class ServerToolUseBlockParam : JsonModel
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

    public JsonElement Name
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "name"); }
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

    public ServerToolUseBlockParam(ServerToolUseBlockParam serverToolUseBlockParam)
        : base(serverToolUseBlockParam) { }

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

class ServerToolUseBlockParamFromRaw : IFromRawJson<ServerToolUseBlockParam>
{
    /// <inheritdoc/>
    public ServerToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ServerToolUseBlockParam.FromRawUnchecked(rawData);
}
