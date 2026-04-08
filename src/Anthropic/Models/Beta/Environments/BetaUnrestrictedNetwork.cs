using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Unrestricted network access.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaUnrestrictedNetwork, BetaUnrestrictedNetworkFromRaw>))]
public sealed record class BetaUnrestrictedNetwork : JsonModel
{
    /// <summary>
    /// Network policy type
    /// </summary>
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("unrestricted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaUnrestrictedNetwork()
    {
        this.Type = JsonSerializer.SerializeToElement("unrestricted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUnrestrictedNetwork(BetaUnrestrictedNetwork betaUnrestrictedNetwork)
        : base(betaUnrestrictedNetwork) { }
#pragma warning restore CS8618

    public BetaUnrestrictedNetwork(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("unrestricted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUnrestrictedNetwork(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUnrestrictedNetworkFromRaw.FromRawUnchecked"/>
    public static BetaUnrestrictedNetwork FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaUnrestrictedNetworkFromRaw : IFromRawJson<BetaUnrestrictedNetwork>
{
    /// <inheritdoc/>
    public BetaUnrestrictedNetwork FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaUnrestrictedNetwork.FromRawUnchecked(rawData);
}
