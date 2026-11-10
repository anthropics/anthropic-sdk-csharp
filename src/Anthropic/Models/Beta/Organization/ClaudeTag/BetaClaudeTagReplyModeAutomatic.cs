using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// Claude reads along and joins in when it can help, and pauses on its own in quiet
/// or busy channels.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagReplyModeAutomatic,
        BetaClaudeTagReplyModeAutomaticFromRaw
    >)
)]
public sealed record class BetaClaudeTagReplyModeAutomatic : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("automatic")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagReplyModeAutomatic()
    {
        this.Type = JsonSerializer.SerializeToElement("automatic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagReplyModeAutomatic(
        BetaClaudeTagReplyModeAutomatic betaClaudeTagReplyModeAutomatic
    )
        : base(betaClaudeTagReplyModeAutomatic) { }
#pragma warning restore CS8618

    public BetaClaudeTagReplyModeAutomatic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("automatic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagReplyModeAutomatic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagReplyModeAutomaticFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagReplyModeAutomatic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagReplyModeAutomaticFromRaw : IFromRawJson<BetaClaudeTagReplyModeAutomatic>
{
    /// <inheritdoc/>
    public BetaClaudeTagReplyModeAutomatic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagReplyModeAutomatic.FromRawUnchecked(rawData);
}
