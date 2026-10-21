using System;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Anthropic.Exceptions;

namespace Anthropic.Core;

/// <summary>
/// A dictionary that holds mixed JSON and binary content.
///
/// <para>It can be mutated and then frozen once no more mutations are expected.
/// This is useful for allowing the dictionary to be modified by a class's
/// <c>init</c> properties, but then preventing it from being modified afterwards.</para>
///
/// <para>It also caches data deserialization for performance.</para>
/// </summary>
sealed class MultipartJsonDictionary
{
    IReadOnlyDictionary<string, MultipartJsonElement> _rawData;

    /// <summary>
    /// Made with one write lock, not the default of one per processor: reads never
    /// lock, and a key is only written when it's set or first read.
    /// </summary>
    readonly ConcurrentDictionary<string, object?> _deserializedData;

    Dictionary<string, MultipartJsonElement> MutableRawData
    {
        get
        {
            if (_rawData is Dictionary<string, MultipartJsonElement> dictionary)
            {
                return dictionary;
            }
            throw new InvalidOperationException("Can't mutate after freezing.");
        }
    }

    public MultipartJsonDictionary()
    {
        _rawData = new Dictionary<string, MultipartJsonElement>();
        // How many properties will be set is unknown, so this keeps the default capacity.
        _deserializedData = new(concurrencyLevel: 1, capacity: 31);
    }

    public MultipartJsonDictionary(IReadOnlyDictionary<string, MultipartJsonElement> dictionary)
    {
        _rawData = Enumerable.ToDictionary(dictionary, (e) => e.Key, (e) => e.Value);
        _deserializedData = new(concurrencyLevel: 1, capacity: _rawData.Count);
    }

    public MultipartJsonDictionary(FrozenDictionary<string, MultipartJsonElement> dictionary)
    {
        _rawData = dictionary;
        _deserializedData = new(concurrencyLevel: 1, capacity: _rawData.Count);
    }

    public MultipartJsonDictionary(MultipartJsonDictionary dictionary)
    {
        _rawData = Enumerable.ToDictionary(dictionary._rawData, (e) => e.Key, (e) => e.Value);
        // The comparer is the default one, spelled out because .NET Framework rejects null.
        _deserializedData = new(
            concurrencyLevel: 1,
            dictionary._deserializedData,
            EqualityComparer<string>.Default
        );
    }

    /// <summary>
    /// Freezes this dictionary and returns a readonly view of it.
    ///
    /// <para>Future calls to mutating methods on this class will throw
    /// <see cref="InvalidOperationException"/></para>.
    /// </summary>
    public IReadOnlyDictionary<string, MultipartJsonElement> Freeze()
    {
        if (_rawData is FrozenDictionary<string, MultipartJsonElement> dictionary)
        {
            return dictionary;
        }

        var frozenRawData = FrozenDictionary.ToFrozenDictionary(_rawData);
        _rawData = frozenRawData;
        return frozenRawData;
    }

    public void Set<T>(string key, T value)
    {
        MutableRawData[key] = MultipartJsonSerializer.SerializeToElement(
            value,
            ModelBase.SerializerOptions
        );
        _deserializedData[key] = value;
    }

    public void Remove(string key)
    {
        MutableRawData.Remove(key);
        _deserializedData.TryRemove(key, out _);
    }

    public T GetNotNullClass<T>(string key)
        where T : class
    {
        if (_deserializedData.TryGetValue(key, out var cached) && cached is T t)
        {
            return t;
        }
        if (!_rawData.TryGetValue(key, out MultipartJsonElement element))
        {
            throw new AnthropicInvalidDataException($"'{key}' cannot be absent");
        }
        T? deserialized = WrappedMultipartJsonSerializer.GetNotNullClass<T>(element, key);
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
        if (!_rawData.TryGetValue(key, out MultipartJsonElement element))
        {
            throw new AnthropicInvalidDataException($"'{key}' cannot be absent");
        }
        T deserialized = WrappedMultipartJsonSerializer.GetNotNullStruct<T>(element, key);
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
        if (!_rawData.TryGetValue(key, out MultipartJsonElement element))
        {
            _deserializedData[key] = null;
            return null;
        }
        T? deserialized = WrappedMultipartJsonSerializer.GetNullableClass<T>(element, key);
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
        if (!_rawData.TryGetValue(key, out MultipartJsonElement element))
        {
            _deserializedData[key] = null;
            return null;
        }
        T? deserialized = WrappedMultipartJsonSerializer.GetNullableStruct<T>(element, key);
        _deserializedData[key] = deserialized;
        return deserialized;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this._rawData),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not MultipartJsonDictionary other || _rawData.Count != other._rawData.Count)
        {
            return false;
        }

        foreach (var item in _rawData)
        {
            if (!other._rawData.TryGetValue(item.Key, out var otherValue))
            {
                return false;
            }

            if (!MultipartJsonElement.DeepEquals(item.Value, otherValue))
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
