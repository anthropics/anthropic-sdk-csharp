using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<Base64ImageSource, Base64ImageSourceFromRaw>))]
public sealed record class Base64ImageSource : JsonModel
{
    public required string Data
    {
        get { return this._rawData.GetNotNullClass<string>("data"); }
        init { this._rawData.Set("data", value); }
    }

    public required ApiEnum<string, MediaType> MediaType
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, MediaType>>("media_type"); }
        init { this._rawData.Set("media_type", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
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

    public Base64ImageSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"base64\"");
    }

    public Base64ImageSource(Base64ImageSource base64ImageSource)
        : base(base64ImageSource) { }

    public Base64ImageSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"base64\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Base64ImageSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Base64ImageSourceFromRaw.FromRawUnchecked"/>
    public static Base64ImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Base64ImageSourceFromRaw : IFromRawJson<Base64ImageSource>
{
    /// <inheritdoc/>
    public Base64ImageSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Base64ImageSource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MediaTypeConverter))]
public enum MediaType
{
    ImageJpeg,
    ImagePng,
    ImageGif,
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
            "image/jpeg" => MediaType.ImageJpeg,
            "image/png" => MediaType.ImagePng,
            "image/gif" => MediaType.ImageGif,
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
                MediaType.ImageJpeg => "image/jpeg",
                MediaType.ImagePng => "image/png",
                MediaType.ImageGif => "image/gif",
                MediaType.ImageWebP => "image/webp",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
