using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The API disabled the destination because the endpoint answered a delivery with
/// a 3xx status. Redirects are never followed, and one such answer disables the destination
/// at once.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationDisabledReasonRedirect,
        BetaTelemetryDestinationDisabledReasonRedirectFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationDisabledReasonRedirect : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("redirect")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationDisabledReasonRedirect()
    {
        this.Type = JsonSerializer.SerializeToElement("redirect");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationDisabledReasonRedirect(
        BetaTelemetryDestinationDisabledReasonRedirect betaTelemetryDestinationDisabledReasonRedirect
    )
        : base(betaTelemetryDestinationDisabledReasonRedirect) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationDisabledReasonRedirect(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("redirect");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationDisabledReasonRedirect(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationDisabledReasonRedirectFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationDisabledReasonRedirect FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationDisabledReasonRedirectFromRaw
    : IFromRawJson<BetaTelemetryDestinationDisabledReasonRedirect>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationDisabledReasonRedirect FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationDisabledReasonRedirect.FromRawUnchecked(rawData);
}
