using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Skills;

[JsonConverter(typeof(JsonModelConverter<SkillSource, SkillSourceFromRaw>))]
public sealed record class SkillSource : JsonModel
{
    /// <summary>
    /// Where the Skill comes from.
    ///
    /// <para>Possible values: * `"custom"`: authored by the platform user; private
    /// to their workspace * `"anthropic"`: published by Anthropic; shared and read-only
    /// * `"anthropic_example"`: Anthropic-published sample Skill * `"plugin"`: resolved
    /// from an installed plugin</para>
    /// </summary>
    public required ApiEnum<string, global::Anthropic.Models.Skills.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Skills.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public SkillSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SkillSource(SkillSource skillSource)
        : base(skillSource) { }
#pragma warning restore CS8618

    public SkillSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillSourceFromRaw.FromRawUnchecked"/>
    public static SkillSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SkillSource(ApiEnum<string, global::Anthropic.Models.Skills.Type> type)
        : this()
    {
        this.Type = type;
    }
}

class SkillSourceFromRaw : IFromRawJson<SkillSource>
{
    /// <inheritdoc/>
    public SkillSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SkillSource.FromRawUnchecked(rawData);
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

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Skills.Type>
{
    public override global::Anthropic.Models.Skills.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom" => global::Anthropic.Models.Skills.Type.Custom,
            "anthropic" => global::Anthropic.Models.Skills.Type.Anthropic,
            "anthropic_example" => global::Anthropic.Models.Skills.Type.AnthropicExample,
            "plugin" => global::Anthropic.Models.Skills.Type.Plugin,
            _ => (global::Anthropic.Models.Skills.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Skills.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Skills.Type.Custom => "custom",
                global::Anthropic.Models.Skills.Type.Anthropic => "anthropic",
                global::Anthropic.Models.Skills.Type.AnthropicExample => "anthropic_example",
                global::Anthropic.Models.Skills.Type.Plugin => "plugin",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
