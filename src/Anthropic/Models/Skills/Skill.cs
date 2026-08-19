using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Skills;

[JsonConverter(typeof(JsonModelConverter<Skill, SkillFromRaw>))]
public sealed record class Skill : JsonModel
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
    /// Human-readable, single-line label for the Skill. Maximum 255 characters. Always
    /// set: derived from the SKILL.md frontmatter `name` when omitted at creation.
    /// Not unique.
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// ID of the newest Skill Version — what `latest` references resolve to. Always
    /// set: a Skill holds at least one version.
    /// </summary>
    public required string LatestVersionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("latest_version_id");
        }
        init { this._rawData.Set("latest_version_id", value); }
    }

    /// <summary>
    /// Where the Skill comes from.
    ///
    /// <para>Possible values: * `"custom"`: authored by the platform user; private
    /// to their workspace * `"anthropic"`: published by Anthropic; shared and read-only
    /// * `"anthropic_example"`: Anthropic-published sample Skill * `"plugin"`: resolved
    /// from an installed plugin</para>
    /// </summary>
    public required SkillSource Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SkillSource>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Skills, this is always `"skill"`.</para>
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
    /// ISO 8601 timestamp of when the skill was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.LatestVersionID;
        this.Source.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("skill")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public Skill()
    {
        this.Type = JsonSerializer.SerializeToElement("skill");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Skill(Skill skill)
        : base(skill) { }
#pragma warning restore CS8618

    public Skill(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("skill");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Skill(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillFromRaw.FromRawUnchecked"/>
    public static Skill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SkillFromRaw : IFromRawJson<Skill>
{
    /// <inheritdoc/>
    public Skill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Skill.FromRawUnchecked(rawData);
}
