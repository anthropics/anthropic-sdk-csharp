using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace Anthropic.Core;

/// <summary>
/// A <see cref="JsonElement"/> that can contain <see cref="BinaryContent"/>.
///
/// <para>Use <see cref="MultipartJsonSerializer"/> to construct or read instances of this class.</para>
/// </summary>
public readonly struct MultipartJsonElement()
{
    /// <summary>
    /// A <see cref="JsonElement"/> with <see cref="BinaryContents">placeholders</see>
    /// for <see cref="BinaryContent"/>.
    /// </summary>
    internal JsonElement Json { get; init; }

    /// <summary>
    /// A dictionary from placeholder string in <see cref="Json">the JSON</see> to
    /// <see cref="BinaryContent"/>.
    /// </summary>
    internal IReadOnlyDictionary<Guid, BinaryContent> BinaryContents { get; init; } =
        FrozenDictionary.ToFrozenDictionary(new Dictionary<Guid, BinaryContent>());

    public static implicit operator MultipartJsonElement(JsonElement json) => new() { Json = json };

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this),
            ModelBase.ToStringSerializerOptions
        );

    public static bool DeepEquals(MultipartJsonElement a, MultipartJsonElement b) =>
        MultipartJsonElement.DeepEqualsInner(a.Json, a.BinaryContents, b.Json, b.BinaryContents);

    static bool DeepEqualsInner(
        JsonElement jsonA,
        IReadOnlyDictionary<Guid, BinaryContent> binaryA,
        JsonElement jsonB,
        IReadOnlyDictionary<Guid, BinaryContent> binaryB
    )
    {
        if (jsonA.ValueKind != jsonB.ValueKind)
        {
            return false;
        }

        switch (jsonA.ValueKind)
        {
            case JsonValueKind.Undefined:
            case JsonValueKind.Null:
            case JsonValueKind.True:
            case JsonValueKind.False:
                return true;
            case JsonValueKind.Number:
                return JsonElement.DeepEquals(jsonA, jsonB);
            case JsonValueKind.String:
                BinaryContent? aContent = null;

                BinaryContent? bContent = null;

                if (jsonA.TryGetGuid(out var guidA) && binaryA.TryGetValue(guidA, out var a))
                {
                    aContent = a;
                }

                if (jsonB.TryGetGuid(out var guidB) && binaryB.TryGetValue(guidB, out var b))
                {
                    bContent = b;
                }

                if (aContent != null && bContent != null)
                {
                    return aContent == bContent;
                }
                else if (aContent == null && bContent == null)
                {
                    return jsonA.GetString() == jsonB.GetString();
                }
                else
                {
                    return false;
                }
            case JsonValueKind.Object:
                Dictionary<string, JsonElement> propertiesA = new();

                foreach (var item1 in jsonA.EnumerateObject())
                {
                    propertiesA[item1.Name] = item1.Value;
                }

                Dictionary<string, JsonElement> propertiesB = new();

                foreach (var item1 in jsonB.EnumerateObject())
                {
                    propertiesB[item1.Name] = item1.Value;
                }

                if (propertiesA.Count != propertiesB.Count)
                {
                    return false;
                }

                foreach (var property in propertiesA)
                {
                    if (!propertiesB.TryGetValue(property.Key, out var b1))
                    {
                        return false;
                    }

                    if (!MultipartJsonElement.DeepEqualsInner(property.Value, binaryA, b1, binaryB))
                    {
                        return false;
                    }
                }

                return true;
            case JsonValueKind.Array:
                if (jsonA.GetArrayLength() != jsonB.GetArrayLength())
                {
                    return false;
                }

                var i = 0;
                foreach (var item in jsonA.EnumerateArray())
                {
                    if (!MultipartJsonElement.DeepEqualsInner(item, binaryA, jsonB[i], binaryB))
                    {
                        return false;
                    }

                    i++;
                }

                return true;
            default:
                throw new InvalidOperationException("Unreachable");
        }
    }
}

