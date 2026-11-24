using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// A copy of the message was stored and can't be returned.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewStoredCopyUnavailable,
        BetaComplianceReviewStoredCopyUnavailableFromRaw
    >)
)]
public sealed record class BetaComplianceReviewStoredCopyUnavailable : JsonModel
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("stored_copy_unavailable")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceReviewStoredCopyUnavailable()
    {
        this.Type = JsonSerializer.SerializeToElement("stored_copy_unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewStoredCopyUnavailable(
        BetaComplianceReviewStoredCopyUnavailable betaComplianceReviewStoredCopyUnavailable
    )
        : base(betaComplianceReviewStoredCopyUnavailable) { }
#pragma warning restore CS8618

    public BetaComplianceReviewStoredCopyUnavailable(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("stored_copy_unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewStoredCopyUnavailable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewStoredCopyUnavailableFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewStoredCopyUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewStoredCopyUnavailableFromRaw
    : IFromRawJson<BetaComplianceReviewStoredCopyUnavailable>
{
    /// <inheritdoc/>
    public BetaComplianceReviewStoredCopyUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewStoredCopyUnavailable.FromRawUnchecked(rawData);
}
