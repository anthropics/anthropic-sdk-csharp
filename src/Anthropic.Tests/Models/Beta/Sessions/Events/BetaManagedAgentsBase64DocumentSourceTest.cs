using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsBase64DocumentSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsBase64DocumentSource
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
        };

        string expectedData = "data";
        string expectedMediaType = "media_type";
        ApiEnum<string, BetaManagedAgentsBase64DocumentSourceType> expectedType =
            BetaManagedAgentsBase64DocumentSourceType.Base64;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsBase64DocumentSource
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBase64DocumentSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsBase64DocumentSource
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBase64DocumentSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedData = "data";
        string expectedMediaType = "media_type";
        ApiEnum<string, BetaManagedAgentsBase64DocumentSourceType> expectedType =
            BetaManagedAgentsBase64DocumentSourceType.Base64;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsBase64DocumentSource
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsBase64DocumentSource
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
        };

        BetaManagedAgentsBase64DocumentSource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsBase64DocumentSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsBase64DocumentSourceType.Base64)]
    public void Validation_Works(BetaManagedAgentsBase64DocumentSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsBase64DocumentSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsBase64DocumentSourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsBase64DocumentSourceType.Base64)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsBase64DocumentSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsBase64DocumentSourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsBase64DocumentSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsBase64DocumentSourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsBase64DocumentSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
