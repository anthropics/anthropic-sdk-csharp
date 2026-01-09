using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Skills.Versions;

[JsonConverter(typeof(JsonModelConverter<VersionRetrieveResponse, VersionRetrieveResponseFromRaw>))]
public sealed record class VersionRetrieveResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the skill version.
    ///
    /// <para>The format and length of IDs may change over time.</para>
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp of when the skill version was created.
    /// </summary>
    public required string CreatedAt
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "created_at"); }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// Description of the skill version.
    ///
    /// <para>This is extracted from the SKILL.md file in the skill upload.</para>
    /// </summary>
    public required string Description
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// Directory name of the skill version.
    ///
    /// <para>This is the top-level directory name that was extracted from the uploaded files.</para>
    /// </summary>
    public required string Directory
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "directory"); }
        init { JsonModel.Set(this._rawData, "directory", value); }
    }

    /// <summary>
    /// Human-readable name of the skill version.
    ///
    /// <para>This is extracted from the SKILL.md file in the skill upload.</para>
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Identifier for the skill that this version belongs to.
    /// </summary>
    public required string SkillID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "skill_id"); }
        init { JsonModel.Set(this._rawData, "skill_id", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Skill Versions, this is always `"skill_version"`.</para>
    /// </summary>
    public required string Type
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Version identifier for the skill.
    ///
    /// <para>Each version is identified by a Unix epoch timestamp (e.g., "1759178010641129").</para>
    /// </summary>
    public required string Version
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "version"); }
        init { JsonModel.Set(this._rawData, "version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Directory;
        _ = this.Name;
        _ = this.SkillID;
        _ = this.Type;
        _ = this.Version;
    }

    public VersionRetrieveResponse() { }

    public VersionRetrieveResponse(VersionRetrieveResponse versionRetrieveResponse)
        : base(versionRetrieveResponse) { }

    public VersionRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static VersionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionRetrieveResponseFromRaw : IFromRawJson<VersionRetrieveResponse>
{
    /// <inheritdoc/>
    public VersionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionRetrieveResponse.FromRawUnchecked(rawData);
}
