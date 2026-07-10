using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// Input session transcripts the dream reads.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDreamSessionsInput, BetaDreamSessionsInputFromRaw>))]
public sealed record class BetaDreamSessionsInput : JsonModel
{
    public required IReadOnlyList<string> SessionIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("session_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "session_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaDreamSessionsInputType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaDreamSessionsInputType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SessionIds;
        this.Type.Validate();
    }

    public BetaDreamSessionsInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamSessionsInput(BetaDreamSessionsInput betaDreamSessionsInput)
        : base(betaDreamSessionsInput) { }
#pragma warning restore CS8618

    public BetaDreamSessionsInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDreamSessionsInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamSessionsInputFromRaw.FromRawUnchecked"/>
    public static BetaDreamSessionsInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDreamSessionsInputFromRaw : IFromRawJson<BetaDreamSessionsInput>
{
    /// <inheritdoc/>
    public BetaDreamSessionsInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDreamSessionsInput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaDreamSessionsInputTypeConverter))]
public enum BetaDreamSessionsInputType
{
    Sessions,
}

sealed class BetaDreamSessionsInputTypeConverter : JsonConverter<BetaDreamSessionsInputType>
{
    public override BetaDreamSessionsInputType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sessions" => BetaDreamSessionsInputType.Sessions,
            _ => (BetaDreamSessionsInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaDreamSessionsInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaDreamSessionsInputType.Sessions => "sessions",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
