using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Skills;

[JsonConverter(typeof(ModelConverter<SkillRetrieveResponse, SkillRetrieveResponseFromRaw>))]
public sealed record class SkillRetrieveResponse : ModelBase
{
    /// <summary>
    /// Unique identifier for the skill.
    ///
    /// <para>The format and length of IDs may change over time.</para>
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp of when the skill was created.
    /// </summary>
    public required string CreatedAt
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// Display title for the skill.
    ///
    /// <para>This is a human-readable label that is not included in the prompt sent
    /// to the model.</para>
    /// </summary>
    public required string? DisplayTitle
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "display_title"); }
        init { ModelBase.Set(this._rawData, "display_title", value); }
    }

    /// <summary>
    /// The latest version identifier for the skill.
    ///
    /// <para>This represents the most recent version of the skill that has been created.</para>
    /// </summary>
    public required string? LatestVersion
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "latest_version"); }
        init { ModelBase.Set(this._rawData, "latest_version", value); }
    }

    /// <summary>
    /// Source of the skill.
    ///
    /// <para>This may be one of the following values: * `"custom"`: the skill was
    /// created by a user * `"anthropic"`: the skill was created by Anthropic</para>
    /// </summary>
    public required string Source
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "source"); }
        init { ModelBase.Set(this._rawData, "source", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Skills, this is always `"skill"`.</para>
    /// </summary>
    public required string Type
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp of when the skill was last updated.
    /// </summary>
    public required string UpdatedAt
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "updated_at"); }
        init { ModelBase.Set(this._rawData, "updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DisplayTitle;
        _ = this.LatestVersion;
        _ = this.Source;
        _ = this.Type;
        _ = this.UpdatedAt;
    }

    public SkillRetrieveResponse() { }

    public SkillRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SkillRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SkillRetrieveResponseFromRaw : IFromRaw<SkillRetrieveResponse>
{
    /// <inheritdoc/>
    public SkillRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SkillRetrieveResponse.FromRawUnchecked(rawData);
}
