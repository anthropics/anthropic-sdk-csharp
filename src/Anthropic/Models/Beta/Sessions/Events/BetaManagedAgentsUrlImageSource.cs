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
/// Image referenced by URL.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUrlImageSource,
        BetaManagedAgentsUrlImageSourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUrlImageSource : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsUrlImageSourceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUrlImageSourceType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// URL of the image to fetch.
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

    public BetaManagedAgentsUrlImageSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUrlImageSource(
        BetaManagedAgentsUrlImageSource betaManagedAgentsUrlImageSource
    )
        : base(betaManagedAgentsUrlImageSource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUrlImageSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUrlImageSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUrlImageSourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUrlImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUrlImageSourceFromRaw : IFromRawJson<BetaManagedAgentsUrlImageSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUrlImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUrlImageSource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUrlImageSourceTypeConverter))]
public enum BetaManagedAgentsUrlImageSourceType
{
    Url,
}

sealed class BetaManagedAgentsUrlImageSourceTypeConverter
    : JsonConverter<BetaManagedAgentsUrlImageSourceType>
{
    public override BetaManagedAgentsUrlImageSourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "url" => BetaManagedAgentsUrlImageSourceType.Url,
            _ => (BetaManagedAgentsUrlImageSourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUrlImageSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUrlImageSourceType.Url => "url",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
