using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The organization has crossed the monthly API usage threshold of its API tier.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EnforcedSpendLimitReachedErrorDetails,
        EnforcedSpendLimitReachedErrorDetailsFromRaw
    >)
)]
public sealed record class EnforcedSpendLimitReachedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("enforced_spend_limit_reached")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public EnforcedSpendLimitReachedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("enforced_spend_limit_reached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnforcedSpendLimitReachedErrorDetails(
        EnforcedSpendLimitReachedErrorDetails enforcedSpendLimitReachedErrorDetails
    )
        : base(enforcedSpendLimitReachedErrorDetails) { }
#pragma warning restore CS8618

    public EnforcedSpendLimitReachedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("enforced_spend_limit_reached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnforcedSpendLimitReachedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnforcedSpendLimitReachedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static EnforcedSpendLimitReachedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnforcedSpendLimitReachedErrorDetailsFromRaw
    : IFromRawJson<EnforcedSpendLimitReachedErrorDetails>
{
    /// <inheritdoc/>
    public EnforcedSpendLimitReachedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EnforcedSpendLimitReachedErrorDetails.FromRawUnchecked(rawData);
}
