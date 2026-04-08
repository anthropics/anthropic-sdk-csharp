using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsPlainTextDocumentSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsPlainTextDocumentSource
        {
            Data = "data",
            MediaType = MediaType.TextPlain,
            Type = BetaManagedAgentsPlainTextDocumentSourceType.Text,
        };

        string expectedData = "data";
        ApiEnum<string, MediaType> expectedMediaType = MediaType.TextPlain;
        ApiEnum<string, BetaManagedAgentsPlainTextDocumentSourceType> expectedType =
            BetaManagedAgentsPlainTextDocumentSourceType.Text;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsPlainTextDocumentSource
        {
            Data = "data",
            MediaType = MediaType.TextPlain,
            Type = BetaManagedAgentsPlainTextDocumentSourceType.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsPlainTextDocumentSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsPlainTextDocumentSource
        {
            Data = "data",
            MediaType = MediaType.TextPlain,
            Type = BetaManagedAgentsPlainTextDocumentSourceType.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsPlainTextDocumentSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedData = "data";
        ApiEnum<string, MediaType> expectedMediaType = MediaType.TextPlain;
        ApiEnum<string, BetaManagedAgentsPlainTextDocumentSourceType> expectedType =
            BetaManagedAgentsPlainTextDocumentSourceType.Text;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsPlainTextDocumentSource
        {
            Data = "data",
            MediaType = MediaType.TextPlain,
            Type = BetaManagedAgentsPlainTextDocumentSourceType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsPlainTextDocumentSource
        {
            Data = "data",
            MediaType = MediaType.TextPlain,
            Type = BetaManagedAgentsPlainTextDocumentSourceType.Text,
        };

        BetaManagedAgentsPlainTextDocumentSource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MediaTypeTest : TestBase
{
    [Theory]
    [InlineData(MediaType.TextPlain)]
    public void Validation_Works(MediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MediaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MediaType.TextPlain)]
    public void SerializationRoundtrip_Works(MediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MediaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsPlainTextDocumentSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsPlainTextDocumentSourceType.Text)]
    public void Validation_Works(BetaManagedAgentsPlainTextDocumentSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsPlainTextDocumentSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsPlainTextDocumentSourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsPlainTextDocumentSourceType.Text)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsPlainTextDocumentSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsPlainTextDocumentSourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsPlainTextDocumentSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsPlainTextDocumentSourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsPlainTextDocumentSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
