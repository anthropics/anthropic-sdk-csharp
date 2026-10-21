using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.ActionUrls;

/// <summary>
/// The end-user that the profile represents enrolls in a program.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaUserProfileEnrollEndUserAction,
        BetaUserProfileEnrollEndUserActionFromRaw
    >)
)]
public sealed record class BetaUserProfileEnrollEndUserAction : JsonModel
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

    public BetaUserProfileEnrollEndUserAction()
    {
        this.Type = JsonSerializer.SerializeToElement("enroll_end_user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUserProfileEnrollEndUserAction(
        BetaUserProfileEnrollEndUserAction betaUserProfileEnrollEndUserAction
    )
        : base(betaUserProfileEnrollEndUserAction) { }
#pragma warning restore CS8618

    public BetaUserProfileEnrollEndUserAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enroll_end_user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUserProfileEnrollEndUserAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUserProfileEnrollEndUserActionFromRaw.FromRawUnchecked"/>
    public static BetaUserProfileEnrollEndUserAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaUserProfileEnrollEndUserActionFromRaw : IFromRawJson<BetaUserProfileEnrollEndUserAction>
{
    /// <inheritdoc/>
    public BetaUserProfileEnrollEndUserAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaUserProfileEnrollEndUserAction.FromRawUnchecked(rawData);
}
