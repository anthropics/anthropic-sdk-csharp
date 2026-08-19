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
/// Specification for a skill to be loaded in a container (request model).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SkillParams, SkillParamsFromRaw>))]
public sealed record class SkillParams : JsonModel
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
    public required ApiEnum<string, SkillParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SkillParamsType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Skill version or 'latest' for most recent version
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
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

    public SkillParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SkillParams(SkillParams skillParams)
        : base(skillParams) { }
#pragma warning restore CS8618

    public SkillParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillParamsFromRaw.FromRawUnchecked"/>
    public static SkillParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SkillParamsFromRaw : IFromRawJson<SkillParams>
{
    /// <inheritdoc/>
    public SkillParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SkillParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of skill - either 'anthropic' (built-in) or 'custom' (user-defined)
/// </summary>
[JsonConverter(typeof(SkillParamsTypeConverter))]
public enum SkillParamsType
{
    Anthropic,
    Custom,
}

sealed class SkillParamsTypeConverter : JsonConverter<SkillParamsType>
{
    public override SkillParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "anthropic" => SkillParamsType.Anthropic,
            "custom" => SkillParamsType.Custom,
            _ => (SkillParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SkillParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SkillParamsType.Anthropic => "anthropic",
                SkillParamsType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
