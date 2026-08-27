using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Skills;

[JsonConverter(typeof(JsonModelConverter<BetaSkillSource, BetaSkillSourceFromRaw>))]
public sealed record class BetaSkillSource : JsonModel
{
    /// <summary>
    /// Where the Skill comes from.
    ///
    /// <para>Possible values: * `"custom"`: authored by the platform user; private
    /// to their workspace * `"anthropic"`: published by Anthropic; shared and read-only
    /// * `"anthropic_example"`: Anthropic-published sample Skill * `"plugin"`: resolved
    /// from an installed plugin</para>
    /// </summary>
    public required ApiEnum<string, global::Anthropic.Models.Beta.Skills.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Skills.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaSkillSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSkillSource(BetaSkillSource betaSkillSource)
        : base(betaSkillSource) { }
#pragma warning restore CS8618

    public BetaSkillSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSkillSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSkillSourceFromRaw.FromRawUnchecked"/>
    public static BetaSkillSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSkillSource(ApiEnum<string, global::Anthropic.Models.Beta.Skills.Type> type)
        : this()
    {
        this.Type = type;
    }
}

class BetaSkillSourceFromRaw : IFromRawJson<BetaSkillSource>
{
    /// <inheritdoc/>
    public BetaSkillSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaSkillSource.FromRawUnchecked(rawData);
}

/// <summary>
/// Where the Skill comes from.
///
/// <para>Possible values: * `"custom"`: authored by the platform user; private to
/// their workspace * `"anthropic"`: published by Anthropic; shared and read-only
/// * `"anthropic_example"`: Anthropic-published sample Skill * `"plugin"`: resolved
/// from an installed plugin</para>
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Custom,
    Anthropic,
    AnthropicExample,
    Plugin,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Skills.Type>
{
    public override global::Anthropic.Models.Beta.Skills.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom" => global::Anthropic.Models.Beta.Skills.Type.Custom,
            "anthropic" => global::Anthropic.Models.Beta.Skills.Type.Anthropic,
            "anthropic_example" => global::Anthropic.Models.Beta.Skills.Type.AnthropicExample,
            "plugin" => global::Anthropic.Models.Beta.Skills.Type.Plugin,
            _ => (global::Anthropic.Models.Beta.Skills.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Skills.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Skills.Type.Custom => "custom",
                global::Anthropic.Models.Beta.Skills.Type.Anthropic => "anthropic",
                global::Anthropic.Models.Beta.Skills.Type.AnthropicExample => "anthropic_example",
                global::Anthropic.Models.Beta.Skills.Type.Plugin => "plugin",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
