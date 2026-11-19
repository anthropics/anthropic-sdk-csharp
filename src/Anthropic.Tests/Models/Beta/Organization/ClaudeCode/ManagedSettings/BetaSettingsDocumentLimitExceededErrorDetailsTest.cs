using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings;

public class BetaSettingsDocumentLimitExceededErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSettingsDocumentLimitExceededErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "settings_document_limit_exceeded"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSettingsDocumentLimitExceededErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaSettingsDocumentLimitExceededErrorDetails>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSettingsDocumentLimitExceededErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaSettingsDocumentLimitExceededErrorDetails>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "settings_document_limit_exceeded"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSettingsDocumentLimitExceededErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSettingsDocumentLimitExceededErrorDetails { };

        BetaSettingsDocumentLimitExceededErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
