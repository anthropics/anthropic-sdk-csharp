using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Base64-encoded image data.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsBase64ImageSource,
        BetaManagedAgentsBase64ImageSourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsBase64ImageSource : JsonModel
{
    /// <summary>
    /// Base64-encoded image data.
    /// </summary>
    public required string Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// MIME type of the image (e.g., "image/png", "image/jpeg", "image/gif", "image/webp").
    /// </summary>
    public required string MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("media_type");
        }
        init { this._rawData.Set("media_type", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsBase64ImageSourceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsBase64ImageSourceType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        _ = this.MediaType;
        this.Type.Validate();
    }

    public BetaManagedAgentsBase64ImageSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsBase64ImageSource(
        BetaManagedAgentsBase64ImageSource betaManagedAgentsBase64ImageSource
    )
        : base(betaManagedAgentsBase64ImageSource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsBase64ImageSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsBase64ImageSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsBase64ImageSourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsBase64ImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsBase64ImageSourceFromRaw : IFromRawJson<BetaManagedAgentsBase64ImageSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsBase64ImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsBase64ImageSource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsBase64ImageSourceTypeConverter))]
public enum BetaManagedAgentsBase64ImageSourceType
{
    Base64,
}

sealed class BetaManagedAgentsBase64ImageSourceTypeConverter
    : JsonConverter<BetaManagedAgentsBase64ImageSourceType>
{
    public override BetaManagedAgentsBase64ImageSourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "base64" => BetaManagedAgentsBase64ImageSourceType.Base64,
            _ => (BetaManagedAgentsBase64ImageSourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsBase64ImageSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsBase64ImageSourceType.Base64 => "base64",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
