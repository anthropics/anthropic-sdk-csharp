using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// Changes through the Claude Tag API are not enabled for the organization.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagWritesNotEnabledErrorDetails,
        BetaClaudeTagWritesNotEnabledErrorDetailsFromRaw
    >)
)]
public sealed record class BetaClaudeTagWritesNotEnabledErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("claude_tag_writes_not_enabled")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagWritesNotEnabledErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("claude_tag_writes_not_enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagWritesNotEnabledErrorDetails(
        BetaClaudeTagWritesNotEnabledErrorDetails betaClaudeTagWritesNotEnabledErrorDetails
    )
        : base(betaClaudeTagWritesNotEnabledErrorDetails) { }
#pragma warning restore CS8618

    public BetaClaudeTagWritesNotEnabledErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("claude_tag_writes_not_enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagWritesNotEnabledErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagWritesNotEnabledErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagWritesNotEnabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagWritesNotEnabledErrorDetailsFromRaw
    : IFromRawJson<BetaClaudeTagWritesNotEnabledErrorDetails>
{
    /// <inheritdoc/>
    public BetaClaudeTagWritesNotEnabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagWritesNotEnabledErrorDetails.FromRawUnchecked(rawData);
}
