using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawContentBlockDeltaTest : TestBase
{
    [Fact]
    public void textValidation_Works()
    {
        RawContentBlockDelta value = new(new TextDelta("text"));
        value.Validate();
    }

    [Fact]
    public void input_jsonValidation_Works()
    {
        RawContentBlockDelta value = new(new InputJSONDelta("partial_json"));
        value.Validate();
    }

    [Fact]
    public void citationsValidation_Works()
    {
        RawContentBlockDelta value = new(
            new CitationsDelta(
                new Citation(
                    new CitationCharLocation()
                    {
                        CitedText = "cited_text",
                        DocumentIndex = 0,
                        DocumentTitle = "document_title",
                        EndCharIndex = 0,
                        FileID = "file_id",
                        StartCharIndex = 0,
                    }
                )
            )
        );
        value.Validate();
    }

    [Fact]
    public void thinkingValidation_Works()
    {
        RawContentBlockDelta value = new(new ThinkingDelta("thinking"));
        value.Validate();
    }

    [Fact]
    public void signatureValidation_Works()
    {
        RawContentBlockDelta value = new(new SignatureDelta("signature"));
        value.Validate();
    }

    [Fact]
    public void textSerializationRoundtrip_Works()
    {
        RawContentBlockDelta value = new(new TextDelta("text"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void input_jsonSerializationRoundtrip_Works()
    {
        RawContentBlockDelta value = new(new InputJSONDelta("partial_json"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void citationsSerializationRoundtrip_Works()
    {
        RawContentBlockDelta value = new(
            new CitationsDelta(
                new Citation(
                    new CitationCharLocation()
                    {
                        CitedText = "cited_text",
                        DocumentIndex = 0,
                        DocumentTitle = "document_title",
                        EndCharIndex = 0,
                        FileID = "file_id",
                        StartCharIndex = 0,
                    }
                )
            )
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void thinkingSerializationRoundtrip_Works()
    {
        RawContentBlockDelta value = new(new ThinkingDelta("thinking"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void signatureSerializationRoundtrip_Works()
    {
        RawContentBlockDelta value = new(new SignatureDelta("signature"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(json);

        Assert.Equal(value, deserialized);
    }
}
