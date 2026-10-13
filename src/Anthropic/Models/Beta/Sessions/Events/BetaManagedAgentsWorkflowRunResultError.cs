using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The run failed or reached its time limit.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWorkflowRunResultError,
        BetaManagedAgentsWorkflowRunResultErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWorkflowRunResultError : JsonModel
{
    /// <summary>
    /// Why the run did not finish.
    /// </summary>
    public required BetaManagedAgentsWorkflowRunError Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsWorkflowRunError>("error");
        }
        init { this._rawData.Set("error", value); }
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
        this.Error.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("error")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsWorkflowRunResultError()
    {
        this.Type = JsonSerializer.SerializeToElement("error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWorkflowRunResultError(
        BetaManagedAgentsWorkflowRunResultError betaManagedAgentsWorkflowRunResultError
    )
        : base(betaManagedAgentsWorkflowRunResultError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWorkflowRunResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWorkflowRunResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWorkflowRunResultErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWorkflowRunResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsWorkflowRunResultError(BetaManagedAgentsWorkflowRunError error)
        : this()
    {
        this.Error = error;
    }
}

class BetaManagedAgentsWorkflowRunResultErrorFromRaw
    : IFromRawJson<BetaManagedAgentsWorkflowRunResultError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWorkflowRunResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWorkflowRunResultError.FromRawUnchecked(rawData);
}
