using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings;

public class BetaRbacGroupManagedSettingsNotFoundErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRbacGroupManagedSettingsNotFoundErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "rbac_group_managed_settings_not_found"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRbacGroupManagedSettingsNotFoundErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaRbacGroupManagedSettingsNotFoundErrorDetails>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRbacGroupManagedSettingsNotFoundErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaRbacGroupManagedSettingsNotFoundErrorDetails>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "rbac_group_managed_settings_not_found"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRbacGroupManagedSettingsNotFoundErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRbacGroupManagedSettingsNotFoundErrorDetails { };

        BetaRbacGroupManagedSettingsNotFoundErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
