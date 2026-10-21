using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// A direct caller of the public API, identified by the API key that authenticated
/// the request.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsApiActor, BetaManagedAgentsApiActorFromRaw>)
)]
public sealed record class BetaManagedAgentsApiActor : JsonModel
{
    /// <summary>
    /// ID of the API key (an `apikey_...` value). This identifies the key, not the secret.
    /// </summary>
    public required string ApiKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("api_key_id");
        }
        init { this._rawData.Set("api_key_id", value); }
    }

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
        _ = this.ApiKeyID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("api_actor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsApiActor()
    {
        this.Type = JsonSerializer.SerializeToElement("api_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsApiActor(BetaManagedAgentsApiActor betaManagedAgentsApiActor)
        : base(betaManagedAgentsApiActor) { }
#pragma warning restore CS8618

    public BetaManagedAgentsApiActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("api_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsApiActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsApiActorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsApiActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsApiActor(string apiKeyID)
        : this()
    {
        this.ApiKeyID = apiKeyID;
    }
}

class BetaManagedAgentsApiActorFromRaw : IFromRawJson<BetaManagedAgentsApiActor>
{
    /// <inheritdoc/>
    public BetaManagedAgentsApiActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsApiActor.FromRawUnchecked(rawData);
}
