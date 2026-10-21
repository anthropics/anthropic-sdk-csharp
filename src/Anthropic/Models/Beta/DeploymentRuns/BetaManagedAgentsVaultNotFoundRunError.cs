using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("vault_not_found_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsVaultNotFoundRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("vault_not_found_error");
    }

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

        this.Type = JsonSerializer.SerializeToElement("vault_not_found_error");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsVaultNotFoundRunError(string message)
        : this()
    {
        this.Message = message;
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