/// <summary>
/// A serializer for mixed JSON and binary content.
/// </summary>
public static class MultipartJsonSerializer
{
    /// <summary>
    /// The current dictionary from placeholder string to <see cref="BinaryContent"/> to use for
    /// serialization/deserialization.
    ///
    /// <para>This isn't a local variable because we want to share <see cref="JsonSerializerOptions"/>
    /// for performance. It's also a thread local to avoid data races between threads.</para>
    /// </summary>
    static readonly ThreadLocal<Dictionary<Guid, BinaryContent>?> CurrentBinaryContents = new(() =>
        null
    );

    internal static Dictionary<Guid, BinaryContent> BinaryContents
    {
        get
        {
            return CurrentBinaryContents.Value
                ?? throw new InvalidOperationException(
                    "Cannot convert BinaryContent without MultipartJsonSerializer"
                );
        }
    }

    static readonly ThreadLocal<
        Dictionary<JsonSerializerOptions, JsonSerializerOptions>
    > MultipartSerializerOptionsCache = new(() => []);

    static readonly JsonSerializerOptions DefaultMultipartSerializerOptions =
        MultipartSerializerOptions(new());

    static JsonSerializerOptions MultipartSerializerOptions(JsonSerializerOptions? options = null)
    {
        if (options == null)
        {
            return DefaultMultipartSerializerOptions;
        }

        if (!MultipartSerializerOptionsCache.Value!.TryGetValue(options, out var multipartOptions))
        {
            multipartOptions = new(options);
            multipartOptions.Converters.Add(new BinaryContentConverter());
            multipartOptions.Converters.Add(new MultipartJsonElementConverter());
            MultipartSerializerOptionsCache.Value![options] = multipartOptions;
        }

        return multipartOptions;
    }

    public static MultipartJsonElement SerializeToElement<T>(
        T value,
        JsonSerializerOptions? options = null
    )
    {
        var previousBinaryContents = CurrentBinaryContents.Value;
        try
        {
            CurrentBinaryContents.Value = [];
            var element = JsonSerializer.SerializeToElement(
                value,
                MultipartSerializerOptions(options)
            );
            return new()
            {
                Json = element,
                BinaryContents = FrozenDictionary.ToFrozenDictionary(CurrentBinaryContents.Value!),
            };
        }
        finally
        {
            CurrentBinaryContents.Value = previousBinaryContents;
        }
    }

    public static T? Deserialize<T>(
        MultipartJsonElement element,
        JsonSerializerOptions? options = null
    )
    {
        var previousBinaryContents = CurrentBinaryContents.Value;
        try
        {
            CurrentBinaryContents.Value = Enumerable.ToDictionary(
                element.BinaryContents,
                (e) => e.Key,
                (e) => e.Value
            );
            return JsonSerializer.Deserialize<T>(element.Json, MultipartSerializerOptions(options));
        }
        finally
        {
            CurrentBinaryContents.Value = previousBinaryContents;
        }
    }

