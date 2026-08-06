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
/// Placeholder for content withheld by Anthropic model policy.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsRedactedBlock,
        BetaManagedAgentsRedactedBlockFromRaw
    >)
)]
public sealed record class BetaManagedAgentsRedactedBlock : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsRedactedBlockType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsRedactedBlockType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsRedactedBlock() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsRedactedBlock(
        BetaManagedAgentsRedactedBlock betaManagedAgentsRedactedBlock
    )
        : base(betaManagedAgentsRedactedBlock) { }
#pragma warning restore CS8618

    public BetaManagedAgentsRedactedBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsRedactedBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsRedactedBlockFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsRedactedBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsRedactedBlock(ApiEnum<string, BetaManagedAgentsRedactedBlockType> type)
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsRedactedBlockFromRaw : IFromRawJson<BetaManagedAgentsRedactedBlock>
{
    /// <inheritdoc/>
    public BetaManagedAgentsRedactedBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsRedactedBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsRedactedBlockTypeConverter))]
public enum BetaManagedAgentsRedactedBlockType
{
    Redacted,
}

sealed class BetaManagedAgentsRedactedBlockTypeConverter
    : JsonConverter<BetaManagedAgentsRedactedBlockType>
{
    public override BetaManagedAgentsRedactedBlockType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "redacted" => BetaManagedAgentsRedactedBlockType.Redacted,
            _ => (BetaManagedAgentsRedactedBlockType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsRedactedBlockType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsRedactedBlockType.Redacted => "redacted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
