using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// Claude answers in the channel.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaClaudeTagGuestPolicyAllow, BetaClaudeTagGuestPolicyAllowFromRaw>)
)]
public sealed record class BetaClaudeTagGuestPolicyAllow : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("allow")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagGuestPolicyAllow()
    {
        this.Type = JsonSerializer.SerializeToElement("allow");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagGuestPolicyAllow(
        BetaClaudeTagGuestPolicyAllow betaClaudeTagGuestPolicyAllow
    )
        : base(betaClaudeTagGuestPolicyAllow) { }
#pragma warning restore CS8618

    public BetaClaudeTagGuestPolicyAllow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("allow");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagGuestPolicyAllow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagGuestPolicyAllowFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagGuestPolicyAllow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagGuestPolicyAllowFromRaw : IFromRawJson<BetaClaudeTagGuestPolicyAllow>
{
    /// <inheritdoc/>
    public BetaClaudeTagGuestPolicyAllow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagGuestPolicyAllow.FromRawUnchecked(rawData);
}
