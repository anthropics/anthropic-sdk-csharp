using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaBundleAttachmentNotSupportedErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBundleAttachmentNotSupportedErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "bundle_attachment_not_supported"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBundleAttachmentNotSupportedErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBundleAttachmentNotSupportedErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBundleAttachmentNotSupportedErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBundleAttachmentNotSupportedErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "bundle_attachment_not_supported"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBundleAttachmentNotSupportedErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBundleAttachmentNotSupportedErrorDetails { };

        BetaBundleAttachmentNotSupportedErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
