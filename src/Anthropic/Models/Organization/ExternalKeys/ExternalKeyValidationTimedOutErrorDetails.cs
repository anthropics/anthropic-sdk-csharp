using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

/// <summary>
/// Anthropic's validation of the External Key did not finish in time, so the request
/// was refused. Wait a moment, then send the request again.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExternalKeyValidationTimedOutErrorDetails,
        ExternalKeyValidationTimedOutErrorDetailsFromRaw
    >)
)]
public sealed record class ExternalKeyValidationTimedOutErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("external_key_validation_timed_out")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ExternalKeyValidationTimedOutErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_validation_timed_out");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalKeyValidationTimedOutErrorDetails(
        ExternalKeyValidationTimedOutErrorDetails externalKeyValidationTimedOutErrorDetails
    )
        : base(externalKeyValidationTimedOutErrorDetails) { }
#pragma warning restore CS8618

    public ExternalKeyValidationTimedOutErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_validation_timed_out");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalKeyValidationTimedOutErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalKeyValidationTimedOutErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ExternalKeyValidationTimedOutErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalKeyValidationTimedOutErrorDetailsFromRaw
    : IFromRawJson<ExternalKeyValidationTimedOutErrorDetails>
{
    /// <inheritdoc/>
    public ExternalKeyValidationTimedOutErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalKeyValidationTimedOutErrorDetails.FromRawUnchecked(rawData);
}
