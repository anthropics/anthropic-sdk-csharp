using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaUserMessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaUserMessageParam
        {
            Content = new(
                [
                    new BetaContentBlockParam(
                        new BetaTextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new BetaCitationCharLocationParam()
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

        BetaMessageContentParam expectedContent = new(
            [
                new BetaContentBlockParam(
                    new BetaTextBlockParam()
                    {
                        Text = "What is a quaternion?",
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                        Citations =
                        [
                            new BetaCitationCharLocationParam()
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
        JsonElement expectedRole = JsonSerializer.SerializeToElement("user");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaUserMessageParam
        {
            Content = new(
                [
                    new BetaContentBlockParam(
                        new BetaTextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new BetaCitationCharLocationParam()
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
        var deserialized = JsonSerializer.Deserialize<BetaUserMessageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaUserMessageParam
        {
            Content = new(
                [
                    new BetaContentBlockParam(
                        new BetaTextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new BetaCitationCharLocationParam()
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
        var deserialized = JsonSerializer.Deserialize<BetaUserMessageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaMessageContentParam expectedContent = new(
            [
                new BetaContentBlockParam(
                    new BetaTextBlockParam()
                    {
                        Text = "What is a quaternion?",
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                        Citations =
                        [
                            new BetaCitationCharLocationParam()
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
        JsonElement expectedRole = JsonSerializer.SerializeToElement("user");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaUserMessageParam
        {
            Content = new(
                [
                    new BetaContentBlockParam(
                        new BetaTextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new BetaCitationCharLocationParam()
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
        var model = new BetaUserMessageParam
        {
            Content = new(
                [
                    new BetaContentBlockParam(
                        new BetaTextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new BetaCitationCharLocationParam()
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

        BetaUserMessageParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
