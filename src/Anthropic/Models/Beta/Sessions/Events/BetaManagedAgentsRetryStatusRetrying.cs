using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The server is retrying automatically. Client should wait; the same error type
/// may fire again as retrying, then once as exhausted when the retry budget runs out.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsRetryStatusRetrying,
        BetaManagedAgentsRetryStatusRetryingFromRaw
    >)
)]
public sealed record class BetaManagedAgentsRetryStatusRetrying : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("retrying")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsRetryStatusRetrying()
    {
        this.Type = JsonSerializer.SerializeToElement("retrying");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsRetryStatusRetrying(
        BetaManagedAgentsRetryStatusRetrying betaManagedAgentsRetryStatusRetrying
    )
        : base(betaManagedAgentsRetryStatusRetrying) { }
#pragma warning restore CS8618

    public BetaManagedAgentsRetryStatusRetrying(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("retrying");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsRetryStatusRetrying(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsRetryStatusRetryingFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsRetryStatusRetrying FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsRetryStatusRetryingFromRaw
    : IFromRawJson<BetaManagedAgentsRetryStatusRetrying>
{
    /// <inheritdoc/>
    public BetaManagedAgentsRetryStatusRetrying FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsRetryStatusRetrying.FromRawUnchecked(rawData);
}
