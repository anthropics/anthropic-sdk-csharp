using System;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Anthropic.Exceptions;

namespace Anthropic.Core;

/// <summary>
/// A dictionary that holds JSON data.
///
/// <para>It can be mutated and then frozen once no more mutations are expected. This
/// is useful for allowing the dictionary to be modified by a class's <c>init</c>
/// properties, but then preventing it from being modified afterwards.</para>
///
/// <para>It also caches data deserialization for performance.</para>
/// </summary>
sealed class JsonDictionary
{
    IDictionary<string, JsonElement> _rawData;

    readonly ConcurrentDictionary<string, object?> _deserializedData;

    Dictionary<string, JsonElement> MutableRawData
    {
        get
        {
            if (_rawData is Dictionary<string, JsonElement> dictionary)
            {
                return dictionary;
            }
            throw new InvalidOperationException("Can't mutate after freezing.");
        }
    }

    public JsonDictionary()
    {
        _rawData = new Dictionary<string, JsonElement>();
        _deserializedData = [];
    }

    public JsonDictionary(IReadOnlyDictionary<string, JsonElement> dictionary)
    {
        _rawData = Enumerable.ToDictionary(dictionary, (e) => e.Key, (e) => e.Value);
        _deserializedData = [];
    }

    public JsonDictionary(FrozenDictionary<string, JsonElement> dictionary)
    {
        _rawData = dictionary;
        _deserializedData = [];
    }

    public JsonDictionary(JsonDictionary dictionary)
    {
        _rawData = Enumerable.ToDictionary(dictionary._rawData, (e) => e.Key, (e) => e.Value);
        _deserializedData = new(dictionary._deserializedData);
    }

    /// <summary>
    /// Freezes this dictionary and returns a readonly view of it.
    ///
    /// <para>Future calls to mutating methods on this class will throw
    /// <see cref="InvalidOperationException"/></para>.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement> Freeze()
    {
        if (_rawData is FrozenDictionary<string, JsonElement> dictionary)
        {
            return dictionary;
        }

        var frozenRawData = FrozenDictionary.ToFrozenDictionary(_rawData);
        _rawData = frozenRawData;
        return frozenRawData;
    }

    public void Set<T>(string key, T value)
    {
        MutableRawData[key] = JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        _deserializedData[key] = value;
    }

    public T GetNotNullClass<T>(string key)
        where T : class
    {
        if (_deserializedData.TryGetValue(key, out var cached) && cached is T t)
        {
            return t;
        }
        if (!_rawData.TryGetValue(key, out JsonElement element))
        {
            throw new AnthropicInvalidDataException($"'{key}' cannot be absent");
        }
        T deserialized;
        try
        {
            deserialized =
                JsonSerializer.Deserialize<T>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
        _deserializedData[key] = deserialized;
        return deserialized;
    }

    public T GetNotNullStruct<T>(string key)
        where T : struct
    {
        if (_deserializedData.TryGetValue(key, out var cached) && cached is T t)
        {
            return t;
        }
        if (!_rawData.TryGetValue(key, out JsonElement element))
        {
            throw new AnthropicInvalidDataException($"'{key}' cannot be absent");
        }
        T deserialized;
        try
        {
            deserialized =
                JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
        _deserializedData[key] = deserialized;
        return deserialized;
    }

    public T? GetNullableClass<T>(string key)
        where T : class
    {
        if (_deserializedData.TryGetValue(key, out var cached) && (cached == null || cached is T))
        {
            return (T?)cached;
        }
        if (!_rawData.TryGetValue(key, out JsonElement element))
        {
            _deserializedData[key] = null;
            return null;
        }
        T? deserialized;
        try
        {
            deserialized = JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
        _deserializedData[key] = deserialized;
        return deserialized;
    }

    public T? GetNullableStruct<T>(string key)
        where T : struct
    {
        if (_deserializedData.TryGetValue(key, out var cached) && (cached == null || cached is T))
        {
            return (T?)cached;
        }
        if (!_rawData.TryGetValue(key, out JsonElement element))
        {
            _deserializedData[key] = null;
            return null;
        }
        T? deserialized;
        try
        {
            deserialized = JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
        _deserializedData[key] = deserialized;
        return deserialized;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._rawData, ModelBase.ToStringSerializerOptions);

    public override bool Equals(object? obj)
    {
        if (obj is not JsonDictionary other || _rawData.Count != other._rawData.Count)
        {
            return false;
        }

        foreach (var item in _rawData)
        {
            if (!other._rawData.TryGetValue(item.Key, out var otherValue))
            {
                return false;
            }

            if (!JsonElement.DeepEquals(item.Value, otherValue))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
