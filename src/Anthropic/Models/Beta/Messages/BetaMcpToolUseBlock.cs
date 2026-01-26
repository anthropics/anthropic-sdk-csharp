using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaMcpToolUseBlock, BetaMcpToolUseBlockFromRaw>))]
public sealed record class BetaMcpToolUseBlock : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Input
    {
        get
        {
            this._rawData.Freeze();
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

    /// <summary>
    /// The name of the MCP tool
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The name of the MCP server
    /// </summary>
    public required string ServerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("server_name");
        }
        init { this._rawData.Set("server_name", value); }
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
        _ = this.ID;
        _ = this.Input;
        _ = this.Name;
        _ = this.ServerName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("mcp_tool_use")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaMcpToolUseBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_tool_use");
    }

    public BetaMcpToolUseBlock(BetaMcpToolUseBlock betaMcpToolUseBlock)
        : base(betaMcpToolUseBlock) { }

    public BetaMcpToolUseBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMcpToolUseBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMcpToolUseBlockFromRaw.FromRawUnchecked"/>
    public static BetaMcpToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMcpToolUseBlockFromRaw : IFromRawJson<BetaMcpToolUseBlock>
{
    /// <inheritdoc/>
    public BetaMcpToolUseBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMcpToolUseBlock.FromRawUnchecked(rawData);
}
