using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Skills;

[JsonConverter(typeof(JsonModelConverter<BetaDeletedSkill, BetaDeletedSkillFromRaw>))]
public sealed record class BetaDeletedSkill : JsonModel
{
    /// <summary>
    /// Unique identifier for the skill.
    ///
    /// <para>The format and length of IDs may change over time.</para>
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
    /// <para>For Skills, this is always `"skill_deleted"`.</para>
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("skill_deleted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDeletedSkill()
    {
        this.Type = JsonSerializer.SerializeToElement("skill_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDeletedSkill(BetaDeletedSkill betaDeletedSkill)
        : base(betaDeletedSkill) { }
#pragma warning restore CS8618

    public BetaDeletedSkill(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("skill_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDeletedSkill(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDeletedSkillFromRaw.FromRawUnchecked"/>
    public static BetaDeletedSkill FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDeletedSkill(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaDeletedSkillFromRaw : IFromRawJson<BetaDeletedSkill>
{
    /// <inheritdoc/>
    public BetaDeletedSkill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDeletedSkill.FromRawUnchecked(rawData);
}
