using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

/// <summary>
/// Some of the request's changes may have been saved and others not. Send the same
/// request again to finish it; changes already saved aren't repeated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChangeOutcomeUnknownErrorDetails,
        ChangeOutcomeUnknownErrorDetailsFromRaw
    >)
)]
public sealed record class ChangeOutcomeUnknownErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("change_outcome_unknown")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ChangeOutcomeUnknownErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("change_outcome_unknown");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChangeOutcomeUnknownErrorDetails(
        ChangeOutcomeUnknownErrorDetails changeOutcomeUnknownErrorDetails
    )
        : base(changeOutcomeUnknownErrorDetails) { }
#pragma warning restore CS8618

    public ChangeOutcomeUnknownErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("change_outcome_unknown");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChangeOutcomeUnknownErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChangeOutcomeUnknownErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ChangeOutcomeUnknownErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChangeOutcomeUnknownErrorDetailsFromRaw : IFromRawJson<ChangeOutcomeUnknownErrorDetails>
{
    /// <inheritdoc/>
    public ChangeOutcomeUnknownErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChangeOutcomeUnknownErrorDetails.FromRawUnchecked(rawData);
}
