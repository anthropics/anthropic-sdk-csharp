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
[JsonConverter(typeof(JsonModelConverter<BetaSkillParams, BetaSkillParamsFromRaw>))]
public sealed record class BetaSkillParams : JsonModel
{
    /// <summary>
    /// Skill ID
    /// </summary>
    public required string SkillID
    {
        get { return this._rawData.GetNotNullClass<string>("skill_id"); }
        init { this._rawData.Set("skill_id", value); }
    }

    /// <summary>
    /// Type of skill - either 'anthropic' (built-in) or 'custom' (user-defined)
    /// </summary>
    public required ApiEnum<string, BetaSkillParamsType> Type
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, BetaSkillParamsType>>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Skill version or 'latest' for most recent version
    /// </summary>
    public string? Version
    {
        get { return this._rawData.GetNullableClass<string>("version"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSkillParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSkillParamsFromRaw.FromRawUnchecked"/>
    public static BetaSkillParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSkillParamsFromRaw : IFromRawJson<BetaSkillParams>
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
