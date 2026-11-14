using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// This Bundle's instructions are managed in claude.ai and can't be changed through
/// the API.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBundleOnCallErrorDetails, BetaBundleOnCallErrorDetailsFromRaw>)
)]
public sealed record class BetaBundleOnCallErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("bundle_on_call")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBundleOnCallErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("bundle_on_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBundleOnCallErrorDetails(BetaBundleOnCallErrorDetails betaBundleOnCallErrorDetails)
        : base(betaBundleOnCallErrorDetails) { }
#pragma warning restore CS8618

    public BetaBundleOnCallErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("bundle_on_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBundleOnCallErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBundleOnCallErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaBundleOnCallErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBundleOnCallErrorDetailsFromRaw : IFromRawJson<BetaBundleOnCallErrorDetails>
{
    /// <inheritdoc/>
    public BetaBundleOnCallErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBundleOnCallErrorDetails.FromRawUnchecked(rawData);
}
