using System.Text.Json;
using Anthropic.Exceptions;

namespace Anthropic.Core;

/// <summary>
/// Helper class for deserializing &lt;c&gt;JsonElement&lt;/c&gt; objects. This handles
/// edge-cases around nullability and reference/value types.
/// </summary>
sealed class WrappedJsonSerializer
{
    public static T GetNotNullClass<T>(JsonElement element, string name)
        where T : class
    {
        T deserialized;
        try
        {
            deserialized =
                JsonSerializer.Deserialize<T>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException($"'{name}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T GetNotNullStruct<T>(JsonElement element, string name)
        where T : struct
    {
        T deserialized;
        try
        {
            deserialized =
                JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException($"'{name}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T? GetNullableClass<T>(JsonElement element, string name)
        where T : class
    {
        T? deserialized;
        try
        {
            deserialized = JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T? GetNullableStruct<T>(JsonElement element, string name)
        where T : struct
    {
        T? deserialized;
        try
        {
            deserialized = JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    /// <summary>
    /// Returns the property of <paramref name="element"/> with the given name deserialized to
    /// <typeparamref name="T"/>.
    /// </summary>
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when <paramref name="element"/> isn't an object with that property or the property
    /// is null or not a valid <typeparamref name="T"/>.
    /// </exception>
    public static T GetNotNullClassProperty<T>(JsonElement element, string name)
        where T : class
    {
        if (
            element.ValueKind != JsonValueKind.Object
            || !element.TryGetProperty(name, out JsonElement property)
        )
        {
            throw new AnthropicInvalidDataException($"'{name}' cannot be absent");
        }
        return GetNotNullClass<T>(property, name);
    }

    /// <summary>
    /// Returns the property of <paramref name="element"/> with the given name deserialized to
    /// <typeparamref name="T"/>.
    /// </summary>
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when <paramref name="element"/> isn't an object with that property or the property
    /// is null or not a valid <typeparamref name="T"/>.
    /// </exception>
    public static T GetNotNullStructProperty<T>(JsonElement element, string name)
        where T : struct
    {
        if (
            element.ValueKind != JsonValueKind.Object
            || !element.TryGetProperty(name, out JsonElement property)
        )
        {
            throw new AnthropicInvalidDataException($"'{name}' cannot be absent");
        }
        return GetNotNullStruct<T>(property, name);
    }

    /// <summary>
    /// Returns the property of <paramref name="element"/> with the given name deserialized to
    /// <typeparamref name="T"/>, or null if <paramref name="element"/> isn't an object with
    /// that property or the property is null or not a valid <typeparamref name="T"/>.
    /// </summary>
    public static T? GetNullableClassProperty<T>(JsonElement element, string name)
        where T : class
    {
        if (
            element.ValueKind != JsonValueKind.Object
            || !element.TryGetProperty(name, out JsonElement property)
        )
        {
            return null;
        }
        try
        {
            return JsonSerializer.Deserialize<T?>(property, ModelBase.SerializerOptions);
        }
        catch (JsonException)
        {
            return null;
        }
    }

    /// <summary>
    /// Returns the property of <paramref name="element"/> with the given name deserialized to
    /// <typeparamref name="T"/>, or null if <paramref name="element"/> isn't an object with
    /// that property or the property is null or not a valid <typeparamref name="T"/>.
    /// </summary>
    public static T? GetNullableStructProperty<T>(JsonElement element, string name)
        where T : struct
    {
        if (
            element.ValueKind != JsonValueKind.Object
            || !element.TryGetProperty(name, out JsonElement property)
        )
        {
            return null;
        }
        try
        {
            return JsonSerializer.Deserialize<T?>(property, ModelBase.SerializerOptions);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}
