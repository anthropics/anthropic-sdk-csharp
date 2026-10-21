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
/// Register an OpenTelemetry destination for the organization.
///
/// <para>The destination starts in state `enabled`. An organization can have at most
/// 10 destinations, including disabled ones.</para>
///
/// <para>See the [OpenTelemetry export guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#add-a-destination)
/// to learn more about adding a destination.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TelemetryDestinationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The base URL of your collector's OTLP/HTTP endpoint, for example `https://gateway.example.com`.
    ///
    /// <para>The URL must use `https` and a hostname, not an IP address. The port,
    /// if given, must be 443. The URL must not contain a query string, a fragment,
    /// or a username and password. At most 2,048 characters.</para>
    ///
    /// <para>A path prefix, such as `/otlp`, is allowed. Don't include the per-signal
    /// path (`/v1/traces`), because the API appends it on delivery. If your collector
    /// takes traces on another path, also set `traces.endpoint_url`.</para>
    /// </summary>
    public required string EndpointUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("endpoint_url");
        }
        init { this._rawBodyData.Set("endpoint_url", value); }
    }

    /// <summary>
    /// Which of the organization's workspaces the destination covers.
    /// </summary>
    public required BetaTelemetryDestinationWorkspacesParams Workspaces
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<BetaTelemetryDestinationWorkspacesParams>(
                "workspaces"
            );
        }
        init { this._rawBodyData.Set("workspaces", value); }
    }

    /// <summary>
    /// Human-readable name for the destination. Optional. 1 to 255 characters.
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
    /// Request headers that the API sends with every delivery, typically your collector's
    /// authentication header (for example `authorization`).
    ///
    /// <para>The API stores the values encrypted and never returns them. Reads show
    /// only `header_names`.</para>
    ///
    /// <para>At most 20 headers. Names are at most 128 characters. Two names can't
    /// differ only in case. Values are printable ASCII, at most 4,096 characters,
    /// and can't begin or end with a space. Names and values together are at most
    /// 16,384 bytes.</para>
    ///
    /// <para>Reserved names are rejected, for example `host`, `cookie`, `user-agent`,
    /// and names that start with `content-`, `proxy-`, `x-forwarded-`, or `anthropic-`.
    /// For this check, `_` in a name counts as `-`.</para>
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("headers");
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The settings for the traces that the destination receives. If you leave it
    /// out, every setting takes its default.
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
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("traces");
                return;
            }

            this._rawBodyData.Set("traces", value);
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

    public TelemetryDestinationCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelemetryDestinationCreateParams(
        TelemetryDestinationCreateParams telemetryDestinationCreateParams
    )
        : base(telemetryDestinationCreateParams)
    {
        this._rawBodyData = new(telemetryDestinationCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TelemetryDestinationCreateParams(
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
    TelemetryDestinationCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TelemetryDestinationCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TelemetryDestinationCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/telemetry_destinations"
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override string Route => "/v1/organizations/telemetry_destinations";

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
