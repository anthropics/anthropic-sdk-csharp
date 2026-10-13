using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The agent stopped the run.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWorkflowRunResultStopped,
        BetaManagedAgentsWorkflowRunResultStoppedFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWorkflowRunResultStopped : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("stopped")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsWorkflowRunResultStopped()
    {
        this.Type = JsonSerializer.SerializeToElement("stopped");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWorkflowRunResultStopped(
        BetaManagedAgentsWorkflowRunResultStopped betaManagedAgentsWorkflowRunResultStopped
    )
        : base(betaManagedAgentsWorkflowRunResultStopped) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWorkflowRunResultStopped(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("stopped");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWorkflowRunResultStopped(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWorkflowRunResultStoppedFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWorkflowRunResultStopped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWorkflowRunResultStoppedFromRaw
    : IFromRawJson<BetaManagedAgentsWorkflowRunResultStopped>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWorkflowRunResultStopped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWorkflowRunResultStopped.FromRawUnchecked(rawData);
}
