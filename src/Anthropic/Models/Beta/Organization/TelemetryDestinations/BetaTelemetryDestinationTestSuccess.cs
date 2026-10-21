using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The destination answered the test span with a 2xx status.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationTestSuccess,
        BetaTelemetryDestinationTestSuccessFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationTestSuccess : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("success")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationTestSuccess()
    {
        this.Type = JsonSerializer.SerializeToElement("success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationTestSuccess(
        BetaTelemetryDestinationTestSuccess betaTelemetryDestinationTestSuccess
    )
        : base(betaTelemetryDestinationTestSuccess) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationTestSuccess(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationTestSuccess(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationTestSuccessFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationTestSuccess FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationTestSuccessFromRaw : IFromRawJson<BetaTelemetryDestinationTestSuccess>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationTestSuccess FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationTestSuccess.FromRawUnchecked(rawData);
}
