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
/// Configures the transformations the server applies to this image before the model
/// observes it. Each key names a condition the server transforms images for; its
/// value selects the transformation applied. Omitted keys keep their default behavior,
/// and an empty object is equivalent to omitting the field.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaImageTransformationsParam, BetaImageTransformationsParamFromRaw>)
)]
public sealed record class BetaImageTransformationsParam : JsonModel
{
    /// <summary>
    /// What the server does when this image exceeds the model's maximum image size.
    /// `"downsize"` (the default) scales the image down to fit, which changes the
    /// dimensions the model observes without telling you. `"error"` instead rejects
    /// the request with a 400 error naming the image's dimensions and the largest
    /// dimensions that fit, so you can scale the image deliberately — your image
    /// is never silently scaled down.
    /// </summary>
    public ApiEnum<string, OversizedImage>? OversizedImage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OversizedImage>>(
                "oversized_image"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("oversized_image", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.OversizedImage?.Validate();
    }

    public BetaImageTransformationsParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaImageTransformationsParam(
        BetaImageTransformationsParam betaImageTransformationsParam
    )
        : base(betaImageTransformationsParam) { }
#pragma warning restore CS8618

    public BetaImageTransformationsParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaImageTransformationsParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaImageTransformationsParamFromRaw.FromRawUnchecked"/>
    public static BetaImageTransformationsParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaImageTransformationsParamFromRaw : IFromRawJson<BetaImageTransformationsParam>
{
    /// <inheritdoc/>
    public BetaImageTransformationsParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaImageTransformationsParam.FromRawUnchecked(rawData);
}

/// <summary>
/// What the server does when this image exceeds the model's maximum image size. `"downsize"`
/// (the default) scales the image down to fit, which changes the dimensions the model
/// observes without telling you. `"error"` instead rejects the request with a 400
/// error naming the image's dimensions and the largest dimensions that fit, so you
/// can scale the image deliberately — your image is never silently scaled down.
/// </summary>
[JsonConverter(typeof(OversizedImageConverter))]
public enum OversizedImage
{
    Downsize,
    Error,
}

sealed class OversizedImageConverter : JsonConverter<OversizedImage>
{
    public override OversizedImage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "downsize" => OversizedImage.Downsize,
            "error" => OversizedImage.Error,
            _ => (OversizedImage)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OversizedImage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OversizedImage.Downsize => "downsize",
                OversizedImage.Error => "error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
