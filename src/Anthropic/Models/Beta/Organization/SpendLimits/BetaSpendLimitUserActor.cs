using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

/// <summary>
/// A user within the organization. `name` and `email_address` are null when the
/// underlying account is unavailable or has been deleted; `deleted` is true only
/// for deleted accounts.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaSpendLimitUserActor, BetaSpendLimitUserActorFromRaw>))]
public sealed record class BetaSpendLimitUserActor : JsonModel
{
    /// <summary>
    /// True only when the underlying account has been deleted.
    /// </summary>
    public required bool Deleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("deleted");
        }
        init { this._rawData.Set("deleted", value); }
    }

    /// <summary>
    /// The user's email address. Null when the account is unavailable or has been deleted.
    /// </summary>
    public required string? EmailAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email_address");
        }
        init { this._rawData.Set("email_address", value); }
    }

    /// <summary>
    /// The user's current display name. Null when the account is unavailable, has
    /// been deleted, or has no name set.
    /// </summary>
    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Actor type. Always `user_actor`.
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

    /// <summary>
    /// Tagged ID of the user.
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Deleted;
        _ = this.EmailAddress;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user_actor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
    }

    public BetaSpendLimitUserActor()
    {
        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSpendLimitUserActor(BetaSpendLimitUserActor betaSpendLimitUserActor)
        : base(betaSpendLimitUserActor) { }
#pragma warning restore CS8618

    public BetaSpendLimitUserActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSpendLimitUserActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSpendLimitUserActorFromRaw.FromRawUnchecked"/>
    public static BetaSpendLimitUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSpendLimitUserActorFromRaw : IFromRawJson<BetaSpendLimitUserActor>
{
    /// <inheritdoc/>
    public BetaSpendLimitUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSpendLimitUserActor.FromRawUnchecked(rawData);
}