    public static MultipartFormDataContent Serialize<T>(
        T value,
        JsonSerializerOptions? options = null
    )
    {
        MultipartFormDataContent formDataContent = [];
        var multipartElement = MultipartJsonSerializer.SerializeToElement(value, options);
        void SerializeParts(string name, JsonElement element)
        {
            HttpContent? content;
            string? fileName = null;
            switch (element.ValueKind)
            {
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    return;
                case JsonValueKind.Number:
                    content = new StringContent(element.ToString());
                    break;
                case JsonValueKind.String:
                    if (
                        element.TryGetGuid(out var guid)
                        && multipartElement.BinaryContents.TryGetValue(guid, out var binaryContent)
                    )
                    {
                        content = new StreamContent(binaryContent.Stream);
                        content.Headers.ContentType = binaryContent.ContentType;
                        fileName = binaryContent.FileName;
                    }
                    else
                    {
                        content = new StringContent(element.ToString());
                    }
                    break;
                case JsonValueKind.True:
                    content = new StringContent("true");
                    break;
                case JsonValueKind.False:
                    content = new StringContent("false");
                    break;
                case JsonValueKind.Object:
                    foreach (var item in element.EnumerateObject())
                    {
                        SerializeParts(
                            name == "" ? item.Name : string.Format("{0}[{1}]", name, item.Name),
                            item.Value
                        );
                    }
                    return;
                case JsonValueKind.Array:
                    var items = new List<string>();
                    foreach (var arrayItem in element.EnumerateArray())
                    {
                        switch (arrayItem.ValueKind)
                        {
                            case JsonValueKind.Undefined:
                            case JsonValueKind.Null:
                                items.Add("");
                                break;
                            case JsonValueKind.True:
                                items.Add("true");
                                break;
                            case JsonValueKind.False:
                                items.Add("false");
                                break;
                            case JsonValueKind.String:
                                if (
                                    arrayItem.TryGetGuid(out var itemGuid)
                                    && multipartElement.BinaryContents.TryGetValue(
                                        itemGuid,
                                        out var itemBinaryContent
                                    )
                                )
                                {
                                    var itemContent = new StreamContent(itemBinaryContent.Stream);
                                    itemContent.Headers.ContentType = itemBinaryContent.ContentType;
                                    var itemFileName = itemBinaryContent.FileName;
                                    if (name == "")
                                    {
                                        formDataContent.Add(itemContent);
                                    }
                                    else if (itemFileName == null)
                                    {
                                        formDataContent.Add(itemContent, $"{name}[]");
                                    }
                                    else
                                    {
                                        formDataContent.Add(itemContent, $"{name}[]", itemFileName);
                                    }
                                }
                                else
                                {
                                    items.Add(arrayItem.ToString());
                                }
                                break;
                            default:
                                throw new InvalidDataException("Unexpected element type in array");
                        }
                    }

                    if (items.Count > 0)
                    {
                        content = new StringContent(string.Join(",", items));
                    }
                    else
                    {
                        content = null;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(element));
            }

            if (content != null)
            {
                if (name == "")
                {
                    formDataContent.Add(content);
                }
                else if (fileName == null)
                {
                    formDataContent.Add(content, name);
                }
                else
                {
                    formDataContent.Add(content, name, fileName);
                }
            }
        }
        SerializeParts("", multipartElement.Json);
        return formDataContent;
    }
}

/// <summary>
/// A JSON converter that serializes/deserializes mixed JSON and binary content.
///
/// <para>It uses placeholder IDs (see <see cref="BinaryContentConverter"/>), which are written/read
/// to/from a thread-local dictionary, so it's expected that this converter is only invoked via
/// <see cref="MultipartJsonSerializer"/>, which ensures the dictionary is set up correctly.</para>
/// </summary>
sealed class MultipartJsonElementConverter : JsonConverter<MultipartJsonElement>
{
    public override MultipartJsonElement Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    ) =>
        new()
        {
            Json = JsonSerializer.Deserialize<JsonElement>(ref reader, options),
            BinaryContents = MultipartJsonSerializer.BinaryContents,
        };

    public override void Write(
        Utf8JsonWriter writer,
        MultipartJsonElement value,
        JsonSerializerOptions options
    )
    {
        foreach (var item in value.BinaryContents)
        {
            MultipartJsonSerializer.BinaryContents.Add(item.Key, item.Value);
        }
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// A JSON converter that serializes/deserializes binary content to/from placeholder IDs.
///
/// <para>The placeholder IDs are written/read to/from a thread-local dictionary, so it's expected that
/// this converter is only invoked via <see cref="MultipartJsonSerializer"/>, which ensures the
/// dictionary is set up correctly.</para>
/// </summary>
sealed class BinaryContentConverter : JsonConverter<BinaryContent>
{
    public override BinaryContent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    ) =>
        MultipartJsonSerializer.BinaryContents[
            JsonSerializer.Deserialize<Guid>(ref reader, options)
        ];

    public override void Write(
        Utf8JsonWriter writer,
        BinaryContent value,
        JsonSerializerOptions options
    )
    {
        var guid = Guid.NewGuid();
        MultipartJsonSerializer.BinaryContents[guid] = value;
        JsonSerializer.Serialize(writer, guid, options);
    }
}
