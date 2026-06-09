using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSystemContentBlock,
        BetaManagedAgentsSystemContentBlockFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSystemContentBlock : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsSystemContentBlockType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSystemContentBlockType>
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

    public BetaManagedAgentsSystemContentBlock() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSystemContentBlock(
        BetaManagedAgentsSystemContentBlock betaManagedAgentsSystemContentBlock
    )
        : base(betaManagedAgentsSystemContentBlock) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSystemContentBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSystemContentBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSystemContentBlockFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSystemContentBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSystemContentBlockFromRaw : IFromRawJson<BetaManagedAgentsSystemContentBlock>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSystemContentBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSystemContentBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSystemContentBlockTypeConverter))]
public enum BetaManagedAgentsSystemContentBlockType
{
    Text,
}

sealed class BetaManagedAgentsSystemContentBlockTypeConverter
    : JsonConverter<BetaManagedAgentsSystemContentBlockType>
{
    public override BetaManagedAgentsSystemContentBlockType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => BetaManagedAgentsSystemContentBlockType.Text,
            _ => (BetaManagedAgentsSystemContentBlockType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSystemContentBlockType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSystemContentBlockType.Text => "text",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
