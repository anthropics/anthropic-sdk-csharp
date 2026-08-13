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
/// Object form of ``fallback_credit_token``: the token plus a redemption mode.
///
/// <para>Requires ``anthropic-beta: fallback-credit-2026-07-01``; without that header
/// the field accepts the bare string only. The bare string and the mode-less object
/// are equivalent (both select ``strict``), so wrapping an existing token changes
/// nothing by itself.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaFallbackCreditTokenParam, BetaFallbackCreditTokenParamFromRaw>)
)]
public sealed record class BetaFallbackCreditTokenParam : JsonModel
{
    /// <summary>
    /// The opaque `fallback_credit_token` from a prior refusal's `stop_details`
    /// — the same string the bare-string form carries.
    /// </summary>
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <summary>
    /// How a failing token affects the retry. `strict` (the default, and the bare-string
    /// behavior): a failing redemption is a 400 and the retry is not served. `best_effort`:
    /// the retry is served either way — a token-layer failure no longer rejects
    /// the request; the retry proceeds at normal price and the outcome is reported
    /// on the response's `usage.fallback_credit`. Two failures stay hard in both
    /// modes: a malformed token, and combining `fallback_credit_token` with `fallbacks`.
    /// </summary>
    public ApiEnum<string, Mode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Mode>>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        this.Mode?.Validate();
    }

    public BetaFallbackCreditTokenParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFallbackCreditTokenParam(BetaFallbackCreditTokenParam betaFallbackCreditTokenParam)
        : base(betaFallbackCreditTokenParam) { }
#pragma warning restore CS8618

    public BetaFallbackCreditTokenParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFallbackCreditTokenParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFallbackCreditTokenParamFromRaw.FromRawUnchecked"/>
    public static BetaFallbackCreditTokenParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaFallbackCreditTokenParam(string token)
        : this()
    {
        this.Token = token;
    }
}

class BetaFallbackCreditTokenParamFromRaw : IFromRawJson<BetaFallbackCreditTokenParam>
{
    /// <inheritdoc/>
    public BetaFallbackCreditTokenParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaFallbackCreditTokenParam.FromRawUnchecked(rawData);
}

/// <summary>
/// How a failing token affects the retry. `strict` (the default, and the bare-string
/// behavior): a failing redemption is a 400 and the retry is not served. `best_effort`:
/// the retry is served either way — a token-layer failure no longer rejects the request;
/// the retry proceeds at normal price and the outcome is reported on the response's
/// `usage.fallback_credit`. Two failures stay hard in both modes: a malformed token,
/// and combining `fallback_credit_token` with `fallbacks`.
/// </summary>
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    Strict,
    BestEffort,
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "strict" => Mode.Strict,
            "best_effort" => Mode.BestEffort,
            _ => (Mode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Mode.Strict => "strict",
                Mode.BestEffort => "best_effort",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
