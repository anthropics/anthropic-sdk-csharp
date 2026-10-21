using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The test span was not delivered.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationTestFailure,
        BetaTelemetryDestinationTestFailureFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationTestFailure : JsonModel
{
    /// <summary>
    /// A message that describes why the test span was not delivered, including the
    /// HTTP status code when the destination returned one. Examples: `HTTP error
    /// (status 403)`, `timeout`, `TLS failure`. It has the same form as the destination's
    /// `delivery_health.last_error` and never contains the destination's response
    /// body, any header value, a network address, or TLS details.
    /// </summary>
    public required string Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("error");
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
        _ = this.Error;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("failure")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationTestFailure()
    {
        this.Type = JsonSerializer.SerializeToElement("failure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationTestFailure(
        BetaTelemetryDestinationTestFailure betaTelemetryDestinationTestFailure
    )
        : base(betaTelemetryDestinationTestFailure) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationTestFailure(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("failure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationTestFailure(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationTestFailureFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationTestFailure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaTelemetryDestinationTestFailure(string error)
        : this()
    {
        this.Error = error;
    }
}

class BetaTelemetryDestinationTestFailureFromRaw : IFromRawJson<BetaTelemetryDestinationTestFailure>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationTestFailure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationTestFailure.FromRawUnchecked(rawData);
}
