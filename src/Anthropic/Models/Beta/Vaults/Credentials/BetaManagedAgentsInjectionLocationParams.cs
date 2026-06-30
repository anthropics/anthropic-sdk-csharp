using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Where in the outbound request the secret value may be substituted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsInjectionLocationParams,
        BetaManagedAgentsInjectionLocationParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsInjectionLocationParams : JsonModel
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

    public BetaManagedAgentsInjectionLocationParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsInjectionLocationParams(
        BetaManagedAgentsInjectionLocationParams betaManagedAgentsInjectionLocationParams
    )
        : base(betaManagedAgentsInjectionLocationParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsInjectionLocationParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsInjectionLocationParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsInjectionLocationParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsInjectionLocationParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsInjectionLocationParamsFromRaw
    : IFromRawJson<BetaManagedAgentsInjectionLocationParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsInjectionLocationParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsInjectionLocationParams.FromRawUnchecked(rawData);
}
