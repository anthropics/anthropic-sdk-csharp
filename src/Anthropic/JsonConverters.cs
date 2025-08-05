using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic;

sealed class ModelConverter<TModel> : JsonConverter<TModel>
    where TModel : ModelBase, IFromRaw<TModel>
{
    public override TModel? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        Dictionary<string, JsonElement>? properties = JsonSerializer.Deserialize<
            Dictionary<string, JsonElement>
        >(ref reader, options);
        if (properties == null)
            return null;

        return TModel.FromRawUnchecked(properties);
    }

    public override void Write(Utf8JsonWriter writer, TModel value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Properties, options);
    }
}

sealed class EnumConverter<TEnum, TValue> : JsonConverter<TEnum>
    where TEnum : IEnum<TEnum, TValue>
{
    public override TEnum Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        return TEnum.FromRaw(JsonSerializer.Deserialize<TValue>(ref reader, options)!);
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Raw(), options);
    }
}

sealed class UnionConverter<T> : JsonConverter<T>
    where T : class
{
    readonly List<global::System.Type> _variantTypes = Enumerable.ToList(
        Enumerable.Where(
            Assembly.GetExecutingAssembly().GetTypes(),
            type => type.BaseType == typeof(T)
        )
    );

    public override T? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];
        foreach (var variantType in _variantTypes)
        {
            try
            {
                return JsonSerializer.Deserialize(ref reader, variantType, options) as T;
            }
            catch (JsonException e)
            {
                exceptions.Add(e);
            }
        }
        throw new global::System.AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var variantType =
            _variantTypes.Find(type => type == value.GetType())
            ?? throw new global::System.ArgumentOutOfRangeException(value.GetType().Name);
        JsonSerializer.Serialize(writer, value, variantType, options);
    }
}

sealed class VariantConverter<TVariant, TValue> : JsonConverter<TVariant>
    where TVariant : IVariant<TVariant, TValue>
{
    public override TVariant Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        return TVariant.From(JsonSerializer.Deserialize<TValue>(ref reader, options)!);
    }

    public override void Write(Utf8JsonWriter writer, TVariant value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Value, options);
    }
}
