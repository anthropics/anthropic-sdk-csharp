using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

/// <summary>
/// The External Key failed Anthropic's validation, so the request was refused. The
/// message gives the reason, if there is one.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExternalKeyValidationFailedErrorDetails,
        ExternalKeyValidationFailedErrorDetailsFromRaw
    >)
)]
public sealed record class ExternalKeyValidationFailedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("external_key_validation_failed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ExternalKeyValidationFailedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_validation_failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalKeyValidationFailedErrorDetails(
        ExternalKeyValidationFailedErrorDetails externalKeyValidationFailedErrorDetails
    )
        : base(externalKeyValidationFailedErrorDetails) { }
#pragma warning restore CS8618

    public ExternalKeyValidationFailedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_validation_failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalKeyValidationFailedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalKeyValidationFailedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ExternalKeyValidationFailedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalKeyValidationFailedErrorDetailsFromRaw
    : IFromRawJson<ExternalKeyValidationFailedErrorDetails>
{
    /// <inheritdoc/>
    public ExternalKeyValidationFailedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalKeyValidationFailedErrorDetails.FromRawUnchecked(rawData);
}
