using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The organization has no active External Key with this ID. The message names the field.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaExternalKeyNotFoundErrorDetails,
        BetaExternalKeyNotFoundErrorDetailsFromRaw
    >)
)]
public sealed record class BetaExternalKeyNotFoundErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("external_key_not_found")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaExternalKeyNotFoundErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaExternalKeyNotFoundErrorDetails(
        BetaExternalKeyNotFoundErrorDetails betaExternalKeyNotFoundErrorDetails
    )
        : base(betaExternalKeyNotFoundErrorDetails) { }
#pragma warning restore CS8618

    public BetaExternalKeyNotFoundErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaExternalKeyNotFoundErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaExternalKeyNotFoundErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaExternalKeyNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaExternalKeyNotFoundErrorDetailsFromRaw : IFromRawJson<BetaExternalKeyNotFoundErrorDetails>
{
    /// <inheritdoc/>
    public BetaExternalKeyNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaExternalKeyNotFoundErrorDetails.FromRawUnchecked(rawData);
}
