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
/// A vault referenced by the deployment no longer exists.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsVaultNotFoundRunError,
        BetaManagedAgentsVaultNotFoundRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsVaultNotFoundRunError : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsVaultNotFoundRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsVaultNotFoundRunErrorType>
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

    public BetaManagedAgentsVaultNotFoundRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsVaultNotFoundRunError(
        BetaManagedAgentsVaultNotFoundRunError betaManagedAgentsVaultNotFoundRunError
    )
        : base(betaManagedAgentsVaultNotFoundRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsVaultNotFoundRunError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsVaultNotFoundRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsVaultNotFoundRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsVaultNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsVaultNotFoundRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsVaultNotFoundRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsVaultNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsVaultNotFoundRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsVaultNotFoundRunErrorTypeConverter))]
public enum BetaManagedAgentsVaultNotFoundRunErrorType
{
    VaultNotFoundError,
}

sealed class BetaManagedAgentsVaultNotFoundRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsVaultNotFoundRunErrorType>
{
    public override BetaManagedAgentsVaultNotFoundRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vault_not_found_error" =>
                BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError,
            _ => (BetaManagedAgentsVaultNotFoundRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsVaultNotFoundRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError =>
                    "vault_not_found_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
