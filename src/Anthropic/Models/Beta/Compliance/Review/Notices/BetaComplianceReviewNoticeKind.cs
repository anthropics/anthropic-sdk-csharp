using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Compliance.Review.Notices;

/// <summary>
/// The kind of a review notice.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewNoticeKind,
        BetaComplianceReviewNoticeKindFromRaw
    >)
)]
public sealed record class BetaComplianceReviewNoticeKind : JsonModel
{
    /// <summary>
    /// `response_requested` asks you to respond to the cases in `case_ids`. For `warning`
    /// and `question`, `message` explains how to answer if an answer is needed.
    /// New values can appear, so accept a value that you don't know.
    /// </summary>
    public required ApiEnum<
        string,
        global::Anthropic.Models.Beta.Compliance.Review.Notices.Type
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Compliance.Review.Notices.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaComplianceReviewNoticeKind() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewNoticeKind(
        BetaComplianceReviewNoticeKind betaComplianceReviewNoticeKind
    )
        : base(betaComplianceReviewNoticeKind) { }
#pragma warning restore CS8618

    public BetaComplianceReviewNoticeKind(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewNoticeKind(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewNoticeKindFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewNoticeKind FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComplianceReviewNoticeKind(
        ApiEnum<string, global::Anthropic.Models.Beta.Compliance.Review.Notices.Type> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaComplianceReviewNoticeKindFromRaw : IFromRawJson<BetaComplianceReviewNoticeKind>
{
    /// <inheritdoc/>
    public BetaComplianceReviewNoticeKind FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewNoticeKind.FromRawUnchecked(rawData);
}

/// <summary>
/// `response_requested` asks you to respond to the cases in `case_ids`. For `warning`
/// and `question`, `message` explains how to answer if an answer is needed. New values
/// can appear, so accept a value that you don't know.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    ResponseRequested = 2053735556,
    Warning = 1688719099,
    Question = 917918359,
}

sealed class TypeConverter
    : JsonConverter<global::Anthropic.Models.Beta.Compliance.Review.Notices.Type>
{
    public override global::Anthropic.Models.Beta.Compliance.Review.Notices.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "response_requested" => global::Anthropic
                .Models
                .Beta
                .Compliance
                .Review
                .Notices
                .Type
                .ResponseRequested,
            "warning" => global::Anthropic.Models.Beta.Compliance.Review.Notices.Type.Warning,
            "question" => global::Anthropic.Models.Beta.Compliance.Review.Notices.Type.Question,
            _ => (global::Anthropic.Models.Beta.Compliance.Review.Notices.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Compliance.Review.Notices.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Compliance.Review.Notices.Type.ResponseRequested =>
                    "response_requested",
                global::Anthropic.Models.Beta.Compliance.Review.Notices.Type.Warning => "warning",
                global::Anthropic.Models.Beta.Compliance.Review.Notices.Type.Question => "question",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
