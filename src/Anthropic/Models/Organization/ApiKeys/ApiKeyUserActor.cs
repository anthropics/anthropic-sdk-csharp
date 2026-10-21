using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ApiKeys;

[JsonConverter(typeof(JsonModelConverter<ApiKeyUserActor, ApiKeyUserActorFromRaw>))]
public sealed record class ApiKeyUserActor : JsonModel
{
    /// <summary>
    /// Principal type. Always `"user_actor"` for a User.
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
    /// ID of the User the API key acts as.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user_actor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
    }

    public ApiKeyUserActor()
    {
        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKeyUserActor(ApiKeyUserActor apiKeyUserActor)
        : base(apiKeyUserActor) { }
#pragma warning restore CS8618

    public ApiKeyUserActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKeyUserActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyUserActorFromRaw.FromRawUnchecked"/>
    public static ApiKeyUserActor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ApiKeyUserActor(string userID)
        : this()
    {
        this.UserID = userID;
    }
}

class ApiKeyUserActorFromRaw : IFromRawJson<ApiKeyUserActor>
{
    /// <inheritdoc/>
    public ApiKeyUserActor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiKeyUserActor.FromRawUnchecked(rawData);
}
