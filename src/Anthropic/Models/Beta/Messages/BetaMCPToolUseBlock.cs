using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMCPToolUseBlock, BetaMCPToolUseBlockFromRaw>))]
public sealed record class BetaMCPToolUseBlock : ModelBase
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

    /// <summary>
    /// The name of the MCP tool
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The name of the MCP server
    /// </summary>
    public required string ServerName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "server_name"); }
        init { ModelBase.Set(this._rawData, "server_name", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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

class BetaMCPToolUseBlockFromRaw : IFromRaw<BetaMCPToolUseBlock>
{
    /// <inheritdoc/>
    public BetaMCPToolUseBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMCPToolUseBlock.FromRawUnchecked(rawData);
}
