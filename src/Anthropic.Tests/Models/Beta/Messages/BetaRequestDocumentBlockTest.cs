using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestDocumentBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestDocumentBlock
        {
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };

        BetaRequestDocumentBlockSource expectedSource = new BetaBase64PdfSource(
            "U3RhaW5sZXNzIHJvY2tz"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("document");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
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
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRequestDocumentBlock
        {
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaRequestDocumentBlockSource expectedSource = new BetaBase64PdfSource(
            "U3RhaW5sZXNzIHJvY2tz"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("document");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
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
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
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
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
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
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaRequestDocumentBlock
        {
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),

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
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),

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
    public void BetaBase64PdfValidationWorks()
    {
        BetaRequestDocumentBlockSource value = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz");
        value.Validate();
    }

    [Fact]
    public void BetaPlainTextValidationWorks()
    {
        BetaRequestDocumentBlockSource value = new BetaPlainTextSource("data");
        value.Validate();
    }

    [Fact]
    public void BetaContentBlockValidationWorks()
    {
        BetaRequestDocumentBlockSource value = new BetaContentBlockSource(
            new BetaContentBlockSourceContent("string")
        );
        value.Validate();
    }

    [Fact]
    public void BetaUrlPdfValidationWorks()
    {
        BetaRequestDocumentBlockSource value = new BetaUrlPdfSource("url");
        value.Validate();
    }

    [Fact]
    public void BetaFileDocumentValidationWorks()
    {
        BetaRequestDocumentBlockSource value = new BetaFileDocumentSource("file_id");
        value.Validate();
    }

    [Fact]
    public void BetaBase64PdfSerializationRoundtripWorks()
    {
        BetaRequestDocumentBlockSource value = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlockSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaPlainTextSerializationRoundtripWorks()
    {
        BetaRequestDocumentBlockSource value = new BetaPlainTextSource("data");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlockSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaContentBlockSerializationRoundtripWorks()
    {
        BetaRequestDocumentBlockSource value = new BetaContentBlockSource(
            new BetaContentBlockSourceContent("string")
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlockSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaUrlPdfSerializationRoundtripWorks()
    {
        BetaRequestDocumentBlockSource value = new BetaUrlPdfSource("url");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlockSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaFileDocumentSerializationRoundtripWorks()
    {
        BetaRequestDocumentBlockSource value = new BetaFileDocumentSource("file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlockSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
