using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Core;

/// <summary>
/// A serializable and deserializable enum wrapper type that handles the possibility of values outside the
/// range of known enum members.
///
/// <para>In most cases you don't have to worry about this type and can rely on its implicit operators to
/// wrap and unwrap enum values.</para>
///
/// <param name="Json">
/// Returns this instance's raw value.
///
/// <para>This is usually only useful if this instance was deserialized from data that doesn't match the
/// expected type (<typeparamref name="TRaw"/>), and you want to know that value. For example, if the
/// SDK is on an older version than the API, then the API may respond with new data types that the SDK is
/// unaware of.</para>
/// </param>
/// </summary>
public record class ApiEnum<TRaw, TEnum>(JsonElement Json)
    where TEnum : struct, Enum
{
    /// <summary>
    /// Returns this instance's raw <typeparamref name="TRaw"/> value.
    ///
    /// <para>This is usually only useful if this instance was deserialized from data that doesn't match
    /// any known enum member, and you want to know that value. For example, if the SDK is on an older
    /// version than the API, then the API may respond with new members that the SDK is unaware of.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when this instance's raw value isn't of type <typeparamref name="TRaw"/>. Use
    /// <see cref="Json"/> to access the raw value.
    /// </exception>
    /// </summary>
    public TRaw Raw()
    {
        try
        {
            return JsonSerializer.Deserialize<TRaw>(this.Json, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException($"{nameof(this.Json)} cannot be null");
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"{this.Json} must be of type {typeof(TRaw).FullName}",
                e
            );
        }
    }

    /// <summary>
    /// Returns an enum member corresponding to this instance's value, or <c>(TEnum)(-1)</c> if the
    /// class was instantiated with an unknown value.
    ///
    /// <para>Use <see cref="Raw"/> to access the raw <typeparamref name="TRaw"/> value.</para>.
    /// </summary>
    public TEnum Value()
    {
        try
        {
            return JsonSerializer.Deserialize<TEnum?>(this.Json, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException($"{nameof(this.Json)} cannot be null");
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"{this.Json} must be of type {typeof(TRaw).FullName}",
                e
            );
        }
    }

    /// <summary>
    /// Verifies that this instance's raw value is a member of <typeparamref name="TEnum"/>.
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when this instance's raw value isn't a member of <typeparamref name="TEnum"/>.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (!Enum.IsDefined(typeof(TEnum), Value()))
        {
            throw new AnthropicInvalidDataException("Invalid enum value");
        }
    }

    public virtual bool Equals(ApiEnum<TRaw, TEnum>? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    public override int GetHashCode()
    {
        return 0;
    }

    public static implicit operator TRaw(ApiEnum<TRaw, TEnum> value) => value.Raw();

    public static implicit operator TEnum(ApiEnum<TRaw, TEnum> value) => value.Value();

    public static implicit operator ApiEnum<TRaw, TEnum>(TRaw value) =>
        new(JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions));

    public static implicit operator ApiEnum<TRaw, TEnum>(TEnum value) =>
        new(JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions));
}

sealed class ApiEnumConverter<TRaw, TEnum> : JsonConverter<ApiEnum<TRaw, TEnum>>
    where TEnum : struct, Enum
{
    public override ApiEnum<TRaw, TEnum> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApiEnum<TRaw, TEnum> value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
