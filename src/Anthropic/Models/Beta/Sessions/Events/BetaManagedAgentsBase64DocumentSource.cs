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
/// Base64-encoded document data.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsBase64DocumentSource,
        BetaManagedAgentsBase64DocumentSourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsBase64DocumentSource : JsonModel
{
    /// <summary>
    /// Base64-encoded document data.
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
    /// MIME type of the document (e.g., "application/pdf").
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

    public required ApiEnum<string, BetaManagedAgentsBase64DocumentSourceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsBase64DocumentSourceType>
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

    public BetaManagedAgentsBase64DocumentSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsBase64DocumentSource(
        BetaManagedAgentsBase64DocumentSource betaManagedAgentsBase64DocumentSource
    )
        : base(betaManagedAgentsBase64DocumentSource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsBase64DocumentSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsBase64DocumentSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsBase64DocumentSourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsBase64DocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsBase64DocumentSourceFromRaw
    : IFromRawJson<BetaManagedAgentsBase64DocumentSource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsBase64DocumentSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsBase64DocumentSource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsBase64DocumentSourceTypeConverter))]
public enum BetaManagedAgentsBase64DocumentSourceType
{
    Base64,
}

sealed class BetaManagedAgentsBase64DocumentSourceTypeConverter
    : JsonConverter<BetaManagedAgentsBase64DocumentSourceType>
{
    public override BetaManagedAgentsBase64DocumentSourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "base64" => BetaManagedAgentsBase64DocumentSourceType.Base64,
            _ => (BetaManagedAgentsBase64DocumentSourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsBase64DocumentSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsBase64DocumentSourceType.Base64 => "base64",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
