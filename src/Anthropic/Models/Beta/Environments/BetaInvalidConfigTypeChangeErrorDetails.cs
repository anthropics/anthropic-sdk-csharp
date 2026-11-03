using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// `config.type` differs from the environment's stored type, which cannot change
/// after creation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaInvalidConfigTypeChangeErrorDetails,
        BetaInvalidConfigTypeChangeErrorDetailsFromRaw
    >)
)]
public sealed record class BetaInvalidConfigTypeChangeErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("invalid_config_type_change")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaInvalidConfigTypeChangeErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("invalid_config_type_change");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaInvalidConfigTypeChangeErrorDetails(
        BetaInvalidConfigTypeChangeErrorDetails betaInvalidConfigTypeChangeErrorDetails
    )
        : base(betaInvalidConfigTypeChangeErrorDetails) { }
#pragma warning restore CS8618

    public BetaInvalidConfigTypeChangeErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("invalid_config_type_change");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInvalidConfigTypeChangeErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInvalidConfigTypeChangeErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaInvalidConfigTypeChangeErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaInvalidConfigTypeChangeErrorDetailsFromRaw
    : IFromRawJson<BetaInvalidConfigTypeChangeErrorDetails>
{
    /// <inheritdoc/>
    public BetaInvalidConfigTypeChangeErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaInvalidConfigTypeChangeErrorDetails.FromRawUnchecked(rawData);
}
