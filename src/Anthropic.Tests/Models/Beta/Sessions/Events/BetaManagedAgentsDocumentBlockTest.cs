using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsDocumentBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = BetaManagedAgentsDocumentBlockType.Document,
            Context = "context",
            Title = "title",
        };

        Source expectedSource = new BetaManagedAgentsBase64DocumentSource()
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
        };
        ApiEnum<string, BetaManagedAgentsDocumentBlockType> expectedType =
            BetaManagedAgentsDocumentBlockType.Document;
        string expectedContext = "context";
        string expectedTitle = "title";

        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedContext, model.Context);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = BetaManagedAgentsDocumentBlockType.Document,
            Context = "context",
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDocumentBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = BetaManagedAgentsDocumentBlockType.Document,
            Context = "context",
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDocumentBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Source expectedSource = new BetaManagedAgentsBase64DocumentSource()
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
        };
        ApiEnum<string, BetaManagedAgentsDocumentBlockType> expectedType =
            BetaManagedAgentsDocumentBlockType.Document;
        string expectedContext = "context";
        string expectedTitle = "title";

        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedContext, deserialized.Context);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = BetaManagedAgentsDocumentBlockType.Document,
            Context = "context",
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = BetaManagedAgentsDocumentBlockType.Document,
        };

        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = BetaManagedAgentsDocumentBlockType.Document,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = BetaManagedAgentsDocumentBlockType.Document,

            Context = null,
            Title = null,
        };

        Assert.Null(model.Context);
        Assert.True(model.RawData.ContainsKey("context"));
        Assert.Null(model.Title);
        Assert.True(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = BetaManagedAgentsDocumentBlockType.Document,

            Context = null,
            Title = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = BetaManagedAgentsDocumentBlockType.Document,
            Context = "context",
            Title = "title",
        };

        BetaManagedAgentsDocumentBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsBase64DocumentValidationWorks()
    {
        Source value = new BetaManagedAgentsBase64DocumentSource()
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsPlainTextDocumentValidationWorks()
    {
        Source value = new BetaManagedAgentsPlainTextDocumentSource()
        {
            Data = "data",
            MediaType = MediaType.TextPlain,
            Type = BetaManagedAgentsPlainTextDocumentSourceType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUrlDocumentValidationWorks()
    {
        Source value = new BetaManagedAgentsUrlDocumentSource()
        {
            Type = BetaManagedAgentsUrlDocumentSourceType.Url,
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileDocumentValidationWorks()
    {
        Source value = new BetaManagedAgentsFileDocumentSource()
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileDocumentSourceType.File,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsBase64DocumentSerializationRoundtripWorks()
    {
        Source value = new BetaManagedAgentsBase64DocumentSource()
        {
            Data = "data",
            MediaType = "media_type",
            Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsPlainTextDocumentSerializationRoundtripWorks()
    {
        Source value = new BetaManagedAgentsPlainTextDocumentSource()
        {
            Data = "data",
            MediaType = MediaType.TextPlain,
            Type = BetaManagedAgentsPlainTextDocumentSourceType.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUrlDocumentSerializationRoundtripWorks()
    {
        Source value = new BetaManagedAgentsUrlDocumentSource()
        {
            Type = BetaManagedAgentsUrlDocumentSourceType.Url,
            Url = "url",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsFileDocumentSerializationRoundtripWorks()
    {
        Source value = new BetaManagedAgentsFileDocumentSource()
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileDocumentSourceType.File,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsDocumentBlockTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDocumentBlockType.Document)]
    public void Validation_Works(BetaManagedAgentsDocumentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDocumentBlockType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsDocumentBlockType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDocumentBlockType.Document)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsDocumentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDocumentBlockType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDocumentBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsDocumentBlockType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDocumentBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
