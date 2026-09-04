using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaDocumentBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDocumentBlock
        {
            Citations = new(true),
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        BetaCitationConfig expectedCitations = new(true);
        Source expectedSource = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz");
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.SerializeToElement("document");

        Assert.Equal(expectedCitations, model.Citations);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDocumentBlock
        {
            Citations = new(true),
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDocumentBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDocumentBlock
        {
            Citations = new(true),
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDocumentBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCitationConfig expectedCitations = new(true);
        Source expectedSource = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz");
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.SerializeToElement("document");

        Assert.Equal(expectedCitations, deserialized.Citations);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDocumentBlock
        {
            Citations = new(true),
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDocumentBlock
        {
            Citations = new(true),
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        BetaDocumentBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void BetaBase64PdfValidationWorks()
    {
        Source value = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz");
        value.Validate();
    }

    [Fact]
    public void BetaPlainTextValidationWorks()
    {
        Source value = new BetaPlainTextSource("data");
        value.Validate();
    }

    [Fact]
    public void BetaBase64PdfSerializationRoundtripWorks()
    {
        Source value = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPlainTextSerializationRoundtripWorks()
    {
        Source value = new BetaPlainTextSource("data");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Source value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "data": "U3RhaW5sZXNzIHJvY2tz",
                  "media_type": "application/pdf",
                  "type": "base64"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        JsonElement expectedMediaType = JsonSerializer.SerializeToElement("application/pdf");
        JsonElement expectedType = JsonSerializer.SerializeToElement("base64");

        Assert.Equal(expectedData, value.Data);
        Assert.True(JsonElement.DeepEquals(expectedMediaType, value.MediaType));
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        Source emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Data);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.MediaType);
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

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.Data);
    }
}
