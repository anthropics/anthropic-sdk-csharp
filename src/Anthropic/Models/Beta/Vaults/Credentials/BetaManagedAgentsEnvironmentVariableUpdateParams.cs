using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Parameters for updating an environment variable credential. `secret_name` is immutable.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsEnvironmentVariableUpdateParams,
        BetaManagedAgentsEnvironmentVariableUpdateParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsEnvironmentVariableUpdateParams : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsEnvironmentVariableUpdateParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsEnvironmentVariableUpdateParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Updated networking scope. Full replacement.
    /// </summary>
    public BetaManagedAgentsCredentialNetworkingParams? Networking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsCredentialNetworkingParams>(
                "networking"
            );
        }
        init { this._rawData.Set("networking", value); }
    }

    /// <summary>
    /// Updated secret value.
    /// </summary>
    public string? SecretValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("secret_value");
        }
        init { this._rawData.Set("secret_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Networking?.Validate();
        _ = this.SecretValue;
    }

    public BetaManagedAgentsEnvironmentVariableUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentVariableUpdateParams(
        BetaManagedAgentsEnvironmentVariableUpdateParams betaManagedAgentsEnvironmentVariableUpdateParams
    )
        : base(betaManagedAgentsEnvironmentVariableUpdateParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEnvironmentVariableUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEnvironmentVariableUpdateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEnvironmentVariableUpdateParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEnvironmentVariableUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentVariableUpdateParams(
        ApiEnum<string, BetaManagedAgentsEnvironmentVariableUpdateParamsType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsEnvironmentVariableUpdateParamsFromRaw
    : IFromRawJson<BetaManagedAgentsEnvironmentVariableUpdateParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEnvironmentVariableUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEnvironmentVariableUpdateParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsEnvironmentVariableUpdateParamsTypeConverter))]
public enum BetaManagedAgentsEnvironmentVariableUpdateParamsType
{
    EnvironmentVariable,
}

sealed class BetaManagedAgentsEnvironmentVariableUpdateParamsTypeConverter
    : JsonConverter<BetaManagedAgentsEnvironmentVariableUpdateParamsType>
{
    public override BetaManagedAgentsEnvironmentVariableUpdateParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "environment_variable" =>
                BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable,
            _ => (BetaManagedAgentsEnvironmentVariableUpdateParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEnvironmentVariableUpdateParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable =>
                    "environment_variable",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
