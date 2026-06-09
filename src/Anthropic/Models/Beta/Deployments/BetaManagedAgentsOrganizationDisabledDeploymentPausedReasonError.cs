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
/// The deployment's organization is disabled.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError,
        BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError
    : JsonModel
{
    public required ApiEnum<
        string,
        BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError(
        BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError betaManagedAgentsOrganizationDisabledDeploymentPausedReasonError
    )
        : base(betaManagedAgentsOrganizationDisabledDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError(
        ApiEnum<string, BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorTypeConverter)
)]
public enum BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType
{
    OrganizationDisabledError,
}

sealed class BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "organization_disabled_error" =>
                BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType.OrganizationDisabledError,
            _ => (BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType.OrganizationDisabledError =>
                    "organization_disabled_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
