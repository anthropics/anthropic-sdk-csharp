using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContentBlockSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContentBlockSource { Content = "string" };

        ContentBlockSourceContent expectedContent = "string";
        JsonElement expectedType = JsonSerializer.SerializeToElement("content");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContentBlockSource { Content = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContentBlockSource { Content = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ContentBlockSourceContent expectedContent = "string";
        JsonElement expectedType = JsonSerializer.SerializeToElement("content");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContentBlockSource { Content = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContentBlockSource { Content = "string" };

        ContentBlockSource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContentBlockSourceContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ContentBlockSourceContent value = "string";
        value.Validate();
    }

    [Fact]
    public void BlockSourceValidationWorks()
    {
        ContentBlockSourceContent value = new(
            [
                new MessageContentBlockSourceContent(
                    new TextBlockParam()
                    {
                        Text = "x",
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                        Citations =
                        [
                            new CitationCharLocationParam()
                            {
                                CitedText = "cited_text",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    }
                ),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ContentBlockSourceContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockSourceContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BlockSourceSerializationRoundtripWorks()
    {
        ContentBlockSourceContent value = new(
            [
                new MessageContentBlockSourceContent(
                    new TextBlockParam()
                    {
                        Text = "x",
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                        Citations =
                        [
                            new CitationCharLocationParam()
                            {
                                CitedText = "cited_text",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    }
                ),
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentBlockSourceContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
