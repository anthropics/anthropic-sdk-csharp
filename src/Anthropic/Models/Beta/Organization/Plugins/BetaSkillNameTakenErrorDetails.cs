using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

/// <summary>
/// One of the Plugin's skills has the name of an organization skill. `skill_name`
/// is that name.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaSkillNameTakenErrorDetails,
        BetaSkillNameTakenErrorDetailsFromRaw
    >)
)]
public sealed record class BetaSkillNameTakenErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    public required string SkillName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("skill_name");
        }
        init { this._rawData.Set("skill_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("skill_name_taken")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.SkillName;
    }

    public BetaSkillNameTakenErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("skill_name_taken");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSkillNameTakenErrorDetails(
        BetaSkillNameTakenErrorDetails betaSkillNameTakenErrorDetails
    )
        : base(betaSkillNameTakenErrorDetails) { }
#pragma warning restore CS8618

    public BetaSkillNameTakenErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("skill_name_taken");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSkillNameTakenErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSkillNameTakenErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaSkillNameTakenErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSkillNameTakenErrorDetails(string skillName)
        : this()
    {
        this.SkillName = skillName;
    }
}

class BetaSkillNameTakenErrorDetailsFromRaw : IFromRawJson<BetaSkillNameTakenErrorDetails>
{
    /// <inheritdoc/>
    public BetaSkillNameTakenErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSkillNameTakenErrorDetails.FromRawUnchecked(rawData);
}
