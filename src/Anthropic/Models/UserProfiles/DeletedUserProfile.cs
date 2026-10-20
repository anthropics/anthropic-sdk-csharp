using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

[JsonConverter(typeof(JsonModelConverter<DeletedUserProfile, DeletedUserProfileFromRaw>))]
public sealed record class DeletedUserProfile : JsonModel
{
    /// <summary>
    /// Identifier of the deleted user profile, prefixed `uprof_`.
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
    /// Object type. Always `user_profile_deleted`.
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("user_profile_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public DeletedUserProfile()
    {
        this.Type = JsonSerializer.SerializeToElement("user_profile_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeletedUserProfile(DeletedUserProfile deletedUserProfile)
        : base(deletedUserProfile) { }
#pragma warning restore CS8618

    public DeletedUserProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_profile_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeletedUserProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeletedUserProfileFromRaw.FromRawUnchecked"/>
    public static DeletedUserProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeletedUserProfile(string id)
        : this()
    {
        this.ID = id;
    }
}

class DeletedUserProfileFromRaw : IFromRawJson<DeletedUserProfile>
{
    /// <inheritdoc/>
    public DeletedUserProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeletedUserProfile.FromRawUnchecked(rawData);
}
