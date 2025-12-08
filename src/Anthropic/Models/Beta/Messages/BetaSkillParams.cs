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
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "skill_id"); }
        init { ModelBase.Set(this._rawData, "skill_id", value); }
    }

    /// <summary>
    /// Type of skill - either 'anthropic' (built-in) or 'custom' (user-defined)
    /// </summary>
    public required ApiEnum<string, BetaSkillParamsType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, BetaSkillParamsType>>(
                this.RawData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Skill version or 'latest' for most recent version
    /// </summary>
    public string? Version
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "version"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SkillID;
        this.Type.Validate();
        _ = this.Version;
    }

    public BetaSkillParams() { }

    public BetaSkillParams(BetaSkillParams betaSkillParams)
        : base(betaSkillParams) { }

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

    /// <inheritdoc cref="BetaSkillParamsFromRaw.FromRawUnchecked"/>
    public static BetaSkillParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSkillParamsFromRaw : IFromRaw<BetaSkillParams>
{
    /// <inheritdoc/>
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
