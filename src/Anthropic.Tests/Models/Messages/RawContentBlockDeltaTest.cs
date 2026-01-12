using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawContentBlockDeltaTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        RawContentBlockDelta value = new(new TextDelta("text"));
        value.Validate();
    }

    [Fact]
    public void InputJsonValidationWorks()
    {
        RawContentBlockDelta value = new(new InputJsonDelta("partial_json"));
        value.Validate();
    }

    [Fact]
    public void CitationsValidationWorks()
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
    public void ThinkingValidationWorks()
    {
        RawContentBlockDelta value = new(new ThinkingDelta("thinking"));
        value.Validate();
    }

    [Fact]
    public void SignatureValidationWorks()
    {
        RawContentBlockDelta value = new(new SignatureDelta("signature"));
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        RawContentBlockDelta value = new(new TextDelta("text"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InputJsonSerializationRoundtripWorks()
    {
        RawContentBlockDelta value = new(new InputJsonDelta("partial_json"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsSerializationRoundtripWorks()
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
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        RawContentBlockDelta value = new(new ThinkingDelta("thinking"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SignatureSerializationRoundtripWorks()
    {
        RawContentBlockDelta value = new(new SignatureDelta("signature"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDelta>(element);

        Assert.Equal(value, deserialized);
    }
}
