using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// What Claude does in a channel while a Slack guest is in it, for everyone in the
/// channel. It changes nothing in a channel without Slack guests. More types can
/// be added.
/// </summary>
[JsonConverter(typeof(BetaClaudeTagGuestPolicyConverter))]
public record class BetaClaudeTagGuestPolicy : ModelBase
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

    public ApiEnum<string, BetaClaudeTagGuestPolicyType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaClaudeTagGuestPolicyAllow _ => BetaClaudeTagGuestPolicyType.Allow,
                BetaClaudeTagGuestPolicyRestrict _ => BetaClaudeTagGuestPolicyType.Restrict,
                BetaClaudeTagGuestPolicyChannelOnly _ => BetaClaudeTagGuestPolicyType.ChannelOnly,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaClaudeTagGuestPolicyType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaClaudeTagGuestPolicy(
        BetaClaudeTagGuestPolicyAllow value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagGuestPolicy(
        BetaClaudeTagGuestPolicyRestrict value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagGuestPolicy(
        BetaClaudeTagGuestPolicyChannelOnly value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeTagGuestPolicy(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagGuestPolicyAllow"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAllow(out var value)) {
    ///     // `value` is of type `BetaClaudeTagGuestPolicyAllow`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAllow([NotNullWhen(true)] out BetaClaudeTagGuestPolicyAllow? value)
    {
        value = this.Value as BetaClaudeTagGuestPolicyAllow;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagGuestPolicyRestrict"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRestrict(out var value)) {
    ///     // `value` is of type `BetaClaudeTagGuestPolicyRestrict`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRestrict([NotNullWhen(true)] out BetaClaudeTagGuestPolicyRestrict? value)
    {
        value = this.Value as BetaClaudeTagGuestPolicyRestrict;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeTagGuestPolicyChannelOnly"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChannelOnly(out var value)) {
    ///     // `value` is of type `BetaClaudeTagGuestPolicyChannelOnly`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChannelOnly(
        [NotNullWhen(true)] out BetaClaudeTagGuestPolicyChannelOnly? value
    )
    {
        value = this.Value as BetaClaudeTagGuestPolicyChannelOnly;
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
    ///     (BetaClaudeTagGuestPolicyAllow value) =&gt; {...},
    ///     (BetaClaudeTagGuestPolicyRestrict value) =&gt; {...},
    ///     (BetaClaudeTagGuestPolicyChannelOnly value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaClaudeTagGuestPolicyAllow> allow,
        Action<BetaClaudeTagGuestPolicyRestrict> restrict,
        Action<BetaClaudeTagGuestPolicyChannelOnly> channelOnly
    )
    {
        switch (this.Value)
        {
            case BetaClaudeTagGuestPolicyAllow value:
                allow(value);
                break;
            case BetaClaudeTagGuestPolicyRestrict value:
                restrict(value);
                break;
            case BetaClaudeTagGuestPolicyChannelOnly value:
                channelOnly(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaClaudeTagGuestPolicy"
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
    ///     (BetaClaudeTagGuestPolicyAllow value) =&gt; {...},
    ///     (BetaClaudeTagGuestPolicyRestrict value) =&gt; {...},
    ///     (BetaClaudeTagGuestPolicyChannelOnly value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaClaudeTagGuestPolicyAllow, T> allow,
        Func<BetaClaudeTagGuestPolicyRestrict, T> restrict,
        Func<BetaClaudeTagGuestPolicyChannelOnly, T> channelOnly
    )
    {
        return this.Value switch
        {
            BetaClaudeTagGuestPolicyAllow value => allow(value),
            BetaClaudeTagGuestPolicyRestrict value => restrict(value),
            BetaClaudeTagGuestPolicyChannelOnly value => channelOnly(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaClaudeTagGuestPolicy"
            ),
        };
    }

    public static implicit operator BetaClaudeTagGuestPolicy(BetaClaudeTagGuestPolicyAllow value) =>
        new(value);

    public static implicit operator BetaClaudeTagGuestPolicy(
        BetaClaudeTagGuestPolicyRestrict value
    ) => new(value);

    public static implicit operator BetaClaudeTagGuestPolicy(
        BetaClaudeTagGuestPolicyChannelOnly value
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
                "Data did not match any variant of BetaClaudeTagGuestPolicy"
            );
        }
        this.Switch(
            (allow) => allow.Validate(),
            (restrict) => restrict.Validate(),
            (channelOnly) => channelOnly.Validate()
        );
    }

    public virtual bool Equals(BetaClaudeTagGuestPolicy? other) =>
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
            BetaClaudeTagGuestPolicyAllow _ => 0,
            BetaClaudeTagGuestPolicyRestrict _ => 1,
            BetaClaudeTagGuestPolicyChannelOnly _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaClaudeTagGuestPolicyConverter : JsonConverter<BetaClaudeTagGuestPolicy>
{
    public override BetaClaudeTagGuestPolicy? Read(
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
            case "allow":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaClaudeTagGuestPolicyAllow>(
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
            case "restrict":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaClaudeTagGuestPolicyRestrict>(
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
            case "channel_only":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeTagGuestPolicyChannelOnly>(
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
                return new BetaClaudeTagGuestPolicy(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeTagGuestPolicy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaClaudeTagGuestPolicyTypeConverter))]
public enum BetaClaudeTagGuestPolicyType
{
    Allow,
    Restrict,
    ChannelOnly,
}

sealed class BetaClaudeTagGuestPolicyTypeConverter : JsonConverter<BetaClaudeTagGuestPolicyType>
{
    public override BetaClaudeTagGuestPolicyType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow" => BetaClaudeTagGuestPolicyType.Allow,
            "restrict" => BetaClaudeTagGuestPolicyType.Restrict,
            "channel_only" => BetaClaudeTagGuestPolicyType.ChannelOnly,
            _ => (BetaClaudeTagGuestPolicyType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeTagGuestPolicyType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaClaudeTagGuestPolicyType.Allow => "allow",
                BetaClaudeTagGuestPolicyType.Restrict => "restrict",
                BetaClaudeTagGuestPolicyType.ChannelOnly => "channel_only",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
