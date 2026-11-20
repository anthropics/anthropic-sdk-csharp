using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

[JsonConverter(typeof(BetaClaudeCodeRbacGroupStatusConverter))]
public record class BetaClaudeCodeRbacGroupStatus : ModelBase
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

    public ApiEnum<string, BetaClaudeCodeRbacGroupStatusType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaClaudeCodeRbacGroupStatusActive _ => BetaClaudeCodeRbacGroupStatusType.Active,
                BetaClaudeCodeRbacGroupStatusDeleted _ => BetaClaudeCodeRbacGroupStatusType.Deleted,
                BetaClaudeCodeRbacGroupStatusUnknown _ => BetaClaudeCodeRbacGroupStatusType.Unknown,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaClaudeCodeRbacGroupStatusType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaClaudeCodeRbacGroupStatus(
        BetaClaudeCodeRbacGroupStatusActive value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeCodeRbacGroupStatus(
        BetaClaudeCodeRbacGroupStatusDeleted value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeCodeRbacGroupStatus(
        BetaClaudeCodeRbacGroupStatusUnknown value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaClaudeCodeRbacGroupStatus(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeCodeRbacGroupStatusActive"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickActive(out var value)) {
    ///     // `value` is of type `BetaClaudeCodeRbacGroupStatusActive`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickActive([NotNullWhen(true)] out BetaClaudeCodeRbacGroupStatusActive? value)
    {
        value = this.Value as BetaClaudeCodeRbacGroupStatusActive;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeCodeRbacGroupStatusDeleted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDeleted(out var value)) {
    ///     // `value` is of type `BetaClaudeCodeRbacGroupStatusDeleted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDeleted([NotNullWhen(true)] out BetaClaudeCodeRbacGroupStatusDeleted? value)
    {
        value = this.Value as BetaClaudeCodeRbacGroupStatusDeleted;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaClaudeCodeRbacGroupStatusUnknown"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnknown(out var value)) {
    ///     // `value` is of type `BetaClaudeCodeRbacGroupStatusUnknown`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnknown([NotNullWhen(true)] out BetaClaudeCodeRbacGroupStatusUnknown? value)
    {
        value = this.Value as BetaClaudeCodeRbacGroupStatusUnknown;
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
    ///     (BetaClaudeCodeRbacGroupStatusActive value) =&gt; {...},
    ///     (BetaClaudeCodeRbacGroupStatusDeleted value) =&gt; {...},
    ///     (BetaClaudeCodeRbacGroupStatusUnknown value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaClaudeCodeRbacGroupStatusActive> active,
        Action<BetaClaudeCodeRbacGroupStatusDeleted> deleted,
        Action<BetaClaudeCodeRbacGroupStatusUnknown> unknown
    )
    {
        switch (this.Value)
        {
            case BetaClaudeCodeRbacGroupStatusActive value:
                active(value);
                break;
            case BetaClaudeCodeRbacGroupStatusDeleted value:
                deleted(value);
                break;
            case BetaClaudeCodeRbacGroupStatusUnknown value:
                unknown(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaClaudeCodeRbacGroupStatus"
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
    ///     (BetaClaudeCodeRbacGroupStatusActive value) =&gt; {...},
    ///     (BetaClaudeCodeRbacGroupStatusDeleted value) =&gt; {...},
    ///     (BetaClaudeCodeRbacGroupStatusUnknown value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaClaudeCodeRbacGroupStatusActive, T> active,
        Func<BetaClaudeCodeRbacGroupStatusDeleted, T> deleted,
        Func<BetaClaudeCodeRbacGroupStatusUnknown, T> unknown
    )
    {
        return this.Value switch
        {
            BetaClaudeCodeRbacGroupStatusActive value => active(value),
            BetaClaudeCodeRbacGroupStatusDeleted value => deleted(value),
            BetaClaudeCodeRbacGroupStatusUnknown value => unknown(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaClaudeCodeRbacGroupStatus"
            ),
        };
    }

    public static implicit operator BetaClaudeCodeRbacGroupStatus(
        BetaClaudeCodeRbacGroupStatusActive value
    ) => new(value);

    public static implicit operator BetaClaudeCodeRbacGroupStatus(
        BetaClaudeCodeRbacGroupStatusDeleted value
    ) => new(value);

    public static implicit operator BetaClaudeCodeRbacGroupStatus(
        BetaClaudeCodeRbacGroupStatusUnknown value
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
                "Data did not match any variant of BetaClaudeCodeRbacGroupStatus"
            );
        }
        this.Switch(
            (active) => active.Validate(),
            (deleted) => deleted.Validate(),
            (unknown) => unknown.Validate()
        );
    }

    public virtual bool Equals(BetaClaudeCodeRbacGroupStatus? other) =>
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
            BetaClaudeCodeRbacGroupStatusActive _ => 0,
            BetaClaudeCodeRbacGroupStatusDeleted _ => 1,
            BetaClaudeCodeRbacGroupStatusUnknown _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaClaudeCodeRbacGroupStatusConverter : JsonConverter<BetaClaudeCodeRbacGroupStatus>
{
    public override BetaClaudeCodeRbacGroupStatus? Read(
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
            case "active":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupStatusActive>(
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
            case "deleted":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupStatusDeleted>(
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
            case "unknown":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupStatusUnknown>(
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
                return new BetaClaudeCodeRbacGroupStatus(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeCodeRbacGroupStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaClaudeCodeRbacGroupStatusTypeConverter))]
public enum BetaClaudeCodeRbacGroupStatusType
{
    Active = 0,
    Deleted = 1,
    Unknown = 2,
}

sealed class BetaClaudeCodeRbacGroupStatusTypeConverter
    : JsonConverter<BetaClaudeCodeRbacGroupStatusType>
{
    public override BetaClaudeCodeRbacGroupStatusType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => BetaClaudeCodeRbacGroupStatusType.Active,
            "deleted" => BetaClaudeCodeRbacGroupStatusType.Deleted,
            "unknown" => BetaClaudeCodeRbacGroupStatusType.Unknown,
            _ => (BetaClaudeCodeRbacGroupStatusType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaClaudeCodeRbacGroupStatusType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaClaudeCodeRbacGroupStatusType.Active => "active",
                BetaClaudeCodeRbacGroupStatusType.Deleted => "deleted",
                BetaClaudeCodeRbacGroupStatusType.Unknown => "unknown",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
