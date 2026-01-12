using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Exceptions;

namespace Anthropic.Core;

/// <summary>
/// The base class for all API objects that are serialized as a mix of JSON objects
/// and binary content.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class MultipartJsonModel : ModelBase
{
    private protected FreezableDictionary<string, MultipartJsonElement> _rawData = [];

    protected MultipartJsonModel(MultipartJsonModel jsonModel)
        : base(jsonModel)
    {
        this._rawData = [.. jsonModel._rawData];
    }

    /// <summary>
    /// The backing mix of JSON and binary content properties of the instance.
    /// </summary>
    public IReadOnlyDictionary<string, MultipartJsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    internal static void Set<T>(
        IDictionary<string, MultipartJsonElement> dictionary,
        string key,
        T value
    )
    {
        dictionary[key] = MultipartJsonSerializer.SerializeToElement(
            value,
            ModelBase.SerializerOptions
        );
    }

    internal static T GetNotNullClass<T>(
        IReadOnlyDictionary<string, MultipartJsonElement> dictionary,
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
            return MultipartJsonSerializer.Deserialize<T>(element)
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
        IReadOnlyDictionary<string, MultipartJsonElement> dictionary,
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
            return MultipartJsonSerializer.Deserialize<T?>(element)
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
        IReadOnlyDictionary<string, MultipartJsonElement> dictionary,
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
            return MultipartJsonSerializer.Deserialize<T?>(element);
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
        IReadOnlyDictionary<string, MultipartJsonElement> dictionary,
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
            return MultipartJsonSerializer.Deserialize<T?>(element);
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
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
interface IFromRawMultipartJson<T>
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
    T FromRawUnchecked(IReadOnlyDictionary<string, MultipartJsonElement> rawData);
}
