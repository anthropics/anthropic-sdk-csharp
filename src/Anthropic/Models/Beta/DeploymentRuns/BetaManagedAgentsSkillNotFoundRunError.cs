using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// A skill referenced by the deployment's agent no longer exists.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSkillNotFoundRunError,
        BetaManagedAgentsSkillNotFoundRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSkillNotFoundRunError : JsonModel
{
    /// <summary>
    /// Human-readable error description.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSkillNotFoundRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSkillNotFoundRunErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.Type.Validate();
    }

    public BetaManagedAgentsSkillNotFoundRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSkillNotFoundRunError(
        BetaManagedAgentsSkillNotFoundRunError betaManagedAgentsSkillNotFoundRunError
    )
        : base(betaManagedAgentsSkillNotFoundRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSkillNotFoundRunError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSkillNotFoundRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSkillNotFoundRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSkillNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSkillNotFoundRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSkillNotFoundRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSkillNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSkillNotFoundRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSkillNotFoundRunErrorTypeConverter))]
public enum BetaManagedAgentsSkillNotFoundRunErrorType
{
    SkillNotFoundError,
}

sealed class BetaManagedAgentsSkillNotFoundRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsSkillNotFoundRunErrorType>
{
    public override BetaManagedAgentsSkillNotFoundRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "skill_not_found_error" =>
                BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError,
            _ => (BetaManagedAgentsSkillNotFoundRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSkillNotFoundRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError =>
                    "skill_not_found_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
