using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// A resolved user-created custom skill.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsCustomSkill, BetaManagedAgentsCustomSkillFromRaw>)
)]
public sealed record class BetaManagedAgentsCustomSkill : JsonModel
{
    public required string SkillID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("skill_id");
        }
        init { this._rawData.Set("skill_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required string Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SkillID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("custom")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Version;
    }

    public BetaManagedAgentsCustomSkill()
    {
        this.Type = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsCustomSkill(BetaManagedAgentsCustomSkill betaManagedAgentsCustomSkill)
        : base(betaManagedAgentsCustomSkill) { }
#pragma warning restore CS8618

    public BetaManagedAgentsCustomSkill(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsCustomSkill(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsCustomSkillFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsCustomSkill FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsCustomSkillFromRaw : IFromRawJson<BetaManagedAgentsCustomSkill>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCustomSkill FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCustomSkill.FromRawUnchecked(rawData);
}
