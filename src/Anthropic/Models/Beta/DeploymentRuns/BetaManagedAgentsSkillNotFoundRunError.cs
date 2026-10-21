using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("skill_not_found_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSkillNotFoundRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("skill_not_found_error");
    }

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

        this.Type = JsonSerializer.SerializeToElement("skill_not_found_error");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsSkillNotFoundRunError(string message)
        : this()
    {
        this.Message = message;
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
