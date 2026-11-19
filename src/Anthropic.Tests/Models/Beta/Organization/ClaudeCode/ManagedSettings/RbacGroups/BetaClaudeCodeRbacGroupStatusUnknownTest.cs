using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

public class BetaClaudeCodeRbacGroupStatusUnknownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeCodeRbacGroupStatusUnknown { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("unknown");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeCodeRbacGroupStatusUnknown { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupStatusUnknown>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeCodeRbacGroupStatusUnknown { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeCodeRbacGroupStatusUnknown>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("unknown");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeCodeRbacGroupStatusUnknown { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeCodeRbacGroupStatusUnknown { };

        BetaClaudeCodeRbacGroupStatusUnknown copied = new(model);

        Assert.Equal(model, copied);
    }
}
