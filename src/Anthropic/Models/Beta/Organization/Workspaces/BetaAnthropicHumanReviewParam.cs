using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.Workspaces;

/// <summary>
/// Whether Anthropic's human review applies to the Workspace's inference data.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnthropicHumanReviewParam, BetaAnthropicHumanReviewParamFromRaw>)
)]
public sealed record class BetaAnthropicHumanReviewParam : JsonModel
{
    public required ApiEnum<string, BetaAnthropicHumanReviewParamType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaAnthropicHumanReviewParamType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaAnthropicHumanReviewParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnthropicHumanReviewParam(
        BetaAnthropicHumanReviewParam betaAnthropicHumanReviewParam
    )
        : base(betaAnthropicHumanReviewParam) { }
#pragma warning restore CS8618

    public BetaAnthropicHumanReviewParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnthropicHumanReviewParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnthropicHumanReviewParamFromRaw.FromRawUnchecked"/>
    public static BetaAnthropicHumanReviewParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnthropicHumanReviewParam(ApiEnum<string, BetaAnthropicHumanReviewParamType> type)
        : this()
    {
        this.Type = type;
    }
}

class BetaAnthropicHumanReviewParamFromRaw : IFromRawJson<BetaAnthropicHumanReviewParam>
{
    /// <inheritdoc/>
    public BetaAnthropicHumanReviewParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnthropicHumanReviewParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaAnthropicHumanReviewParamTypeConverter))]
public enum BetaAnthropicHumanReviewParamType
{
    Disabled = 2068438255,
    Enabled = 924343854,
}

sealed class BetaAnthropicHumanReviewParamTypeConverter
    : JsonConverter<BetaAnthropicHumanReviewParamType>
{
    public override BetaAnthropicHumanReviewParamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => BetaAnthropicHumanReviewParamType.Disabled,
            "enabled" => BetaAnthropicHumanReviewParamType.Enabled,
            _ => (BetaAnthropicHumanReviewParamType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnthropicHumanReviewParamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnthropicHumanReviewParamType.Disabled => "disabled",
                BetaAnthropicHumanReviewParamType.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
