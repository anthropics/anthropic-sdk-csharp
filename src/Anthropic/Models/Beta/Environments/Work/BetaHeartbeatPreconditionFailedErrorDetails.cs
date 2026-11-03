using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments.Work;

/// <summary>
/// `expected_last_heartbeat` does not match the stored heartbeat, so another worker
/// may hold the lease.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaHeartbeatPreconditionFailedErrorDetails,
        BetaHeartbeatPreconditionFailedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaHeartbeatPreconditionFailedErrorDetails : JsonModel
{
    /// <summary>
    /// The lease as the server holds it.
    /// </summary>
    public required BetaWorkLeaseState CurrentState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaWorkLeaseState>("current_state");
        }
        init { this._rawData.Set("current_state", value); }
    }

    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CurrentState.Validate();
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("heartbeat_precondition_failed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaHeartbeatPreconditionFailedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("heartbeat_precondition_failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaHeartbeatPreconditionFailedErrorDetails(
        BetaHeartbeatPreconditionFailedErrorDetails betaHeartbeatPreconditionFailedErrorDetails
    )
        : base(betaHeartbeatPreconditionFailedErrorDetails) { }
#pragma warning restore CS8618

    public BetaHeartbeatPreconditionFailedErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("heartbeat_precondition_failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaHeartbeatPreconditionFailedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaHeartbeatPreconditionFailedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaHeartbeatPreconditionFailedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaHeartbeatPreconditionFailedErrorDetails(BetaWorkLeaseState currentState)
        : this()
    {
        this.CurrentState = currentState;
    }
}

class BetaHeartbeatPreconditionFailedErrorDetailsFromRaw
    : IFromRawJson<BetaHeartbeatPreconditionFailedErrorDetails>
{
    /// <inheritdoc/>
    public BetaHeartbeatPreconditionFailedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaHeartbeatPreconditionFailedErrorDetails.FromRawUnchecked(rawData);
}
