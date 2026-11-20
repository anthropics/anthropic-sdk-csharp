using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacRoles;

[JsonConverter(typeof(BetaRbacRoleSourceConverter))]
public record class BetaRbacRoleSource : ModelBase
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

    public ApiEnum<string, BetaRbacRoleSourceType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaRbacRoleSourceBuiltIn _ => BetaRbacRoleSourceType.BuiltIn,
                BetaRbacRoleSourceCustom _ => BetaRbacRoleSourceType.Custom,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaRbacRoleSourceType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaRbacRoleSource(BetaRbacRoleSourceBuiltIn value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRbacRoleSource(BetaRbacRoleSourceCustom value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRbacRoleSource(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRbacRoleSourceBuiltIn"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBuiltIn(out var value)) {
    ///     // `value` is of type `BetaRbacRoleSourceBuiltIn`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBuiltIn([NotNullWhen(true)] out BetaRbacRoleSourceBuiltIn? value)
    {
        value = this.Value as BetaRbacRoleSourceBuiltIn;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRbacRoleSourceCustom"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCustom(out var value)) {
    ///     // `value` is of type `BetaRbacRoleSourceCustom`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCustom([NotNullWhen(true)] out BetaRbacRoleSourceCustom? value)
    {
        value = this.Value as BetaRbacRoleSourceCustom;
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
    ///     (BetaRbacRoleSourceBuiltIn value) =&gt; {...},
    ///     (BetaRbacRoleSourceCustom value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaRbacRoleSourceBuiltIn> builtIn,
        Action<BetaRbacRoleSourceCustom> custom
    )
    {
        switch (this.Value)
        {
            case BetaRbacRoleSourceBuiltIn value:
                builtIn(value);
                break;
            case BetaRbacRoleSourceCustom value:
                custom(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaRbacRoleSource"
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
    ///     (BetaRbacRoleSourceBuiltIn value) =&gt; {...},
    ///     (BetaRbacRoleSourceCustom value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaRbacRoleSourceBuiltIn, T> builtIn,
        Func<BetaRbacRoleSourceCustom, T> custom
    )
    {
        return this.Value switch
        {
            BetaRbacRoleSourceBuiltIn value => builtIn(value),
            BetaRbacRoleSourceCustom value => custom(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRbacRoleSource"
            ),
        };
    }

    public static implicit operator BetaRbacRoleSource(BetaRbacRoleSourceBuiltIn value) =>
        new(value);

    public static implicit operator BetaRbacRoleSource(BetaRbacRoleSourceCustom value) =>
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
                "Data did not match any variant of BetaRbacRoleSource"
            );
        }
        this.Switch((builtIn) => builtIn.Validate(), (custom) => custom.Validate());
    }

    public virtual bool Equals(BetaRbacRoleSource? other) =>
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
            BetaRbacRoleSourceBuiltIn _ => 0,
            BetaRbacRoleSourceCustom _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaRbacRoleSourceConverter : JsonConverter<BetaRbacRoleSource>
{
    public override BetaRbacRoleSource? Read(
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
            case "built_in":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRbacRoleSourceBuiltIn>(
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
            case "custom":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRbacRoleSourceCustom>(
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
                return new BetaRbacRoleSource(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaRbacRoleSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaRbacRoleSourceTypeConverter))]
public enum BetaRbacRoleSourceType
{
    BuiltIn = 0,
    Custom = 1,
}

sealed class BetaRbacRoleSourceTypeConverter : JsonConverter<BetaRbacRoleSourceType>
{
    public override BetaRbacRoleSourceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "built_in" => BetaRbacRoleSourceType.BuiltIn,
            "custom" => BetaRbacRoleSourceType.Custom,
            _ => (BetaRbacRoleSourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaRbacRoleSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaRbacRoleSourceType.BuiltIn => "built_in",
                BetaRbacRoleSourceType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
