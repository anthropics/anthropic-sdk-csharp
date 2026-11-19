using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// This stored settings document currently cannot be read or replaced. Contact support,
/// or, if you no longer need these settings, delete the group's settings or clear
/// the default.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaCmekFeatureUnsupportedErrorDetails,
        BetaCmekFeatureUnsupportedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaCmekFeatureUnsupportedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cmek_feature_unsupported")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCmekFeatureUnsupportedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_feature_unsupported");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCmekFeatureUnsupportedErrorDetails(
        BetaCmekFeatureUnsupportedErrorDetails betaCmekFeatureUnsupportedErrorDetails
    )
        : base(betaCmekFeatureUnsupportedErrorDetails) { }
#pragma warning restore CS8618

    public BetaCmekFeatureUnsupportedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_feature_unsupported");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCmekFeatureUnsupportedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCmekFeatureUnsupportedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaCmekFeatureUnsupportedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCmekFeatureUnsupportedErrorDetailsFromRaw
    : IFromRawJson<BetaCmekFeatureUnsupportedErrorDetails>
{
    /// <inheritdoc/>
    public BetaCmekFeatureUnsupportedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCmekFeatureUnsupportedErrorDetails.FromRawUnchecked(rawData);
}
