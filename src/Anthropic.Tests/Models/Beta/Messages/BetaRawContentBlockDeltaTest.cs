using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRawContentBlockDeltaTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaTextDelta("text");
        value.Validate();
    }

    [Fact]
    public void InputJsonValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaInputJsonDelta("partial_json");
        value.Validate();
    }

    [Fact]
    public void CitationsValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaCitationsDelta(
            new Citation(
                new BetaCitationCharLocation()
                {
                    CitedText = "cited_text",
                    DocumentIndex = 0,
                    DocumentTitle = "document_title",
                    EndCharIndex = 0,
                    FileID = "file_id",
                    StartCharIndex = 0,
                }
            )
        );
        value.Validate();
    }

    [Fact]
    public void ThinkingValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaThinkingDelta("thinking");
        value.Validate();
    }

    [Fact]
    public void SignatureValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaSignatureDelta("signature");
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaTextDelta("text");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InputJsonSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaInputJsonDelta("partial_json");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaCitationsDelta(
            new Citation(
                new BetaCitationCharLocation()
                {
                    CitedText = "cited_text",
                    DocumentIndex = 0,
                    DocumentTitle = "document_title",
                    EndCharIndex = 0,
                    FileID = "file_id",
                    StartCharIndex = 0,
                }
            )
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaThinkingDelta("thinking");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SignatureSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaSignatureDelta("signature");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(element);

        Assert.Equal(value, deserialized);
    }
}
