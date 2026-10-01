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
[JsonConverter(typeof(JsonModelConverter<BetaMcpTool, BetaMcpToolFromRaw>))]
public sealed record class BetaMcpTool : JsonModel
{
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

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputSchema;
        _ = this.Name;
        _ = this.Description;
    }

    public BetaMcpTool() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaMcpTool(BetaMcpTool betaMcpTool)
        : base(betaMcpTool) { }
#pragma warning restore CS8618

    public BetaMcpTool(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMcpTool(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMcpToolFromRaw.FromRawUnchecked"/>
    public static BetaMcpTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMcpToolFromRaw : IFromRawJson<BetaMcpTool>
{
    /// <inheritdoc/>
    public BetaMcpTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMcpTool.FromRawUnchecked(rawData);
}
