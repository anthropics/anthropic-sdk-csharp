using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// No reprice was applied; ``reason`` says why.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaFallbackCreditNotApplied, BetaFallbackCreditNotAppliedFromRaw>)
)]
public sealed record class BetaFallbackCreditNotApplied : JsonModel
{
    /// <summary>
    /// Why the reprice was not applied.
    ///
    /// <para>A closed enum; additions to the redemption-check vocabulary arrive as
    /// deliberate schema updates.</para>
    /// </summary>
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
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

    /// <summary>
    /// Request fields to remove before retrying, so the retry can redeem this token.
    ///
    /// <para>Present exactly when `reason` is `variant_fields_present` — never null,
    /// never an empty array; absent otherwise. Fields are named only from your own
    /// request, and only after the sealed variant hash matched. A served best-effort
    /// retry has already been billed at normal price; nothing redeems retroactively,
    /// but a corrected re-send inside the token's five-minute window can still redeem.</para>
    /// </summary>
    public IReadOnlyList<string>? RemoveToRedeem
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("remove_to_redeem");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "remove_to_redeem",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reason.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("not_applied")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.RemoveToRedeem;
    }

    public BetaFallbackCreditNotApplied()
    {
        this.Type = JsonSerializer.SerializeToElement("not_applied");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFallbackCreditNotApplied(BetaFallbackCreditNotApplied betaFallbackCreditNotApplied)
        : base(betaFallbackCreditNotApplied) { }
#pragma warning restore CS8618

    public BetaFallbackCreditNotApplied(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("not_applied");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFallbackCreditNotApplied(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFallbackCreditNotAppliedFromRaw.FromRawUnchecked"/>
    public static BetaFallbackCreditNotApplied FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaFallbackCreditNotApplied(ApiEnum<string, Reason> reason)
        : this()
    {
        this.Reason = reason;
    }
}

class BetaFallbackCreditNotAppliedFromRaw : IFromRawJson<BetaFallbackCreditNotApplied>
{
    /// <inheritdoc/>
    public BetaFallbackCreditNotApplied FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaFallbackCreditNotApplied.FromRawUnchecked(rawData);
}

/// <summary>
/// Why the reprice was not applied.
///
/// <para>A closed enum; additions to the redemption-check vocabulary arrive as deliberate
/// schema updates.</para>
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    BodyMismatch,
    ContinuationExcluded,
    ContinuationOnly,
    Expired,
    InvalidTargetModel,
    NotEnabled,
    RepriceUnavailable,
    TemporarilyUnavailable,
    VariantFieldsPresent,
    WrongOrganization,
    WrongPlatform,
    WrongWorkspace,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "body_mismatch" => Reason.BodyMismatch,
            "continuation_excluded" => Reason.ContinuationExcluded,
            "continuation_only" => Reason.ContinuationOnly,
            "expired" => Reason.Expired,
            "invalid_target_model" => Reason.InvalidTargetModel,
            "not_enabled" => Reason.NotEnabled,
            "reprice_unavailable" => Reason.RepriceUnavailable,
            "temporarily_unavailable" => Reason.TemporarilyUnavailable,
            "variant_fields_present" => Reason.VariantFieldsPresent,
            "wrong_organization" => Reason.WrongOrganization,
            "wrong_platform" => Reason.WrongPlatform,
            "wrong_workspace" => Reason.WrongWorkspace,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.BodyMismatch => "body_mismatch",
                Reason.ContinuationExcluded => "continuation_excluded",
                Reason.ContinuationOnly => "continuation_only",
                Reason.Expired => "expired",
                Reason.InvalidTargetModel => "invalid_target_model",
                Reason.NotEnabled => "not_enabled",
                Reason.RepriceUnavailable => "reprice_unavailable",
                Reason.TemporarilyUnavailable => "temporarily_unavailable",
                Reason.VariantFieldsPresent => "variant_fields_present",
                Reason.WrongOrganization => "wrong_organization",
                Reason.WrongPlatform => "wrong_platform",
                Reason.WrongWorkspace => "wrong_workspace",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
