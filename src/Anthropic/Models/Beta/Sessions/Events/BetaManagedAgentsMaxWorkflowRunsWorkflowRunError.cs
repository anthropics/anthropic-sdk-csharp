using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// No run was created, because the session was at its limit of open workflow runs,
/// which are runs that have not ended. Only `workflow_run.error` carries this type.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMaxWorkflowRunsWorkflowRunError,
        BetaManagedAgentsMaxWorkflowRunsWorkflowRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMaxWorkflowRunsWorkflowRunError : JsonModel
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
                JsonSerializer.SerializeToElement("max_workflow_runs_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsMaxWorkflowRunsWorkflowRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("max_workflow_runs_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMaxWorkflowRunsWorkflowRunError(
        BetaManagedAgentsMaxWorkflowRunsWorkflowRunError betaManagedAgentsMaxWorkflowRunsWorkflowRunError
    )
        : base(betaManagedAgentsMaxWorkflowRunsWorkflowRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMaxWorkflowRunsWorkflowRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("max_workflow_runs_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMaxWorkflowRunsWorkflowRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMaxWorkflowRunsWorkflowRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMaxWorkflowRunsWorkflowRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsMaxWorkflowRunsWorkflowRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsMaxWorkflowRunsWorkflowRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsMaxWorkflowRunsWorkflowRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMaxWorkflowRunsWorkflowRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMaxWorkflowRunsWorkflowRunError.FromRawUnchecked(rawData);
}
