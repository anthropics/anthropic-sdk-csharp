using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Only the named tools' results contribute URLs that may be fetched.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWebFetchUrlSourceOnly,
        BetaManagedAgentsWebFetchUrlSourceOnlyFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWebFetchUrlSourceOnly : JsonModel
{
    /// <summary>
    /// The tools whose results contribute. Between 1 and 128 entries, each with
    /// a different name. An empty list is rejected; use "none" to allow no tool's results.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsWebFetchUrlSourceToolReference> Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsWebFetchUrlSourceToolReference>
            >("tools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsWebFetchUrlSourceToolReference>>(
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
        foreach (var item in this.Tools)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("only")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsWebFetchUrlSourceOnly()
    {
        this.Type = JsonSerializer.SerializeToElement("only");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWebFetchUrlSourceOnly(
        BetaManagedAgentsWebFetchUrlSourceOnly betaManagedAgentsWebFetchUrlSourceOnly
    )
        : base(betaManagedAgentsWebFetchUrlSourceOnly) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWebFetchUrlSourceOnly(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("only");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWebFetchUrlSourceOnly(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWebFetchUrlSourceOnlyFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWebFetchUrlSourceOnly FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsWebFetchUrlSourceOnly(
        IReadOnlyList<BetaManagedAgentsWebFetchUrlSourceToolReference> tools
    )
        : this()
    {
        this.Tools = tools;
    }
}

class BetaManagedAgentsWebFetchUrlSourceOnlyFromRaw
    : IFromRawJson<BetaManagedAgentsWebFetchUrlSourceOnly>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWebFetchUrlSourceOnly FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWebFetchUrlSourceOnly.FromRawUnchecked(rawData);
}
