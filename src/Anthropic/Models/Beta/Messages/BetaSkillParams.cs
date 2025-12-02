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
/// Specification for a skill to be loaded in a container (request model).
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaSkillParams, BetaSkillParamsFromRaw>))]
public sealed record class BetaSkillParams : ModelBase
{
    /// <summary>
    /// Skill ID
    /// </summary>
    public required string SkillID
    {
        get
        {
            if (!this._rawData.TryGetValue("skill_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'skill_id' cannot be null",
                    new System::ArgumentOutOfRangeException("skill_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'skill_id' cannot be null",
                    new System::ArgumentNullException("skill_id")
                );
        }
        init
        {
            this._rawData["skill_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Type of skill - either 'anthropic' (built-in) or 'custom' (user-defined)
    /// </summary>
    public required ApiEnum<string, BetaSkillParamsType> Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, BetaSkillParamsType>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentNullException("type")
                );
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Skill version or 'latest' for most recent version
    /// </summary>
    public string? Version
    {
        get
        {
            if (!this._rawData.TryGetValue("version", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.SkillID;
        this.Type.Validate();
        _ = this.Version;
    }

    public BetaSkillParams() { }

    public BetaSkillParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSkillParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaSkillParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSkillParamsFromRaw : IFromRaw<BetaSkillParams>
{
    public BetaSkillParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaSkillParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of skill - either 'anthropic' (built-in) or 'custom' (user-defined)
/// </summary>
[JsonConverter(typeof(BetaSkillParamsTypeConverter))]
public enum BetaSkillParamsType
{
    Anthropic,
    Custom,
}

sealed class BetaSkillParamsTypeConverter : JsonConverter<BetaSkillParamsType>
{
    public override BetaSkillParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "anthropic" => BetaSkillParamsType.Anthropic,
            "custom" => BetaSkillParamsType.Custom,
            _ => (BetaSkillParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaSkillParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaSkillParamsType.Anthropic => "anthropic",
                BetaSkillParamsType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
