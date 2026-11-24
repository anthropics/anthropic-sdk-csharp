using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// Anthropic has not approved keeping data in a customer-owned storage bucket for
/// the organization, project or user profile this request applies to, or has paused
/// or withdrawn its approval. If you did not expect this, contact Anthropic.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaStorageNotApprovedErrorDetails,
        BetaStorageNotApprovedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaStorageNotApprovedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("storage_not_approved")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaStorageNotApprovedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("storage_not_approved");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaStorageNotApprovedErrorDetails(
        BetaStorageNotApprovedErrorDetails betaStorageNotApprovedErrorDetails
    )
        : base(betaStorageNotApprovedErrorDetails) { }
#pragma warning restore CS8618

    public BetaStorageNotApprovedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("storage_not_approved");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaStorageNotApprovedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaStorageNotApprovedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaStorageNotApprovedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaStorageNotApprovedErrorDetailsFromRaw : IFromRawJson<BetaStorageNotApprovedErrorDetails>
{
    /// <inheritdoc/>
    public BetaStorageNotApprovedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaStorageNotApprovedErrorDetails.FromRawUnchecked(rawData);
}
