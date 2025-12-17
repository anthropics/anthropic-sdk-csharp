using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContentBlockSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaContentBlockSource { Content = "string" };

        BetaContentBlockSourceContent expectedContent = "string";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"content\"");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaContentBlockSource { Content = "string" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockSource>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaContentBlockSource { Content = "string" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockSource>(json);
        Assert.NotNull(deserialized);

        BetaContentBlockSourceContent expectedContent = "string";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"content\"");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaContentBlockSource { Content = "string" };

        model.Validate();
    }
}

public class BetaContentBlockSourceContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BetaContentBlockSourceContent value = new("string");
        value.Validate();
    }

    [Fact]
    public void BetaContentBlockSourceValidationWorks()
    {
        BetaContentBlockSourceContent value = new(
            [
                new MessageBetaContentBlockSourceContent(
                    new BetaTextBlockParam()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
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
                    }
                ),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        BetaContentBlockSourceContent value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockSourceContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaContentBlockSourceSerializationRoundtripWorks()
    {
        BetaContentBlockSourceContent value = new(
            [
                new MessageBetaContentBlockSourceContent(
                    new BetaTextBlockParam()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
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
                    }
                ),
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockSourceContent>(json);

        Assert.Equal(value, deserialized);
    }
}
