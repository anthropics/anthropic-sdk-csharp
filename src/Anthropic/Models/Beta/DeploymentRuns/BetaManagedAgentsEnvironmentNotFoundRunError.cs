using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// The deployment's environment no longer exists.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsEnvironmentNotFoundRunError,
        BetaManagedAgentsEnvironmentNotFoundRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsEnvironmentNotFoundRunError : JsonModel
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
                JsonSerializer.SerializeToElement("environment_not_found_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsEnvironmentNotFoundRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("environment_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentNotFoundRunError(
        BetaManagedAgentsEnvironmentNotFoundRunError betaManagedAgentsEnvironmentNotFoundRunError
    )
        : base(betaManagedAgentsEnvironmentNotFoundRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEnvironmentNotFoundRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("environment_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEnvironmentNotFoundRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEnvironmentNotFoundRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEnvironmentNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentNotFoundRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsEnvironmentNotFoundRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsEnvironmentNotFoundRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEnvironmentNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEnvironmentNotFoundRunError.FromRawUnchecked(rawData);
}
