using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// Anthropic has not approved customer-managed encryption keys for the organization,
/// project or user profile this request applies to, or has paused or withdrawn its
/// approval. If you did not expect this, contact Anthropic.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaCmekNotApprovedErrorDetails,
        BetaCmekNotApprovedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaCmekNotApprovedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cmek_not_approved")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCmekNotApprovedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_not_approved");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCmekNotApprovedErrorDetails(
        BetaCmekNotApprovedErrorDetails betaCmekNotApprovedErrorDetails
    )
        : base(betaCmekNotApprovedErrorDetails) { }
#pragma warning restore CS8618

    public BetaCmekNotApprovedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_not_approved");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCmekNotApprovedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCmekNotApprovedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaCmekNotApprovedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCmekNotApprovedErrorDetailsFromRaw : IFromRawJson<BetaCmekNotApprovedErrorDetails>
{
    /// <inheritdoc/>
    public BetaCmekNotApprovedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCmekNotApprovedErrorDetails.FromRawUnchecked(rawData);
}
