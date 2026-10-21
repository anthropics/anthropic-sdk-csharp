using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// This turn is dead; queued inputs are flushed and the session returns to idle.
/// Client may send a new prompt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsRetryStatusExhausted,
        BetaManagedAgentsRetryStatusExhaustedFromRaw
    >)
)]
public sealed record class BetaManagedAgentsRetryStatusExhausted : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("exhausted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsRetryStatusExhausted()
    {
        this.Type = JsonSerializer.SerializeToElement("exhausted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsRetryStatusExhausted(
        BetaManagedAgentsRetryStatusExhausted betaManagedAgentsRetryStatusExhausted
    )
        : base(betaManagedAgentsRetryStatusExhausted) { }
#pragma warning restore CS8618

    public BetaManagedAgentsRetryStatusExhausted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("exhausted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsRetryStatusExhausted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsRetryStatusExhaustedFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsRetryStatusExhausted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsRetryStatusExhaustedFromRaw
    : IFromRawJson<BetaManagedAgentsRetryStatusExhausted>
{
    /// <inheritdoc/>
    public BetaManagedAgentsRetryStatusExhausted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsRetryStatusExhausted.FromRawUnchecked(rawData);
}
