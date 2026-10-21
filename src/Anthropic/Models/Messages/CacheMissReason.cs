using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(CacheMissReasonConverter))]
public record class CacheMissReason : ModelBase
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

    public long? CacheMissedInputTokens
    {
        get
        {
            return this.Value switch
            {
                CacheMissModelChanged x => x.CacheMissedInputTokens,
                CacheMissSystemChanged x => x.CacheMissedInputTokens,
                CacheMissToolsChanged x => x.CacheMissedInputTokens,
                CacheMissMessagesChanged x => x.CacheMissedInputTokens,
                CacheMissPreviousMessageNotFound _ => null,
                CacheMissUnavailable _ => null,
                _ => WrappedJsonSerializer.GetNullableStructProperty<long>(
                    this.Json,
                    "cache_missed_input_tokens"
                ),
            };
        }
    }

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                CacheMissModelChanged x => x.Type,
                CacheMissSystemChanged x => x.Type,
                CacheMissToolsChanged x => x.Type,
                CacheMissMessagesChanged x => x.Type,
                CacheMissPreviousMessageNotFound x => x.Type,
                CacheMissUnavailable x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public CacheMissReason(CacheMissModelChanged value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(CacheMissSystemChanged value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(CacheMissToolsChanged value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(CacheMissMessagesChanged value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(CacheMissPreviousMessageNotFound value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(CacheMissUnavailable value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CacheMissReason(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CacheMissModelChanged"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickModelChanged(out var value)) {
    ///     // `value` is of type `CacheMissModelChanged`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickModelChanged([NotNullWhen(true)] out CacheMissModelChanged? value)
    {
        value = this.Value as CacheMissModelChanged;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CacheMissSystemChanged"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSystemChanged(out var value)) {
    ///     // `value` is of type `CacheMissSystemChanged`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSystemChanged([NotNullWhen(true)] out CacheMissSystemChanged? value)
    {
        value = this.Value as CacheMissSystemChanged;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CacheMissToolsChanged"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolsChanged(out var value)) {
    ///     // `value` is of type `CacheMissToolsChanged`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolsChanged([NotNullWhen(true)] out CacheMissToolsChanged? value)
    {
        value = this.Value as CacheMissToolsChanged;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CacheMissMessagesChanged"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMessagesChanged(out var value)) {
    ///     // `value` is of type `CacheMissMessagesChanged`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMessagesChanged([NotNullWhen(true)] out CacheMissMessagesChanged? value)
    {
        value = this.Value as CacheMissMessagesChanged;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CacheMissPreviousMessageNotFound"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPreviousMessageNotFound(out var value)) {
    ///     // `value` is of type `CacheMissPreviousMessageNotFound`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPreviousMessageNotFound(
        [NotNullWhen(true)] out CacheMissPreviousMessageNotFound? value
    )
    {
        value = this.Value as CacheMissPreviousMessageNotFound;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CacheMissUnavailable"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnavailable(out var value)) {
    ///     // `value` is of type `CacheMissUnavailable`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnavailable([NotNullWhen(true)] out CacheMissUnavailable? value)
    {
        value = this.Value as CacheMissUnavailable;
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
    ///     (CacheMissModelChanged value) =&gt; {...},
    ///     (CacheMissSystemChanged value) =&gt; {...},
    ///     (CacheMissToolsChanged value) =&gt; {...},
    ///     (CacheMissMessagesChanged value) =&gt; {...},
    ///     (CacheMissPreviousMessageNotFound value) =&gt; {...},
    ///     (CacheMissUnavailable value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<CacheMissModelChanged> modelChanged,
        System::Action<CacheMissSystemChanged> systemChanged,
        System::Action<CacheMissToolsChanged> toolsChanged,
        System::Action<CacheMissMessagesChanged> messagesChanged,
        System::Action<CacheMissPreviousMessageNotFound> previousMessageNotFound,
        System::Action<CacheMissUnavailable> unavailable
    )
    {
        switch (this.Value)
        {
            case CacheMissModelChanged value:
                modelChanged(value);
                break;
            case CacheMissSystemChanged value:
                systemChanged(value);
                break;
            case CacheMissToolsChanged value:
                toolsChanged(value);
                break;
            case CacheMissMessagesChanged value:
                messagesChanged(value);
                break;
            case CacheMissPreviousMessageNotFound value:
                previousMessageNotFound(value);
                break;
            case CacheMissUnavailable value:
                unavailable(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of CacheMissReason"
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
    ///     (CacheMissModelChanged value) =&gt; {...},
    ///     (CacheMissSystemChanged value) =&gt; {...},
    ///     (CacheMissToolsChanged value) =&gt; {...},
    ///     (CacheMissMessagesChanged value) =&gt; {...},
    ///     (CacheMissPreviousMessageNotFound value) =&gt; {...},
    ///     (CacheMissUnavailable value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<CacheMissModelChanged, T> modelChanged,
        System::Func<CacheMissSystemChanged, T> systemChanged,
        System::Func<CacheMissToolsChanged, T> toolsChanged,
        System::Func<CacheMissMessagesChanged, T> messagesChanged,
        System::Func<CacheMissPreviousMessageNotFound, T> previousMessageNotFound,
        System::Func<CacheMissUnavailable, T> unavailable
    )
    {
        return this.Value switch
        {
            CacheMissModelChanged value => modelChanged(value),
            CacheMissSystemChanged value => systemChanged(value),
            CacheMissToolsChanged value => toolsChanged(value),
            CacheMissMessagesChanged value => messagesChanged(value),
            CacheMissPreviousMessageNotFound value => previousMessageNotFound(value),
            CacheMissUnavailable value => unavailable(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of CacheMissReason"
            ),
        };
    }

    public static implicit operator CacheMissReason(CacheMissModelChanged value) => new(value);

    public static implicit operator CacheMissReason(CacheMissSystemChanged value) => new(value);

    public static implicit operator CacheMissReason(CacheMissToolsChanged value) => new(value);

    public static implicit operator CacheMissReason(CacheMissMessagesChanged value) => new(value);

    public static implicit operator CacheMissReason(CacheMissPreviousMessageNotFound value) =>
        new(value);

    public static implicit operator CacheMissReason(CacheMissUnavailable value) => new(value);

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
                "Data did not match any variant of CacheMissReason"
            );
        }
        this.Switch(
            (modelChanged) => modelChanged.Validate(),
            (systemChanged) => systemChanged.Validate(),
            (toolsChanged) => toolsChanged.Validate(),
            (messagesChanged) => messagesChanged.Validate(),
            (previousMessageNotFound) => previousMessageNotFound.Validate(),
            (unavailable) => unavailable.Validate()
        );
    }

    public virtual bool Equals(CacheMissReason? other) =>
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
            CacheMissModelChanged _ => 0,
            CacheMissSystemChanged _ => 1,
            CacheMissToolsChanged _ => 2,
            CacheMissMessagesChanged _ => 3,
            CacheMissPreviousMessageNotFound _ => 4,
            CacheMissUnavailable _ => 5,
            _ => -1,
        };
    }
}

sealed class CacheMissReasonConverter : JsonConverter<CacheMissReason>
{
    public override CacheMissReason? Read(
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
            case "model_changed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CacheMissModelChanged>(
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
            case "system_changed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CacheMissSystemChanged>(
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
            case "tools_changed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CacheMissToolsChanged>(
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
            case "messages_changed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CacheMissMessagesChanged>(
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
            case "previous_message_not_found":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CacheMissPreviousMessageNotFound>(
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
            case "unavailable":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CacheMissUnavailable>(
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
                return new CacheMissReason(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CacheMissReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
