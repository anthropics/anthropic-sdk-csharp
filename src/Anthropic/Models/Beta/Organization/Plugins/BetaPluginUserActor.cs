using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(typeof(JsonModelConverter<BetaPluginUserActor, BetaPluginUserActorFromRaw>))]
public sealed record class BetaPluginUserActor : JsonModel
{
    /// <summary>
    /// The member's email address; may be null, for example when they are no longer
    /// a member of the organization.
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
    /// A member of the organization.
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
        _ = this.EmailAddress;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user_actor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
    }

    public BetaPluginUserActor()
    {
        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginUserActor(BetaPluginUserActor betaPluginUserActor)
        : base(betaPluginUserActor) { }
#pragma warning restore CS8618

    public BetaPluginUserActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginUserActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginUserActorFromRaw.FromRawUnchecked"/>
    public static BetaPluginUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginUserActorFromRaw : IFromRawJson<BetaPluginUserActor>
{
    /// <inheritdoc/>
    public BetaPluginUserActor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPluginUserActor.FromRawUnchecked(rawData);
}
