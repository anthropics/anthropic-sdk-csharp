using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// A skill that was loaded in a container (response model).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContainerSkill, ContainerSkillFromRaw>))]
public sealed record class ContainerSkill : JsonModel
{
    /// <summary>
    /// Skill ID
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
    /// Type of skill - either 'anthropic' (built-in) or 'custom' (user-defined)
    /// </summary>
    public required ApiEnum<string, ContainerSkillType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ContainerSkillType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The resolved version: a skill version ID for custom skills.
    /// </summary>
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

    public ContainerSkill() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContainerSkill(ContainerSkill containerSkill)
        : base(containerSkill) { }
#pragma warning restore CS8618

    public ContainerSkill(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContainerSkill(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContainerSkillFromRaw.FromRawUnchecked"/>
    public static ContainerSkill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContainerSkillFromRaw : IFromRawJson<ContainerSkill>
{
    /// <inheritdoc/>
    public ContainerSkill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContainerSkill.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of skill - either 'anthropic' (built-in) or 'custom' (user-defined)
/// </summary>
[JsonConverter(typeof(ContainerSkillTypeConverter))]
public enum ContainerSkillType
{
    Anthropic,
    Custom,
}

sealed class ContainerSkillTypeConverter : JsonConverter<ContainerSkillType>
{
    public override ContainerSkillType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "anthropic" => ContainerSkillType.Anthropic,
            "custom" => ContainerSkillType.Custom,
            _ => (ContainerSkillType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContainerSkillType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContainerSkillType.Anthropic => "anthropic",
                ContainerSkillType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
