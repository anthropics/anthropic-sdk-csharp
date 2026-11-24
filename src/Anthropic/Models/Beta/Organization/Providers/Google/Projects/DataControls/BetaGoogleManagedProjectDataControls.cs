using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// A Google Cloud project's encryption key and storage bucket settings for Claude
/// on Google Cloud's Agent Platform. Your organization has one of these objects
/// for each Google Cloud project that it has proved it owns. You can read and update
/// it, but not create or delete it. Keys and buckets are set for each region. A
/// request's region depends on the Google endpoint it is sent to: `us` is the US
/// multi-region endpoint and the regional endpoint of every location whose name
/// starts with `us-`, `eu` is the EU multi-region endpoint and the regional endpoint
/// of every location whose name starts with `europe-`, `sg` is the `asia-southeast1`
/// regional endpoint, and `global` is the global endpoint, wherever Google serves
/// the request. Anthropic may add regions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGoogleManagedProjectDataControls,
        BetaGoogleManagedProjectDataControlsFromRaw
    >)
)]
public sealed record class BetaGoogleManagedProjectDataControls : JsonModel
{
    /// <summary>
    /// The customer-managed encryption key control: the key in your Google Cloud
    /// KMS that is set for each region. It covers the project's requests that name
    /// no user profile, or a user profile that has no key of its own for the project.
    /// </summary>
    public required BetaGoogleManagedProjectCmekControl Cmek
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaGoogleManagedProjectCmekControl>("cmek");
        }
        init { this._rawData.Set("cmek", value); }
    }

    /// <summary>
    /// The number of the Google Cloud project that these controls belong to, in decimal.
    /// </summary>
    public required string ProjectNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_number");
        }
        init { this._rawData.Set("project_number", value); }
    }

    /// <summary>
    /// The customer-owned storage control: your Cloud Storage bucket that is set
    /// for each region. It covers the project's requests that name no user profile,
    /// or a user profile that has no bucket of its own for the project.
    /// </summary>
    public required BetaGoogleManagedProjectStorageControl Storage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaGoogleManagedProjectStorageControl>("storage");
        }
        init { this._rawData.Set("storage", value); }
    }

    /// <summary>
    /// Object type. Always `google_managed_project_data_controls`.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cmek.Validate();
        _ = this.ProjectNumber;
        this.Storage.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("google_managed_project_data_controls")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaGoogleManagedProjectDataControls()
    {
        this.Type = JsonSerializer.SerializeToElement("google_managed_project_data_controls");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGoogleManagedProjectDataControls(
        BetaGoogleManagedProjectDataControls betaGoogleManagedProjectDataControls
    )
        : base(betaGoogleManagedProjectDataControls) { }
#pragma warning restore CS8618

    public BetaGoogleManagedProjectDataControls(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("google_managed_project_data_controls");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGoogleManagedProjectDataControls(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGoogleManagedProjectDataControlsFromRaw.FromRawUnchecked"/>
    public static BetaGoogleManagedProjectDataControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGoogleManagedProjectDataControlsFromRaw
    : IFromRawJson<BetaGoogleManagedProjectDataControls>
{
    /// <inheritdoc/>
    public BetaGoogleManagedProjectDataControls FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGoogleManagedProjectDataControls.FromRawUnchecked(rawData);
}
