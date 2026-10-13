using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The run reached its time limit.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTimeoutWorkflowRunError,
        BetaManagedAgentsTimeoutWorkflowRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTimeoutWorkflowRunError : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("timeout_error")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsTimeoutWorkflowRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("timeout_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTimeoutWorkflowRunError(
        BetaManagedAgentsTimeoutWorkflowRunError betaManagedAgentsTimeoutWorkflowRunError
    )
        : base(betaManagedAgentsTimeoutWorkflowRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTimeoutWorkflowRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("timeout_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTimeoutWorkflowRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTimeoutWorkflowRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTimeoutWorkflowRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTimeoutWorkflowRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsTimeoutWorkflowRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsTimeoutWorkflowRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTimeoutWorkflowRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTimeoutWorkflowRunError.FromRawUnchecked(rawData);
}
