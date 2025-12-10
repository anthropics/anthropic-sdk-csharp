using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestDocumentBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestDocumentBlock
        {
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };

        BetaRequestDocumentBlockSource expectedSource = new BetaBase64PDFSource(
            "U3RhaW5sZXNzIHJvY2tz"
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"document\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        BetaCitationsConfigParam expectedCitations = new() { Enabled = true };
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
        var model = new BetaRequestDocumentBlock
        {
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRequestDocumentBlock
        {
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlock>(json);
        Assert.NotNull(deserialized);

        BetaRequestDocumentBlockSource expectedSource = new BetaBase64PDFSource(
            "U3RhaW5sZXNzIHJvY2tz"
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"document\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        BetaCitationsConfigParam expectedCitations = new() { Enabled = true };
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
        var model = new BetaRequestDocumentBlock
        {
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
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
        var model = new BetaRequestDocumentBlock
        {
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
        };

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
        var model = new BetaRequestDocumentBlock
        {
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaRequestDocumentBlock
        {
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),

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
        var model = new BetaRequestDocumentBlock
        {
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),

            CacheControl = null,
            Citations = null,
            Context = null,
            Title = null,
        };

        model.Validate();
    }
}

public class BetaRequestDocumentBlockSourceTest : TestBase
{
    [Fact]
    public void beta_base64_pdfValidation_Works()
    {
        BetaRequestDocumentBlockSource value = new(new("U3RhaW5sZXNzIHJvY2tz"));
        value.Validate();
    }

    [Fact]
    public void beta_plain_textValidation_Works()
    {
        BetaRequestDocumentBlockSource value = new(new("data"));
        value.Validate();
    }

    [Fact]
    public void beta_content_blockValidation_Works()
    {
        BetaRequestDocumentBlockSource value = new(
            new(new BetaContentBlockSourceContent("string"))
        );
        value.Validate();
    }

    [Fact]
    public void beta_url_pdfValidation_Works()
    {
        BetaRequestDocumentBlockSource value = new(new("url"));
        value.Validate();
    }

    [Fact]
    public void beta_file_documentValidation_Works()
    {
        BetaRequestDocumentBlockSource value = new(new("file_id"));
        value.Validate();
    }

    [Fact]
    public void beta_base64_pdfSerializationRoundtrip_Works()
    {
        BetaRequestDocumentBlockSource value = new(new("U3RhaW5sZXNzIHJvY2tz"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlockSource>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_plain_textSerializationRoundtrip_Works()
    {
        BetaRequestDocumentBlockSource value = new(new("data"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlockSource>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_content_blockSerializationRoundtrip_Works()
    {
        BetaRequestDocumentBlockSource value = new(
            new(new BetaContentBlockSourceContent("string"))
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlockSource>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_url_pdfSerializationRoundtrip_Works()
    {
        BetaRequestDocumentBlockSource value = new(new("url"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlockSource>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_file_documentSerializationRoundtrip_Works()
    {
        BetaRequestDocumentBlockSource value = new(new("file_id"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlockSource>(json);

        Assert.Equal(value, deserialized);
    }
}
