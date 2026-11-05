using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request would exceed a ramp limit, which caps how fast usage can grow. Retry
/// after the time in the `retry-after` header.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RampLimitExceededErrorDetails, RampLimitExceededErrorDetailsFromRaw>)
)]
public sealed record class RampLimitExceededErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("ramp_limit_exceeded")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RampLimitExceededErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("ramp_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RampLimitExceededErrorDetails(
        RampLimitExceededErrorDetails rampLimitExceededErrorDetails
    )
        : base(rampLimitExceededErrorDetails) { }
#pragma warning restore CS8618

    public RampLimitExceededErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("ramp_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RampLimitExceededErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RampLimitExceededErrorDetailsFromRaw.FromRawUnchecked"/>
    public static RampLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RampLimitExceededErrorDetailsFromRaw : IFromRawJson<RampLimitExceededErrorDetails>
{
    /// <inheritdoc/>
    public RampLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RampLimitExceededErrorDetails.FromRawUnchecked(rawData);
}
