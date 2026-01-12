using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Core;

sealed class MultipartJsonModelConverter<TModel, TFromRaw> : JsonConverter<TModel>
    where TModel : MultipartJsonModel
    where TFromRaw : IFromRawMultipartJson<TModel>, new()
{
    public override TModel? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var rawData = JsonSerializer.Deserialize<Dictionary<string, MultipartJsonElement>>(
            ref reader,
            options
        );
        if (rawData == null)
            return null;

        return new TFromRaw().FromRawUnchecked(rawData);
    }

    public override void Write(Utf8JsonWriter writer, TModel value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.RawData, options);
    }
}
