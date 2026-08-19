using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Skills.Versions;

[JsonConverter(typeof(JsonModelConverter<DeletedSkillVersion, DeletedSkillVersionFromRaw>))]
public sealed record class DeletedSkillVersion : JsonModel
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
    /// Deleted object type.
    ///
    /// <para>For Skill Versions, this is always `"skill_version_deleted"`.</para>
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("skill_version_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public DeletedSkillVersion()
    {
        this.Type = JsonSerializer.SerializeToElement("skill_version_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeletedSkillVersion(DeletedSkillVersion deletedSkillVersion)
        : base(deletedSkillVersion) { }
#pragma warning restore CS8618

    public DeletedSkillVersion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("skill_version_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeletedSkillVersion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeletedSkillVersionFromRaw.FromRawUnchecked"/>
    public static DeletedSkillVersion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeletedSkillVersion(string id)
        : this()
    {
        this.ID = id;
    }
}

class DeletedSkillVersionFromRaw : IFromRawJson<DeletedSkillVersion>
{
    /// <inheritdoc/>
    public DeletedSkillVersion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeletedSkillVersion.FromRawUnchecked(rawData);
}
