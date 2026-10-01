using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

/// <summary>
/// Scope selecting a single member of the organization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaSpendLimitUserScope, BetaSpendLimitUserScopeFromRaw>))]
public sealed record class BetaSpendLimitUserScope : JsonModel
{
    /// <summary>
    /// Scope type. Always `user` for this scope.
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
    /// Tagged ID of the member the spend limit applies to.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
    }

    public BetaSpendLimitUserScope()
    {
        this.Type = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSpendLimitUserScope(BetaSpendLimitUserScope betaSpendLimitUserScope)
        : base(betaSpendLimitUserScope) { }
#pragma warning restore CS8618

    public BetaSpendLimitUserScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSpendLimitUserScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSpendLimitUserScopeFromRaw.FromRawUnchecked"/>
    public static BetaSpendLimitUserScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSpendLimitUserScope(string userID)
        : this()
    {
        this.UserID = userID;
    }
}

class BetaSpendLimitUserScopeFromRaw : IFromRawJson<BetaSpendLimitUserScope>
{
    /// <inheritdoc/>
    public BetaSpendLimitUserScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSpendLimitUserScope.FromRawUnchecked(rawData);
}
