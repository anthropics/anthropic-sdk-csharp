using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Core;

sealed class FrozenDictionaryConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
        {
            return false;
        }

        var genericTypeDefinition = typeToConvert.GetGenericTypeDefinition();
        return genericTypeDefinition == typeof(FrozenDictionary<,>);
    }

    public override JsonConverter? CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var keyType = typeToConvert.GetGenericArguments()[0];
        var valueType = typeToConvert.GetGenericArguments()[1];

        var converterType = typeof(FrozenDictionaryConverter<,>).MakeGenericType(
            keyType,
            valueType
        );
        return (JsonConverter?)Activator.CreateInstance(converterType);
    }
}

sealed class FrozenDictionaryConverter<TKey, TValue> : JsonConverter<FrozenDictionary<TKey, TValue>>
    where TKey : notnull
{
    public override FrozenDictionary<TKey, TValue>? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var dictionary = JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(ref reader, options);
        if (dictionary == null)
        {
            return null;
        }

        return FrozenDictionary.ToFrozenDictionary(dictionary);
    }

    public override void Write(
        Utf8JsonWriter writer,
        FrozenDictionary<TKey, TValue> value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value, typeof(IReadOnlyDictionary<TKey, TValue>), options);
    }
}
