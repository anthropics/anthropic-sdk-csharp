using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Webhooks;

/// <summary>
/// An organization webhook endpoint's new signing secret.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaOrganizationWebhookEndpointSigningSecret,
        BetaOrganizationWebhookEndpointSigningSecretFromRaw
    >)
)]
public sealed record class BetaOrganizationWebhookEndpointSigningSecret : JsonModel
{
    /// <summary>
    /// The new signing secret. Deliveries are signed with it from now on, and no
    /// other response returns it.
    /// </summary>
    public required string SigningSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("signing_secret");
        }
        init { this._rawData.Set("signing_secret", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SigningSecret;
    }

    public BetaOrganizationWebhookEndpointSigningSecret() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationWebhookEndpointSigningSecret(
        BetaOrganizationWebhookEndpointSigningSecret betaOrganizationWebhookEndpointSigningSecret
    )
        : base(betaOrganizationWebhookEndpointSigningSecret) { }
#pragma warning restore CS8618

    public BetaOrganizationWebhookEndpointSigningSecret(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationWebhookEndpointSigningSecret(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationWebhookEndpointSigningSecretFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationWebhookEndpointSigningSecret FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaOrganizationWebhookEndpointSigningSecret(string signingSecret)
        : this()
    {
        this.SigningSecret = signingSecret;
    }
}

class BetaOrganizationWebhookEndpointSigningSecretFromRaw
    : IFromRawJson<BetaOrganizationWebhookEndpointSigningSecret>
{
    /// <inheritdoc/>
    public BetaOrganizationWebhookEndpointSigningSecret FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationWebhookEndpointSigningSecret.FromRawUnchecked(rawData);
}
