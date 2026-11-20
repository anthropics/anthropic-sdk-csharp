using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

/// <summary>
/// Turning human review off needs Anthropic's approval for the organization, and
/// the organization doesn't have it. Contact Anthropic support to request approval.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaApprovalRequiredErrorDetails,
        BetaApprovalRequiredErrorDetailsFromRaw
    >)
)]
public sealed record class BetaApprovalRequiredErrorDetails : JsonModel
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

    /// <summary>
    /// The request field that needs the approval.
    /// </summary>
    public required string Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("approval_required")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Field;
    }

    public BetaApprovalRequiredErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("approval_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaApprovalRequiredErrorDetails(
        BetaApprovalRequiredErrorDetails betaApprovalRequiredErrorDetails
    )
        : base(betaApprovalRequiredErrorDetails) { }
#pragma warning restore CS8618

    public BetaApprovalRequiredErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("approval_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaApprovalRequiredErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaApprovalRequiredErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaApprovalRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaApprovalRequiredErrorDetails(string field)
        : this()
    {
        this.Field = field;
    }
}

class BetaApprovalRequiredErrorDetailsFromRaw : IFromRawJson<BetaApprovalRequiredErrorDetails>
{
    /// <inheritdoc/>
    public BetaApprovalRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaApprovalRequiredErrorDetails.FromRawUnchecked(rawData);
}
