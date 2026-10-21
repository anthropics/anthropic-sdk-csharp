using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// The deployment's environment was archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsEnvironmentArchivedRunError,
        BetaManagedAgentsEnvironmentArchivedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsEnvironmentArchivedRunError : JsonModel
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
                JsonSerializer.SerializeToElement("environment_archived_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsEnvironmentArchivedRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("environment_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentArchivedRunError(
        BetaManagedAgentsEnvironmentArchivedRunError betaManagedAgentsEnvironmentArchivedRunError
    )
        : base(betaManagedAgentsEnvironmentArchivedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEnvironmentArchivedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("environment_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEnvironmentArchivedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEnvironmentArchivedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEnvironmentArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentArchivedRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsEnvironmentArchivedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsEnvironmentArchivedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEnvironmentArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEnvironmentArchivedRunError.FromRawUnchecked(rawData);
}
