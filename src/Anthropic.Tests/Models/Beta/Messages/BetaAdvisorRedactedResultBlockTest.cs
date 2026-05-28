using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaAdvisorRedactedResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAdvisorRedactedResultBlock
        {
            EncryptedContent = "encrypted_content",
            StopReason = "stop_reason",
        };

        string expectedEncryptedContent = "encrypted_content";
        string expectedStopReason = "stop_reason";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_redacted_result");

        Assert.Equal(expectedEncryptedContent, model.EncryptedContent);
        Assert.Equal(expectedStopReason, model.StopReason);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAdvisorRedactedResultBlock
        {
            EncryptedContent = "encrypted_content",
            StopReason = "stop_reason",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorRedactedResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAdvisorRedactedResultBlock
        {
            EncryptedContent = "encrypted_content",
            StopReason = "stop_reason",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorRedactedResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEncryptedContent = "encrypted_content";
        string expectedStopReason = "stop_reason";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_redacted_result");

        Assert.Equal(expectedEncryptedContent, deserialized.EncryptedContent);
        Assert.Equal(expectedStopReason, deserialized.StopReason);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAdvisorRedactedResultBlock
        {
            EncryptedContent = "encrypted_content",
            StopReason = "stop_reason",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAdvisorRedactedResultBlock
        {
            EncryptedContent = "encrypted_content",
            StopReason = "stop_reason",
        };

        BetaAdvisorRedactedResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
