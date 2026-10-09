using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The plan, a program that the agent wrote, failed, or the server refused it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsProgramWorkflowRunError,
        BetaManagedAgentsProgramWorkflowRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsProgramWorkflowRunError : JsonModel
{
    /// <summary>
    /// Short explanation written by the server. It never contains content from the
    /// run or its agents.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("program_error")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsProgramWorkflowRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("program_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsProgramWorkflowRunError(
        BetaManagedAgentsProgramWorkflowRunError betaManagedAgentsProgramWorkflowRunError
    )
        : base(betaManagedAgentsProgramWorkflowRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsProgramWorkflowRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("program_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsProgramWorkflowRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsProgramWorkflowRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsProgramWorkflowRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsProgramWorkflowRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsProgramWorkflowRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsProgramWorkflowRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsProgramWorkflowRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsProgramWorkflowRunError.FromRawUnchecked(rawData);
}
