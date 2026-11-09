using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// Like `automatic`, but Claude never pauses on its own. Available where it is enabled
/// for the channel.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagReplyModeAlwaysAwake,
        BetaClaudeTagReplyModeAlwaysAwakeFromRaw
    >)
)]
public sealed record class BetaClaudeTagReplyModeAlwaysAwake : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("always_awake")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagReplyModeAlwaysAwake()
    {
        this.Type = JsonSerializer.SerializeToElement("always_awake");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagReplyModeAlwaysAwake(
        BetaClaudeTagReplyModeAlwaysAwake betaClaudeTagReplyModeAlwaysAwake
    )
        : base(betaClaudeTagReplyModeAlwaysAwake) { }
#pragma warning restore CS8618

    public BetaClaudeTagReplyModeAlwaysAwake(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("always_awake");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagReplyModeAlwaysAwake(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagReplyModeAlwaysAwakeFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagReplyModeAlwaysAwake FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagReplyModeAlwaysAwakeFromRaw : IFromRawJson<BetaClaudeTagReplyModeAlwaysAwake>
{
    /// <inheritdoc/>
    public BetaClaudeTagReplyModeAlwaysAwake FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagReplyModeAlwaysAwake.FromRawUnchecked(rawData);
}
