using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Webhooks;

/// <summary>
/// A webhook endpoint that belongs to the organization rather than to one of its workspaces.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaOrganizationWebhookEndpoint,
        BetaOrganizationWebhookEndpointFromRaw
    >)
)]
public sealed record class BetaOrganizationWebhookEndpoint : JsonModel
{
    /// <summary>
    /// ID of the webhook endpoint.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// When the endpoint was created, in RFC 3339 format.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Notes about the endpoint. An empty string when none were given.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Why Anthropic disabled the endpoint automatically. An empty string when the
    /// endpoint is enabled, or when you disabled it.
    /// </summary>
    public required string DisabledReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("disabled_reason");
        }
        init { this._rawData.Set("disabled_reason", value); }
    }

    /// <summary>
    /// The event types delivered to the endpoint.
    /// </summary>
    public required IReadOnlyList<
        ApiEnum<string, BetaOrganizationWebhookEndpointEnabledEvent>
    > EnabledEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, BetaOrganizationWebhookEndpointEnabledEvent>>
            >("enabled_events");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, BetaOrganizationWebhookEndpointEnabledEvent>>
            >("enabled_events", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// A short label for the endpoint. An empty string when none was given.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Whether deliveries are sent to the endpoint.
    /// </summary>
    public required ApiEnum<string, BetaOrganizationWebhookEndpointState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaOrganizationWebhookEndpointState>
            >("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// When the endpoint was last changed, in RFC 3339 format.
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
    /// The HTTPS URL that deliveries are sent to.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DisabledReason;
        foreach (var item in this.EnabledEvents)
        {
            item.Validate();
        }
        _ = this.Name;
        this.State.Validate();
        _ = this.UpdatedAt;
        _ = this.Url;
    }

    public BetaOrganizationWebhookEndpoint() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationWebhookEndpoint(
        BetaOrganizationWebhookEndpoint betaOrganizationWebhookEndpoint
    )
        : base(betaOrganizationWebhookEndpoint) { }
#pragma warning restore CS8618

    public BetaOrganizationWebhookEndpoint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationWebhookEndpoint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationWebhookEndpointFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationWebhookEndpoint FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOrganizationWebhookEndpointFromRaw : IFromRawJson<BetaOrganizationWebhookEndpoint>
{
    /// <inheritdoc/>
    public BetaOrganizationWebhookEndpoint FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationWebhookEndpoint.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaOrganizationWebhookEndpointEnabledEventConverter))]
public enum BetaOrganizationWebhookEndpointEnabledEvent
{
    UserProfileEnforcementActionOpened,
    UserProfileEnforcementActionResolved,
}

sealed class BetaOrganizationWebhookEndpointEnabledEventConverter
    : JsonConverter<BetaOrganizationWebhookEndpointEnabledEvent>
{
    public override BetaOrganizationWebhookEndpointEnabledEvent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_profile.enforcement_action_opened" =>
                BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
            "user_profile.enforcement_action_resolved" =>
                BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionResolved,
            _ => (BetaOrganizationWebhookEndpointEnabledEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaOrganizationWebhookEndpointEnabledEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened =>
                    "user_profile.enforcement_action_opened",
                BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionResolved =>
                    "user_profile.enforcement_action_resolved",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
