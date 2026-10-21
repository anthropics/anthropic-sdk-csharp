using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// The deployment's agent was archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentArchivedRunError,
        BetaManagedAgentsAgentArchivedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentArchivedRunError : JsonModel
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
                JsonSerializer.SerializeToElement("agent_archived_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAgentArchivedRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("agent_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentArchivedRunError(
        BetaManagedAgentsAgentArchivedRunError betaManagedAgentsAgentArchivedRunError
    )
        : base(betaManagedAgentsAgentArchivedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentArchivedRunError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("agent_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentArchivedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentArchivedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentArchivedRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsAgentArchivedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsAgentArchivedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentArchivedRunError.FromRawUnchecked(rawData);
}
