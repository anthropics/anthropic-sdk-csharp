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
/// Parameters for creating an environment variable credential.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsEnvironmentVariableCreateParams,
        BetaManagedAgentsEnvironmentVariableCreateParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsEnvironmentVariableCreateParams : JsonModel
{
    /// <summary>
    /// Outbound hosts the secret value is substituted on.
    /// </summary>
    public required BetaManagedAgentsCredentialNetworkingParams Networking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsCredentialNetworkingParams>(
                "networking"
            );
        }
        init { this._rawData.Set("networking", value); }
    }

    /// <summary>
    /// Name of the environment variable. Immutable after create.
    /// </summary>
    public required string SecretName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secret_name");
        }
        init { this._rawData.Set("secret_name", value); }
    }

    /// <summary>
    /// Secret value. Write-only; never returned in responses.
    /// </summary>
    public required string SecretValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secret_value");
        }
        init { this._rawData.Set("secret_value", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsEnvironmentVariableCreateParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsEnvironmentVariableCreateParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Where in the outbound request the secret value may be substituted.
    /// </summary>
    public BetaManagedAgentsInjectionLocationParams? InjectionLocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsInjectionLocationParams>(
                "injection_location"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("injection_location", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Networking.Validate();
        _ = this.SecretName;
        _ = this.SecretValue;
        this.Type.Validate();
        this.InjectionLocation?.Validate();
    }

    public BetaManagedAgentsEnvironmentVariableCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentVariableCreateParams(
        BetaManagedAgentsEnvironmentVariableCreateParams betaManagedAgentsEnvironmentVariableCreateParams
    )
        : base(betaManagedAgentsEnvironmentVariableCreateParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEnvironmentVariableCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEnvironmentVariableCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEnvironmentVariableCreateParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEnvironmentVariableCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsEnvironmentVariableCreateParamsFromRaw
    : IFromRawJson<BetaManagedAgentsEnvironmentVariableCreateParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEnvironmentVariableCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEnvironmentVariableCreateParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsEnvironmentVariableCreateParamsTypeConverter))]
public enum BetaManagedAgentsEnvironmentVariableCreateParamsType
{
    EnvironmentVariable,
}

sealed class BetaManagedAgentsEnvironmentVariableCreateParamsTypeConverter
    : JsonConverter<BetaManagedAgentsEnvironmentVariableCreateParamsType>
{
    public override BetaManagedAgentsEnvironmentVariableCreateParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "environment_variable" =>
                BetaManagedAgentsEnvironmentVariableCreateParamsType.EnvironmentVariable,
            _ => (BetaManagedAgentsEnvironmentVariableCreateParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEnvironmentVariableCreateParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEnvironmentVariableCreateParamsType.EnvironmentVariable =>
                    "environment_variable",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
