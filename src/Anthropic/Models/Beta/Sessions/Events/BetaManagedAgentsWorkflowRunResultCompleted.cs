using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The run's plan, a program that the agent wrote, finished. This does not say whether
/// the work succeeded.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWorkflowRunResultCompleted,
        BetaManagedAgentsWorkflowRunResultCompletedFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWorkflowRunResultCompleted : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("completed")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsWorkflowRunResultCompleted()
    {
        this.Type = JsonSerializer.SerializeToElement("completed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWorkflowRunResultCompleted(
        BetaManagedAgentsWorkflowRunResultCompleted betaManagedAgentsWorkflowRunResultCompleted
    )
        : base(betaManagedAgentsWorkflowRunResultCompleted) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWorkflowRunResultCompleted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("completed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWorkflowRunResultCompleted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWorkflowRunResultCompletedFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWorkflowRunResultCompleted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWorkflowRunResultCompletedFromRaw
    : IFromRawJson<BetaManagedAgentsWorkflowRunResultCompleted>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWorkflowRunResultCompleted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWorkflowRunResultCompleted.FromRawUnchecked(rawData);
}
