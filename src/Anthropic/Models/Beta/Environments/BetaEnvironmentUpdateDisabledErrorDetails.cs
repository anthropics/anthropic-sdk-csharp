using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Anthropic has turned off updating environments for this organization. Existing
/// environments still work as they are.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaEnvironmentUpdateDisabledErrorDetails,
        BetaEnvironmentUpdateDisabledErrorDetailsFromRaw
    >)
)]
public sealed record class BetaEnvironmentUpdateDisabledErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("environment_update_disabled")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaEnvironmentUpdateDisabledErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("environment_update_disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaEnvironmentUpdateDisabledErrorDetails(
        BetaEnvironmentUpdateDisabledErrorDetails betaEnvironmentUpdateDisabledErrorDetails
    )
        : base(betaEnvironmentUpdateDisabledErrorDetails) { }
#pragma warning restore CS8618

    public BetaEnvironmentUpdateDisabledErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("environment_update_disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaEnvironmentUpdateDisabledErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaEnvironmentUpdateDisabledErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaEnvironmentUpdateDisabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaEnvironmentUpdateDisabledErrorDetailsFromRaw
    : IFromRawJson<BetaEnvironmentUpdateDisabledErrorDetails>
{
    /// <inheritdoc/>
    public BetaEnvironmentUpdateDisabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaEnvironmentUpdateDisabledErrorDetails.FromRawUnchecked(rawData);
}
