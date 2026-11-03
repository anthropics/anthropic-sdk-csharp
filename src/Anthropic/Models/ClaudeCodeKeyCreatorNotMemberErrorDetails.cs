using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The API key belongs to the Claude Code workspace, and the user who created it
/// is no longer a member of the organization or of that workspace.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ClaudeCodeKeyCreatorNotMemberErrorDetails,
        ClaudeCodeKeyCreatorNotMemberErrorDetailsFromRaw
    >)
)]
public sealed record class ClaudeCodeKeyCreatorNotMemberErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("claude_code_key_creator_not_member")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ClaudeCodeKeyCreatorNotMemberErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("claude_code_key_creator_not_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClaudeCodeKeyCreatorNotMemberErrorDetails(
        ClaudeCodeKeyCreatorNotMemberErrorDetails claudeCodeKeyCreatorNotMemberErrorDetails
    )
        : base(claudeCodeKeyCreatorNotMemberErrorDetails) { }
#pragma warning restore CS8618

    public ClaudeCodeKeyCreatorNotMemberErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("claude_code_key_creator_not_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClaudeCodeKeyCreatorNotMemberErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClaudeCodeKeyCreatorNotMemberErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ClaudeCodeKeyCreatorNotMemberErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClaudeCodeKeyCreatorNotMemberErrorDetailsFromRaw
    : IFromRawJson<ClaudeCodeKeyCreatorNotMemberErrorDetails>
{
    /// <inheritdoc/>
    public ClaudeCodeKeyCreatorNotMemberErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClaudeCodeKeyCreatorNotMemberErrorDetails.FromRawUnchecked(rawData);
}
