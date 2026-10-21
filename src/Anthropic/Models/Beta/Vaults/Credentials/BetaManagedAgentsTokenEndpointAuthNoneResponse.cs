using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Token endpoint requires no client authentication.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTokenEndpointAuthNoneResponse,
        BetaManagedAgentsTokenEndpointAuthNoneResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthNoneResponse : JsonModel
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

    public BetaManagedAgentsTokenEndpointAuthNoneResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthNoneResponse(
        BetaManagedAgentsTokenEndpointAuthNoneResponse betaManagedAgentsTokenEndpointAuthNoneResponse
    )
        : base(betaManagedAgentsTokenEndpointAuthNoneResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthNoneResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthNoneResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthNoneResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthNoneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsTokenEndpointAuthNoneResponseFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthNoneResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthNoneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthNoneResponse.FromRawUnchecked(rawData);
}
