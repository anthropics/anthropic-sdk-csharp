using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Skills;

[JsonConverter(typeof(JsonModelConverter<SkillDeleteResponse, SkillDeleteResponseFromRaw>))]
public sealed record class SkillDeleteResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the skill.
    ///
    /// <para>The format and length of IDs may change over time.</para>
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Deleted object type.
    ///
    /// <para>For Skills, this is always `"skill_deleted"`.</para>
    /// </summary>
    public required string Type
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
    }

    public SkillDeleteResponse() { }

    public SkillDeleteResponse(SkillDeleteResponse skillDeleteResponse)
        : base(skillDeleteResponse) { }

    public SkillDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillDeleteResponseFromRaw.FromRawUnchecked"/>
    public static SkillDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SkillDeleteResponseFromRaw : IFromRawJson<SkillDeleteResponse>
{
    /// <inheritdoc/>
    public SkillDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SkillDeleteResponse.FromRawUnchecked(rawData);
}
