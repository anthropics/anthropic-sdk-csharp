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
/// Document referenced by URL.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUrlDocumentSource,
        BetaManagedAgentsUrlDocumentSourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUrlDocumentSource : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsUrlDocumentSourceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUrlDocumentSourceType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// URL of the document to fetch.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Url;
    }

    public BetaManagedAgentsUrlDocumentSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUrlDocumentSource(
        BetaManagedAgentsUrlDocumentSource betaManagedAgentsUrlDocumentSource
    )
        : base(betaManagedAgentsUrlDocumentSource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUrlDocumentSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUrlDocumentSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUrlDocumentSourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUrlDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUrlDocumentSourceFromRaw : IFromRawJson<BetaManagedAgentsUrlDocumentSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUrlDocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUrlDocumentSource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUrlDocumentSourceTypeConverter))]
public enum BetaManagedAgentsUrlDocumentSourceType
{
    Url,
}

sealed class BetaManagedAgentsUrlDocumentSourceTypeConverter
    : JsonConverter<BetaManagedAgentsUrlDocumentSourceType>
{
    public override BetaManagedAgentsUrlDocumentSourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "url" => BetaManagedAgentsUrlDocumentSourceType.Url,
            _ => (BetaManagedAgentsUrlDocumentSourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUrlDocumentSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUrlDocumentSourceType.Url => "url",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
