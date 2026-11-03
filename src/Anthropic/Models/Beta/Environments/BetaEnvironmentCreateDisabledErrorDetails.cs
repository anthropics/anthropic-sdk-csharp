using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Anthropic has turned off creating environments for this organization. Existing
/// environments still work.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaEnvironmentCreateDisabledErrorDetails,
        BetaEnvironmentCreateDisabledErrorDetailsFromRaw
    >)
)]
public sealed record class BetaEnvironmentCreateDisabledErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("environment_create_disabled")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaEnvironmentCreateDisabledErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("environment_create_disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaEnvironmentCreateDisabledErrorDetails(
        BetaEnvironmentCreateDisabledErrorDetails betaEnvironmentCreateDisabledErrorDetails
    )
        : base(betaEnvironmentCreateDisabledErrorDetails) { }
#pragma warning restore CS8618

    public BetaEnvironmentCreateDisabledErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("environment_create_disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaEnvironmentCreateDisabledErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaEnvironmentCreateDisabledErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaEnvironmentCreateDisabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaEnvironmentCreateDisabledErrorDetailsFromRaw
    : IFromRawJson<BetaEnvironmentCreateDisabledErrorDetails>
{
    /// <inheritdoc/>
    public BetaEnvironmentCreateDisabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaEnvironmentCreateDisabledErrorDetails.FromRawUnchecked(rawData);
}
