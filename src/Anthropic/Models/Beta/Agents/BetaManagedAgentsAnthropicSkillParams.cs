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

    public required ApiEnum<string, BetaManagedAgentsAnthropicSkillParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAnthropicSkillParamsType>
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

    public BetaManagedAgentsAnthropicSkillParams() { }

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
}

class BetaManagedAgentsAnthropicSkillParamsFromRaw
    : IFromRawJson<BetaManagedAgentsAnthropicSkillParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAnthropicSkillParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAnthropicSkillParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsAnthropicSkillParamsTypeConverter))]
public enum BetaManagedAgentsAnthropicSkillParamsType
{
    Anthropic,
}

sealed class BetaManagedAgentsAnthropicSkillParamsTypeConverter
    : JsonConverter<BetaManagedAgentsAnthropicSkillParamsType>
{
    public override BetaManagedAgentsAnthropicSkillParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "anthropic" => BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
            _ => (BetaManagedAgentsAnthropicSkillParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAnthropicSkillParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAnthropicSkillParamsType.Anthropic => "anthropic",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
