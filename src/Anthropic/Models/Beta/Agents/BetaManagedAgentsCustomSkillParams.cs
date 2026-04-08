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
/// A user-created custom skill.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsCustomSkillParams,
        BetaManagedAgentsCustomSkillParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsCustomSkillParams : JsonModel
{
    /// <summary>
    /// Tagged ID of the custom skill (e.g., "skill_01XJ5...").
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

    public required ApiEnum<string, BetaManagedAgentsCustomSkillParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsCustomSkillParamsType>
            >("type");
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
        this.Type.Validate();
        _ = this.Version;
    }

    public BetaManagedAgentsCustomSkillParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsCustomSkillParams(
        BetaManagedAgentsCustomSkillParams betaManagedAgentsCustomSkillParams
    )
        : base(betaManagedAgentsCustomSkillParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsCustomSkillParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsCustomSkillParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsCustomSkillParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsCustomSkillParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsCustomSkillParamsFromRaw : IFromRawJson<BetaManagedAgentsCustomSkillParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCustomSkillParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCustomSkillParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsCustomSkillParamsTypeConverter))]
public enum BetaManagedAgentsCustomSkillParamsType
{
    Custom,
}

sealed class BetaManagedAgentsCustomSkillParamsTypeConverter
    : JsonConverter<BetaManagedAgentsCustomSkillParamsType>
{
    public override BetaManagedAgentsCustomSkillParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom" => BetaManagedAgentsCustomSkillParamsType.Custom,
            _ => (BetaManagedAgentsCustomSkillParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsCustomSkillParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsCustomSkillParamsType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
