using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaBase64ImageSource, BetaBase64ImageSourceFromRaw>))]
public sealed record class BetaBase64ImageSource : ModelBase
{
    public required string Data
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public required ApiEnum<string, MediaType> MediaType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, MediaType>>(
                this.RawData,
                "media_type"
            );
        }
        init { ModelBase.Set(this._rawData, "media_type", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        this.MediaType.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"base64\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBase64ImageSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"base64\"");
    }

    public BetaBase64ImageSource(BetaBase64ImageSource betaBase64ImageSource)
        : base(betaBase64ImageSource) { }

    public BetaBase64ImageSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"base64\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBase64ImageSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBase64ImageSourceFromRaw.FromRawUnchecked"/>
    public static BetaBase64ImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBase64ImageSourceFromRaw : IFromRaw<BetaBase64ImageSource>
{
    /// <inheritdoc/>
    public BetaBase64ImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBase64ImageSource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MediaTypeConverter))]
public enum MediaType
{
    ImageJPEG,
    ImagePNG,
    ImageGIF,
    ImageWebP,
}

sealed class MediaTypeConverter : JsonConverter<MediaType>
{
    public override MediaType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image/jpeg" => MediaType.ImageJPEG,
            "image/png" => MediaType.ImagePNG,
            "image/gif" => MediaType.ImageGIF,
            "image/webp" => MediaType.ImageWebP,
            _ => (MediaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MediaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MediaType.ImageJPEG => "image/jpeg",
                MediaType.ImagePNG => "image/png",
                MediaType.ImageGIF => "image/gif",
                MediaType.ImageWebP => "image/webp",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
