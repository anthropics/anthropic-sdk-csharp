using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRawContentBlockDeltaTest : TestBase
{
    [Fact]
    public void textValidation_Works()
    {
        BetaRawContentBlockDelta value = new(new BetaTextDelta("text"));
        value.Validate();
    }

    [Fact]
    public void input_jsonValidation_Works()
    {
        BetaRawContentBlockDelta value = new(new BetaInputJSONDelta("partial_json"));
        value.Validate();
    }

    [Fact]
    public void citationsValidation_Works()
    {
        BetaRawContentBlockDelta value = new(
            new BetaCitationsDelta(
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
            )
        );
        value.Validate();
    }

    [Fact]
    public void thinkingValidation_Works()
    {
        BetaRawContentBlockDelta value = new(new BetaThinkingDelta("thinking"));
        value.Validate();
    }

    [Fact]
    public void signatureValidation_Works()
    {
        BetaRawContentBlockDelta value = new(new BetaSignatureDelta("signature"));
        value.Validate();
    }

    [Fact]
    public void textSerializationRoundtrip_Works()
    {
        BetaRawContentBlockDelta value = new(new BetaTextDelta("text"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void input_jsonSerializationRoundtrip_Works()
    {
        BetaRawContentBlockDelta value = new(new BetaInputJSONDelta("partial_json"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void citationsSerializationRoundtrip_Works()
    {
        BetaRawContentBlockDelta value = new(
            new BetaCitationsDelta(
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
            )
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void thinkingSerializationRoundtrip_Works()
    {
        BetaRawContentBlockDelta value = new(new BetaThinkingDelta("thinking"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void signatureSerializationRoundtrip_Works()
    {
        BetaRawContentBlockDelta value = new(new BetaSignatureDelta("signature"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(json);

        Assert.Equal(value, deserialized);
    }
}
