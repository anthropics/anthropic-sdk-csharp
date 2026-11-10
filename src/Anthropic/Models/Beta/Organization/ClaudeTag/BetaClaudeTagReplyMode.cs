using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// How Claude takes part in a Slack channel. A channel alone stores one. More types
/// can be added.
/// </summary>
[JsonConverter(typeof(BetaClaudeTagReplyModeConverter))]
public record class BetaClaudeTagReplyMode : ModelBase
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

    public ApiEnum<string, BetaClaudeTagReplyModeType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaClaudeTagReplyModeAutomatic _ => BetaClaudeTagReplyModeType.Automatic,
                BetaClaudeTagReplyModeMentionOnly _ => BetaClaudeTagReplyModeType.MentionOnly,
                BetaClaudeTagReplyModeAlwaysAwake _ => BetaClaudeTagReplyModeType.AlwaysAwake,
                BetaClaudeTagReplyModeThread _ => BetaClaudeTagReplyModeType.Thread,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaClaudeTagReplyModeType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaClaudeTagReplyMode(
        BetaClaudeTagReplyModeAutomatic value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagReplyMode(
        BetaClaudeTagReplyModeMentionOnly value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagReplyMode(
        BetaClaudeTagReplyModeAlwaysAwake value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagReplyMode(BetaClaudeTagReplyModeThread value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagReplyMode(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagReplyModeAutomatic"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAutomatic(out var value)) {
    ///     // `value` is of type `BetaClaudeTagReplyModeAutomatic`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAutomatic([NotNullWhen(true)] out BetaClaudeTagReplyModeAutomatic? value)
    {
        value = this.Value as BetaClaudeTagReplyModeAutomatic;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagReplyModeMentionOnly"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMentionOnly(out var value)) {
    ///     // `value` is of type `BetaClaudeTagReplyModeMentionOnly`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMentionOnly([NotNullWhen(true)] out BetaClaudeTagReplyModeMentionOnly? value)
    {
        value = this.Value as BetaClaudeTagReplyModeMentionOnly;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagReplyModeAlwaysAwake"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAlwaysAwake(out var value)) {
    ///     // `value` is of type `BetaClaudeTagReplyModeAlwaysAwake`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAlwaysAwake([NotNullWhen(true)] out BetaClaudeTagReplyModeAlwaysAwake? value)
    {
        value = this.Value as BetaClaudeTagReplyModeAlwaysAwake;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagReplyModeThread"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThread(out var value)) {
    ///     // `value` is of type `BetaClaudeTagReplyModeThread`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThread([NotNullWhen(true)] out BetaClaudeTagReplyModeThread? value)
    {
        value = this.Value as BetaClaudeTagReplyModeThread;
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
    ///     (BetaClaudeTagReplyModeAutomatic value) =&gt; {...},
    ///     (BetaClaudeTagReplyModeMentionOnly value) =&gt; {...},
    ///     (BetaClaudeTagReplyModeAlwaysAwake value) =&gt; {...},
    ///     (BetaClaudeTagReplyModeThread value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaClaudeTagReplyModeAutomatic> automatic,
        Action<BetaClaudeTagReplyModeMentionOnly> mentionOnly,
        Action<BetaClaudeTagReplyModeAlwaysAwake> alwaysAwake,
        Action<BetaClaudeTagReplyModeThread> thread
    )
    {
        switch (this.Value)
        {
            case BetaClaudeTagReplyModeAutomatic value:
                automatic(value);
                break;
            case BetaClaudeTagReplyModeMentionOnly value:
                mentionOnly(value);
                break;
            case BetaClaudeTagReplyModeAlwaysAwake value:
                alwaysAwake(value);
                break;
            case BetaClaudeTagReplyModeThread value:
                thread(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaClaudeTagReplyMode"
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
    ///     (BetaClaudeTagReplyModeAutomatic value) =&gt; {...},
    ///     (BetaClaudeTagReplyModeMentionOnly value) =&gt; {...},
    ///     (BetaClaudeTagReplyModeAlwaysAwake value) =&gt; {...},
    ///     (BetaClaudeTagReplyModeThread value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaClaudeTagReplyModeAutomatic, T> automatic,
        Func<BetaClaudeTagReplyModeMentionOnly, T> mentionOnly,
        Func<BetaClaudeTagReplyModeAlwaysAwake, T> alwaysAwake,
        Func<BetaClaudeTagReplyModeThread, T> thread
    )
    {
        return this.Value switch
        {
            BetaClaudeTagReplyModeAutomatic value => automatic(value),
            BetaClaudeTagReplyModeMentionOnly value => mentionOnly(value),
            BetaClaudeTagReplyModeAlwaysAwake value => alwaysAwake(value),
            BetaClaudeTagReplyModeThread value => thread(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaClaudeTagReplyMode"
            ),
        };
    }

    public static implicit operator BetaClaudeTagReplyMode(BetaClaudeTagReplyModeAutomatic value) =>
        new(value);

    public static implicit operator BetaClaudeTagReplyMode(
        BetaClaudeTagReplyModeMentionOnly value
    ) => new(value);

    public static implicit operator BetaClaudeTagReplyMode(
        BetaClaudeTagReplyModeAlwaysAwake value
    ) => new(value);

    public static implicit operator BetaClaudeTagReplyMode(BetaClaudeTagReplyModeThread value) =>
        new(value);

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
                "Data did not match any variant of BetaClaudeTagReplyMode"
            );
        }
        this.Switch(
            (automatic) => automatic.Validate(),
            (mentionOnly) => mentionOnly.Validate(),
            (alwaysAwake) => alwaysAwake.Validate(),
            (thread) => thread.Validate()
        );
    }

    public virtual bool Equals(BetaClaudeTagReplyMode? other) =>
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
            BetaClaudeTagReplyModeAutomatic _ => 0,
            BetaClaudeTagReplyModeMentionOnly _ => 1,
            BetaClaudeTagReplyModeAlwaysAwake _ => 2,
            BetaClaudeTagReplyModeThread _ => 3,
            _ => -1,
        };
    }
}

sealed class BetaClaudeTagReplyModeConverter : JsonConverter<BetaClaudeTagReplyMode>
{
    public override BetaClaudeTagReplyMode? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "automatic":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaClaudeTagReplyModeAutomatic>(
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
            case "mention_only":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeTagReplyModeMentionOnly>(
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
            case "always_awake":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeTagReplyModeAlwaysAwake>(
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
            case "thread":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaClaudeTagReplyModeThread>(
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
                return new BetaClaudeTagReplyMode(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeTagReplyMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaClaudeTagReplyModeTypeConverter))]
public enum BetaClaudeTagReplyModeType
{
    Automatic,
    MentionOnly,
    AlwaysAwake,
    Thread,
}

sealed class BetaClaudeTagReplyModeTypeConverter : JsonConverter<BetaClaudeTagReplyModeType>
{
    public override BetaClaudeTagReplyModeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "automatic" => BetaClaudeTagReplyModeType.Automatic,
            "mention_only" => BetaClaudeTagReplyModeType.MentionOnly,
            "always_awake" => BetaClaudeTagReplyModeType.AlwaysAwake,
            "thread" => BetaClaudeTagReplyModeType.Thread,
            _ => (BetaClaudeTagReplyModeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeTagReplyModeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaClaudeTagReplyModeType.Automatic => "automatic",
                BetaClaudeTagReplyModeType.MentionOnly => "mention_only",
                BetaClaudeTagReplyModeType.AlwaysAwake => "always_awake",
                BetaClaudeTagReplyModeType.Thread => "thread",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
