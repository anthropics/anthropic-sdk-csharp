using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Skills;

[JsonConverter(typeof(JsonModelConverter<DeletedSkill, DeletedSkillFromRaw>))]
public sealed record class DeletedSkill : JsonModel
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

    public DeletedSkill()
    {
        this.Type = JsonSerializer.SerializeToElement("skill_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeletedSkill(DeletedSkill deletedSkill)
        : base(deletedSkill) { }
#pragma warning restore CS8618

    public DeletedSkill(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("skill_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeletedSkill(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeletedSkillFromRaw.FromRawUnchecked"/>
    public static DeletedSkill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeletedSkill(string id)
        : this()
    {
        this.ID = id;
    }
}

class DeletedSkillFromRaw : IFromRawJson<DeletedSkill>
{
    /// <inheritdoc/>
    public DeletedSkill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeletedSkill.FromRawUnchecked(rawData);
}
