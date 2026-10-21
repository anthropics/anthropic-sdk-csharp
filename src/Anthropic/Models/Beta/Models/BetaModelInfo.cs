using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Models;

[JsonConverter(typeof(JsonModelConverter<BetaModelInfo, BetaModelInfoFromRaw>))]
public sealed record class BetaModelInfo : JsonModel
{
    /// <summary>
    /// Unique model identifier.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Model IDs this model accepts as `fallbacks[i].model` on the Messages API.
    /// An empty list means the `fallbacks` parameter is not supported for this model
    /// as primary.
    /// </summary>
    public required IReadOnlyList<string>? AllowedFallbackModels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "allowed_fallback_models"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_fallback_models",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Object mapping capability names to their support details. Keys are always
    /// present for all known capabilities.
    /// </summary>
    public required BetaModelCapabilities? Capabilities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaModelCapabilities>("capabilities");
        }
        init { this._rawData.Set("capabilities", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the model was released.
    /// May be set to an epoch value if the release date is unknown.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time of the model's most recent
    /// deprecation. Populated for `deprecated` and `retired` models; `null` while
    /// the model is `active`.
    /// </summary>
    public required DateTimeOffset? DeprecatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("deprecated_at");
        }
        init { this._rawData.Set("deprecated_at", value); }
    }

    /// <summary>
    /// A human-readable name for the model.
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// The model's current lifecycle stage.
    ///
    /// <para>- `active`: The model is available for use, open to new adopters, and
    /// not scheduled for retirement. - `deprecated`: The model remains callable for
    /// organizations with existing access, but is headed for retirement and closed
    /// to new adopters. - `retired`: The model is no longer available for use; inference
    /// requests naming it fail. It remains in the catalogue as the historical record
    /// of its retirement.</para>
    /// </summary>
    public required ApiEnum<string, BetaModelInfoLifecycle> Lifecycle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaModelInfoLifecycle>>(
                "lifecycle"
            );
        }
        init { this._rawData.Set("lifecycle", value); }
    }

    /// <summary>
    /// The model line this model belongs to, such as `opus` for both Claude Opus
    /// 4.5 and Claude Opus 4.6. More lines may be added. `null` when the model belongs
    /// to no line; do not infer a line from the `id`.
    /// </summary>
    public required ApiEnum<string, BetaModelLine>? Line
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaModelLine>>("line");
        }
        init { this._rawData.Set("line", value); }
    }

    /// <summary>
    /// Maximum input context window size in tokens for this model.
    /// </summary>
    public required long? MaxInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_input_tokens");
        }
        init { this._rawData.Set("max_input_tokens", value); }
    }

    /// <summary>
    /// Maximum value for the `max_tokens` parameter when using this model.
    /// </summary>
    public required long? MaxTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_tokens");
        }
        init { this._rawData.Set("max_tokens", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the model's currently scheduled retirement
    /// date. The schedule can be revised until retirement occurs; `null` while the
    /// model is `active` or while no retirement is scheduled. A past date on a `deprecated`
    /// model means retirement is overdue, not that it has occurred: `lifecycle`
    /// is the retirement signal.
    /// </summary>
    public required DateTimeOffset? RetiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("retires_at");
        }
        init { this._rawData.Set("retires_at", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Models, this is always `"model"`.</para>
    /// </summary>
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
        _ = this.ID;
        _ = this.AllowedFallbackModels;
        this.Capabilities?.Validate();
        _ = this.CreatedAt;
        _ = this.DeprecatedAt;
        _ = this.DisplayName;
        this.Lifecycle.Validate();
        this.Line?.Validate();
        _ = this.MaxInputTokens;
        _ = this.MaxTokens;
        _ = this.RetiresAt;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("model")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaModelInfo()
    {
        this.Type = JsonSerializer.SerializeToElement("model");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaModelInfo(BetaModelInfo betaModelInfo)
        : base(betaModelInfo) { }
#pragma warning restore CS8618

    public BetaModelInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("model");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaModelInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaModelInfoFromRaw.FromRawUnchecked"/>
    public static BetaModelInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaModelInfoFromRaw : IFromRawJson<BetaModelInfo>
{
    /// <inheritdoc/>
    public BetaModelInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaModelInfo.FromRawUnchecked(rawData);
}

/// <summary>
/// The model's current lifecycle stage.
///
/// <para>- `active`: The model is available for use, open to new adopters, and not
/// scheduled for retirement. - `deprecated`: The model remains callable for organizations
/// with existing access, but is headed for retirement and closed to new adopters.
/// - `retired`: The model is no longer available for use; inference requests naming
/// it fail. It remains in the catalogue as the historical record of its retirement.</para>
/// </summary>
[JsonConverter(typeof(BetaModelInfoLifecycleConverter))]
public enum BetaModelInfoLifecycle
{
    Active,
    Deprecated,
    Retired,
}

sealed class BetaModelInfoLifecycleConverter : JsonConverter<BetaModelInfoLifecycle>
{
    public override BetaModelInfoLifecycle Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => BetaModelInfoLifecycle.Active,
            "deprecated" => BetaModelInfoLifecycle.Deprecated,
            "retired" => BetaModelInfoLifecycle.Retired,
            _ => (BetaModelInfoLifecycle)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaModelInfoLifecycle value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaModelInfoLifecycle.Active => "active",
                BetaModelInfoLifecycle.Deprecated => "deprecated",
                BetaModelInfoLifecycle.Retired => "retired",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
