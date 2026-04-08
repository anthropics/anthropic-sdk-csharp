using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// A resolved Anthropic-managed skill.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAnthropicSkill,
        BetaManagedAgentsAnthropicSkillFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAnthropicSkill : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsAnthropicSkillType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAnthropicSkillType>
            >("type");
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
        this.Type.Validate();
        _ = this.Version;
    }

    public BetaManagedAgentsAnthropicSkill() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAnthropicSkill(
        BetaManagedAgentsAnthropicSkill betaManagedAgentsAnthropicSkill
    )
        : base(betaManagedAgentsAnthropicSkill) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAnthropicSkill(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAnthropicSkill(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAnthropicSkillFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAnthropicSkill FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAnthropicSkillFromRaw : IFromRawJson<BetaManagedAgentsAnthropicSkill>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAnthropicSkill FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAnthropicSkill.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsAnthropicSkillTypeConverter))]
public enum BetaManagedAgentsAnthropicSkillType
{
    Anthropic,
}

sealed class BetaManagedAgentsAnthropicSkillTypeConverter
    : JsonConverter<BetaManagedAgentsAnthropicSkillType>
{
    public override BetaManagedAgentsAnthropicSkillType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "anthropic" => BetaManagedAgentsAnthropicSkillType.Anthropic,
            _ => (BetaManagedAgentsAnthropicSkillType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAnthropicSkillType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAnthropicSkillType.Anthropic => "anthropic",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
