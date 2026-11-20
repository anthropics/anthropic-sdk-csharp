using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The Workspace was archived, but External Storage was attached to it during the
/// archive and is still attached. To detach it, archive the Workspace again as a
/// caller with the `org:external-storage:use` permission.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StorageAttachedDuringArchiveErrorDetails,
        StorageAttachedDuringArchiveErrorDetailsFromRaw
    >)
)]
public sealed record class StorageAttachedDuringArchiveErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("storage_attached_during_archive")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public StorageAttachedDuringArchiveErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("storage_attached_during_archive");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StorageAttachedDuringArchiveErrorDetails(
        StorageAttachedDuringArchiveErrorDetails storageAttachedDuringArchiveErrorDetails
    )
        : base(storageAttachedDuringArchiveErrorDetails) { }
#pragma warning restore CS8618

    public StorageAttachedDuringArchiveErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("storage_attached_during_archive");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StorageAttachedDuringArchiveErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StorageAttachedDuringArchiveErrorDetailsFromRaw.FromRawUnchecked"/>
    public static StorageAttachedDuringArchiveErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StorageAttachedDuringArchiveErrorDetailsFromRaw
    : IFromRawJson<StorageAttachedDuringArchiveErrorDetails>
{
    /// <inheritdoc/>
    public StorageAttachedDuringArchiveErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StorageAttachedDuringArchiveErrorDetails.FromRawUnchecked(rawData);
}
