using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// A memory store referenced by the deployment is archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMemoryStoreArchivedRunError,
        BetaManagedAgentsMemoryStoreArchivedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMemoryStoreArchivedRunError : JsonModel
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
                JsonSerializer.SerializeToElement("memory_store_archived_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsMemoryStoreArchivedRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("memory_store_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryStoreArchivedRunError(
        BetaManagedAgentsMemoryStoreArchivedRunError betaManagedAgentsMemoryStoreArchivedRunError
    )
        : base(betaManagedAgentsMemoryStoreArchivedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemoryStoreArchivedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("memory_store_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMemoryStoreArchivedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMemoryStoreArchivedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMemoryStoreArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryStoreArchivedRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsMemoryStoreArchivedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsMemoryStoreArchivedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemoryStoreArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemoryStoreArchivedRunError.FromRawUnchecked(rawData);
}
