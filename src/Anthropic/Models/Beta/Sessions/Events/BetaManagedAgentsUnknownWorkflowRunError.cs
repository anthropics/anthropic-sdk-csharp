using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// A failure that has no type of its own.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUnknownWorkflowRunError,
        BetaManagedAgentsUnknownWorkflowRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUnknownWorkflowRunError : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("unknown_error")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsUnknownWorkflowRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("unknown_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUnknownWorkflowRunError(
        BetaManagedAgentsUnknownWorkflowRunError betaManagedAgentsUnknownWorkflowRunError
    )
        : base(betaManagedAgentsUnknownWorkflowRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUnknownWorkflowRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("unknown_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUnknownWorkflowRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUnknownWorkflowRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUnknownWorkflowRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsUnknownWorkflowRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsUnknownWorkflowRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsUnknownWorkflowRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUnknownWorkflowRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUnknownWorkflowRunError.FromRawUnchecked(rawData);
}
