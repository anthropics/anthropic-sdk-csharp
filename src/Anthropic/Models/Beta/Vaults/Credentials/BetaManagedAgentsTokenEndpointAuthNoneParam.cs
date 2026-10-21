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
        BetaManagedAgentsTokenEndpointAuthNoneParam,
        BetaManagedAgentsTokenEndpointAuthNoneParamFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthNoneParam : JsonModel
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

    public BetaManagedAgentsTokenEndpointAuthNoneParam()
    {
        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthNoneParam(
        BetaManagedAgentsTokenEndpointAuthNoneParam betaManagedAgentsTokenEndpointAuthNoneParam
    )
        : base(betaManagedAgentsTokenEndpointAuthNoneParam) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthNoneParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthNoneParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthNoneParamFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthNoneParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsTokenEndpointAuthNoneParamFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthNoneParam>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthNoneParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthNoneParam.FromRawUnchecked(rawData);
}
