using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The session encountered a terminal error and will transition to `terminated` state.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsRetryStatusTerminal,
        BetaManagedAgentsRetryStatusTerminalFromRaw
    >)
)]
public sealed record class BetaManagedAgentsRetryStatusTerminal : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("terminal")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsRetryStatusTerminal()
    {
        this.Type = JsonSerializer.SerializeToElement("terminal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsRetryStatusTerminal(
        BetaManagedAgentsRetryStatusTerminal betaManagedAgentsRetryStatusTerminal
    )
        : base(betaManagedAgentsRetryStatusTerminal) { }
#pragma warning restore CS8618

    public BetaManagedAgentsRetryStatusTerminal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("terminal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsRetryStatusTerminal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsRetryStatusTerminalFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsRetryStatusTerminal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsRetryStatusTerminalFromRaw
    : IFromRawJson<BetaManagedAgentsRetryStatusTerminal>
{
    /// <inheritdoc/>
    public BetaManagedAgentsRetryStatusTerminal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsRetryStatusTerminal.FromRawUnchecked(rawData);
}
