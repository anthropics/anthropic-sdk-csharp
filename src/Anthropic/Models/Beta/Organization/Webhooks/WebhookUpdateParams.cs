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
/// Update an organization webhook endpoint. Only the fields you send are changed.
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
public record class WebhookUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? WebhookEndpointID { get; init; }

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
    /// The event types to deliver to the endpoint. Replaces the whole set; an empty
    /// list leaves it unchanged.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, WebhookUpdateParamsEnabledEvent>>? EnabledEvents
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, WebhookUpdateParamsEnabledEvent>>
            >("enabled_events");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("enabled_events");
                return;
            }

            this._rawBodyData.Set<ImmutableArray<
                ApiEnum<string, WebhookUpdateParamsEnabledEvent>
            >?>("enabled_events", value == null ? null : ImmutableArray.ToImmutableArray(value));
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
    /// `disabled` stops deliveries. `enabled` resumes them and clears `disabled_reason`.
    /// Events that happen while the endpoint is disabled are never delivered.
    /// </summary>
    public ApiEnum<string, State>? State
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, State>>("state");
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
    /// The HTTPS URL that deliveries are sent to.
    /// </summary>
    public string? UrlValue
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("url");
                return;
            }

            this._rawBodyData.Set("url", value);
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

    public WebhookUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookUpdateParams(WebhookUpdateParams webhookUpdateParams)
        : base(webhookUpdateParams)
    {
        this.WebhookEndpointID = webhookUpdateParams.WebhookEndpointID;

        this._rawBodyData = new(webhookUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WebhookUpdateParams(
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
    WebhookUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string webhookEndpointID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.WebhookEndpointID = webhookEndpointID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WebhookUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string webhookEndpointID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            webhookEndpointID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["WebhookEndpointID"] = JsonSerializer.SerializeToElement(
                        this.WebhookEndpointID
                    ),
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

    public virtual bool Equals(WebhookUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.WebhookEndpointID?.Equals(other.WebhookEndpointID)
                ?? other.WebhookEndpointID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/webhooks/{0}",
                    ParamsBase.EncodePathSegment(
                        this.WebhookEndpointID,
                        nameof(this.WebhookEndpointID)
                    )
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/organizations/webhooks/{webhook_endpoint_id}";

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

[JsonConverter(typeof(WebhookUpdateParamsEnabledEventConverter))]
public enum WebhookUpdateParamsEnabledEvent
{
    UserProfileEnforcementActionOpened,
    UserProfileEnforcementActionResolved,
}

sealed class WebhookUpdateParamsEnabledEventConverter
    : JsonConverter<WebhookUpdateParamsEnabledEvent>
{
    public override WebhookUpdateParamsEnabledEvent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_profile.enforcement_action_opened" =>
                WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionOpened,
            "user_profile.enforcement_action_resolved" =>
                WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionResolved,
            _ => (WebhookUpdateParamsEnabledEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookUpdateParamsEnabledEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionOpened =>
                    "user_profile.enforcement_action_opened",
                WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionResolved =>
                    "user_profile.enforcement_action_resolved",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// `disabled` stops deliveries. `enabled` resumes them and clears `disabled_reason`.
/// Events that happen while the endpoint is disabled are never delivered.
/// </summary>
[JsonConverter(typeof(StateConverter))]
public enum State
{
    Disabled,
    Enabled,
}

sealed class StateConverter : JsonConverter<State>
{
    public override State Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => State.Disabled,
            "enabled" => State.Enabled,
            _ => (State)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, State value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                State.Disabled => "disabled",
                State.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
