using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Parameters for sending an interrupt to pause the agent.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserInterruptEventParams,
        BetaManagedAgentsUserInterruptEventParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserInterruptEventParams : JsonModel
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
    /// If absent, interrupts every non-archived thread in a multiagent session (or
    /// the primary alone in a single-agent session). If present, interrupts only
    /// the named thread.
    /// </summary>
    public string? SessionThreadID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("session_thread_id");
        }
        init { this._rawData.Set("session_thread_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user.interrupt")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.SessionThreadID;
    }

    public BetaManagedAgentsUserInterruptEventParams()
    {
        this.Type = JsonSerializer.SerializeToElement("user.interrupt");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserInterruptEventParams(
        BetaManagedAgentsUserInterruptEventParams betaManagedAgentsUserInterruptEventParams
    )
        : base(betaManagedAgentsUserInterruptEventParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserInterruptEventParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user.interrupt");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserInterruptEventParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserInterruptEventParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserInterruptEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserInterruptEventParamsFromRaw
    : IFromRawJson<BetaManagedAgentsUserInterruptEventParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserInterruptEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserInterruptEventParams.FromRawUnchecked(rawData);
}
