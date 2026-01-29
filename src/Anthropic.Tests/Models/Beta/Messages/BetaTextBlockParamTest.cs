using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextBlockParam
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
        };

        string expectedText = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        List<BetaTextCitationParam> expectedCitations =
        [
            new BetaCitationCharLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndCharIndex = 0,
                StartCharIndex = 0,
            },
        ];

        Assert.Equal(expectedText, model.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.NotNull(model.Citations);
        Assert.Equal(expectedCitations.Count, model.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], model.Citations[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTextBlockParam
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTextBlockParam
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        List<BetaTextCitationParam> expectedCitations =
        [
            new BetaCitationCharLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndCharIndex = 0,
                StartCharIndex = 0,
            },
        ];

        Assert.Equal(expectedText, deserialized.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.NotNull(deserialized.Citations);
        Assert.Equal(expectedCitations.Count, deserialized.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], deserialized.Citations[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTextBlockParam
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaTextBlockParam { Text = "x" };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaTextBlockParam { Text = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaTextBlockParam
        {
            Text = "x",

            CacheControl = null,
            Citations = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Citations);
        Assert.True(model.RawData.ContainsKey("citations"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaTextBlockParam
        {
            Text = "x",

            CacheControl = null,
            Citations = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTextBlockParam
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
        };

        BetaTextBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
