using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Every URL from this source may be fetched. This is the default.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWebFetchUrlSourceAll,
        BetaManagedAgentsWebFetchUrlSourceAllFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWebFetchUrlSourceAll : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("all")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsWebFetchUrlSourceAll()
    {
        this.Type = JsonSerializer.SerializeToElement("all");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWebFetchUrlSourceAll(
        BetaManagedAgentsWebFetchUrlSourceAll betaManagedAgentsWebFetchUrlSourceAll
    )
        : base(betaManagedAgentsWebFetchUrlSourceAll) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWebFetchUrlSourceAll(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("all");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWebFetchUrlSourceAll(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWebFetchUrlSourceAllFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWebFetchUrlSourceAll FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWebFetchUrlSourceAllFromRaw
    : IFromRawJson<BetaManagedAgentsWebFetchUrlSourceAll>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWebFetchUrlSourceAll FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWebFetchUrlSourceAll.FromRawUnchecked(rawData);
}
