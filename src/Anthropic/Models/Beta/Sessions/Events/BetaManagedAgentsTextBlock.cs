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
/// Regular text content.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsTextBlock, BetaManagedAgentsTextBlockFromRaw>)
)]
public sealed record class BetaManagedAgentsTextBlock : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsTextBlockType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsTextBlockType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        this.Type.Validate();
    }

    public BetaManagedAgentsTextBlock() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTextBlock(BetaManagedAgentsTextBlock betaManagedAgentsTextBlock)
        : base(betaManagedAgentsTextBlock) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTextBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTextBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTextBlockFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTextBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsTextBlockFromRaw : IFromRawJson<BetaManagedAgentsTextBlock>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTextBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTextBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsTextBlockTypeConverter))]
public enum BetaManagedAgentsTextBlockType
{
    Text,
}

sealed class BetaManagedAgentsTextBlockTypeConverter : JsonConverter<BetaManagedAgentsTextBlockType>
{
    public override BetaManagedAgentsTextBlockType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => BetaManagedAgentsTextBlockType.Text,
            _ => (BetaManagedAgentsTextBlockType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTextBlockType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTextBlockType.Text => "text",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
