using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaMcpToolUseBlockParam, BetaMcpToolUseBlockParamFromRaw>)
)]
public sealed record class BetaMcpToolUseBlockParam : JsonModel
{
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Input
    {
        get
        {
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("input");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "input",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The name of the MCP server
    /// </summary>
    public required string ServerName
    {
        get { return this._rawData.GetNotNullClass<string>("server_name"); }
        init { this._rawData.Set("server_name", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get { return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control"); }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Input;
        _ = this.Name;
        _ = this.ServerName;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_use\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaMcpToolUseBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_use\"");
    }

    public BetaMcpToolUseBlockParam(BetaMcpToolUseBlockParam betaMcpToolUseBlockParam)
        : base(betaMcpToolUseBlockParam) { }

    public BetaMcpToolUseBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_use\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMcpToolUseBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMcpToolUseBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaMcpToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMcpToolUseBlockParamFromRaw : IFromRawJson<BetaMcpToolUseBlockParam>
{
    /// <inheritdoc/>
    public BetaMcpToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMcpToolUseBlockParam.FromRawUnchecked(rawData);
}
