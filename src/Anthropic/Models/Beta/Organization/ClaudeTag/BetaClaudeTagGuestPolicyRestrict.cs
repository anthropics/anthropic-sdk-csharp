using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// Claude does not answer in the channel.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagGuestPolicyRestrict,
        BetaClaudeTagGuestPolicyRestrictFromRaw
    >)
)]
public sealed record class BetaClaudeTagGuestPolicyRestrict : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("restrict")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagGuestPolicyRestrict()
    {
        this.Type = JsonSerializer.SerializeToElement("restrict");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagGuestPolicyRestrict(
        BetaClaudeTagGuestPolicyRestrict betaClaudeTagGuestPolicyRestrict
    )
        : base(betaClaudeTagGuestPolicyRestrict) { }
#pragma warning restore CS8618

    public BetaClaudeTagGuestPolicyRestrict(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("restrict");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagGuestPolicyRestrict(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagGuestPolicyRestrictFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagGuestPolicyRestrict FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagGuestPolicyRestrictFromRaw : IFromRawJson<BetaClaudeTagGuestPolicyRestrict>
{
    /// <inheritdoc/>
    public BetaClaudeTagGuestPolicyRestrict FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagGuestPolicyRestrict.FromRawUnchecked(rawData);
}
