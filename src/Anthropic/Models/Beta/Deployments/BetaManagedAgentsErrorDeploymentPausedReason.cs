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
/// A scheduled fire recorded a failed run whose error auto-pauses the deployment.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsErrorDeploymentPausedReason,
        BetaManagedAgentsErrorDeploymentPausedReasonFromRaw
    >)
)]
public sealed record class BetaManagedAgentsErrorDeploymentPausedReason : JsonModel
{
    /// <summary>
    /// The error that triggered an auto-pause. Matches the failed run's `error.type`.
    /// </summary>
    public required BetaManagedAgentsDeploymentPausedReasonError Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsDeploymentPausedReasonError>(
                "error"
            );
        }
        init { this._rawData.Set("error", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsErrorDeploymentPausedReasonType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsErrorDeploymentPausedReasonType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Error.Validate();
        this.Type.Validate();
    }

    public BetaManagedAgentsErrorDeploymentPausedReason() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsErrorDeploymentPausedReason(
        BetaManagedAgentsErrorDeploymentPausedReason betaManagedAgentsErrorDeploymentPausedReason
    )
        : base(betaManagedAgentsErrorDeploymentPausedReason) { }
#pragma warning restore CS8618

    public BetaManagedAgentsErrorDeploymentPausedReason(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsErrorDeploymentPausedReason(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsErrorDeploymentPausedReasonFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsErrorDeploymentPausedReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsErrorDeploymentPausedReasonFromRaw
    : IFromRawJson<BetaManagedAgentsErrorDeploymentPausedReason>
{
    /// <inheritdoc/>
    public BetaManagedAgentsErrorDeploymentPausedReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsErrorDeploymentPausedReason.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsErrorDeploymentPausedReasonTypeConverter))]
public enum BetaManagedAgentsErrorDeploymentPausedReasonType
{
    Error,
}

sealed class BetaManagedAgentsErrorDeploymentPausedReasonTypeConverter
    : JsonConverter<BetaManagedAgentsErrorDeploymentPausedReasonType>
{
    public override BetaManagedAgentsErrorDeploymentPausedReasonType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "error" => BetaManagedAgentsErrorDeploymentPausedReasonType.Error,
            _ => (BetaManagedAgentsErrorDeploymentPausedReasonType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsErrorDeploymentPausedReasonType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsErrorDeploymentPausedReasonType.Error => "error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
