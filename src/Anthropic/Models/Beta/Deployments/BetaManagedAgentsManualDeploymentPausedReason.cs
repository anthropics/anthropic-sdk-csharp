using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// The caller invoked the pause endpoint on the deployment.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsManualDeploymentPausedReason,
        BetaManagedAgentsManualDeploymentPausedReasonFromRaw
    >)
)]
public sealed record class BetaManagedAgentsManualDeploymentPausedReason : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsManualDeploymentPausedReasonType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsManualDeploymentPausedReasonType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsManualDeploymentPausedReason() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsManualDeploymentPausedReason(
        BetaManagedAgentsManualDeploymentPausedReason betaManagedAgentsManualDeploymentPausedReason
    )
        : base(betaManagedAgentsManualDeploymentPausedReason) { }
#pragma warning restore CS8618

    public BetaManagedAgentsManualDeploymentPausedReason(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsManualDeploymentPausedReason(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsManualDeploymentPausedReasonFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsManualDeploymentPausedReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsManualDeploymentPausedReason(
        ApiEnum<string, BetaManagedAgentsManualDeploymentPausedReasonType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsManualDeploymentPausedReasonFromRaw
    : IFromRawJson<BetaManagedAgentsManualDeploymentPausedReason>
{
    /// <inheritdoc/>
    public BetaManagedAgentsManualDeploymentPausedReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsManualDeploymentPausedReason.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsManualDeploymentPausedReasonTypeConverter))]
public enum BetaManagedAgentsManualDeploymentPausedReasonType
{
    Manual,
}

sealed class BetaManagedAgentsManualDeploymentPausedReasonTypeConverter
    : JsonConverter<BetaManagedAgentsManualDeploymentPausedReasonType>
{
    public override BetaManagedAgentsManualDeploymentPausedReasonType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "manual" => BetaManagedAgentsManualDeploymentPausedReasonType.Manual,
            _ => (BetaManagedAgentsManualDeploymentPausedReasonType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsManualDeploymentPausedReasonType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsManualDeploymentPausedReasonType.Manual => "manual",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
