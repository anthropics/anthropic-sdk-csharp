using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaSearchResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
        };

        List<BetaTextBlockParam> expectedContent =
        [
            new()
            {
                Text = "x",
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations =
                [
                    new BetaCitationCharLocationParam()
                    {
                        CitedText = "cited_text",
                        DocumentIndex = 0,
                        DocumentTitle = "x",
                        EndCharIndex = 0,
                        StartCharIndex = 0,
                    },
                ],
            },
        ];
        string expectedSource = "source";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"search_result\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaCitationsConfigParam expectedCitations = new() { Enabled = true };

        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCitations, model.Citations);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaSearchResultBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaSearchResultBlockParam>(element);
        Assert.NotNull(deserialized);

        List<BetaTextBlockParam> expectedContent =
        [
            new()
            {
                Text = "x",
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations =
                [
                    new BetaCitationCharLocationParam()
                    {
                        CitedText = "cited_text",
                        DocumentIndex = 0,
                        DocumentTitle = "x",
                        EndCharIndex = 0,
                        StartCharIndex = 0,
                    },
                ],
            },
        ];
        string expectedSource = "source";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"search_result\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaCitationsConfigParam expectedCitations = new() { Enabled = true };

        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedCitations, deserialized.Citations);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            Citations = null,
        };

        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            Citations = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            Citations = new() { Enabled = true },
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            Citations = new() { Enabled = true },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            Citations = new() { Enabled = true },

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaSearchResultBlockParam
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ],
            Source = "source",
            Title = "title",
            Citations = new() { Enabled = true },

            CacheControl = null,
        };

        model.Validate();
    }
}
