using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The API key lacks the scope the request needs: `read:claude_tag` for a read, `write:claude_tag`
/// for a change.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaApiKeyScopeMissingErrorDetails,
        BetaApiKeyScopeMissingErrorDetailsFromRaw
    >)
)]
public sealed record class BetaApiKeyScopeMissingErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("api_key_scope_missing")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaApiKeyScopeMissingErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("api_key_scope_missing");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaApiKeyScopeMissingErrorDetails(
        BetaApiKeyScopeMissingErrorDetails betaApiKeyScopeMissingErrorDetails
    )
        : base(betaApiKeyScopeMissingErrorDetails) { }
#pragma warning restore CS8618

    public BetaApiKeyScopeMissingErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("api_key_scope_missing");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaApiKeyScopeMissingErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaApiKeyScopeMissingErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaApiKeyScopeMissingErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaApiKeyScopeMissingErrorDetailsFromRaw : IFromRawJson<BetaApiKeyScopeMissingErrorDetails>
{
    /// <inheritdoc/>
    public BetaApiKeyScopeMissingErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaApiKeyScopeMissingErrorDetails.FromRawUnchecked(rawData);
}
