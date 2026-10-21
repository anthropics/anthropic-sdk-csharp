using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The telemetry destination receives the spans of the workspaces that it covers.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationStateEnabled,
        BetaTelemetryDestinationStateEnabledFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationStateEnabled : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationStateEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationStateEnabled(
        BetaTelemetryDestinationStateEnabled betaTelemetryDestinationStateEnabled
    )
        : base(betaTelemetryDestinationStateEnabled) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationStateEnabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationStateEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationStateEnabledFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationStateEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationStateEnabledFromRaw
    : IFromRawJson<BetaTelemetryDestinationStateEnabled>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationStateEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationStateEnabled.FromRawUnchecked(rawData);
}
