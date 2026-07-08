using System.Text.Json;
using Anthropic.Core;
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
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "My Document",
                    EndCharIndex = 0,
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    StartCharIndex = 0,
                }
            )
        );
        value.Validate();
    }

    [Fact]
    public void ThinkingValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaThinkingDelta()
        {
            EstimatedTokens = 0,
            Thinking = "thinking",
        };
        value.Validate();
    }

    [Fact]
    public void SignatureValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaSignatureDelta("signature");
        value.Validate();
    }

    [Fact]
    public void CompactionValidationWorks()
    {
        BetaRawContentBlockDelta value = new BetaCompactionContentBlockDelta()
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
        };
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaTextDelta("text");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InputJsonSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaInputJsonDelta("partial_json");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CitationsSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaCitationsDelta(
            new Citation(
                new BetaCitationCharLocation()
                {
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "My Document",
                    EndCharIndex = 0,
                    FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                    StartCharIndex = 0,
                }
            )
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaThinkingDelta()
        {
            EstimatedTokens = 0,
            Thinking = "thinking",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SignatureSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaSignatureDelta("signature");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CompactionSerializationRoundtripWorks()
    {
        BetaRawContentBlockDelta value = new BetaCompactionContentBlockDelta()
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
