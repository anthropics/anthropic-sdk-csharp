using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsDeltaContent, BetaManagedAgentsDeltaContentFromRaw>)
)]
public sealed record class BetaManagedAgentsDeltaContent : JsonModel
{
    /// <summary>
    /// Regular text content.
    /// </summary>
    public required BetaManagedAgentsTextBlock Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsTextBlock>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsDeltaContentType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsDeltaContentType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Which entry in the previewed event's content array this fragment lands in.
    /// Insert content as that entry when the index is new; append to the existing
    /// entry otherwise.
    /// </summary>
    public long? Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("index", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        this.Type.Validate();
        _ = this.Index;
    }

    public BetaManagedAgentsDeltaContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeltaContent(
        BetaManagedAgentsDeltaContent betaManagedAgentsDeltaContent
    )
        : base(betaManagedAgentsDeltaContent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeltaContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeltaContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeltaContentFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeltaContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsDeltaContentFromRaw : IFromRawJson<BetaManagedAgentsDeltaContent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeltaContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeltaContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsDeltaContentTypeConverter))]
public enum BetaManagedAgentsDeltaContentType
{
    ContentDelta,
}

sealed class BetaManagedAgentsDeltaContentTypeConverter
    : JsonConverter<BetaManagedAgentsDeltaContentType>
{
    public override BetaManagedAgentsDeltaContentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "content_delta" => BetaManagedAgentsDeltaContentType.ContentDelta,
            _ => (BetaManagedAgentsDeltaContentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeltaContentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeltaContentType.ContentDelta => "content_delta",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
