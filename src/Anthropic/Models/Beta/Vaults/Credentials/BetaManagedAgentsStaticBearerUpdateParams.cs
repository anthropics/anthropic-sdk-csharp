using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Parameters for updating a static bearer token credential. The `mcp_server_url`
/// is immutable.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsStaticBearerUpdateParams,
        BetaManagedAgentsStaticBearerUpdateParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsStaticBearerUpdateParams : JsonModel
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
    /// The new static bearer token to replace the stored one.
    /// </summary>
    public string? Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("static_bearer")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Token;
    }

    public BetaManagedAgentsStaticBearerUpdateParams()
    {
        this.Type = JsonSerializer.SerializeToElement("static_bearer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsStaticBearerUpdateParams(
        BetaManagedAgentsStaticBearerUpdateParams betaManagedAgentsStaticBearerUpdateParams
    )
        : base(betaManagedAgentsStaticBearerUpdateParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsStaticBearerUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("static_bearer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsStaticBearerUpdateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsStaticBearerUpdateParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsStaticBearerUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsStaticBearerUpdateParamsFromRaw
    : IFromRawJson<BetaManagedAgentsStaticBearerUpdateParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsStaticBearerUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsStaticBearerUpdateParams.FromRawUnchecked(rawData);
}
