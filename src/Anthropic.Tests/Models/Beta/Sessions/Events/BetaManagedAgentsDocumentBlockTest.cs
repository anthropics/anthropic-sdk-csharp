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
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
            Context = "context",
            Title = "title",
        };

        Source expectedSource = new BetaManagedAgentsBase64DocumentSource()
        {
            Data = "x",
            MediaType = "x",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("document");
        string expectedContext = "context";
        string expectedTitle = "title";

        Assert.Equal(expectedSource, model.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedContext, model.Context);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
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
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
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
            Data = "x",
            MediaType = "x",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("document");
        string expectedContext = "context";
        string expectedTitle = "title";

        Assert.Equal(expectedSource, deserialized.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedContext, deserialized.Context);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
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
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
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
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsDocumentBlock
        {
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },

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
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },

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
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
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
        Source value = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsPlainTextDocumentValidationWorks()
    {
        Source value = new BetaManagedAgentsPlainTextDocumentSource("x");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUrlDocumentValidationWorks()
    {
        Source value = new BetaManagedAgentsUrlDocumentSource("x");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileDocumentValidationWorks()
    {
        Source value = new BetaManagedAgentsFileDocumentSource("x");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsBase64DocumentSerializationRoundtripWorks()
    {
        Source value = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsPlainTextDocumentSerializationRoundtripWorks()
    {
        Source value = new BetaManagedAgentsPlainTextDocumentSource("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUrlDocumentSerializationRoundtripWorks()
    {
        Source value = new BetaManagedAgentsUrlDocumentSource("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsFileDocumentSerializationRoundtripWorks()
    {
        Source value = new BetaManagedAgentsFileDocumentSource("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsBase64DocumentTypeWorks()
    {
        Source value = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" };
        Assert.Equal(SourceType.Base64, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsPlainTextDocumentTypeWorks()
    {
        Source value = new BetaManagedAgentsPlainTextDocumentSource("x");
        Assert.Equal(SourceType.Text, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsUrlDocumentTypeWorks()
    {
        Source value = new BetaManagedAgentsUrlDocumentSource("x");
        Assert.Equal(SourceType.Url, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsFileDocumentTypeWorks()
    {
        Source value = new BetaManagedAgentsFileDocumentSource("x");
        Assert.Equal(SourceType.File, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Source value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "data": "x",
                  "type": "base64"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedData = "x";
        ApiEnum<string, SourceType> expectedType = SourceType.Base64;

        Assert.Equal(expectedData, value.Data);
        Assert.Equal(expectedType, value.Type);

        Source emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.Data);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        Source mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "data": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.Data);
    }
}

public class SourceTypeTest : TestBase
{
    [Theory]
    [InlineData(SourceType.Base64)]
    [InlineData(SourceType.Text)]
    [InlineData(SourceType.Url)]
    [InlineData(SourceType.File)]
    public void Validation_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SourceType.Base64)]
    [InlineData(SourceType.Text)]
    [InlineData(SourceType.Url)]
    [InlineData(SourceType.File)]
    public void SerializationRoundtrip_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
