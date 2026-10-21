using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Updated injection location.
    /// </summary>
    public BetaManagedAgentsInjectionLocationUpdateParams? InjectionLocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsInjectionLocationUpdateParams>(
                "injection_location"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("injection_location");
                return;
            }

            this._rawData.Set("injection_location", value);
        }
    }

    /// <summary>
    /// The new networking scope, which replaces the stored one as a whole.
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
    /// The new secret value to replace the stored one.
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("environment_variable")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.InjectionLocation?.Validate();
        this.Networking?.Validate();
        _ = this.SecretValue;
    }

    public BetaManagedAgentsEnvironmentVariableUpdateParams()
    {
        this.Type = JsonSerializer.SerializeToElement("environment_variable");
    }

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

        this.Type = JsonSerializer.SerializeToElement("environment_variable");
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
}

class BetaManagedAgentsEnvironmentVariableUpdateParamsFromRaw
    : IFromRawJson<BetaManagedAgentsEnvironmentVariableUpdateParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEnvironmentVariableUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEnvironmentVariableUpdateParams.FromRawUnchecked(rawData);
}
