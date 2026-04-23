using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsPrecondition, BetaManagedAgentsPreconditionFromRaw>)
)]
public sealed record class BetaManagedAgentsPrecondition : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsPreconditionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsPreconditionType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? ContentSha256
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_sha256");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content_sha256", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ContentSha256;
    }

    public BetaManagedAgentsPrecondition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsPrecondition(
        BetaManagedAgentsPrecondition betaManagedAgentsPrecondition
    )
        : base(betaManagedAgentsPrecondition) { }
#pragma warning restore CS8618

    public BetaManagedAgentsPrecondition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsPrecondition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsPreconditionFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsPrecondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsPrecondition(ApiEnum<string, BetaManagedAgentsPreconditionType> type)
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsPreconditionFromRaw : IFromRawJson<BetaManagedAgentsPrecondition>
{
    /// <inheritdoc/>
    public BetaManagedAgentsPrecondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsPrecondition.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsPreconditionTypeConverter))]
public enum BetaManagedAgentsPreconditionType
{
    ContentSha256,
}

sealed class BetaManagedAgentsPreconditionTypeConverter
    : JsonConverter<BetaManagedAgentsPreconditionType>
{
    public override BetaManagedAgentsPreconditionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "content_sha256" => BetaManagedAgentsPreconditionType.ContentSha256,
            _ => (BetaManagedAgentsPreconditionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsPreconditionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsPreconditionType.ContentSha256 => "content_sha256",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
