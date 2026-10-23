using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// Change a telemetry destination's settings, its state, or which workspaces it covers.
///
/// <para>Send at least one field. Omitted fields keep their stored values, except
/// the registered headers, which a change of the endpoint's hostname or port removes.
/// Only `display_name`, `traces`, `traces.endpoint_url`, `traces.content_mode`,
/// `traces.max_content_bytes`, and individual `headers` values accept `null`.</para>
///
/// <para>If another request changes the destination while the update runs, the API
/// returns a 409 `conflict_error`. Read the destination again, then retry the update.</para>
///
/// <para>See the [OpenTelemetry export guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#delivery-and-health)
/// to learn more about changing a destination.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TelemetryDestinationUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? DestinationID { get; init; }

    /// <summary>
    /// New human-readable name, 1 to 255 characters. Null clears it.
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("display_name");
        }
        init { this._rawBodyData.Set("display_name", value); }
    }

    /// <summary>
    /// The new base URL of the destination's OTLP/HTTP endpoint. The same rules
    /// as on create apply.
    ///
    /// <para>A change of hostname or port first removes every registered header,
    /// so send the headers for the new endpoint in the same request. When the destination
    /// has a `traces.endpoint_url`, such a change must also set `traces.endpoint_url`
    /// to a URL with the new hostname and port, or to `null`. A change of the path
    /// alone keeps the headers.</para>
    /// </summary>
    public string? EndpointUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("endpoint_url");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("endpoint_url");
                return;
            }

            this._rawBodyData.Set("endpoint_url", value);
        }
    }

    /// <summary>
    /// Headers to set or remove. The API merges them into the destination's headers
    /// by name.
    ///
    /// <para>Names compare case-insensitively. A string value sets or replaces that
    /// header. A `null` value removes it. Headers that you omit don't change. The
    /// field itself can't be `null`.</para>
    ///
    /// <para>A request that sets a header value must also include `endpoint_url`.
    /// The current URL is accepted.</para>
    ///
    /// <para>The resulting set must stay within the same limits as on create. When
    /// the request sets a value, each stored value that it doesn't set counts as
    /// 4,096 bytes toward the 16,384-byte limit, because you can't read its real
    /// length. So to change one header of a destination that has four or more other
    /// headers, send the values of the others again in the same request.</para>
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Headers
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string?>>("headers");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string?>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether the destination receives deliveries after the update. The field can't
    /// be `null`.
    /// </summary>
    public BetaTelemetryDestinationStateParams? State
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaTelemetryDestinationStateParams>("state");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("state");
                return;
            }

            this._rawBodyData.Set("state", value);
        }
    }

    /// <summary>
    /// The traces settings to change. Omitted settings keep their stored values.
    ///
    /// <para>`null` sets every traces setting to its create default.</para>
    /// </summary>
    public BetaTelemetryDestinationTracesParams? Traces
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaTelemetryDestinationTracesParams>(
                "traces"
            );
        }
        init { this._rawBodyData.Set("traces", value); }
    }

    /// <summary>
    /// The new workspace scope, in the same form as on create. The field can't be `null`.
    ///
    /// <para>The API refuses an update that changes the type or sends `workspace_ids`
    /// while the destination's list has more than 750 workspaces. Remove workspaces
    /// one at a time until 750 or fewer remain, then send the update again.</para>
    /// </summary>
    public BetaTelemetryDestinationWorkspacesParams? Workspaces
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaTelemetryDestinationWorkspacesParams>(
                "workspaces"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("workspaces");
                return;
            }

            this._rawBodyData.Set("workspaces", value);
        }
    }

    /// <summary>
    /// This endpoint is in beta: requests must send `telemetry-destinations-2026-08-11`
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

    public TelemetryDestinationUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelemetryDestinationUpdateParams(
        TelemetryDestinationUpdateParams telemetryDestinationUpdateParams
    )
        : base(telemetryDestinationUpdateParams)
    {
        this.DestinationID = telemetryDestinationUpdateParams.DestinationID;

        this._rawBodyData = new(telemetryDestinationUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TelemetryDestinationUpdateParams(
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
    TelemetryDestinationUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string destinationID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.DestinationID = destinationID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TelemetryDestinationUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string destinationID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            destinationID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["DestinationID"] = JsonSerializer.SerializeToElement(this.DestinationID),
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

    public virtual bool Equals(TelemetryDestinationUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.DestinationID?.Equals(other.DestinationID) ?? other.DestinationID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/telemetry_destinations/{0}",
                    ParamsBase.EncodePathSegment(this.DestinationID, nameof(this.DestinationID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/organizations/telemetry_destinations/{destination_id}";

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        TelemetryDestinationService.AddDefaultHeaders(request);
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
