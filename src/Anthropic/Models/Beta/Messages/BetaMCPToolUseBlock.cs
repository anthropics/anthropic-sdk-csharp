using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaMCPToolUseBlock, BetaMCPToolUseBlockFromRaw>))]
public sealed record class BetaMCPToolUseBlock : JsonModel
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

    /// <summary>
    /// The name of the MCP tool
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The name of the MCP server
    /// </summary>
    public required string ServerName
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "server_name"); }
        init { JsonModel.Set(this._rawData, "server_name", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
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
    }

    public BetaMCPToolUseBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_use\"");
    }

    public BetaMCPToolUseBlock(BetaMCPToolUseBlock betaMCPToolUseBlock)
        : base(betaMCPToolUseBlock) { }

    public BetaMCPToolUseBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_use\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMCPToolUseBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMCPToolUseBlockFromRaw.FromRawUnchecked"/>
    public static BetaMCPToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMCPToolUseBlockFromRaw : IFromRawJson<BetaMCPToolUseBlock>
{
    /// <inheritdoc/>
    public BetaMCPToolUseBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMCPToolUseBlock.FromRawUnchecked(rawData);
}
