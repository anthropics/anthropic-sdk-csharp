using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Confirmation that a `session` has been permanently deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDeletedSession,
        BetaManagedAgentsDeletedSessionFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDeletedSession : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("session_deleted"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsDeletedSession()
    {
        this.Type = JsonSerializer.SerializeToElement("session_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeletedSession(
        BetaManagedAgentsDeletedSession betaManagedAgentsDeletedSession
    )
        : base(betaManagedAgentsDeletedSession) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeletedSession(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeletedSession(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeletedSessionFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeletedSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsDeletedSession(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsDeletedSessionFromRaw : IFromRawJson<BetaManagedAgentsDeletedSession>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeletedSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeletedSession.FromRawUnchecked(rawData);
}
