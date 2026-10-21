using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsImageBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsImageBlock
        {
            Source = new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" },
        };

        BetaManagedAgentsImageBlockSource expectedSource = new BetaManagedAgentsBase64ImageSource()
        {
            Data = "x",
            MediaType = "x",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("image");

        Assert.Equal(expectedSource, model.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsImageBlock
        {
            Source = new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsImageBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsImageBlock
        {
            Source = new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsImageBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsImageBlockSource expectedSource = new BetaManagedAgentsBase64ImageSource()
        {
            Data = "x",
            MediaType = "x",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("image");

        Assert.Equal(expectedSource, deserialized.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsImageBlock
        {
            Source = new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsImageBlock
        {
            Source = new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" },
        };

        BetaManagedAgentsImageBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsImageBlockSourceTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsBase64ImageValidationWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsBase64ImageSource()
        {
            Data = "x",
            MediaType = "x",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUrlImageValidationWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsUrlImageSource("x");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileImageValidationWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsFileImageSource("x");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsBase64ImageSerializationRoundtripWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsBase64ImageSource()
        {
            Data = "x",
            MediaType = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsImageBlockSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUrlImageSerializationRoundtripWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsUrlImageSource("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsImageBlockSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsFileImageSerializationRoundtripWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsFileImageSource("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsImageBlockSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsBase64ImageTypeWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsBase64ImageSource()
        {
            Data = "x",
            MediaType = "x",
        };
        Assert.Equal(BetaManagedAgentsImageBlockSourceType.Base64, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsUrlImageTypeWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsUrlImageSource("x");
        Assert.Equal(BetaManagedAgentsImageBlockSourceType.Url, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsFileImageTypeWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsFileImageSource("x");
        Assert.Equal(BetaManagedAgentsImageBlockSourceType.File, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsImageBlockSource value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "base64"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsImageBlockSourceType> expectedType =
            BetaManagedAgentsImageBlockSourceType.Base64;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsImageBlockSource emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsImageBlockSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsImageBlockSourceType.Base64)]
    [InlineData(BetaManagedAgentsImageBlockSourceType.Url)]
    [InlineData(BetaManagedAgentsImageBlockSourceType.File)]
    public void Validation_Works(BetaManagedAgentsImageBlockSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsImageBlockSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsImageBlockSourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsImageBlockSourceType.Base64)]
    [InlineData(BetaManagedAgentsImageBlockSourceType.Url)]
    [InlineData(BetaManagedAgentsImageBlockSourceType.File)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsImageBlockSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsImageBlockSourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsImageBlockSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsImageBlockSourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsImageBlockSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
