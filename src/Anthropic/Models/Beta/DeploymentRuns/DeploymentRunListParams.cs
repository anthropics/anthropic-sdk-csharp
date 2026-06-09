using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// List Deployment Runs
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DeploymentRunListParams : ParamsBase
{
    /// <summary>
    /// Return runs created strictly after this time (exclusive).
    /// </summary>
    public DateTimeOffset? CreatedAtGt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[gt]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at[gt]", value);
        }
    }

    /// <summary>
    /// Return runs created at or after this time (inclusive).
    /// </summary>
    public DateTimeOffset? CreatedAtGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[gte]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at[gte]", value);
        }
    }

    /// <summary>
    /// Return runs created strictly before this time (exclusive).
    /// </summary>
    public DateTimeOffset? CreatedAtLt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[lt]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at[lt]", value);
        }
    }

    /// <summary>
    /// Return runs created at or before this time (inclusive).
    /// </summary>
    public DateTimeOffset? CreatedAtLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[lte]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at[lte]", value);
        }
    }

    /// <summary>
    /// Filter to a specific deployment. Omit to list across all deployments in the
    /// workspace. Filtering by a non-existent deployment_id returns 200 with empty data.
    /// </summary>
    public string? DeploymentID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("deployment_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("deployment_id", value);
        }
    }

    /// <summary>
    /// Filter: true for runs with non-null error, false for runs with non-null session_id.
    /// Omit for all.
    /// </summary>
    public bool? HasError
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("has_error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("has_error", value);
        }
    }

    /// <summary>
    /// Maximum results per page. Default 20, maximum 1000.
    /// </summary>
    public int? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Opaque pagination cursor. Pass next_page from the previous response. Invalid
    /// or expired cursors return 400.
    /// </summary>
    public string? Page
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page", value);
        }
    }

    /// <summary>
    /// Filter runs by what triggered them. Omit to return all runs.
    /// </summary>
    public ApiEnum<string, BetaManagedAgentsTriggerType>? TriggerType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, BetaManagedAgentsTriggerType>
            >("trigger_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("trigger_type", value);
        }
    }

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
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public DeploymentRunListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeploymentRunListParams(DeploymentRunListParams deploymentRunListParams)
        : base(deploymentRunListParams) { }
#pragma warning restore CS8618

    public DeploymentRunListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeploymentRunListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DeploymentRunListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(DeploymentRunListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/deployment_runs")
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        DeploymentRunService.AddDefaultHeaders(request);
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
