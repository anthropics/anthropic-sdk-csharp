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
/// The deployment configures resources, but its environment is self-hosted and cannot
/// mount them.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunError,
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSelfHostedResourcesUnsupportedRunError : JsonModel
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

    public required ApiEnum<
        string,
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.Type.Validate();
    }

    public BetaManagedAgentsSelfHostedResourcesUnsupportedRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSelfHostedResourcesUnsupportedRunError(
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunError betaManagedAgentsSelfHostedResourcesUnsupportedRunError
    )
        : base(betaManagedAgentsSelfHostedResourcesUnsupportedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSelfHostedResourcesUnsupportedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSelfHostedResourcesUnsupportedRunError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSelfHostedResourcesUnsupportedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSelfHostedResourcesUnsupportedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSelfHostedResourcesUnsupportedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSelfHostedResourcesUnsupportedRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorTypeConverter))]
public enum BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType
{
    SelfHostedResourcesUnsupportedError,
}

sealed class BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType>
{
    public override BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "self_hosted_resources_unsupported_error" =>
                BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError,
            _ => (BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError =>
                    "self_hosted_resources_unsupported_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
