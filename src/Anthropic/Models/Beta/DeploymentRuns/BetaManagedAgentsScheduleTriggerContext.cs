using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset ScheduledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("scheduled_at");
        }
        init { this._rawData.Set("scheduled_at", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsScheduleTriggerContextType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsScheduleTriggerContextType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ScheduledAt;
        this.Type.Validate();
    }

    public BetaManagedAgentsScheduleTriggerContext() { }

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
}

class BetaManagedAgentsScheduleTriggerContextFromRaw
    : IFromRawJson<BetaManagedAgentsScheduleTriggerContext>
{
    /// <inheritdoc/>
    public BetaManagedAgentsScheduleTriggerContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsScheduleTriggerContext.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsScheduleTriggerContextTypeConverter))]
public enum BetaManagedAgentsScheduleTriggerContextType
{
    Schedule,
}

sealed class BetaManagedAgentsScheduleTriggerContextTypeConverter
    : JsonConverter<BetaManagedAgentsScheduleTriggerContextType>
{
    public override BetaManagedAgentsScheduleTriggerContextType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "schedule" => BetaManagedAgentsScheduleTriggerContextType.Schedule,
            _ => (BetaManagedAgentsScheduleTriggerContextType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsScheduleTriggerContextType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsScheduleTriggerContextType.Schedule => "schedule",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
