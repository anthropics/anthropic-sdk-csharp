using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// Why a review case closed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewCaseCloseReason,
        BetaComplianceReviewCaseCloseReasonFromRaw
    >)
)]
public sealed record class BetaComplianceReviewCaseCloseReason : JsonModel
{
    /// <summary>
    /// `responded` means that Anthropic recorded a response. `window_ended` means
    /// that the time to respond ended with no response. `ended_by_anthropic` means
    /// that Anthropic ended the case before that time was over. New values can appear,
    /// so accept a value that you don't know.
    /// </summary>
    public required ApiEnum<string, global::Anthropic.Models.Beta.Compliance.Review.Cases.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Compliance.Review.Cases.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaComplianceReviewCaseCloseReason() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewCaseCloseReason(
        BetaComplianceReviewCaseCloseReason betaComplianceReviewCaseCloseReason
    )
        : base(betaComplianceReviewCaseCloseReason) { }
#pragma warning restore CS8618

    public BetaComplianceReviewCaseCloseReason(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewCaseCloseReason(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewCaseCloseReasonFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewCaseCloseReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComplianceReviewCaseCloseReason(
        ApiEnum<string, global::Anthropic.Models.Beta.Compliance.Review.Cases.Type> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaComplianceReviewCaseCloseReasonFromRaw : IFromRawJson<BetaComplianceReviewCaseCloseReason>
{
    /// <inheritdoc/>
    public BetaComplianceReviewCaseCloseReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewCaseCloseReason.FromRawUnchecked(rawData);
}

/// <summary>
/// `responded` means that Anthropic recorded a response. `window_ended` means that
/// the time to respond ended with no response. `ended_by_anthropic` means that Anthropic
/// ended the case before that time was over. New values can appear, so accept a value
/// that you don't know.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Responded = 278813038,
    WindowEnded = 12550579,
    EndedByAnthropic = 1208623564,
}

sealed class TypeConverter
    : JsonConverter<global::Anthropic.Models.Beta.Compliance.Review.Cases.Type>
{
    public override global::Anthropic.Models.Beta.Compliance.Review.Cases.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "responded" => global::Anthropic.Models.Beta.Compliance.Review.Cases.Type.Responded,
            "window_ended" => global::Anthropic
                .Models
                .Beta
                .Compliance
                .Review
                .Cases
                .Type
                .WindowEnded,
            "ended_by_anthropic" => global::Anthropic
                .Models
                .Beta
                .Compliance
                .Review
                .Cases
                .Type
                .EndedByAnthropic,
            _ => (global::Anthropic.Models.Beta.Compliance.Review.Cases.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Compliance.Review.Cases.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Compliance.Review.Cases.Type.Responded => "responded",
                global::Anthropic.Models.Beta.Compliance.Review.Cases.Type.WindowEnded =>
                    "window_ended",
                global::Anthropic.Models.Beta.Compliance.Review.Cases.Type.EndedByAnthropic =>
                    "ended_by_anthropic",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
