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
/// An asynchronous memory-consolidation job that reads a memory store plus a set
/// of session transcripts and writes consolidated memories into a new output memory
/// store. The Dreams API is in research preview: the request and response shapes
/// are volatile and may change without the deprecation period that applies to generally-available endpoints.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDream, BetaDreamFromRaw>))]
public sealed record class BetaDream : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset? EndedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("ended_at");
        }
        init { this._rawData.Set("ended_at", value); }
    }

    /// <summary>
    /// Failure detail for a Dream whose `status` is `failed`.
    /// </summary>
    public required BetaDreamError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaDreamError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    public required IReadOnlyList<BetaDreamInput> Inputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaDreamInput>>("inputs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaDreamInput>>(
                "inputs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <summary>
    /// Model identifier and configuration applied to every pipeline stage. Same
    /// wire shape as the Agents API ModelConfig.
    /// </summary>
    public required BetaDreamModelConfig Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaDreamModelConfig>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    public required IReadOnlyList<BetaDreamOutput> Outputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaDreamOutput>>("outputs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaDreamOutput>>(
                "outputs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string? SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// Lifecycle status of a Dream.
    /// </summary>
    public required ApiEnum<string, BetaDreamStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaDreamStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ApiEnum<string, global::Anthropic.Models.Beta.Dreams.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Dreams.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Cumulative token usage for the dream across every pipeline stage.
    /// </summary>
    public required BetaDreamUsage Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaDreamUsage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ArchivedAt;
        _ = this.CreatedAt;
        _ = this.EndedAt;
        this.Error?.Validate();
        foreach (var item in this.Inputs)
        {
            item.Validate();
        }
        _ = this.Instructions;
        this.Model.Validate();
        foreach (var item in this.Outputs)
        {
            item.Validate();
        }
        _ = this.SessionID;
        this.Status.Validate();
        this.Type.Validate();
        this.Usage.Validate();
    }

    public BetaDream() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDream(BetaDream betaDream)
        : base(betaDream) { }
#pragma warning restore CS8618

    public BetaDream(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDream(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamFromRaw.FromRawUnchecked"/>
    public static BetaDream FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDreamFromRaw : IFromRawJson<BetaDream>
{
    /// <inheritdoc/>
    public BetaDream FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDream.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Dream,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Dreams.Type>
{
    public override global::Anthropic.Models.Beta.Dreams.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dream" => global::Anthropic.Models.Beta.Dreams.Type.Dream,
            _ => (global::Anthropic.Models.Beta.Dreams.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Dreams.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Dreams.Type.Dream => "dream",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
