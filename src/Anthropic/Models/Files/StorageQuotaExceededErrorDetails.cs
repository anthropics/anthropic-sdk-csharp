using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Files;

/// <summary>
/// The organization's file storage quota is exhausted. Delete files to free up space,
/// then retry the upload.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StorageQuotaExceededErrorDetails,
        StorageQuotaExceededErrorDetailsFromRaw
    >)
)]
public sealed record class StorageQuotaExceededErrorDetails : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("storage_quota_exceeded")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public StorageQuotaExceededErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("storage_quota_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StorageQuotaExceededErrorDetails(
        StorageQuotaExceededErrorDetails storageQuotaExceededErrorDetails
    )
        : base(storageQuotaExceededErrorDetails) { }
#pragma warning restore CS8618

    public StorageQuotaExceededErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("storage_quota_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StorageQuotaExceededErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StorageQuotaExceededErrorDetailsFromRaw.FromRawUnchecked"/>
    public static StorageQuotaExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StorageQuotaExceededErrorDetailsFromRaw : IFromRawJson<StorageQuotaExceededErrorDetails>
{
    /// <inheritdoc/>
    public StorageQuotaExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StorageQuotaExceededErrorDetails.FromRawUnchecked(rawData);
}
