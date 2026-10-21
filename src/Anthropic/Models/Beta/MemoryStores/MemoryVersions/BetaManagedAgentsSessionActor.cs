using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// An agent acting during a session, for example through the session's mounted filesystem.
/// It names the session itself, not the user or API key that started the session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsSessionActor, BetaManagedAgentsSessionActorFromRaw>)
)]
public sealed record class BetaManagedAgentsSessionActor : JsonModel
{
    /// <summary>
    /// ID of the session (a `sesn_...` value). Look up the session via [Retrieve
    /// a session](/en/api/beta/sessions/retrieve) for further provenance.
    /// </summary>
    public required string SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
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
        _ = this.SessionID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("session_actor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionActor()
    {
        this.Type = JsonSerializer.SerializeToElement("session_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionActor(
        BetaManagedAgentsSessionActor betaManagedAgentsSessionActor
    )
        : base(betaManagedAgentsSessionActor) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionActorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsSessionActor(string sessionID)
        : this()
    {
        this.SessionID = sessionID;
    }
}

class BetaManagedAgentsSessionActorFromRaw : IFromRawJson<BetaManagedAgentsSessionActor>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionActor.FromRawUnchecked(rawData);
}
