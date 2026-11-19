using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// The RBAC Group order already has the most groups allowed. Delete another group's
/// settings first.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaRbacGroupOrderLimitExceededErrorDetails,
        BetaRbacGroupOrderLimitExceededErrorDetailsFromRaw
    >)
)]
public sealed record class BetaRbacGroupOrderLimitExceededErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("rbac_group_order_limit_exceeded")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRbacGroupOrderLimitExceededErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_group_order_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacGroupOrderLimitExceededErrorDetails(
        BetaRbacGroupOrderLimitExceededErrorDetails betaRbacGroupOrderLimitExceededErrorDetails
    )
        : base(betaRbacGroupOrderLimitExceededErrorDetails) { }
#pragma warning restore CS8618

    public BetaRbacGroupOrderLimitExceededErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_group_order_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacGroupOrderLimitExceededErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacGroupOrderLimitExceededErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaRbacGroupOrderLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRbacGroupOrderLimitExceededErrorDetailsFromRaw
    : IFromRawJson<BetaRbacGroupOrderLimitExceededErrorDetails>
{
    /// <inheritdoc/>
    public BetaRbacGroupOrderLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRbacGroupOrderLimitExceededErrorDetails.FromRawUnchecked(rawData);
}
