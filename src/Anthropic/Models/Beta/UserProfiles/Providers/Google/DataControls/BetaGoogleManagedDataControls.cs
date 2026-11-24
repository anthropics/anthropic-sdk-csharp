using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// A user profile's encryption key and storage bucket settings for Claude on Google
/// Cloud's Agent Platform. Every user profile has one of these objects. You can
/// read and update it, but not create or delete it. Keys and buckets are set for
/// each region. A request's region depends on the Google endpoint it is sent to:
/// `us` is the US multi-region endpoint and the regional endpoint of every location
/// whose name starts with `us-`, `eu` is the EU multi-region endpoint and the regional
/// endpoint of every location whose name starts with `europe-`, `sg` is the `asia-southeast1`
/// regional endpoint, and `global` is the global endpoint, wherever Google serves
/// the request. Anthropic may add regions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaGoogleManagedDataControls, BetaGoogleManagedDataControlsFromRaw>)
)]
public sealed record class BetaGoogleManagedDataControls : JsonModel
{
    /// <summary>
    /// The label value that every bucket set up for this profile must have. It never changes.
    /// </summary>
    public required string BucketLabelValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bucket_label_value");
        }
        init { this._rawData.Set("bucket_label_value", value); }
    }

    /// <summary>
    /// The customer-managed encryption key control: the key in the end customer's
    /// Google Cloud KMS that is set for each region.
    /// </summary>
    public required BetaGoogleManagedCmekControl Cmek
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaGoogleManagedCmekControl>("cmek");
        }
        init { this._rawData.Set("cmek", value); }
    }

    /// <summary>
    /// The customer-owned storage control: the end customer's Cloud Storage bucket
    /// that is set for each region.
    /// </summary>
    public required BetaGoogleManagedStorageControl Storage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaGoogleManagedStorageControl>("storage");
        }
        init { this._rawData.Set("storage", value); }
    }

    /// <summary>
    /// Object type. Always `google_managed_data_controls`.
    /// </summary>
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
    /// When an update last changed a control, or a region's status last changed,
    /// in RFC 3339 format. A region that starts or stops reading `suspended`, a
    /// change to `last_checked_at` alone, and the removal of a retired entry do
    /// not count.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// The ID of the user profile that these controls belong to (`uprof_...`).
    /// </summary>
    public required string UserProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_profile_id");
        }
        init { this._rawData.Set("user_profile_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BucketLabelValue;
        this.Cmek.Validate();
        this.Storage.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("google_managed_data_controls")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        _ = this.UserProfileID;
    }

    public BetaGoogleManagedDataControls()
    {
        this.Type = JsonSerializer.SerializeToElement("google_managed_data_controls");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedDataControls(
        BetaGoogleManagedDataControls betaGoogleManagedDataControls
    )
        : base(betaGoogleManagedDataControls) { }
#pragma warning restore CS8618

    public BetaGoogleManagedDataControls(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("google_managed_data_controls");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedDataControls(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedDataControlsFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedDataControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedDataControlsFromRaw : IFromRawJson<BetaGoogleManagedDataControls>
{
    /// <inheritdoc/>
    public BetaGoogleManagedDataControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedDataControls.FromRawUnchecked(rawData);
}
