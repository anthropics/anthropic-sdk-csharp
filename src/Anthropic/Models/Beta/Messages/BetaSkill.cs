using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A skill that was loaded in a container (response model).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaSkill, BetaSkillFromRaw>))]
public sealed record class BetaSkill : JsonModel
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
    public required ApiEnum<string, global::Anthropic.Models.Beta.Messages.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Messages.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Skill version or 'latest' for most recent version
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

    public BetaSkill() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSkill(BetaSkill betaSkill)
        : base(betaSkill) { }
#pragma warning restore CS8618

    public BetaSkill(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSkill(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSkillFromRaw.FromRawUnchecked"/>
    public static BetaSkill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSkillFromRaw : IFromRawJson<BetaSkill>
{
    /// <inheritdoc/>
    public BetaSkill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaSkill.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of skill - either 'anthropic' (built-in) or 'custom' (user-defined)
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Anthropic,
    Custom,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Messages.Type>
{
    public override global::Anthropic.Models.Beta.Messages.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "anthropic" => global::Anthropic.Models.Beta.Messages.Type.Anthropic,
            "custom" => global::Anthropic.Models.Beta.Messages.Type.Custom,
            _ => (global::Anthropic.Models.Beta.Messages.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Messages.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Messages.Type.Anthropic => "anthropic",
                global::Anthropic.Models.Beta.Messages.Type.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
