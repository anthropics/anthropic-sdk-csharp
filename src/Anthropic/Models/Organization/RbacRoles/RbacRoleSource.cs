using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RbacRoles;

[JsonConverter(typeof(RbacRoleSourceConverter))]
public record class RbacRoleSource : ModelBase
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

    public ApiEnum<string, RbacRoleSourceType> Type
    {
        get
        {
            return this.Value switch
            {
                RbacRoleSourceBuiltIn _ => RbacRoleSourceType.BuiltIn,
                RbacRoleSourceCustom _ => RbacRoleSourceType.Custom,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, RbacRoleSourceType>
                >(this.Json, "type"),
            };
        }
    }

    public RbacRoleSource(RbacRoleSourceBuiltIn value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public RbacRoleSource(RbacRoleSourceCustom value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public RbacRoleSource(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RbacRoleSourceBuiltIn"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBuiltIn(out var value)) {
    ///     // `value` is of type `RbacRoleSourceBuiltIn`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBuiltIn([NotNullWhen(true)] out RbacRoleSourceBuiltIn? value)
    {
        value = this.Value as RbacRoleSourceBuiltIn;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RbacRoleSourceCustom"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCustom(out var value)) {
    ///     // `value` is of type `RbacRoleSourceCustom`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCustom([NotNullWhen(true)] out RbacRoleSourceCustom? value)
    {
        value = this.Value as RbacRoleSourceCustom;
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
    ///     (RbacRoleSourceBuiltIn value) =&gt; {...},
    ///     (RbacRoleSourceCustom value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<RbacRoleSourceBuiltIn> builtIn, Action<RbacRoleSourceCustom> custom)
    {
        switch (this.Value)
        {
            case RbacRoleSourceBuiltIn value:
                builtIn(value);
                break;
            case RbacRoleSourceCustom value:
                custom(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of RbacRoleSource"
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
    ///     (RbacRoleSourceBuiltIn value) =&gt; {...},
    ///     (RbacRoleSourceCustom value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<RbacRoleSourceBuiltIn, T> builtIn, Func<RbacRoleSourceCustom, T> custom)
    {
        return this.Value switch
        {
            RbacRoleSourceBuiltIn value => builtIn(value),
            RbacRoleSourceCustom value => custom(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of RbacRoleSource"
            ),
        };
    }

    public static implicit operator RbacRoleSource(RbacRoleSourceBuiltIn value) => new(value);

    public static implicit operator RbacRoleSource(RbacRoleSourceCustom value) => new(value);

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
                "Data did not match any variant of RbacRoleSource"
            );
        }
        this.Switch((builtIn) => builtIn.Validate(), (custom) => custom.Validate());
    }

    public virtual bool Equals(RbacRoleSource? other) =>
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
            RbacRoleSourceBuiltIn _ => 0,
            RbacRoleSourceCustom _ => 1,
            _ => -1,
        };
    }
}

sealed class RbacRoleSourceConverter : JsonConverter<RbacRoleSource>
{
    public override RbacRoleSource? Read(
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
                    var deserialized = JsonSerializer.Deserialize<RbacRoleSourceBuiltIn>(
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
                    var deserialized = JsonSerializer.Deserialize<RbacRoleSourceCustom>(
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
                return new RbacRoleSource(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        RbacRoleSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(RbacRoleSourceTypeConverter))]
public enum RbacRoleSourceType
{
    BuiltIn = 0,
    Custom = 1,
}

sealed class RbacRoleSourceTypeConverter : JsonConverter<RbacRoleSourceType>
{
    public override RbacRoleSourceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "built_in" => RbacRoleSourceType.BuiltIn,
            "custom" => RbacRoleSourceType.Custom,
            _ => (RbacRoleSourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RbacRoleSourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RbacRoleSourceType.BuiltIn => "built_in",
                RbacRoleSourceType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
