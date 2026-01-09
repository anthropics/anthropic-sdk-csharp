using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebFetchBlockParam
        {
            Content = new()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            URL = "url",
            RetrievedAt = "retrieved_at",
        };

        BetaRequestDocumentBlock expectedContent = new()
        {
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\"");
        string expectedURL = "url";
        string expectedRetrievedAt = "retrieved_at";

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedRetrievedAt, model.RetrievedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebFetchBlockParam
        {
            Content = new()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            URL = "url",
            RetrievedAt = "retrieved_at",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebFetchBlockParam
        {
            Content = new()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            URL = "url",
            RetrievedAt = "retrieved_at",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlockParam>(element);
        Assert.NotNull(deserialized);

        BetaRequestDocumentBlock expectedContent = new()
        {
            Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_result\"");
        string expectedURL = "url";
        string expectedRetrievedAt = "retrieved_at";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedURL, deserialized.URL);
        Assert.Equal(expectedRetrievedAt, deserialized.RetrievedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebFetchBlockParam
        {
            Content = new()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            URL = "url",
            RetrievedAt = "retrieved_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebFetchBlockParam
        {
            Content = new()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            URL = "url",
        };

        Assert.Null(model.RetrievedAt);
        Assert.False(model.RawData.ContainsKey("retrieved_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaWebFetchBlockParam
        {
            Content = new()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            URL = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaWebFetchBlockParam
        {
            Content = new()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            URL = "url",

            RetrievedAt = null,
        };

        Assert.Null(model.RetrievedAt);
        Assert.True(model.RawData.ContainsKey("retrieved_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaWebFetchBlockParam
        {
            Content = new()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            URL = "url",

            RetrievedAt = null,
        };

        model.Validate();
    }
}
