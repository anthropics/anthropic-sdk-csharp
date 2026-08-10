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
/// of session transcripts and writes consolidated memories into an output memory
/// store — a new store by default, or an existing store chosen via output_behavior.
/// The Dreams API is in research preview: the request and response shapes are volatile
/// and may change without the deprecation period that applies to generally-available endpoints.
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

    /// <summary>
    /// The default destination: the job creates a new output memory store as a clone
    /// of the memory_store input and writes the consolidated memories into it. The
    /// input store is never mutated.
    /// </summary>
    public required BetaDreamOutputBehavior OutputBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaDreamOutputBehavior>("output_behavior");
        }
        init { this._rawData.Set("output_behavior", value); }
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

/// <summary>
/// The default destination: the job creates a new output memory store as a clone
/// of the memory_store input and writes the consolidated memories into it. The input
/// store is never mutated.
/// </summary>
[JsonConverter(typeof(BetaDreamOutputBehaviorConverter))]
public record class BetaDreamOutputBehavior : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BetaDreamOutputBehavior(
        BetaDreamOutputBehaviorCreateNew value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaDreamOutputBehavior(
        BetaDreamOutputBehaviorUpdateExisting value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaDreamOutputBehavior(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaDreamOutputBehaviorCreateNew"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreateNew(out var value)) {
    ///     // `value` is of type `BetaDreamOutputBehaviorCreateNew`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreateNew([NotNullWhen(true)] out BetaDreamOutputBehaviorCreateNew? value)
    {
        value = this.Value as BetaDreamOutputBehaviorCreateNew;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaDreamOutputBehaviorUpdateExisting"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUpdateExisting(out var value)) {
    ///     // `value` is of type `BetaDreamOutputBehaviorUpdateExisting`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUpdateExisting(
        [NotNullWhen(true)] out BetaDreamOutputBehaviorUpdateExisting? value
    )
    {
        value = this.Value as BetaDreamOutputBehaviorUpdateExisting;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (BetaDreamOutputBehaviorCreateNew value) =&gt; {...},
    ///     (BetaDreamOutputBehaviorUpdateExisting value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaDreamOutputBehaviorCreateNew> createNew,
        System::Action<BetaDreamOutputBehaviorUpdateExisting> updateExisting
    )
    {
        switch (this.Value)
        {
            case BetaDreamOutputBehaviorCreateNew value:
                createNew(value);
                break;
            case BetaDreamOutputBehaviorUpdateExisting value:
                updateExisting(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaDreamOutputBehavior"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (BetaDreamOutputBehaviorCreateNew value) =&gt; {...},
    ///     (BetaDreamOutputBehaviorUpdateExisting value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaDreamOutputBehaviorCreateNew, T> createNew,
        System::Func<BetaDreamOutputBehaviorUpdateExisting, T> updateExisting
    )
    {
        return this.Value switch
        {
            BetaDreamOutputBehaviorCreateNew value => createNew(value),
            BetaDreamOutputBehaviorUpdateExisting value => updateExisting(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaDreamOutputBehavior"
            ),
        };
    }

    public static implicit operator BetaDreamOutputBehavior(
        BetaDreamOutputBehaviorCreateNew value
    ) => new(value);

    public static implicit operator BetaDreamOutputBehavior(
        BetaDreamOutputBehaviorUpdateExisting value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaDreamOutputBehavior"
            );
        }
        this.Switch(
            (createNew) => createNew.Validate(),
            (updateExisting) => updateExisting.Validate()
        );
    }

    public virtual bool Equals(BetaDreamOutputBehavior? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaDreamOutputBehaviorCreateNew _ => 0,
            BetaDreamOutputBehaviorUpdateExisting _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaDreamOutputBehaviorConverter : JsonConverter<BetaDreamOutputBehavior>
{
    public override BetaDreamOutputBehavior? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "create_new":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaDreamOutputBehaviorCreateNew>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "update_existing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaDreamOutputBehaviorUpdateExisting>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new BetaDreamOutputBehavior(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaDreamOutputBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// The default destination: the job creates a new output memory store as a clone
/// of the memory_store input and writes the consolidated memories into it. The input
/// store is never mutated.
/// </summary>
[JsonConverter(typeof(BetaDreamOutputBehaviorCreateNewConverter))]
public record class BetaDreamOutputBehaviorCreateNew
{
    public JsonElement Element { get; private init; }

    public BetaDreamOutputBehaviorCreateNew()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "create_new"
            }
            """
        );
    }

    internal BetaDreamOutputBehaviorCreateNew(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new BetaDreamOutputBehaviorCreateNew())
        {
            throw new AnthropicInvalidDataException(
                "Invalid value given for 'BetaDreamOutputBehaviorCreateNew'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(BetaDreamOutputBehaviorCreateNew? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class BetaDreamOutputBehaviorCreateNewConverter : JsonConverter<BetaDreamOutputBehaviorCreateNew>
{
    public override BetaDreamOutputBehaviorCreateNew? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaDreamOutputBehaviorCreateNew value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// The job writes the consolidated memories into this existing memory store instead
/// of creating one. In EAP the store must be the job's own memory_store input, so
/// the job consolidates the store in place.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaDreamOutputBehaviorUpdateExisting,
        BetaDreamOutputBehaviorUpdateExistingFromRaw
    >)
)]
public sealed record class BetaDreamOutputBehaviorUpdateExisting : JsonModel
{
    public required string MemoryStoreID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("memory_store_id");
        }
        init { this._rawData.Set("memory_store_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MemoryStoreID;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("update_existing"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDreamOutputBehaviorUpdateExisting()
    {
        this.Type = JsonSerializer.SerializeToElement("update_existing");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamOutputBehaviorUpdateExisting(
        BetaDreamOutputBehaviorUpdateExisting betaDreamOutputBehaviorUpdateExisting
    )
        : base(betaDreamOutputBehaviorUpdateExisting) { }
#pragma warning restore CS8618

    public BetaDreamOutputBehaviorUpdateExisting(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("update_existing");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDreamOutputBehaviorUpdateExisting(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamOutputBehaviorUpdateExistingFromRaw.FromRawUnchecked"/>
    public static BetaDreamOutputBehaviorUpdateExisting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDreamOutputBehaviorUpdateExisting(string memoryStoreID)
        : this()
    {
        this.MemoryStoreID = memoryStoreID;
    }
}

class BetaDreamOutputBehaviorUpdateExistingFromRaw
    : IFromRawJson<BetaDreamOutputBehaviorUpdateExisting>
{
    /// <inheritdoc/>
    public BetaDreamOutputBehaviorUpdateExisting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDreamOutputBehaviorUpdateExisting.FromRawUnchecked(rawData);
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
