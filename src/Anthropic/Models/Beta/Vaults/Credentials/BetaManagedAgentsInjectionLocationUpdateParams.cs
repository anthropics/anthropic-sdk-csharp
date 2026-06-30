using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Updated injection location.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsInjectionLocationUpdateParams,
        BetaManagedAgentsInjectionLocationUpdateParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsInjectionLocationUpdateParams : JsonModel
{
    /// <summary>
    /// Substitute when the placeholder appears in the request body.
    /// </summary>
    public bool? Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("body");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("body", value);
        }
    }

    /// <summary>
    /// Substitute when the placeholder appears in a request header value.
    /// </summary>
    public bool? Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("header");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("header", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Body;
        _ = this.Header;
    }

    public BetaManagedAgentsInjectionLocationUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsInjectionLocationUpdateParams(
        BetaManagedAgentsInjectionLocationUpdateParams betaManagedAgentsInjectionLocationUpdateParams
    )
        : base(betaManagedAgentsInjectionLocationUpdateParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsInjectionLocationUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsInjectionLocationUpdateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsInjectionLocationUpdateParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsInjectionLocationUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsInjectionLocationUpdateParamsFromRaw
    : IFromRawJson<BetaManagedAgentsInjectionLocationUpdateParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsInjectionLocationUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsInjectionLocationUpdateParams.FromRawUnchecked(rawData);
}
