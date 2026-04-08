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
/// Plain text document content.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsPlainTextDocumentSource,
        BetaManagedAgentsPlainTextDocumentSourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsPlainTextDocumentSource : JsonModel
{
    /// <summary>
    /// The plain text content.
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
    /// MIME type of the text content. Must be "text/plain".
    /// </summary>
    public required ApiEnum<string, MediaType> MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MediaType>>("media_type");
        }
        init { this._rawData.Set("media_type", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsPlainTextDocumentSourceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsPlainTextDocumentSourceType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        this.MediaType.Validate();
        this.Type.Validate();
    }

    public BetaManagedAgentsPlainTextDocumentSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsPlainTextDocumentSource(
        BetaManagedAgentsPlainTextDocumentSource betaManagedAgentsPlainTextDocumentSource
    )
        : base(betaManagedAgentsPlainTextDocumentSource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsPlainTextDocumentSource(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsPlainTextDocumentSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsPlainTextDocumentSourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsPlainTextDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsPlainTextDocumentSourceFromRaw
    : IFromRawJson<BetaManagedAgentsPlainTextDocumentSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsPlainTextDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsPlainTextDocumentSource.FromRawUnchecked(rawData);
}

/// <summary>
/// MIME type of the text content. Must be "text/plain".
/// </summary>
[JsonConverter(typeof(MediaTypeConverter))]
public enum MediaType
{
    TextPlain,
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
            "text/plain" => MediaType.TextPlain,
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
                MediaType.TextPlain => "text/plain",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BetaManagedAgentsPlainTextDocumentSourceTypeConverter))]
public enum BetaManagedAgentsPlainTextDocumentSourceType
{
    Text,
}

sealed class BetaManagedAgentsPlainTextDocumentSourceTypeConverter
    : JsonConverter<BetaManagedAgentsPlainTextDocumentSourceType>
{
    public override BetaManagedAgentsPlainTextDocumentSourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => BetaManagedAgentsPlainTextDocumentSourceType.Text,
            _ => (BetaManagedAgentsPlainTextDocumentSourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsPlainTextDocumentSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsPlainTextDocumentSourceType.Text => "text",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
