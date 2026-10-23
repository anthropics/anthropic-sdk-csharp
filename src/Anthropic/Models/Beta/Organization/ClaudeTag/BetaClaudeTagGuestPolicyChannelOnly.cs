using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// Claude answers with only the Bundles attached to the channel itself.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagGuestPolicyChannelOnly,
        BetaClaudeTagGuestPolicyChannelOnlyFromRaw
    >)
)]
public sealed record class BetaClaudeTagGuestPolicyChannelOnly : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("channel_only")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagGuestPolicyChannelOnly()
    {
        this.Type = JsonSerializer.SerializeToElement("channel_only");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagGuestPolicyChannelOnly(
        BetaClaudeTagGuestPolicyChannelOnly betaClaudeTagGuestPolicyChannelOnly
    )
        : base(betaClaudeTagGuestPolicyChannelOnly) { }
#pragma warning restore CS8618

    public BetaClaudeTagGuestPolicyChannelOnly(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("channel_only");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagGuestPolicyChannelOnly(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagGuestPolicyChannelOnlyFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagGuestPolicyChannelOnly FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagGuestPolicyChannelOnlyFromRaw : IFromRawJson<BetaClaudeTagGuestPolicyChannelOnly>
{
    /// <inheritdoc/>
    public BetaClaudeTagGuestPolicyChannelOnly FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagGuestPolicyChannelOnly.FromRawUnchecked(rawData);
}
