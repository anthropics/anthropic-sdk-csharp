using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// An Anthropic-managed skill.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAnthropicSkillParams,
        BetaManagedAgentsAnthropicSkillParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAnthropicSkillParams : JsonModel
{
    /// <summary>
    /// Identifier of the Anthropic skill (e.g., "xlsx").
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
    /// Version to pin. Defaults to latest if omitted.
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SkillID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("anthropic")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Version;
    }

    public BetaManagedAgentsAnthropicSkillParams()
    {
        this.Type = JsonSerializer.SerializeToElement("anthropic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAnthropicSkillParams(
        BetaManagedAgentsAnthropicSkillParams betaManagedAgentsAnthropicSkillParams
    )
        : base(betaManagedAgentsAnthropicSkillParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAnthropicSkillParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("anthropic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAnthropicSkillParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAnthropicSkillParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAnthropicSkillParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAnthropicSkillParams(string skillID)
        : this()
    {
        this.SkillID = skillID;
    }
}

class BetaManagedAgentsAnthropicSkillParamsFromRaw
    : IFromRawJson<BetaManagedAgentsAnthropicSkillParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAnthropicSkillParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAnthropicSkillParams.FromRawUnchecked(rawData);
}
