using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The organization has reached the spend limit of its contract.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ContractSpendLimitReachedErrorDetails,
        ContractSpendLimitReachedErrorDetailsFromRaw
    >)
)]
public sealed record class ContractSpendLimitReachedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("contract_spend_limit_reached")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ContractSpendLimitReachedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("contract_spend_limit_reached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractSpendLimitReachedErrorDetails(
        ContractSpendLimitReachedErrorDetails contractSpendLimitReachedErrorDetails
    )
        : base(contractSpendLimitReachedErrorDetails) { }
#pragma warning restore CS8618

    public ContractSpendLimitReachedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("contract_spend_limit_reached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractSpendLimitReachedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractSpendLimitReachedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ContractSpendLimitReachedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractSpendLimitReachedErrorDetailsFromRaw
    : IFromRawJson<ContractSpendLimitReachedErrorDetails>
{
    /// <inheritdoc/>
    public ContractSpendLimitReachedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContractSpendLimitReachedErrorDetails.FromRawUnchecked(rawData);
}
