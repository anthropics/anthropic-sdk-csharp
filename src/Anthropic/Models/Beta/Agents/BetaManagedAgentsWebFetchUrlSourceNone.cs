using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// This source contributes no URLs that may be fetched.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWebFetchUrlSourceNone,
        BetaManagedAgentsWebFetchUrlSourceNoneFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWebFetchUrlSourceNone : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("none")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsWebFetchUrlSourceNone()
    {
        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWebFetchUrlSourceNone(
        BetaManagedAgentsWebFetchUrlSourceNone betaManagedAgentsWebFetchUrlSourceNone
    )
        : base(betaManagedAgentsWebFetchUrlSourceNone) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWebFetchUrlSourceNone(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWebFetchUrlSourceNone(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWebFetchUrlSourceNoneFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWebFetchUrlSourceNone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWebFetchUrlSourceNoneFromRaw
    : IFromRawJson<BetaManagedAgentsWebFetchUrlSourceNone>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWebFetchUrlSourceNone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWebFetchUrlSourceNone.FromRawUnchecked(rawData);
}
