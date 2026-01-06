using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class DocumentBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DocumentBlockParam
        {
            Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };

        Source expectedSource = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"document\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        CitationsConfigParam expectedCitations = new() { Enabled = true };
        string expectedContext = "x";
        string expectedTitle = "x";

        Assert.Equal(expectedSource, model.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCitations, model.Citations);
        Assert.Equal(expectedContext, model.Context);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DocumentBlockParam
        {
            Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DocumentBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DocumentBlockParam
        {
            Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DocumentBlockParam>(element);
        Assert.NotNull(deserialized);

        Source expectedSource = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"document\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        CitationsConfigParam expectedCitations = new() { Enabled = true };
        string expectedContext = "x";
        string expectedTitle = "x";

        Assert.Equal(expectedSource, deserialized.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedCitations, deserialized.Citations);
        Assert.Equal(expectedContext, deserialized.Context);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DocumentBlockParam
        {
            Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DocumentBlockParam { Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz") };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DocumentBlockParam { Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz") };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DocumentBlockParam
        {
            Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"),

            CacheControl = null,
            Citations = null,
            Context = null,
            Title = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Citations);
        Assert.True(model.RawData.ContainsKey("citations"));
        Assert.Null(model.Context);
        Assert.True(model.RawData.ContainsKey("context"));
        Assert.Null(model.Title);
        Assert.True(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DocumentBlockParam
        {
            Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"),

            CacheControl = null,
            Citations = null,
            Context = null,
            Title = null,
        };

        model.Validate();
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void Base64PDFValidationWorks()
    {
        Source value = new(new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"));
        value.Validate();
    }

    [Fact]
    public void PlainTextValidationWorks()
    {
        Source value = new(new PlainTextSource("data"));
        value.Validate();
    }

    [Fact]
    public void ContentBlockValidationWorks()
    {
        Source value = new(new ContentBlockSource(new Content("string")));
        value.Validate();
    }

    [Fact]
    public void URLPDFValidationWorks()
    {
        Source value = new(new URLPDFSource("url"));
        value.Validate();
    }

    [Fact]
    public void Base64PDFSerializationRoundtripWorks()
    {
        Source value = new(new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Source>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PlainTextSerializationRoundtripWorks()
    {
        Source value = new(new PlainTextSource("data"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Source>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockSerializationRoundtripWorks()
    {
        Source value = new(new ContentBlockSource(new Content("string")));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Source>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void URLPDFSerializationRoundtripWorks()
    {
        Source value = new(new URLPDFSource("url"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Source>(element);

        Assert.Equal(value, deserialized);
    }
}
