using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// Attribution for a write made by a workload authenticated as a service account,
/// for example via Workload Identity Federation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsServiceAccountActor,
        BetaManagedAgentsServiceAccountActorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsServiceAccountActor : JsonModel
{
    /// <summary>
    /// ID of the service account that performed the write (a `svac_...` value).
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

    public BetaManagedAgentsServiceAccountActor()
    {
        this.Type = JsonSerializer.SerializeToElement("service_account_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsServiceAccountActor(
        BetaManagedAgentsServiceAccountActor betaManagedAgentsServiceAccountActor
    )
        : base(betaManagedAgentsServiceAccountActor) { }
#pragma warning restore CS8618

    public BetaManagedAgentsServiceAccountActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("service_account_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsServiceAccountActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsServiceAccountActorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsServiceAccountActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsServiceAccountActor(string serviceAccountID)
        : this()
    {
        this.ServiceAccountID = serviceAccountID;
    }
}

class BetaManagedAgentsServiceAccountActorFromRaw
    : IFromRawJson<BetaManagedAgentsServiceAccountActor>
{
    /// <inheritdoc/>
    public BetaManagedAgentsServiceAccountActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsServiceAccountActor.FromRawUnchecked(rawData);
}
