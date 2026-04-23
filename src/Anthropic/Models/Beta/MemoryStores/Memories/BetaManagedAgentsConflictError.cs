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
    typeof(JsonModelConverter<
        BetaManagedAgentsConflictError,
        BetaManagedAgentsConflictErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsConflictError : JsonModel
{
    public required ApiEnum<string, global::Anthropic.Models.Beta.MemoryStores.Memories.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.MemoryStores.Memories.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Message;
    }

    public BetaManagedAgentsConflictError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsConflictError(
        BetaManagedAgentsConflictError betaManagedAgentsConflictError
    )
        : base(betaManagedAgentsConflictError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsConflictError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsConflictError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsConflictErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsConflictError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsConflictError(
        ApiEnum<string, global::Anthropic.Models.Beta.MemoryStores.Memories.Type> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsConflictErrorFromRaw : IFromRawJson<BetaManagedAgentsConflictError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsConflictError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsConflictError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    ConflictError,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.MemoryStores.Memories.Type>
{
    public override global::Anthropic.Models.Beta.MemoryStores.Memories.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "conflict_error" => global::Anthropic
                .Models
                .Beta
                .MemoryStores
                .Memories
                .Type
                .ConflictError,
            _ => (global::Anthropic.Models.Beta.MemoryStores.Memories.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.MemoryStores.Memories.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.MemoryStores.Memories.Type.ConflictError =>
                    "conflict_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
