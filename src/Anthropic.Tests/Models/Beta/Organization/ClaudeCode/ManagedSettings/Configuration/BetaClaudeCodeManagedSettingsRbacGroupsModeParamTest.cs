using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

public class BetaClaudeCodeManagedSettingsRbacGroupsModeParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsRbacGroupsModeParam { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_groups");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsRbacGroupsModeParam { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsRbacGroupsModeParam>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsRbacGroupsModeParam { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsRbacGroupsModeParam>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_groups");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsRbacGroupsModeParam { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsRbacGroupsModeParam { };

        BetaClaudeCodeManagedSettingsRbacGroupsModeParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
