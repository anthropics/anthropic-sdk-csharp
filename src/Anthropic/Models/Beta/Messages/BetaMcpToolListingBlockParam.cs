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
/// The tool listing an MCP server returned while an earlier response was produced,
/// as that response carried it. Send the assistant message back unchanged, this block
/// included, and the server uses this listing for the matching `mcp_toolset` instead
/// of asking the MCP server again.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaMcpToolListingBlockParam, BetaMcpToolListingBlockParamFromRaw>)
)]
public sealed record class BetaMcpToolListingBlockParam : JsonModel
{
    /// <summary>
    /// The name of the MCP server this listing came from, as `mcp_servers` declares it.
    /// </summary>
    public required string McpServerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mcp_server_name");
        }
        init { this._rawData.Set("mcp_server_name", value); }
    }

    /// <summary>
    /// The server's tools, exactly as the response listed them.
    /// </summary>
    public required IReadOnlyList<BetaMcpToolParam> Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaMcpToolParam>>("tools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaMcpToolParam>>(
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

    public BetaMcpToolListingBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_tool_listing");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaMcpToolListingBlockParam(BetaMcpToolListingBlockParam betaMcpToolListingBlockParam)
        : base(betaMcpToolListingBlockParam) { }
#pragma warning restore CS8618

    public BetaMcpToolListingBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_tool_listing");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMcpToolListingBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMcpToolListingBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaMcpToolListingBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMcpToolListingBlockParamFromRaw : IFromRawJson<BetaMcpToolListingBlockParam>
{
    /// <inheritdoc/>
    public BetaMcpToolListingBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMcpToolListingBlockParam.FromRawUnchecked(rawData);
}
