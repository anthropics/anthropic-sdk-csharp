using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class AssistantMessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AssistantMessageParam
        {
            Content = new(
                [
                    new ContentBlockParam(
                        new TextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new CitationCharLocationParam()
                                {
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        }
                    ),
                ]
            ),
        };

        MessageContentParam expectedContent = new(
            [
                new ContentBlockParam(
                    new TextBlockParam()
                    {
                        Text = "What is a quaternion?",
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                        Citations =
                        [
                            new CitationCharLocationParam()
                            {
                                CitedText = "The grass is green. The sky is blue.",
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
        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AssistantMessageParam
        {
            Content = new(
                [
                    new ContentBlockParam(
                        new TextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new CitationCharLocationParam()
                                {
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        }
                    ),
                ]
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssistantMessageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AssistantMessageParam
        {
            Content = new(
                [
                    new ContentBlockParam(
                        new TextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new CitationCharLocationParam()
                                {
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        }
                    ),
                ]
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssistantMessageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        MessageContentParam expectedContent = new(
            [
                new ContentBlockParam(
                    new TextBlockParam()
                    {
                        Text = "What is a quaternion?",
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                        Citations =
                        [
                            new CitationCharLocationParam()
                            {
                                CitedText = "The grass is green. The sky is blue.",
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
        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AssistantMessageParam
        {
            Content = new(
                [
                    new ContentBlockParam(
                        new TextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new CitationCharLocationParam()
                                {
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        }
                    ),
                ]
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AssistantMessageParam
        {
            Content = new(
                [
                    new ContentBlockParam(
                        new TextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new CitationCharLocationParam()
                                {
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        }
                    ),
                ]
            ),
        };

        AssistantMessageParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
