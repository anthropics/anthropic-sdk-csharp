using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// A caller disabled the destination with an update that set `state` to `disabled`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationDisabledReasonCaller,
        BetaTelemetryDestinationDisabledReasonCallerFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationDisabledReasonCaller : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("caller")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationDisabledReasonCaller()
    {
        this.Type = JsonSerializer.SerializeToElement("caller");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationDisabledReasonCaller(
        BetaTelemetryDestinationDisabledReasonCaller betaTelemetryDestinationDisabledReasonCaller
    )
        : base(betaTelemetryDestinationDisabledReasonCaller) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationDisabledReasonCaller(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("caller");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationDisabledReasonCaller(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationDisabledReasonCallerFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationDisabledReasonCaller FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationDisabledReasonCallerFromRaw
    : IFromRawJson<BetaTelemetryDestinationDisabledReasonCaller>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationDisabledReasonCaller FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationDisabledReasonCaller.FromRawUnchecked(rawData);
}
