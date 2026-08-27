using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Skills.Versions;

[JsonConverter(typeof(JsonModelConverter<BetaSkillVersion, BetaSkillVersionFromRaw>))]
public sealed record class BetaSkillVersion : JsonModel
{
    /// <summary>
    /// Unique identifier for this Skill Version. The id addresses the version in
    /// paths and pins it in references.
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
    /// ISO 8601 timestamp of when the skill was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Description of the skill version.
    ///
    /// <para>This is extracted from the SKILL.md file in the skill upload.</para>
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The Skill's immutable kebab-case slug, set at creation from the first upload's
    /// SKILL.md frontmatter `name` (or its enclosing directory). Every later upload
    /// must resolve to the same value. Also the top-level directory of the Skill's
    /// mounted files and the base name of a downloaded archive.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Unique identifier for the skill.
    ///
    /// <para>The format and length of IDs may change over time.</para>
    /// </summary>
    public required string SkillID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("skill_id");
        }
        init { this._rawData.Set("skill_id", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Skill Versions, this is always `"skill_version"`.</para>
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
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Name;
        _ = this.SkillID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("skill_version")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSkillVersion()
    {
        this.Type = JsonSerializer.SerializeToElement("skill_version");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSkillVersion(BetaSkillVersion betaSkillVersion)
        : base(betaSkillVersion) { }
#pragma warning restore CS8618

    public BetaSkillVersion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("skill_version");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSkillVersion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSkillVersionFromRaw.FromRawUnchecked"/>
    public static BetaSkillVersion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSkillVersionFromRaw : IFromRawJson<BetaSkillVersion>
{
    /// <inheritdoc/>
    public BetaSkillVersion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaSkillVersion.FromRawUnchecked(rawData);
}
