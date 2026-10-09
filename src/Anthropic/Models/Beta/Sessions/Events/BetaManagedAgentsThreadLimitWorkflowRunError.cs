using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The run exceeded the limit on the number of threads that a run can create.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsThreadLimitWorkflowRunError,
        BetaManagedAgentsThreadLimitWorkflowRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsThreadLimitWorkflowRunError : JsonModel
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("thread_limit_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsThreadLimitWorkflowRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("thread_limit_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsThreadLimitWorkflowRunError(
        BetaManagedAgentsThreadLimitWorkflowRunError betaManagedAgentsThreadLimitWorkflowRunError
    )
        : base(betaManagedAgentsThreadLimitWorkflowRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsThreadLimitWorkflowRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thread_limit_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsThreadLimitWorkflowRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsThreadLimitWorkflowRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsThreadLimitWorkflowRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsThreadLimitWorkflowRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsThreadLimitWorkflowRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsThreadLimitWorkflowRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsThreadLimitWorkflowRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsThreadLimitWorkflowRunError.FromRawUnchecked(rawData);
}
