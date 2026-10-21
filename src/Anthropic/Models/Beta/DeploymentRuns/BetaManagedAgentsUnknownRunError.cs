using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// An unknown or unexpected error caused the run to fail. A fallback variant; clients
/// that do not recognize a new error type can match on message alone.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUnknownRunError,
        BetaManagedAgentsUnknownRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUnknownRunError : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("unknown_error")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsUnknownRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("unknown_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUnknownRunError(
        BetaManagedAgentsUnknownRunError betaManagedAgentsUnknownRunError
    )
        : base(betaManagedAgentsUnknownRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUnknownRunError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("unknown_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUnknownRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUnknownRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUnknownRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsUnknownRunError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaManagedAgentsUnknownRunErrorFromRaw : IFromRawJson<BetaManagedAgentsUnknownRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUnknownRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUnknownRunError.FromRawUnchecked(rawData);
}
