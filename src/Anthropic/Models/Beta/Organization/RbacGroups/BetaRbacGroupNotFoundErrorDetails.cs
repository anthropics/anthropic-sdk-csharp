using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacGroups;

/// <summary>
/// The RBAC Group is not one of the organization's groups.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaRbacGroupNotFoundErrorDetails,
        BetaRbacGroupNotFoundErrorDetailsFromRaw
    >)
)]
public sealed record class BetaRbacGroupNotFoundErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("rbac_group_not_found")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRbacGroupNotFoundErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_group_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacGroupNotFoundErrorDetails(
        BetaRbacGroupNotFoundErrorDetails betaRbacGroupNotFoundErrorDetails
    )
        : base(betaRbacGroupNotFoundErrorDetails) { }
#pragma warning restore CS8618

    public BetaRbacGroupNotFoundErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_group_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacGroupNotFoundErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacGroupNotFoundErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaRbacGroupNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRbacGroupNotFoundErrorDetailsFromRaw : IFromRawJson<BetaRbacGroupNotFoundErrorDetails>
{
    /// <inheritdoc/>
    public BetaRbacGroupNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRbacGroupNotFoundErrorDetails.FromRawUnchecked(rawData);
}
