using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// A human user, for example acting through the Anthropic Console.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsUserActor, BetaManagedAgentsUserActorFromRaw>)
)]
public sealed record class BetaManagedAgentsUserActor : JsonModel
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
    /// ID of the user (a `user_...` value).
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user_actor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
    }

    public BetaManagedAgentsUserActor()
    {
        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserActor(BetaManagedAgentsUserActor betaManagedAgentsUserActor)
        : base(betaManagedAgentsUserActor) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserActorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsUserActor(string userID)
        : this()
    {
        this.UserID = userID;
    }
}

class BetaManagedAgentsUserActorFromRaw : IFromRawJson<BetaManagedAgentsUserActor>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserActor.FromRawUnchecked(rawData);
}
