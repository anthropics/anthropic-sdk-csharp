using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// Read one message that Anthropic flagged for your organization to review, with
/// its request and response.
///
/// <para>A message that the API key can't read, or that isn't flagged, returns the
/// same 404 as one that doesn't exist. For a message recorded with a user profile,
/// send that profile's ID in the `anthropic-user-profile-id` header. A flagged message
/// can also return 404 if it belongs to another organization than the key's own,
/// or to your end customer's user profile or Workspace.</para>
///
/// <para>If your encryption key or storage bucket refuses the read, the API returns
/// a 400 with `cmek_key_disabled`, `storage_bucket_unreadable` or `customer_storage_refusal_unattributed`
/// in `error.details.error_code`.</para>
///
/// <para>The API key must have the `read:compliance_review_items`, `read:compliance_user_data`
/// or `read:org_audit` scope. A key of an organization with no parent organization
/// must have `read:compliance_review_items`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ItemRetrieveParams : ParamsBase
{
    public string? ItemID { get; init; }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                this._rawHeaderData.Remove("anthropic-beta");
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The ID of the user profile that the message was recorded with (`uprof_...`).
    /// Send it for a message recorded with a user profile, and leave it out for
    /// a message recorded with none.
    /// </summary>
    public string? UserProfileID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("anthropic-user-profile-id");
        }
        init
        {
            if (value == null)
            {
                this._rawHeaderData.Remove("anthropic-user-profile-id");
                return;
            }

            this._rawHeaderData.Set("anthropic-user-profile-id", value);
        }
    }

    public ItemRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ItemRetrieveParams(ItemRetrieveParams itemRetrieveParams)
        : base(itemRetrieveParams)
    {
        this.ItemID = itemRetrieveParams.ItemID;
    }
#pragma warning restore CS8618

    public ItemRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string itemID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ItemID = itemID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ItemRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string itemID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            itemID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ItemID"] = JsonSerializer.SerializeToElement(this.ItemID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ItemRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ItemID?.Equals(other.ItemID) ?? other.ItemID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/compliance/review/items/{0}",
                    ParamsBase.EncodePathSegment(this.ItemID, nameof(this.ItemID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/compliance/review/items/{item_id}";

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
