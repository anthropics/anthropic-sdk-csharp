using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ApiKeys;

[JsonConverter(
    typeof(JsonModelConverter<BetaApiKeyServiceAccountActor, BetaApiKeyServiceAccountActorFromRaw>)
)]
public sealed record class BetaApiKeyServiceAccountActor : JsonModel
{
    /// <summary>
    /// ID of the Service Account the API key acts as.
    /// </summary>
    public required string ServiceAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("service_account_id");
        }
        init { this._rawData.Set("service_account_id", value); }
    }

    /// <summary>
    /// Principal type. Always `"service_account_actor"` for a Service Account.
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
        _ = this.ServiceAccountID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("service_account_actor")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaApiKeyServiceAccountActor()
    {
        this.Type = JsonSerializer.SerializeToElement("service_account_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaApiKeyServiceAccountActor(
        BetaApiKeyServiceAccountActor betaApiKeyServiceAccountActor
    )
        : base(betaApiKeyServiceAccountActor) { }
#pragma warning restore CS8618

    public BetaApiKeyServiceAccountActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("service_account_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaApiKeyServiceAccountActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaApiKeyServiceAccountActorFromRaw.FromRawUnchecked"/>
    public static BetaApiKeyServiceAccountActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaApiKeyServiceAccountActor(string serviceAccountID)
        : this()
    {
        this.ServiceAccountID = serviceAccountID;
    }
}

class BetaApiKeyServiceAccountActorFromRaw : IFromRawJson<BetaApiKeyServiceAccountActor>
{
    /// <inheritdoc/>
    public BetaApiKeyServiceAccountActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaApiKeyServiceAccountActor.FromRawUnchecked(rawData);
}
