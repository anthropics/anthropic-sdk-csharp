using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// Session creation was rejected due to rate limiting. The schedule keeps firing;
/// subsequent runs may succeed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionRateLimitedRunError,
        BetaManagedAgentsSessionRateLimitedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionRateLimitedRunError : JsonModel
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
                JsonSerializer.SerializeToElement("session_rate_limited_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionRateLimitedRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("session_rate_limited_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionRateLimitedRunError(
        BetaManagedAgentsSessionRateLimitedRunError betaManagedAgentsSessionRateLimitedRunError
    )
        : base(betaManagedAgentsSessionRateLimitedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionRateLimitedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session_rate_limited_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionRateLimitedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionRateLimitedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionRateLimitedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsSessionRateLimitedRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsSessionRateLimitedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSessionRateLimitedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionRateLimitedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionRateLimitedRunError.FromRawUnchecked(rawData);
}
