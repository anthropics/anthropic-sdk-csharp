using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

public class BetaClaudeCodeManagedSettingsRbacGroupsModeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsRbacGroupsMode { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_groups");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsRbacGroupsMode { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsRbacGroupsMode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsRbacGroupsMode { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeManagedSettingsRbacGroupsMode>(
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
        var model = new BetaClaudeCodeManagedSettingsRbacGroupsMode { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeCodeManagedSettingsRbacGroupsMode { };

        BetaClaudeCodeManagedSettingsRbacGroupsMode copied = new(model);

        Assert.Equal(model, copied);
    }
}
