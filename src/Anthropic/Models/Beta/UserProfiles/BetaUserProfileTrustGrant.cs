using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.UserProfiles;

[JsonConverter(
    typeof(JsonModelConverter<BetaUserProfileTrustGrant, BetaUserProfileTrustGrantFromRaw>)
)]
public sealed record class BetaUserProfileTrustGrant : JsonModel
{
    /// <summary>
    /// Status of the trust grant.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
    }

    public BetaUserProfileTrustGrant() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUserProfileTrustGrant(BetaUserProfileTrustGrant betaUserProfileTrustGrant)
        : base(betaUserProfileTrustGrant) { }
#pragma warning restore CS8618

    public BetaUserProfileTrustGrant(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUserProfileTrustGrant(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUserProfileTrustGrantFromRaw.FromRawUnchecked"/>
    public static BetaUserProfileTrustGrant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaUserProfileTrustGrant(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}

class BetaUserProfileTrustGrantFromRaw : IFromRawJson<BetaUserProfileTrustGrant>
{
    /// <inheritdoc/>
    public BetaUserProfileTrustGrant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaUserProfileTrustGrant.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the trust grant.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Pending,
    Rejected,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status.Active,
            "pending" => Status.Pending,
            "rejected" => Status.Rejected,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Pending => "pending",
                Status.Rejected => "rejected",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
