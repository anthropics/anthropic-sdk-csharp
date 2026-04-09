using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsUrlDocumentSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUrlDocumentSource
        {
            Type = BetaManagedAgentsUrlDocumentSourceType.Url,
            Url = "x",
        };

        ApiEnum<string, BetaManagedAgentsUrlDocumentSourceType> expectedType =
            BetaManagedAgentsUrlDocumentSourceType.Url;
        string expectedUrl = "x";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUrlDocumentSource
        {
            Type = BetaManagedAgentsUrlDocumentSourceType.Url,
            Url = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUrlDocumentSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUrlDocumentSource
        {
            Type = BetaManagedAgentsUrlDocumentSourceType.Url,
            Url = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUrlDocumentSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsUrlDocumentSourceType> expectedType =
            BetaManagedAgentsUrlDocumentSourceType.Url;
        string expectedUrl = "x";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUrlDocumentSource
        {
            Type = BetaManagedAgentsUrlDocumentSourceType.Url,
            Url = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUrlDocumentSource
        {
            Type = BetaManagedAgentsUrlDocumentSourceType.Url,
            Url = "x",
        };

        BetaManagedAgentsUrlDocumentSource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUrlDocumentSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUrlDocumentSourceType.Url)]
    public void Validation_Works(BetaManagedAgentsUrlDocumentSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUrlDocumentSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUrlDocumentSourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUrlDocumentSourceType.Url)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsUrlDocumentSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUrlDocumentSourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUrlDocumentSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUrlDocumentSourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUrlDocumentSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
