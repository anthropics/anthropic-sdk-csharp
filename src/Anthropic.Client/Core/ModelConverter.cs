using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Client.Core;

sealed class ModelConverter<TModel> : JsonConverter<TModel>
    where TModel : ModelBase, IFromRaw<TModel>
{
    public override TModel? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var properties = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            ref reader,
            options
        );
        if (properties == null)
            return null;

        return TModel.FromRawUnchecked(properties);
    }

    public override void Write(Utf8JsonWriter writer, TModel value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Properties, options);
    }
}
