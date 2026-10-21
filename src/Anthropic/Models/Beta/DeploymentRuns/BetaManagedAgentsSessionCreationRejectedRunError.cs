using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// The session create request was rejected with a non-retryable validation error.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionCreationRejectedRunError,
        BetaManagedAgentsSessionCreationRejectedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionCreationRejectedRunError : JsonModel
{
    /// <summary>
    /// Human-readable error description.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
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
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("session_creation_rejected_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionCreationRejectedRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("session_creation_rejected_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionCreationRejectedRunError(
        BetaManagedAgentsSessionCreationRejectedRunError betaManagedAgentsSessionCreationRejectedRunError
    )
        : base(betaManagedAgentsSessionCreationRejectedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionCreationRejectedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session_creation_rejected_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionCreationRejectedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionCreationRejectedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionCreationRejectedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsSessionCreationRejectedRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsSessionCreationRejectedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSessionCreationRejectedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionCreationRejectedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionCreationRejectedRunError.FromRawUnchecked(rawData);
}
