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
/// The deployment configures resources, but its environment is self-hosted and cannot
/// mount them.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError,
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError
    : JsonModel
{
    public required ApiEnum<
        string,
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType
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

    public BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError(
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError betaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError
    )
        : base(betaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError(
        ApiEnum<
            string,
            BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType
        > type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorTypeConverter)
)]
public enum BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType
{
    SelfHostedResourcesUnsupportedError,
}

sealed class BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "self_hosted_resources_unsupported_error" =>
                BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType.SelfHostedResourcesUnsupportedError,
            _ => (BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType.SelfHostedResourcesUnsupportedError =>
                    "self_hosted_resources_unsupported_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
