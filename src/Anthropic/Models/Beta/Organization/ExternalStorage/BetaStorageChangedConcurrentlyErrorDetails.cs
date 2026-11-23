using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// Another request changed this storage setting while this one was running, so this
/// request left it as it is. Read the Workspace and send the request again if you
/// still want the change.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaStorageChangedConcurrentlyErrorDetails,
        BetaStorageChangedConcurrentlyErrorDetailsFromRaw
    >)
)]
public sealed record class BetaStorageChangedConcurrentlyErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// The storage setting that changed.
    /// </summary>
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("storage_changed_concurrently")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Field;
    }

    public BetaStorageChangedConcurrentlyErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("storage_changed_concurrently");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaStorageChangedConcurrentlyErrorDetails(
        BetaStorageChangedConcurrentlyErrorDetails betaStorageChangedConcurrentlyErrorDetails
    )
        : base(betaStorageChangedConcurrentlyErrorDetails) { }
#pragma warning restore CS8618

    public BetaStorageChangedConcurrentlyErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("storage_changed_concurrently");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaStorageChangedConcurrentlyErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaStorageChangedConcurrentlyErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaStorageChangedConcurrentlyErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaStorageChangedConcurrentlyErrorDetails(string field)
        : this()
    {
        this.Field = field;
    }
}

class BetaStorageChangedConcurrentlyErrorDetailsFromRaw
    : IFromRawJson<BetaStorageChangedConcurrentlyErrorDetails>
{
    /// <inheritdoc/>
    public BetaStorageChangedConcurrentlyErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaStorageChangedConcurrentlyErrorDetails.FromRawUnchecked(rawData);
}
