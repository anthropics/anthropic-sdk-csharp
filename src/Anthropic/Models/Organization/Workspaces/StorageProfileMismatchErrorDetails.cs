using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The Workspace's storage and its user profile don't match: the Workspace and its
/// storage must have the same user profile, or both have none.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        StorageProfileMismatchErrorDetails,
        StorageProfileMismatchErrorDetailsFromRaw
    >)
)]
public sealed record class StorageProfileMismatchErrorDetails : JsonModel
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
    /// The storage setting that doesn't match the Workspace's user profile.
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
                JsonSerializer.SerializeToElement("storage_profile_mismatch")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Field;
    }

    public StorageProfileMismatchErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("storage_profile_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StorageProfileMismatchErrorDetails(
        StorageProfileMismatchErrorDetails storageProfileMismatchErrorDetails
    )
        : base(storageProfileMismatchErrorDetails) { }
#pragma warning restore CS8618

    public StorageProfileMismatchErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("storage_profile_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StorageProfileMismatchErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StorageProfileMismatchErrorDetailsFromRaw.FromRawUnchecked"/>
    public static StorageProfileMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public StorageProfileMismatchErrorDetails(string field)
        : this()
    {
        this.Field = field;
    }
}

class StorageProfileMismatchErrorDetailsFromRaw : IFromRawJson<StorageProfileMismatchErrorDetails>
{
    /// <inheritdoc/>
    public StorageProfileMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StorageProfileMismatchErrorDetails.FromRawUnchecked(rawData);
}
