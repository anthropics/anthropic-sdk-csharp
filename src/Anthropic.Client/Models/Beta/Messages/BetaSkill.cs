using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

/// <summary>
/// A skill that was loaded in a container (response model).
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaSkill>))]
public sealed record class BetaSkill : ModelBase, IFromRaw<BetaSkill>
{
    /// <summary>
    /// Skill ID
    /// </summary>
    public required string SkillID
    {
        get
        {
            if (!this._properties.TryGetValue("skill_id", out JsonElement element))
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
            this._properties["skill_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Type of skill - either 'anthropic' (built-in) or 'custom' (user-defined)
    /// </summary>
    public required ApiEnum<string, global::Anthropic.Client.Models.Beta.Messages.Type> Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Anthropic.Client.Models.Beta.Messages.Type>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Skill version or 'latest' for most recent version
    /// </summary>
    public required string Version
    {
        get
        {
            if (!this._properties.TryGetValue("version", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'version' cannot be null",
                    new System::ArgumentOutOfRangeException("version", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'version' cannot be null",
                    new System::ArgumentNullException("version")
                );
        }
        init
        {
            this._properties["version"] = JsonSerializer.SerializeToElement(
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

    public BetaSkill() { }

    public BetaSkill(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSkill(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaSkill FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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

sealed class TypeConverter : JsonConverter<global::Anthropic.Client.Models.Beta.Messages.Type>
{
    public override global::Anthropic.Client.Models.Beta.Messages.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "anthropic" => global::Anthropic.Client.Models.Beta.Messages.Type.Anthropic,
            "custom" => global::Anthropic.Client.Models.Beta.Messages.Type.Custom,
            _ => (global::Anthropic.Client.Models.Beta.Messages.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Client.Models.Beta.Messages.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Client.Models.Beta.Messages.Type.Anthropic => "anthropic",
                global::Anthropic.Client.Models.Beta.Messages.Type.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
