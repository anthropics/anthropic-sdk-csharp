using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta.Organization;

namespace Anthropic.Models.Beta.Organization.Webhooks;

/// <summary>
/// Create an organization webhook endpoint.
///
/// <para>An organization webhook endpoint belongs to the organization rather than
/// to one of its workspaces. An organization can have at most 32 organization webhook
/// endpoints, enabled or disabled.</para>
///
/// <para>The response includes the endpoint's signing secret. No read returns it,
/// so store it when you receive it.</para>
///
/// <para>Every request must include the beta header `anthropic-beta: webhooks-2026-10-07`.
/// A request without it returns `404`, exactly as if this API did not exist. Anthropic
/// turns organization webhook endpoints on for each organization; until yours is
/// on, requests also return `404`. Organization webhook endpoints are in beta and
/// are not available to organizations with HIPAA readiness enabled.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WebhookCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The event types to deliver to the endpoint. Must list at least one.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, EnabledEvent>> EnabledEvents
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, EnabledEvent>>
            >("enabled_events");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, EnabledEvent>>>(
                "enabled_events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The HTTPS URL that deliveries are sent to.
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("url");
        }
        init { this._rawBodyData.Set("url", value); }
    }

    /// <summary>
    /// Notes about the endpoint.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("description");
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// A short label for the endpoint.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("name");
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    /// <summary>
    /// This endpoint is in beta: requests must send `webhooks-2026-10-07` in this header.
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

    public WebhookCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookCreateParams(WebhookCreateParams webhookCreateParams)
        : base(webhookCreateParams)
    {
        this._rawBodyData = new(webhookCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WebhookCreateParams(
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
    WebhookCreateParams(
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
    public static WebhookCreateParams FromRawUnchecked(
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

    public virtual bool Equals(WebhookCreateParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/webhooks"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/organizations/webhooks";

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
        WebhookService.AddDefaultHeaders(request);
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

[JsonConverter(typeof(EnabledEventConverter))]
public enum EnabledEvent
{
    UserProfileEnforcementActionOpened,
    UserProfileEnforcementActionResolved,
}

sealed class EnabledEventConverter : JsonConverter<EnabledEvent>
{
    public override EnabledEvent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_profile.enforcement_action_opened" =>
                EnabledEvent.UserProfileEnforcementActionOpened,
            "user_profile.enforcement_action_resolved" =>
                EnabledEvent.UserProfileEnforcementActionResolved,
            _ => (EnabledEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EnabledEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EnabledEvent.UserProfileEnforcementActionOpened =>
                    "user_profile.enforcement_action_opened",
                EnabledEvent.UserProfileEnforcementActionResolved =>
                    "user_profile.enforcement_action_resolved",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
