using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic;

public sealed class ModelConverter<MB> : JsonConverter<MB>
    where MB : ModelBase, IFromRaw<MB>
{
    public override MB? Read(
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

        return MB.FromRawUnchecked(properties);
    }

    public override void Write(Utf8JsonWriter writer, MB value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Properties, options);
    }
}

public sealed class EnumConverter<IE, T> : JsonConverter<IE>
    where IE : IEnum<IE, T>
{
    public override IE Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        return IE.FromRaw(JsonSerializer.Deserialize<T>(ref reader, options)!);
    }

    public override void Write(Utf8JsonWriter writer, IE value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Raw(), options);
    }
}

public sealed class UnionConverter<T> : JsonConverter<T>
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

public sealed class VariantConverter<IV, T> : JsonConverter<IV>
    where IV : IVariant<IV, T>
{
    public override IV Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        return IV.From(JsonSerializer.Deserialize<T>(ref reader, options)!);
    }

    public override void Write(Utf8JsonWriter writer, IV value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Value, options);
    }
}
