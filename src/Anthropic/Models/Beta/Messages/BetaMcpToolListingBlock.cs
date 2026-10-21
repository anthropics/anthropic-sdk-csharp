using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The tool listing the server fetched from an MCP server while producing this response.
/// Send the assistant message back unchanged, this block included, so later requests
/// use this listing instead of asking the MCP server again.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaMcpToolListingBlock, BetaMcpToolListingBlockFromRaw>))]
public sealed record class BetaMcpToolListingBlock : JsonModel
{
    public required string McpServerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mcp_server_name");
        }
        init { this._rawData.Set("mcp_server_name", value); }
    }

    public required IReadOnlyList<BetaMcpTool> Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaMcpTool>>("tools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaMcpTool>>(
                "tools",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        _ = this.McpServerName;
        foreach (var item in this.Tools)
        {
            item.Validate();
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("mcp_tool_listing")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaMcpToolListingBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_tool_listing");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaMcpToolListingBlock(BetaMcpToolListingBlock betaMcpToolListingBlock)
        : base(betaMcpToolListingBlock) { }
#pragma warning restore CS8618

    public BetaMcpToolListingBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_tool_listing");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMcpToolListingBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMcpToolListingBlockFromRaw.FromRawUnchecked"/>
    public static BetaMcpToolListingBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMcpToolListingBlockFromRaw : IFromRawJson<BetaMcpToolListingBlock>
{
    /// <inheritdoc/>
    public BetaMcpToolListingBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMcpToolListingBlock.FromRawUnchecked(rawData);
}
