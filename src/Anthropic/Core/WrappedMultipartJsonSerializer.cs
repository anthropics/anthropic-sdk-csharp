using System.Text.Json;
using Anthropic.Exceptions;

namespace Anthropic.Core;

/// <summary>
/// Helper class for deserializing &lt;c&gt;MultipartJsonElement&lt;/c&gt; objects.
/// This handles edge-cases around nullability and reference/value types.
/// </summary>
sealed class WrappedMultipartJsonSerializer
{
    public static T GetNotNullClass<T>(MultipartJsonElement element, string name)
        where T : class
    {
        T deserialized;
        try
        {
            deserialized =
                MultipartJsonSerializer.Deserialize<T>(element, ModelBase.SerializerOptions)
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

    public static T GetNotNullStruct<T>(MultipartJsonElement element, string name)
        where T : struct
    {
        T deserialized;
        try
        {
            deserialized =
                MultipartJsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions)
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

    public static T? GetNullableClass<T>(MultipartJsonElement element, string name)
        where T : class
    {
        T? deserialized;
        try
        {
            deserialized = MultipartJsonSerializer.Deserialize<T?>(
                element,
                ModelBase.SerializerOptions
            );
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

    public static T? GetNullableStruct<T>(MultipartJsonElement element, string name)
        where T : struct
    {
        T? deserialized;
        try
        {
            deserialized = MultipartJsonSerializer.Deserialize<T?>(
                element,
                ModelBase.SerializerOptions
            );
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
    public static T GetNotNullClassProperty<T>(MultipartJsonElement element, string name)
        where T : class
    {
        if (
            element.Json.ValueKind != JsonValueKind.Object
            || !element.Json.TryGetProperty(name, out JsonElement json)
        )
        {
            throw new AnthropicInvalidDataException($"'{name}' cannot be absent");
        }
        MultipartJsonElement property = new()
        {
            Json = json,
            BinaryContents = element.BinaryContents,
        };
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
    public static T GetNotNullStructProperty<T>(MultipartJsonElement element, string name)
        where T : struct
    {
        if (
            element.Json.ValueKind != JsonValueKind.Object
            || !element.Json.TryGetProperty(name, out JsonElement json)
        )
        {
            throw new AnthropicInvalidDataException($"'{name}' cannot be absent");
        }
        MultipartJsonElement property = new()
        {
            Json = json,
            BinaryContents = element.BinaryContents,
        };
        return GetNotNullStruct<T>(property, name);
    }

    /// <summary>
    /// Returns the property of <paramref name="element"/> with the given name deserialized to
    /// <typeparamref name="T"/>, or null if <paramref name="element"/> isn't an object with
    /// that property or the property is null or not a valid <typeparamref name="T"/>.
    /// </summary>
    public static T? GetNullableClassProperty<T>(MultipartJsonElement element, string name)
        where T : class
    {
        if (
            element.Json.ValueKind != JsonValueKind.Object
            || !element.Json.TryGetProperty(name, out JsonElement json)
        )
        {
            return null;
        }
        MultipartJsonElement property = new()
        {
            Json = json,
            BinaryContents = element.BinaryContents,
        };
        try
        {
            return MultipartJsonSerializer.Deserialize<T?>(property, ModelBase.SerializerOptions);
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
    public static T? GetNullableStructProperty<T>(MultipartJsonElement element, string name)
        where T : struct
    {
        if (
            element.Json.ValueKind != JsonValueKind.Object
            || !element.Json.TryGetProperty(name, out JsonElement json)
        )
        {
            return null;
        }
        MultipartJsonElement property = new()
        {
            Json = json,
            BinaryContents = element.BinaryContents,
        };
        try
        {
            return MultipartJsonSerializer.Deserialize<T?>(property, ModelBase.SerializerOptions);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}
