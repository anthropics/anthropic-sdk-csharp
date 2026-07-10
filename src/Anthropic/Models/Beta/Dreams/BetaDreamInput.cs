using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// An input memory store the dream reads from. The dream never mutates this store.
/// </summary>
[JsonConverter(typeof(BetaDreamInputConverter))]
public record class BetaDreamInput : ModelBase
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

    public BetaDreamInput(BetaDreamMemoryStoreInput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaDreamInput(BetaDreamSessionsInput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaDreamInput(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaDreamMemoryStoreInput"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMemoryStore(out var value)) {
    ///     // `value` is of type `BetaDreamMemoryStoreInput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMemoryStore([NotNullWhen(true)] out BetaDreamMemoryStoreInput? value)
    {
        value = this.Value as BetaDreamMemoryStoreInput;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaDreamSessionsInput"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessions(out var value)) {
    ///     // `value` is of type `BetaDreamSessionsInput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessions([NotNullWhen(true)] out BetaDreamSessionsInput? value)
    {
        value = this.Value as BetaDreamSessionsInput;
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
    ///     (BetaDreamMemoryStoreInput value) =&gt; {...},
    ///     (BetaDreamSessionsInput value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaDreamMemoryStoreInput> memoryStore,
        System::Action<BetaDreamSessionsInput> sessions
    )
    {
        switch (this.Value)
        {
            case BetaDreamMemoryStoreInput value:
                memoryStore(value);
                break;
            case BetaDreamSessionsInput value:
                sessions(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaDreamInput"
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
    ///     (BetaDreamMemoryStoreInput value) =&gt; {...},
    ///     (BetaDreamSessionsInput value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaDreamMemoryStoreInput, T> memoryStore,
        System::Func<BetaDreamSessionsInput, T> sessions
    )
    {
        return this.Value switch
        {
            BetaDreamMemoryStoreInput value => memoryStore(value),
            BetaDreamSessionsInput value => sessions(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaDreamInput"
            ),
        };
    }

    public static implicit operator BetaDreamInput(BetaDreamMemoryStoreInput value) => new(value);

    public static implicit operator BetaDreamInput(BetaDreamSessionsInput value) => new(value);

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
                "Data did not match any variant of BetaDreamInput"
            );
        }
        this.Switch((memoryStore) => memoryStore.Validate(), (sessions) => sessions.Validate());
    }

    public virtual bool Equals(BetaDreamInput? other) =>
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
            BetaDreamMemoryStoreInput _ => 0,
            BetaDreamSessionsInput _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaDreamInputConverter : JsonConverter<BetaDreamInput>
{
    public override BetaDreamInput? Read(
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
            case "memory_store":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaDreamMemoryStoreInput>(
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
            case "sessions":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaDreamSessionsInput>(
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
                return new BetaDreamInput(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaDreamInput value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
