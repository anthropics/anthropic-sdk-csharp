using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
    /// The secret to substitute into the agent's outbound requests. It's write-only
    /// and never returned in responses.
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
                this._rawData.Remove("injection_location");
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
    }

    public BetaManagedAgentsEnvironmentVariableCreateParams()
    {
        this.Type = JsonSerializer.SerializeToElement("environment_variable");
    }

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

        this.Type = JsonSerializer.SerializeToElement("environment_variable");
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
