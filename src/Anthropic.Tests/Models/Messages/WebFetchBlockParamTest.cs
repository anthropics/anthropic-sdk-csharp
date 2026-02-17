using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebFetchBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebFetchBlockParam
        {
            Content = new()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",
            RetrievedAt = "retrieved_at",
        };

        DocumentBlockParam expectedContent = new()
        {
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_result");
        string expectedUrl = "url";
        string expectedRetrievedAt = "retrieved_at";

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedRetrievedAt, model.RetrievedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebFetchBlockParam
        {
            Content = new()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",
            RetrievedAt = "retrieved_at",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebFetchBlockParam
        {
            Content = new()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",
            RetrievedAt = "retrieved_at",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DocumentBlockParam expectedContent = new()
        {
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_result");
        string expectedUrl = "url";
        string expectedRetrievedAt = "retrieved_at";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedRetrievedAt, deserialized.RetrievedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebFetchBlockParam
        {
            Content = new()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",
            RetrievedAt = "retrieved_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebFetchBlockParam
        {
            Content = new()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",
        };

        Assert.Null(model.RetrievedAt);
        Assert.False(model.RawData.ContainsKey("retrieved_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebFetchBlockParam
        {
            Content = new()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebFetchBlockParam
        {
            Content = new()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",

            RetrievedAt = null,
        };

        Assert.Null(model.RetrievedAt);
        Assert.True(model.RawData.ContainsKey("retrieved_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebFetchBlockParam
        {
            Content = new()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",

            RetrievedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebFetchBlockParam
        {
            Content = new()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",
            RetrievedAt = "retrieved_at",
        };

        WebFetchBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
