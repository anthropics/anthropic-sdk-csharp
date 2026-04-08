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
            Source = new BetaManagedAgentsBase64ImageSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64ImageSourceType.Base64,
            },
            Type = BetaManagedAgentsImageBlockType.Image,
        };

        BetaManagedAgentsImageBlockSource expectedSource = new BetaManagedAgentsBase64ImageSource()
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64ImageSourceType.Base64,
        };
        ApiEnum<string, BetaManagedAgentsImageBlockType> expectedType =
            BetaManagedAgentsImageBlockType.Image;

        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsImageBlock
        {
            Source = new BetaManagedAgentsBase64ImageSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64ImageSourceType.Base64,
            },
            Type = BetaManagedAgentsImageBlockType.Image,
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
            Source = new BetaManagedAgentsBase64ImageSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64ImageSourceType.Base64,
            },
            Type = BetaManagedAgentsImageBlockType.Image,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsImageBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsImageBlockSource expectedSource = new BetaManagedAgentsBase64ImageSource()
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64ImageSourceType.Base64,
        };
        ApiEnum<string, BetaManagedAgentsImageBlockType> expectedType =
            BetaManagedAgentsImageBlockType.Image;

        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsImageBlock
        {
            Source = new BetaManagedAgentsBase64ImageSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64ImageSourceType.Base64,
            },
            Type = BetaManagedAgentsImageBlockType.Image,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsImageBlock
        {
            Source = new BetaManagedAgentsBase64ImageSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64ImageSourceType.Base64,
            },
            Type = BetaManagedAgentsImageBlockType.Image,
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
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64ImageSourceType.Base64,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUrlImageValidationWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsUrlImageSource()
        {
            Type = BetaManagedAgentsUrlImageSourceType.Url,
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileImageValidationWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsFileImageSource()
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileImageSourceType.File,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsBase64ImageSerializationRoundtripWorks()
    {
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsBase64ImageSource()
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64ImageSourceType.Base64,
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
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsUrlImageSource()
        {
            Type = BetaManagedAgentsUrlImageSourceType.Url,
            Url = "url",
        };
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
        BetaManagedAgentsImageBlockSource value = new BetaManagedAgentsFileImageSource()
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileImageSourceType.File,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsImageBlockSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsImageBlockTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsImageBlockType.Image)]
    public void Validation_Works(BetaManagedAgentsImageBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsImageBlockType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsImageBlockType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsImageBlockType.Image)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsImageBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsImageBlockType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsImageBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsImageBlockType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsImageBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
