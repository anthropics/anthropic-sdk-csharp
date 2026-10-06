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
/// Every tool's results contribute URLs that may be fetched, except the named tools' results.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWebFetchUrlSourceExcept,
        BetaManagedAgentsWebFetchUrlSourceExceptFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWebFetchUrlSourceExcept : JsonModel
{
    /// <summary>
    /// The tools whose results do not contribute. Between 1 and 128 entries, each
    /// with a different name. An empty list is rejected; use "all" to leave out no
    /// tool's results.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("except")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsWebFetchUrlSourceExcept()
    {
        this.Type = JsonSerializer.SerializeToElement("except");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWebFetchUrlSourceExcept(
        BetaManagedAgentsWebFetchUrlSourceExcept betaManagedAgentsWebFetchUrlSourceExcept
    )
        : base(betaManagedAgentsWebFetchUrlSourceExcept) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWebFetchUrlSourceExcept(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("except");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWebFetchUrlSourceExcept(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWebFetchUrlSourceExceptFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWebFetchUrlSourceExcept FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsWebFetchUrlSourceExcept(
        IReadOnlyList<BetaManagedAgentsWebFetchUrlSourceToolReference> tools
    )
        : this()
    {
        this.Tools = tools;
    }
}

class BetaManagedAgentsWebFetchUrlSourceExceptFromRaw
    : IFromRawJson<BetaManagedAgentsWebFetchUrlSourceExcept>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWebFetchUrlSourceExcept FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWebFetchUrlSourceExcept.FromRawUnchecked(rawData);
}
