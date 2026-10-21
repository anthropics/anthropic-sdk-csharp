using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(typeof(JsonModelConverter<BetaPluginOwnerUser, BetaPluginOwnerUserFromRaw>))]
public sealed record class BetaPluginOwnerUser : JsonModel
{
    /// <summary>
    /// The Plugin lives in one member's personal plugin marketplace.
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
    /// The member's User ID.
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

    public BetaPluginOwnerUser()
    {
        this.Type = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginOwnerUser(BetaPluginOwnerUser betaPluginOwnerUser)
        : base(betaPluginOwnerUser) { }
#pragma warning restore CS8618

    public BetaPluginOwnerUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginOwnerUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginOwnerUserFromRaw.FromRawUnchecked"/>
    public static BetaPluginOwnerUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaPluginOwnerUser(string userID)
        : this()
    {
        this.UserID = userID;
    }
}

class BetaPluginOwnerUserFromRaw : IFromRawJson<BetaPluginOwnerUser>
{
    /// <inheritdoc/>
    public BetaPluginOwnerUser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPluginOwnerUser.FromRawUnchecked(rawData);
}
