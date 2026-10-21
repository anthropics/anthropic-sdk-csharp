using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// A vault referenced by the deployment is archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsVaultArchivedRunError,
        BetaManagedAgentsVaultArchivedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsVaultArchivedRunError : JsonModel
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
                JsonSerializer.SerializeToElement("vault_archived_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsVaultArchivedRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("vault_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsVaultArchivedRunError(
        BetaManagedAgentsVaultArchivedRunError betaManagedAgentsVaultArchivedRunError
    )
        : base(betaManagedAgentsVaultArchivedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsVaultArchivedRunError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("vault_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsVaultArchivedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsVaultArchivedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsVaultArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsVaultArchivedRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsVaultArchivedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsVaultArchivedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsVaultArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsVaultArchivedRunError.FromRawUnchecked(rawData);
}
