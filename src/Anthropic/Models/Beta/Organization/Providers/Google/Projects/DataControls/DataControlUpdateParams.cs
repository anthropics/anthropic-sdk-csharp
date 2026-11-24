using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Providers.Google.Projects;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// Turn a control on or off, or change the key or bucket set for a region. Controls
/// and regions that you leave out stay as they are.
///
/// <para>Your organization must have proved that it owns the project. Only one organization
/// at a time can have controls turned on for a project.</para>
///
/// <para>**Requires a credential that identifies a user or a service account**: an
/// OAuth access token with the `org:admin` scope, or an organization-scoped API key
/// that belongs to a user or service account whose organization role can update these
/// controls. The `admin`, `owner` and `primary_owner` roles can. An Admin API key
/// gets a `403` error.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DataControlUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ProjectNumber { get; init; }

    /// <summary>
    /// The customer-managed encryption key control. Leave it out to keep the control
    /// as it is. Send `cmek`, `storage`, or both.
    /// </summary>
    public BetaGoogleManagedProjectCmekControlParams? Cmek
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaGoogleManagedProjectCmekControlParams>(
                "cmek"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("cmek");
                return;
            }

            this._rawBodyData.Set("cmek", value);
        }
    }

    /// <summary>
    /// The customer-owned storage control. Leave it out to keep the control as it
    /// is. Send `cmek`, `storage`, or both.
    /// </summary>
    public BetaGoogleManagedProjectStorageControlParams? Storage
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaGoogleManagedProjectStorageControlParams>(
                "storage"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("storage");
                return;
            }

            this._rawBodyData.Set("storage", value);
        }
    }

    /// <summary>
    /// This endpoint is in beta: requests must send `google-managed-data-controls-2026-09-01`
    /// in this header.
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

    public DataControlUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataControlUpdateParams(DataControlUpdateParams dataControlUpdateParams)
        : base(dataControlUpdateParams)
    {
        this.ProjectNumber = dataControlUpdateParams.ProjectNumber;

        this._rawBodyData = new(dataControlUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public DataControlUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataControlUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string projectNumber
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ProjectNumber = projectNumber;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DataControlUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string projectNumber
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            projectNumber
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ProjectNumber"] = JsonSerializer.SerializeToElement(this.ProjectNumber),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(DataControlUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ProjectNumber?.Equals(other.ProjectNumber) ?? other.ProjectNumber == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/providers/google/projects/{0}/data_controls",
                    ParamsBase.EncodePathSegment(this.ProjectNumber, nameof(this.ProjectNumber))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route =>
        "/v1/organizations/providers/google/projects/{project_number}/data_controls";

    internal override HttpContent? BodyContent()
    {
        return ParamsBase.JsonBodyContent(this.RawBodyData);
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        DataControlService.AddDefaultHeaders(request);
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
