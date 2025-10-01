using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Core;

public record struct ApiEnum<TRaw, TEnum>(JsonElement Json)
    where TEnum : struct, Enum
{
    public readonly TRaw Raw() =>
        JsonSerializer.Deserialize<TRaw>(this.Json, ModelBase.SerializerOptions)
        ?? throw new AnthropicInvalidDataException(
            string.Format("{0} cannot be null", nameof(this.Json))
        );

    public readonly TEnum Value() =>
        JsonSerializer.Deserialize<TEnum>(this.Json, ModelBase.SerializerOptions);

    public readonly void Validate()
    {
        if (!Enum.IsDefined(Value()))
        {
            throw new AnthropicInvalidDataException("Invalid enum value");
        }
    }

    public static implicit operator TRaw(ApiEnum<TRaw, TEnum> value) => value.Raw();

    public static implicit operator TEnum(ApiEnum<TRaw, TEnum> value) => value.Value();

    public static implicit operator ApiEnum<TRaw, TEnum>(TRaw value) =>
        new(JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions));

    public static implicit operator ApiEnum<TRaw, TEnum>(TEnum value) =>
        new(JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions));
}

sealed class ApiEnumConverter<TRaw, TEnum> : JsonConverter<ApiEnum<TRaw, TEnum>>
    where TEnum : struct, Enum
{
    public override ApiEnum<TRaw, TEnum> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApiEnum<TRaw, TEnum> value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
