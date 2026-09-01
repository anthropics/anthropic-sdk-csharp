using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Controls for block binding: what happens when a thinking block this request sends
/// back fails the conversation check. Every field is optional; an empty object means
/// every default.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaThinkingBlockBinding, BetaThinkingBlockBindingFromRaw>)
)]
public sealed record class BetaThinkingBlockBinding : JsonModel
{
    /// <summary>
    /// What happens when a thinking block in `messages` fails the conversation check:
    /// it was created in a different conversation, or the messages before it have
    /// changed since. `"error"` (the default) fails the request with a 400 error.
    /// `"drop_block"` removes the failing blocks and the request proceeds; the model
    /// no longer sees the dropped reasoning.
    /// </summary>
    public ApiEnum<string, BetaThinkingPrefixMismatchBehavior>? PrefixMismatchBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaThinkingPrefixMismatchBehavior>
            >("prefix_mismatch_behavior");
        }
        init { this._rawData.Set("prefix_mismatch_behavior", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PrefixMismatchBehavior?.Validate();
    }

    public BetaThinkingBlockBinding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingBlockBinding(BetaThinkingBlockBinding betaThinkingBlockBinding)
        : base(betaThinkingBlockBinding) { }
#pragma warning restore CS8618

    public BetaThinkingBlockBinding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingBlockBinding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingBlockBindingFromRaw.FromRawUnchecked"/>
    public static BetaThinkingBlockBinding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThinkingBlockBindingFromRaw : IFromRawJson<BetaThinkingBlockBinding>
{
    /// <inheritdoc/>
    public BetaThinkingBlockBinding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThinkingBlockBinding.FromRawUnchecked(rawData);
}
