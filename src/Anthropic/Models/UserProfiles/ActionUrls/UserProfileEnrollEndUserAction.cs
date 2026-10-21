using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles.ActionUrls;

/// <summary>
/// The end-user that the profile represents enrolls in a program.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserProfileEnrollEndUserAction,
        UserProfileEnrollEndUserActionFromRaw
    >)
)]
public sealed record class UserProfileEnrollEndUserAction : JsonModel
{
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
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enroll_end_user"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public UserProfileEnrollEndUserAction()
    {
        this.Type = JsonSerializer.SerializeToElement("enroll_end_user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileEnrollEndUserAction(
        UserProfileEnrollEndUserAction userProfileEnrollEndUserAction
    )
        : base(userProfileEnrollEndUserAction) { }
#pragma warning restore CS8618

    public UserProfileEnrollEndUserAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enroll_end_user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileEnrollEndUserAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileEnrollEndUserActionFromRaw.FromRawUnchecked"/>
    public static UserProfileEnrollEndUserAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileEnrollEndUserActionFromRaw : IFromRawJson<UserProfileEnrollEndUserAction>
{
    /// <inheritdoc/>
    public UserProfileEnrollEndUserAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileEnrollEndUserAction.FromRawUnchecked(rawData);
}
