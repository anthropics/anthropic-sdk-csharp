using System.Collections.Generic;
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
