using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MidConversationSystemBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MidConversationSystemBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
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
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        List<TextBlockParam> expectedContent =
        [
            new()
            {
                Text = "x",
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
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("mid_conv_system");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MidConversationSystemBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
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
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MidConversationSystemBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MidConversationSystemBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
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
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MidConversationSystemBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TextBlockParam> expectedContent =
        [
            new()
            {
                Text = "x",
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
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("mid_conv_system");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MidConversationSystemBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
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
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MidConversationSystemBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
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
                },
            ],
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MidConversationSystemBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MidConversationSystemBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
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
                },
            ],

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MidConversationSystemBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
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
                },
            ],

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MidConversationSystemBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
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
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        MidConversationSystemBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
