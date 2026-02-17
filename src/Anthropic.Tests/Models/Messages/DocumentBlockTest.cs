using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class DocumentBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DocumentBlock
        {
            Citations = new(true),
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        CitationsConfig expectedCitations = new(true);
        Source expectedSource = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz");
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
        var model = new DocumentBlock
        {
            Citations = new(true),
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DocumentBlock
        {
            Citations = new(true),
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CitationsConfig expectedCitations = new(true);
        Source expectedSource = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz");
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
        var model = new DocumentBlock
        {
            Citations = new(true),
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DocumentBlock
        {
            Citations = new(true),
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };

        DocumentBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void Base64PdfValidationWorks()
    {
        Source value = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz");
        value.Validate();
    }

    [Fact]
    public void PlainTextValidationWorks()
    {
        Source value = new PlainTextSource("data");
        value.Validate();
    }

    [Fact]
    public void Base64PdfSerializationRoundtripWorks()
    {
        Source value = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PlainTextSerializationRoundtripWorks()
    {
        Source value = new PlainTextSource("data");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
