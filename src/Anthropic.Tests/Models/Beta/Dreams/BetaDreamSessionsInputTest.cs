using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamSessionsInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDreamSessionsInput
        {
            SessionIds = ["string"],
            Type = BetaDreamSessionsInputType.Sessions,
        };

        List<string> expectedSessionIds = ["string"];
        ApiEnum<string, BetaDreamSessionsInputType> expectedType =
            BetaDreamSessionsInputType.Sessions;

        Assert.Equal(expectedSessionIds.Count, model.SessionIds.Count);
        for (int i = 0; i < expectedSessionIds.Count; i++)
        {
            Assert.Equal(expectedSessionIds[i], model.SessionIds[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDreamSessionsInput
        {
            SessionIds = ["string"],
            Type = BetaDreamSessionsInputType.Sessions,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamSessionsInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDreamSessionsInput
        {
            SessionIds = ["string"],
            Type = BetaDreamSessionsInputType.Sessions,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamSessionsInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedSessionIds = ["string"];
        ApiEnum<string, BetaDreamSessionsInputType> expectedType =
            BetaDreamSessionsInputType.Sessions;

        Assert.Equal(expectedSessionIds.Count, deserialized.SessionIds.Count);
        for (int i = 0; i < expectedSessionIds.Count; i++)
        {
            Assert.Equal(expectedSessionIds[i], deserialized.SessionIds[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDreamSessionsInput
        {
            SessionIds = ["string"],
            Type = BetaDreamSessionsInputType.Sessions,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDreamSessionsInput
        {
            SessionIds = ["string"],
            Type = BetaDreamSessionsInputType.Sessions,
        };

        BetaDreamSessionsInput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaDreamSessionsInputTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaDreamSessionsInputType.Sessions)]
    public void Validation_Works(BetaDreamSessionsInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamSessionsInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamSessionsInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaDreamSessionsInputType.Sessions)]
    public void SerializationRoundtrip_Works(BetaDreamSessionsInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamSessionsInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamSessionsInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamSessionsInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamSessionsInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
