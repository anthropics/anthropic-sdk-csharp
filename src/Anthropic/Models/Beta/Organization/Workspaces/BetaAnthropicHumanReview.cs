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
/// The Workspace's human review setting.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnthropicHumanReview, BetaAnthropicHumanReviewFromRaw>)
)]
public sealed record class BetaAnthropicHumanReview : JsonModel
{
    public required ApiEnum<string, global::Anthropic.Models.Beta.Organization.Workspaces.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Organization.Workspaces.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaAnthropicHumanReview() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnthropicHumanReview(BetaAnthropicHumanReview betaAnthropicHumanReview)
        : base(betaAnthropicHumanReview) { }
#pragma warning restore CS8618

    public BetaAnthropicHumanReview(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnthropicHumanReview(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnthropicHumanReviewFromRaw.FromRawUnchecked"/>
    public static BetaAnthropicHumanReview FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnthropicHumanReview(
        ApiEnum<string, global::Anthropic.Models.Beta.Organization.Workspaces.Type> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaAnthropicHumanReviewFromRaw : IFromRawJson<BetaAnthropicHumanReview>
{
    /// <inheritdoc/>
    public BetaAnthropicHumanReview FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnthropicHumanReview.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Disabled = 2068438255,
    Enabled = 924343854,
}

sealed class TypeConverter
    : JsonConverter<global::Anthropic.Models.Beta.Organization.Workspaces.Type>
{
    public override global::Anthropic.Models.Beta.Organization.Workspaces.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => global::Anthropic.Models.Beta.Organization.Workspaces.Type.Disabled,
            "enabled" => global::Anthropic.Models.Beta.Organization.Workspaces.Type.Enabled,
            _ => (global::Anthropic.Models.Beta.Organization.Workspaces.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Organization.Workspaces.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Organization.Workspaces.Type.Disabled => "disabled",
                global::Anthropic.Models.Beta.Organization.Workspaces.Type.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
