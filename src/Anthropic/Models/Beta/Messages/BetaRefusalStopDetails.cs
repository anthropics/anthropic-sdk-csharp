using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Structured information about a refusal.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaRefusalStopDetails, BetaRefusalStopDetailsFromRaw>))]
public sealed record class BetaRefusalStopDetails : JsonModel
{
    /// <summary>
    /// The policy category that triggered a refusal.
    /// </summary>
    public required ApiEnum<string, Category>? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Human-readable explanation of the refusal.
    ///
    /// <para>This text is not guaranteed to be stable. `null` when no explanation
    /// is available for the category.</para>
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <summary>
    /// Opaque code that refunds the cache-miss cost when retrying this refused request
    /// on the fallback model. Pass it as `fallback_credit_token` on the retry request.
    /// Expires 5 minutes after the refusal.
    ///
    /// <para>The retry is sent either with the same request body (`system`, `messages`,
    /// `tools`, and other render-shaping fields), or with the same body plus one
    /// appended `assistant` message whose content is the partial text (with any trailing
    /// whitespace stripped from the final text block) and paired server-tool blocks
    /// from this refusal — which also authorizes that appended turn as an assistant-prefill
    /// continuation on models that otherwise disallow prefill. A token minted mid-server-tool-loop
    /// whose partial content was continuable may only be redeemed the second way
    /// — if a same-body retry is rejected with a 400 saying the token must be redeemed
    /// by continuing the partial response, retry the second way instead. Either
    /// way: same workspace, same platform; a mismatch is a 400. Resending a token
    /// for an already-warm prefix is permitted but yields no additional credit.</para>
    ///
    /// <para>`null` when the refused model isn't eligible for a fallback credit.</para>
    /// </summary>
    public required string? FallbackCreditToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fallback_credit_token");
        }
        init { this._rawData.Set("fallback_credit_token", value); }
    }

    /// <summary>
    /// Whether the accompanying `fallback_credit_token` may be redeemed with the
    /// appended-assistant retry form. Only set when `fallback_credit_token` is present.
    ///
    /// <para>`true`: retry by resending the same request body plus one appended `assistant`
    /// message whose content is this response's `content` with any trailing whitespace
    /// stripped from the final text block and unpaired `tool_use` blocks omitted
    /// (the same appended-turn shape described on `fallback_credit_token`), with
    /// the token attached. `false`: retry by resending the original request body
    /// unchanged, with the token attached — the appended-assistant form is not available
    /// for this refusal (no continuable partial content, or the request uses `output_format`
    /// or a `tool_choice` that forces tool use). One exception: when the request
    /// used `output_format` or a forced `tool_choice` and the refusal arrived after
    /// server tools (including MCP connector tools) had already executed, the token
    /// may not be redeemable by either retry form; if the exact-body retry is then
    /// rejected with a 400 saying the token must be redeemed by continuing the partial
    /// response, discard the token and retry without it.</para>
    ///
    /// <para>Advisory: if an appended-assistant retry is rejected with a 400 despite
    /// `true`, fall back to resending the original request body with the token.</para>
    /// </summary>
    public required bool? FallbackHasPrefillClaim
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("fallback_has_prefill_claim");
        }
        init { this._rawData.Set("fallback_has_prefill_claim", value); }
    }

    /// <summary>
    /// The server's suggested retry target for this refusal. Populated when a fallback
    /// attempt could not be made (the fallback model's rate limit was exhausted,
    /// or it was overloaded); names the fallback model the caller can retry directly.
    /// Null otherwise.
    /// </summary>
    public required string? RecommendedModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recommended_model");
        }
        init { this._rawData.Set("recommended_model", value); }
    }

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
        this.Category?.Validate();
        _ = this.Explanation;
        _ = this.FallbackCreditToken;
        _ = this.FallbackHasPrefillClaim;
        _ = this.RecommendedModel;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("refusal")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRefusalStopDetails()
    {
        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRefusalStopDetails(BetaRefusalStopDetails betaRefusalStopDetails)
        : base(betaRefusalStopDetails) { }
#pragma warning restore CS8618

    public BetaRefusalStopDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRefusalStopDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRefusalStopDetailsFromRaw.FromRawUnchecked"/>
    public static BetaRefusalStopDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRefusalStopDetailsFromRaw : IFromRawJson<BetaRefusalStopDetails>
{
    /// <inheritdoc/>
    public BetaRefusalStopDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRefusalStopDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The policy category that triggered a refusal.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    Cyber,
    Bio,
    FrontierLlm,
    ReasoningExtraction,
    MilitaryWeapons,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cyber" => Category.Cyber,
            "bio" => Category.Bio,
            "frontier_llm" => Category.FrontierLlm,
            "reasoning_extraction" => Category.ReasoningExtraction,
            "military_weapons" => Category.MilitaryWeapons,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.Cyber => "cyber",
                Category.Bio => "bio",
                Category.FrontierLlm => "frontier_llm",
                Category.ReasoningExtraction => "reasoning_extraction",
                Category.MilitaryWeapons => "military_weapons",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
