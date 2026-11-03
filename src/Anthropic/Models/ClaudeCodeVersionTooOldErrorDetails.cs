using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request comes from a Claude Code version older than the minimum that the
/// requested model or the organization requires. Update Claude Code, then retry.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClaudeCodeVersionTooOldErrorDetails,
        ClaudeCodeVersionTooOldErrorDetailsFromRaw
    >)
)]
public sealed record class ClaudeCodeVersionTooOldErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("claude_code_version_too_old")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ClaudeCodeVersionTooOldErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("claude_code_version_too_old");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClaudeCodeVersionTooOldErrorDetails(
        ClaudeCodeVersionTooOldErrorDetails claudeCodeVersionTooOldErrorDetails
    )
        : base(claudeCodeVersionTooOldErrorDetails) { }
#pragma warning restore CS8618

    public ClaudeCodeVersionTooOldErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("claude_code_version_too_old");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClaudeCodeVersionTooOldErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClaudeCodeVersionTooOldErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ClaudeCodeVersionTooOldErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClaudeCodeVersionTooOldErrorDetailsFromRaw : IFromRawJson<ClaudeCodeVersionTooOldErrorDetails>
{
    /// <inheritdoc/>
    public ClaudeCodeVersionTooOldErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClaudeCodeVersionTooOldErrorDetails.FromRawUnchecked(rawData);
}
