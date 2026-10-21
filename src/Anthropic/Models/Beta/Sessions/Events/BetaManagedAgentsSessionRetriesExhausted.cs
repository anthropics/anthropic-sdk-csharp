using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The turn ended because repeated errors exhausted the retry budget or an error
/// escalated to `retry_status: 'exhausted'`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionRetriesExhausted,
        BetaManagedAgentsSessionRetriesExhaustedFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionRetriesExhausted : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("retries_exhausted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionRetriesExhausted()
    {
        this.Type = JsonSerializer.SerializeToElement("retries_exhausted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionRetriesExhausted(
        BetaManagedAgentsSessionRetriesExhausted betaManagedAgentsSessionRetriesExhausted
    )
        : base(betaManagedAgentsSessionRetriesExhausted) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionRetriesExhausted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("retries_exhausted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionRetriesExhausted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionRetriesExhaustedFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionRetriesExhausted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionRetriesExhaustedFromRaw
    : IFromRawJson<BetaManagedAgentsSessionRetriesExhausted>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionRetriesExhausted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionRetriesExhausted.FromRawUnchecked(rawData);
}
