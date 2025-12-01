using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Collections = System.Collections;

namespace Anthropic.Core;

/// <summary>
/// A dictionary that can be mutated and then frozen once no more mutations are expected.
///
/// <para>This is useful for allowing a dictionary to be modified by a class's <c>init</c>
/// properties, but then preventing it from being modified afterwards.</para>
/// </summary>
class FreezableDictionary<K, V> : IDictionary<K, V>
    where K : notnull
{
    IDictionary<K, V> _dictionary = new Dictionary<K, V>();

    Dictionary<K, V> _mutableDictionary
    {
        get
        {
            if (_dictionary is Dictionary<K, V> dict)
            {
                return dict;
            }

            throw new InvalidOperationException("Can't mutate after freezing.");
        }
    }

    public FreezableDictionary() { }

    public FreezableDictionary(IReadOnlyDictionary<K, V> dictionary)
    {
        _dictionary = Enumerable.ToDictionary(dictionary, e => e.Key, e => e.Value);
    }

    public FreezableDictionary(FrozenDictionary<K, V> frozen)
    {
        _dictionary = frozen;
    }

    /// <summary>
    /// Freezes this dictionary and returns a readonly view of it.
    ///
    /// <para>Future calls to mutating methods on this class will throw
    /// <see cref="InvalidOperationException"/></para>.
    /// </summary>
    public IReadOnlyDictionary<K, V> Freeze()
    {
        if (_dictionary is FrozenDictionary<K, V> dict)
        {
            return dict;
        }

        var dictionary = FrozenDictionary.ToFrozenDictionary(_dictionary);
        _dictionary = dictionary;

        return dictionary;
    }

    /// <inheritdoc/>
    public V this[K key]
    {
        get => _dictionary[key];
        set => _mutableDictionary[key] = value;
    }

    /// <inheritdoc/>
    public ICollection<K> Keys
    {
        get { return _dictionary.Keys; }
    }

    /// <inheritdoc/>
    public ICollection<V> Values
    {
        get { return _dictionary.Values; }
    }

    /// <inheritdoc/>
    public int Count
    {
        get { return _dictionary.Count; }
    }

    /// <inheritdoc/>
    public bool IsReadOnly
    {
        get { return _dictionary.IsReadOnly; }
    }

    /// <inheritdoc/>
    public void Add(K key, V value)
    {
        _mutableDictionary.Add(key, value);
    }

    /// <inheritdoc/>
    public void Add(KeyValuePair<K, V> item)
    {
        _mutableDictionary.Add(item.Key, item.Value);
    }

    /// <inheritdoc/>
    public void Clear()
    {
        _mutableDictionary.Clear();
    }

    /// <inheritdoc/>
    public bool Contains(KeyValuePair<K, V> item)
    {
        return _dictionary.Contains(item);
    }

    /// <inheritdoc/>
    public bool ContainsKey(K key)
    {
        return _dictionary.ContainsKey(key);
    }

    /// <inheritdoc/>
    public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
    {
        _dictionary.CopyTo(array, arrayIndex);
    }

    /// <inheritdoc/>
    public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
    {
        return _dictionary.GetEnumerator();
    }

    /// <inheritdoc/>
    public bool Remove(K key)
    {
        return _mutableDictionary.Remove(key);
    }

    /// <inheritdoc/>
    public bool Remove(KeyValuePair<K, V> item)
    {
        return _mutableDictionary.Remove(item.Key);
    }

    /// <inheritdoc/>
    public bool TryGetValue(K key,
#if NET
        [MaybeNullWhen(false)]
#endif

        out V value)
    {
        return _dictionary.TryGetValue(key, out value);
    }

    /// <inheritdoc/>
    Collections::IEnumerator Collections::IEnumerable.GetEnumerator()
    {
        return _dictionary.GetEnumerator();
    }
}
