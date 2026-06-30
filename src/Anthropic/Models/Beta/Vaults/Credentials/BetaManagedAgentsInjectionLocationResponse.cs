using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Where in the outbound request the secret value is substituted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsInjectionLocationResponse,
        BetaManagedAgentsInjectionLocationResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsInjectionLocationResponse : JsonModel
{
    /// <summary>
    /// Whether the placeholder is substituted in the request body.
    /// </summary>
    public required bool Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("body");
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// Whether the placeholder is substituted in request header values.
    /// </summary>
    public required bool Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("header");
        }
        init { this._rawData.Set("header", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Body;
        _ = this.Header;
    }

    public BetaManagedAgentsInjectionLocationResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsInjectionLocationResponse(
        BetaManagedAgentsInjectionLocationResponse betaManagedAgentsInjectionLocationResponse
    )
        : base(betaManagedAgentsInjectionLocationResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsInjectionLocationResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsInjectionLocationResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsInjectionLocationResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsInjectionLocationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsInjectionLocationResponseFromRaw
    : IFromRawJson<BetaManagedAgentsInjectionLocationResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsInjectionLocationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsInjectionLocationResponse.FromRawUnchecked(rawData);
}
