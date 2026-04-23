using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

[JsonConverter(typeof(BetaManagedAgentsMemoryListItemConverter))]
public record class BetaManagedAgentsMemoryListItem : ModelBase
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

    public string Path
    {
        get { return Match(betaManagedAgentsMemory: (x) => x.Path, prefix: (x) => x.Path); }
    }

    public BetaManagedAgentsMemoryListItem(
        BetaManagedAgentsMemory value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMemoryListItem(
        BetaManagedAgentsMemoryPrefix value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMemoryListItem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMemory"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMemory(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMemory`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMemory(
        [NotNullWhen(true)] out BetaManagedAgentsMemory? value
    )
    {
        value = this.Value as BetaManagedAgentsMemory;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMemoryPrefix"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPrefix(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMemoryPrefix`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPrefix([NotNullWhen(true)] out BetaManagedAgentsMemoryPrefix? value)
    {
        value = this.Value as BetaManagedAgentsMemoryPrefix;
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
    ///     (BetaManagedAgentsMemory value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryPrefix value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsMemory> betaManagedAgentsMemory,
        System::Action<BetaManagedAgentsMemoryPrefix> prefix
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsMemory value:
                betaManagedAgentsMemory(value);
                break;
            case BetaManagedAgentsMemoryPrefix value:
                prefix(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsMemoryListItem"
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
    ///     (BetaManagedAgentsMemory value) =&gt; {...},
    ///     (BetaManagedAgentsMemoryPrefix value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsMemory, T> betaManagedAgentsMemory,
        System::Func<BetaManagedAgentsMemoryPrefix, T> prefix
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsMemory value => betaManagedAgentsMemory(value),
            BetaManagedAgentsMemoryPrefix value => prefix(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsMemoryListItem"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsMemoryListItem(
        BetaManagedAgentsMemory value
    ) => new(value);

    public static implicit operator BetaManagedAgentsMemoryListItem(
        BetaManagedAgentsMemoryPrefix value
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
                "Data did not match any variant of BetaManagedAgentsMemoryListItem"
            );
        }
        this.Switch(
            (betaManagedAgentsMemory) => betaManagedAgentsMemory.Validate(),
            (prefix) => prefix.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsMemoryListItem? other) =>
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
            BetaManagedAgentsMemory _ => 0,
            BetaManagedAgentsMemoryPrefix _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsMemoryListItemConverter
    : JsonConverter<BetaManagedAgentsMemoryListItem>
{
    public override BetaManagedAgentsMemoryListItem? Read(
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
            case "memory":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemory>(
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
            case "memory_prefix":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryPrefix>(
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
                return new BetaManagedAgentsMemoryListItem(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryListItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
