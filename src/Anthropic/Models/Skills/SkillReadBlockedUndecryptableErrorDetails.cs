using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Skills;

/// <summary>
/// A custom skill the request names is stored under an encryption key state the
/// workspace cannot currently decrypt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        SkillReadBlockedUndecryptableErrorDetails,
        SkillReadBlockedUndecryptableErrorDetailsFromRaw
    >)
)]
public sealed record class SkillReadBlockedUndecryptableErrorDetails : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("skill_read_blocked_undecryptable")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public SkillReadBlockedUndecryptableErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("skill_read_blocked_undecryptable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SkillReadBlockedUndecryptableErrorDetails(
        SkillReadBlockedUndecryptableErrorDetails skillReadBlockedUndecryptableErrorDetails
    )
        : base(skillReadBlockedUndecryptableErrorDetails) { }
#pragma warning restore CS8618

    public SkillReadBlockedUndecryptableErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("skill_read_blocked_undecryptable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillReadBlockedUndecryptableErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillReadBlockedUndecryptableErrorDetailsFromRaw.FromRawUnchecked"/>
    public static SkillReadBlockedUndecryptableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SkillReadBlockedUndecryptableErrorDetailsFromRaw
    : IFromRawJson<SkillReadBlockedUndecryptableErrorDetails>
{
    /// <inheritdoc/>
    public SkillReadBlockedUndecryptableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SkillReadBlockedUndecryptableErrorDetails.FromRawUnchecked(rawData);
}
