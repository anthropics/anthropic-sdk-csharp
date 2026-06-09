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
/// The deployment's organization is disabled.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsOrganizationDisabledRunError,
        BetaManagedAgentsOrganizationDisabledRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsOrganizationDisabledRunError : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsOrganizationDisabledRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsOrganizationDisabledRunErrorType>
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

    public BetaManagedAgentsOrganizationDisabledRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsOrganizationDisabledRunError(
        BetaManagedAgentsOrganizationDisabledRunError betaManagedAgentsOrganizationDisabledRunError
    )
        : base(betaManagedAgentsOrganizationDisabledRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsOrganizationDisabledRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsOrganizationDisabledRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsOrganizationDisabledRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsOrganizationDisabledRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsOrganizationDisabledRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsOrganizationDisabledRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsOrganizationDisabledRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsOrganizationDisabledRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsOrganizationDisabledRunErrorTypeConverter))]
public enum BetaManagedAgentsOrganizationDisabledRunErrorType
{
    OrganizationDisabledError,
}

sealed class BetaManagedAgentsOrganizationDisabledRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsOrganizationDisabledRunErrorType>
{
    public override BetaManagedAgentsOrganizationDisabledRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "organization_disabled_error" =>
                BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError,
            _ => (BetaManagedAgentsOrganizationDisabledRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsOrganizationDisabledRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError =>
                    "organization_disabled_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
