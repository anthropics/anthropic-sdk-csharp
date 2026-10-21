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
/// An asynchronous job that reads a memory store and past sessions, then writes a
/// reorganized version of that memory store.
///
/// <para>By default the dream writes its result to a new memory store and doesn't
/// change the input memory store. With `output_behavior` set to `update_existing`,
/// it writes its result into the input memory store instead.</para>
///
/// <para>The Dreams API is in research preview: the request and response shapes
/// are volatile and may change without the deprecation period that applies to generally-available endpoints.</para>
///
/// <para>See the [Dreams guide](https://platform.claude.com/docs/en/managed-agents/dreams#how-it-works)
/// for what a dream reads and produces.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDream, BetaDreamFromRaw>))]
public sealed record class BetaDream : JsonModel
{
    /// <summary>
    /// The unique ID of the dream (`drm_...`).
    /// </summary>
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
    /// When the dream was archived, in RFC 3339, or `null` if it hasn't been archived.
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
    /// When the dream was created, in RFC 3339.
    ///
    /// <para>Lists of dreams are sorted by this time, newest first.</para>
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
    /// When the dream reached `completed`, `failed`, or `canceled`, in RFC 3339,
    /// or `null` if it is still `pending` or `running`.
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
    /// Why the dream failed, or `null` if `status` isn't `failed`.
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

    /// <summary>
    /// The sources that the dream reads, from the request that created it.
    /// </summary>
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

    /// <summary>
    /// The guidance given when the dream was created, or `null` if none was given.
    /// </summary>
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
    /// The model that runs a dream, from the request that created it.
    ///
    /// <para>The dream uses this model for all of its work. The response always gives
    /// the model as an object, even if the request gave only a model ID.</para>
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

    /// <summary>
    /// Where the dream writes its result, as set in the request that created the
    /// dream. If that request left out `output_behavior`, the dream used the `create_new` behavior.
    /// </summary>
    public required BetaOutputBehavior OutputBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaOutputBehavior>("output_behavior");
        }
        init { this._rawData.Set("output_behavior", value); }
    }

    /// <summary>
    /// The memory store that holds the dream's result, as a one-item array, or an
    /// empty array until the dream records that memory store.
    ///
    /// <para>The array is empty while the dream is `pending` and for a short time
    /// after it starts `running`. It can stay empty if the dream fails or is canceled
    /// before then. The memory store holds the complete result only once `status`
    /// is `completed`.</para>
    ///
    /// <para>See the [Dreams guide](https://platform.claude.com/docs/en/managed-agents/dreams#use-the-output)
    /// for how to review and use the result.</para>
    /// </summary>
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

    /// <summary>
    /// The ID of the session that runs the dream (`sesn_...`), or `null` if that
    /// session hasn't started.
    ///
    /// <para>Stream that session's events to follow what the dream reads and writes.</para>
    ///
    /// <para>See the [Dreams guide](https://platform.claude.com/docs/en/managed-agents/dreams#watch-the-pipeline-run)
    /// for how to watch a running dream.</para>
    /// </summary>
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
    /// Where a dream is in its lifecycle.
    ///
    /// <para>`completed`, `failed`, and `canceled` are final: once a dream has one
    /// of these statuses, its status doesn't change again.</para>
    ///
    /// <para>See the [Dreams guide](https://platform.claude.com/docs/en/managed-agents/dreams#lifecycle)
    /// for what each status means.</para>
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
    /// The dream's token counts, which stop changing once its `status` is `completed`
    /// or `failed`. After a cancel, they can keep changing.
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
        this.OutputBehavior.Validate();
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
