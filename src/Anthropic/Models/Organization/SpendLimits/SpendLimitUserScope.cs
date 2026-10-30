using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits;

/// <summary>
/// Scope selecting a single member of the organization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SpendLimitUserScope, SpendLimitUserScopeFromRaw>))]
public sealed record class SpendLimitUserScope : JsonModel
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

    public SpendLimitUserScope()
    {
        this.Type = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitUserScope(SpendLimitUserScope spendLimitUserScope)
        : base(spendLimitUserScope) { }
#pragma warning restore CS8618

    public SpendLimitUserScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitUserScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendLimitUserScopeFromRaw.FromRawUnchecked"/>
    public static SpendLimitUserScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SpendLimitUserScope(string userID)
        : this()
    {
        this.UserID = userID;
    }
}

class SpendLimitUserScopeFromRaw : IFromRawJson<SpendLimitUserScope>
{
    /// <inheritdoc/>
    public SpendLimitUserScope FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SpendLimitUserScope.FromRawUnchecked(rawData);
}
