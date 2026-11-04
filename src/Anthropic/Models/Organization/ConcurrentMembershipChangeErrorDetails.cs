using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

/// <summary>
/// Another change to the organization's members is in progress. Retry the request
/// once it completes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConcurrentMembershipChangeErrorDetails,
        ConcurrentMembershipChangeErrorDetailsFromRaw
    >)
)]
public sealed record class ConcurrentMembershipChangeErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("concurrent_membership_change")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ConcurrentMembershipChangeErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("concurrent_membership_change");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConcurrentMembershipChangeErrorDetails(
        ConcurrentMembershipChangeErrorDetails concurrentMembershipChangeErrorDetails
    )
        : base(concurrentMembershipChangeErrorDetails) { }
#pragma warning restore CS8618

    public ConcurrentMembershipChangeErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("concurrent_membership_change");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConcurrentMembershipChangeErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConcurrentMembershipChangeErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ConcurrentMembershipChangeErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConcurrentMembershipChangeErrorDetailsFromRaw
    : IFromRawJson<ConcurrentMembershipChangeErrorDetails>
{
    /// <inheritdoc/>
    public ConcurrentMembershipChangeErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConcurrentMembershipChangeErrorDetails.FromRawUnchecked(rawData);
}
