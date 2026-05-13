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
/// Text content within a search result.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSearchResultContent,
        BetaManagedAgentsSearchResultContentFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSearchResultContent : JsonModel
{
    /// <summary>
    /// The text content.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSearchResultContentType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSearchResultContentType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        this.Type.Validate();
    }

    public BetaManagedAgentsSearchResultContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSearchResultContent(
        BetaManagedAgentsSearchResultContent betaManagedAgentsSearchResultContent
    )
        : base(betaManagedAgentsSearchResultContent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSearchResultContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSearchResultContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSearchResultContentFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSearchResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSearchResultContentFromRaw
    : IFromRawJson<BetaManagedAgentsSearchResultContent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSearchResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSearchResultContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSearchResultContentTypeConverter))]
public enum BetaManagedAgentsSearchResultContentType
{
    Text,
}

sealed class BetaManagedAgentsSearchResultContentTypeConverter
    : JsonConverter<BetaManagedAgentsSearchResultContentType>
{
    public override BetaManagedAgentsSearchResultContentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => BetaManagedAgentsSearchResultContentType.Text,
            _ => (BetaManagedAgentsSearchResultContentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSearchResultContentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSearchResultContentType.Text => "text",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
