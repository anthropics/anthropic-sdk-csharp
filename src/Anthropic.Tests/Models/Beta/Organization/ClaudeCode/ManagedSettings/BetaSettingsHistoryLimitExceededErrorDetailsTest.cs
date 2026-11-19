using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings;

public class BetaSettingsHistoryLimitExceededErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSettingsHistoryLimitExceededErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "settings_history_limit_exceeded"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSettingsHistoryLimitExceededErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSettingsHistoryLimitExceededErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSettingsHistoryLimitExceededErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSettingsHistoryLimitExceededErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "settings_history_limit_exceeded"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSettingsHistoryLimitExceededErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSettingsHistoryLimitExceededErrorDetails { };

        BetaSettingsHistoryLimitExceededErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
