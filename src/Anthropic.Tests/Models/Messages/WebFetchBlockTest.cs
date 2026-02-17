using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebFetchBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebFetchBlock
        {
            Content = new()
            {
                Citations = new(true),
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                Title = "title",
            },
            RetrievedAt = "retrieved_at",
            Url = "url",
        };

        DocumentBlock expectedContent = new()
        {
            Citations = new(true),
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };
        string expectedRetrievedAt = "retrieved_at";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_result");
        string expectedUrl = "url";

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRetrievedAt, model.RetrievedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebFetchBlock
        {
            Content = new()
            {
                Citations = new(true),
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                Title = "title",
            },
            RetrievedAt = "retrieved_at",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebFetchBlock
        {
            Content = new()
            {
                Citations = new(true),
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                Title = "title",
            },
            RetrievedAt = "retrieved_at",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DocumentBlock expectedContent = new()
        {
            Citations = new(true),
            Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            Title = "title",
        };
        string expectedRetrievedAt = "retrieved_at";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_result");
        string expectedUrl = "url";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRetrievedAt, deserialized.RetrievedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebFetchBlock
        {
            Content = new()
            {
                Citations = new(true),
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                Title = "title",
            },
            RetrievedAt = "retrieved_at",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebFetchBlock
        {
            Content = new()
            {
                Citations = new(true),
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                Title = "title",
            },
            RetrievedAt = "retrieved_at",
            Url = "url",
        };

        WebFetchBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
