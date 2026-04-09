using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaAdvisorRedactedResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAdvisorRedactedResultBlockParam
        {
            EncryptedContent = "encrypted_content",
        };

        string expectedEncryptedContent = "encrypted_content";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_redacted_result");

        Assert.Equal(expectedEncryptedContent, model.EncryptedContent);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAdvisorRedactedResultBlockParam
        {
            EncryptedContent = "encrypted_content",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorRedactedResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAdvisorRedactedResultBlockParam
        {
            EncryptedContent = "encrypted_content",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorRedactedResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEncryptedContent = "encrypted_content";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_redacted_result");

        Assert.Equal(expectedEncryptedContent, deserialized.EncryptedContent);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAdvisorRedactedResultBlockParam
        {
            EncryptedContent = "encrypted_content",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAdvisorRedactedResultBlockParam
        {
            EncryptedContent = "encrypted_content",
        };

        BetaAdvisorRedactedResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
