using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// Claude replies only when it is @-mentioned.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagReplyModeMentionOnly,
        BetaClaudeTagReplyModeMentionOnlyFromRaw
    >)
)]
public sealed record class BetaClaudeTagReplyModeMentionOnly : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("mention_only")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagReplyModeMentionOnly()
    {
        this.Type = JsonSerializer.SerializeToElement("mention_only");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagReplyModeMentionOnly(
        BetaClaudeTagReplyModeMentionOnly betaClaudeTagReplyModeMentionOnly
    )
        : base(betaClaudeTagReplyModeMentionOnly) { }
#pragma warning restore CS8618

    public BetaClaudeTagReplyModeMentionOnly(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mention_only");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagReplyModeMentionOnly(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagReplyModeMentionOnlyFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagReplyModeMentionOnly FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagReplyModeMentionOnlyFromRaw : IFromRawJson<BetaClaudeTagReplyModeMentionOnly>
{
    /// <inheritdoc/>
    public BetaClaudeTagReplyModeMentionOnly FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagReplyModeMentionOnly.FromRawUnchecked(rawData);
}
