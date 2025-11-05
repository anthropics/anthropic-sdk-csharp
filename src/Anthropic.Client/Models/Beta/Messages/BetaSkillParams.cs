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
/// Specification for a skill to be loaded in a container (request model).
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaSkillParams>))]
public sealed record class BetaSkillParams : ModelBase, IFromRaw<BetaSkillParams>
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
    public required ApiEnum<string, TypeModel> Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TypeModel>>(
                element,
                ModelBase.SerializerOptions
            );
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
    public string? Version
    {
        get
        {
            if (!this._properties.TryGetValue("version", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
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

    public BetaSkillParams() { }

    public BetaSkillParams(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSkillParams(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaSkillParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Type of skill - either 'anthropic' (built-in) or 'custom' (user-defined)
/// </summary>
[JsonConverter(typeof(TypeModelConverter))]
public enum TypeModel
{
    Anthropic,
    Custom,
}

sealed class TypeModelConverter : JsonConverter<TypeModel>
{
    public override TypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "anthropic" => TypeModel.Anthropic,
            "custom" => TypeModel.Custom,
            _ => (TypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TypeModel.Anthropic => "anthropic",
                TypeModel.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
