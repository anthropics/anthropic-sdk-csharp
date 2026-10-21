using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamInputTest : TestBase
{
    [Fact]
    public void MemoryStoreValidationWorks()
    {
        BetaDreamInput value = new BetaDreamMemoryStoreInput("x");
        value.Validate();
    }

    [Fact]
    public void SessionsValidationWorks()
    {
        BetaDreamInput value = new BetaDreamSessionsInput(["string"]);
        value.Validate();
    }

    [Fact]
    public void MemoryStoreSerializationRoundtripWorks()
    {
        BetaDreamInput value = new BetaDreamMemoryStoreInput("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionsSerializationRoundtripWorks()
    {
        BetaDreamInput value = new BetaDreamSessionsInput(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MemoryStoreTypeWorks()
    {
        BetaDreamInput value = new BetaDreamMemoryStoreInput("x");
        Assert.Equal(BetaDreamInputType.MemoryStore, value.Type.Value());
    }

    [Fact]
    public void SessionsTypeWorks()
    {
        BetaDreamInput value = new BetaDreamSessionsInput(["string"]);
        Assert.Equal(BetaDreamInputType.Sessions, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaDreamInput value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "memory_store"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaDreamInputType> expectedType = BetaDreamInputType.MemoryStore;

        Assert.Equal(expectedType, value.Type);

        BetaDreamInput emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaDreamInputTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaDreamInputType.MemoryStore)]
    [InlineData(BetaDreamInputType.Sessions)]
    public void Validation_Works(BetaDreamInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaDreamInputType.MemoryStore)]
    [InlineData(BetaDreamInputType.Sessions)]
    public void SerializationRoundtrip_Works(BetaDreamInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
