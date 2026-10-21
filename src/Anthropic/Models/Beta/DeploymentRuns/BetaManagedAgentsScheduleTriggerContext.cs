using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// The run was fired by the deployment's cron schedule.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsScheduleTriggerContext,
        BetaManagedAgentsScheduleTriggerContextFromRaw
    >)
)]
public sealed record class BetaManagedAgentsScheduleTriggerContext : JsonModel
{
    /// <summary>
    /// The UTC instant at which the cron expression matched in the configured timezone,
    /// before jitter is applied. At most one run is recorded per (`deployment_id`,
    /// `scheduled_at`) pair.
    /// </summary>
    public required DateTimeOffset ScheduledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("scheduled_at");
        }
        init { this._rawData.Set("scheduled_at", value); }
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
        _ = this.ScheduledAt;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("schedule")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsScheduleTriggerContext()
    {
        this.Type = JsonSerializer.SerializeToElement("schedule");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsScheduleTriggerContext(
        BetaManagedAgentsScheduleTriggerContext betaManagedAgentsScheduleTriggerContext
    )
        : base(betaManagedAgentsScheduleTriggerContext) { }
#pragma warning restore CS8618

    public BetaManagedAgentsScheduleTriggerContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("schedule");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsScheduleTriggerContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsScheduleTriggerContextFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsScheduleTriggerContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsScheduleTriggerContext(DateTimeOffset scheduledAt)
        : this()
    {
        this.ScheduledAt = scheduledAt;
    }
}

class BetaManagedAgentsScheduleTriggerContextFromRaw
    : IFromRawJson<BetaManagedAgentsScheduleTriggerContext>
{
    /// <inheritdoc/>
    public BetaManagedAgentsScheduleTriggerContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsScheduleTriggerContext.FromRawUnchecked(rawData);
}
