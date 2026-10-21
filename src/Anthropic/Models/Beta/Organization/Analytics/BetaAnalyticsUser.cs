using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A user in the organization, identified by tagged id and email address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaAnalyticsUser, BetaAnalyticsUserFromRaw>))]
public sealed record class BetaAnalyticsUser : JsonModel
{
    /// <summary>
    /// Tagged user identifier (e.g. `user_...`)
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
    /// Email address of the user
    /// </summary>
    public required string EmailAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email_address");
        }
        init { this._rawData.Set("email_address", value); }
    }

    /// <summary>
    /// Object type. Always `user`.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.EmailAddress;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAnalyticsUser()
    {
        this.Type = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUser(BetaAnalyticsUser betaAnalyticsUser)
        : base(betaAnalyticsUser) { }
#pragma warning restore CS8618

    public BetaAnalyticsUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUserFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUserFromRaw : IFromRawJson<BetaAnalyticsUser>
{
    /// <inheritdoc/>
    public BetaAnalyticsUser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaAnalyticsUser.FromRawUnchecked(rawData);
}
