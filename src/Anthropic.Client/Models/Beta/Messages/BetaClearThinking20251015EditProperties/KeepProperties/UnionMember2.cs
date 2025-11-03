using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaClearThinking20251015EditProperties.KeepProperties;

[JsonConverter(typeof(Converter))]
public class UnionMember2
{
    public JsonElement Json { get; private init; }

    public UnionMember2()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"all\"");
    }

    UnionMember2(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new UnionMember2().Json))
        {
            throw new AnthropicInvalidDataException("Invalid constant given for 'UnionMember2'");
        }
    }

    class Converter : JsonConverter<UnionMember2>
    {
        public override UnionMember2? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            UnionMember2 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
