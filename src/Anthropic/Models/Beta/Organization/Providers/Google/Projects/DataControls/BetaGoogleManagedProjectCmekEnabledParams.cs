using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// Turns the control on, or changes its keys while it is on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectCmekEnabledParams,
        BetaGoogleManagedProjectCmekEnabledParamsFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectCmekEnabledParams : JsonModel
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

    /// <summary>
    /// The External Key to use in each region, keyed by region code, such as `us`
    /// or `eu`. An External Key ID (`ekey_...`) sets that region's key, `null` removes
    /// it, and a region you leave out keeps its key. While the control is on, at
    /// least one region must have a key.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? ExternalKeyIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>(
                "external_key_ids"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("external_key_ids");
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "external_key_ids",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ExternalKeyIds;
    }

    public BetaGoogleManagedProjectCmekEnabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectCmekEnabledParams(
        BetaGoogleManagedProjectCmekEnabledParams betaGoogleManagedProjectCmekEnabledParams
    )
        : base(betaGoogleManagedProjectCmekEnabledParams) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectCmekEnabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectCmekEnabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectCmekEnabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectCmekEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectCmekEnabledParamsFromRaw
    : IFromRawJson<BetaGoogleManagedProjectCmekEnabledParams>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectCmekEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectCmekEnabledParams.FromRawUnchecked(rawData);
}
