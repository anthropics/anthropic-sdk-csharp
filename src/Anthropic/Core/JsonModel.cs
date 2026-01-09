using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Exceptions;

namespace Anthropic.Core;

/// <summary>
/// The base class for all API objects that are serialized as JSON objects.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class JsonModel : ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    protected JsonModel(JsonModel jsonModel)
        : base(jsonModel)
    {
        this._rawData = [.. jsonModel._rawData];
    }

    /// <summary>
    /// The backing JSON properties of the instance.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    internal static void Set<T>(IDictionary<string, JsonElement> dictionary, string key, T value)
    {
        dictionary[key] = JsonSerializer.SerializeToElement(value, SerializerOptions);
    }

    internal static T GetNotNullClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out var element))
        {
            throw new AnthropicInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T>(element, SerializerOptions)
                ?? throw new AnthropicInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T GetNotNullStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out var element))
        {
            throw new AnthropicInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions)
                ?? throw new AnthropicInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out var element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out var element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    public sealed override string ToString() =>
        JsonSerializer.Serialize(this.RawData, ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(JsonModel? other)
    {
        if (other == null || this.RawData.Count != other.RawData.Count)
        {
            return false;
        }

        foreach (var item in this.RawData)
        {
            if (!other.RawData.TryGetValue(item.Key, out var otherValue))
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

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
///
/// <para>NOTE: This interface is in the style of a factory instance instead of using
/// abstract static methods because .NET Standard 2.0 doesn't support abstract static methods.</para>
/// </summary>
interface IFromRawJson<T>
{
    /// <summary>
    /// Returns an instance constructed from the given raw JSON properties.
    ///
    /// <para>Required field and type mismatches are not checked. In these cases accessing
    /// the relevant properties of the constructed instance may throw.</para>
    ///
    /// <para>This method is useful for constructing an instance from already serialized
    /// data or for sending arbitrary data to the API (e.g. for undocumented or not
    /// yet supported properties or values).</para>
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
