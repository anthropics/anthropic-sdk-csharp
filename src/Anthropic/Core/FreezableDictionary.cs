using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Collections = System.Collections;

namespace Anthropic.Core;

/// <summary>
/// A dictionary that can be mutated and then frozen once no more mutations are expected.<br
/// /><br />
///
/// <para>This is useful for allowing a dictionary to be modified by a class's `init`
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
        _dictionary = new Dictionary<K, V>(dictionary);
    }

    public FreezableDictionary(FrozenDictionary<K, V> frozen)
    {
        _dictionary = frozen;
    }

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

    public V this[K key]
    {
        get => _dictionary[key];
        set => _mutableDictionary[key] = value;
    }

    public ICollection<K> Keys
    {
        get { return _dictionary.Keys; }
    }

    public ICollection<V> Values
    {
        get { return _dictionary.Values; }
    }

    public int Count
    {
        get { return _dictionary.Count; }
    }

    public bool IsReadOnly
    {
        get { return _dictionary.IsReadOnly; }
    }

    public void Add(K key, V value)
    {
        _mutableDictionary.Add(key, value);
    }

    public void Add(KeyValuePair<K, V> item)
    {
        _mutableDictionary.Add(item.Key, item.Value);
    }

    public void Clear()
    {
        _mutableDictionary.Clear();
    }

    public bool Contains(KeyValuePair<K, V> item)
    {
        return _dictionary.Contains(item);
    }

    public bool ContainsKey(K key)
    {
        return _dictionary.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
    {
        _dictionary.CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
    {
        return _dictionary.GetEnumerator();
    }

    public bool Remove(K key)
    {
        return _mutableDictionary.Remove(key);
    }

    public bool Remove(KeyValuePair<K, V> item)
    {
        return _mutableDictionary.Remove(item.Key);
    }

    public bool TryGetValue(K key, [MaybeNullWhenAttribute(false)] out V value)
    {
        return _dictionary.TryGetValue(key, out value);
    }

    Collections::IEnumerator Collections::IEnumerable.GetEnumerator()
    {
        return _dictionary.GetEnumerator();
    }
}
