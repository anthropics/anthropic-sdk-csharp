using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A tool as an MCP server lists it: its name on that server, its description, and
/// its input schema.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaMcpToolParam, BetaMcpToolParamFromRaw>))]
public sealed record class BetaMcpToolParam : JsonModel
{
    /// <summary>
    /// The tool's input schema as the MCP server lists it, verbatim.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> InputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "input_schema"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "input_schema",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The tool's name as the MCP server lists it (not prefixed with the server name).
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
    /// The tool's description as the MCP server lists it.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputSchema;
        _ = this.Name;
        _ = this.Description;
    }

    public BetaMcpToolParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaMcpToolParam(BetaMcpToolParam betaMcpToolParam)
        : base(betaMcpToolParam) { }
#pragma warning restore CS8618

    public BetaMcpToolParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMcpToolParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMcpToolParamFromRaw.FromRawUnchecked"/>
    public static BetaMcpToolParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMcpToolParamFromRaw : IFromRawJson<BetaMcpToolParam>
{
    /// <inheritdoc/>
    public BetaMcpToolParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMcpToolParam.FromRawUnchecked(rawData);
}
