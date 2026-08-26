using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

[JsonConverter(typeof(JsonModelConverter<UserRemoveResponse, UserRemoveResponseFromRaw>))]
public sealed record class UserRemoveResponse : JsonModel
{
    /// <summary>
    /// ID of the User.
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
    /// Deleted object type.
    ///
    /// <para>For Users, this is always `"user_deleted"`.</para>
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user_deleted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public UserRemoveResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("user_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRemoveResponse(UserRemoveResponse userRemoveResponse)
        : base(userRemoveResponse) { }
#pragma warning restore CS8618

    public UserRemoveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRemoveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRemoveResponseFromRaw.FromRawUnchecked"/>
    public static UserRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserRemoveResponse(string id)
        : this()
    {
        this.ID = id;
    }
}

class UserRemoveResponseFromRaw : IFromRawJson<UserRemoveResponse>
{
    /// <inheritdoc/>
    public UserRemoveResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserRemoveResponse.FromRawUnchecked(rawData);
}
