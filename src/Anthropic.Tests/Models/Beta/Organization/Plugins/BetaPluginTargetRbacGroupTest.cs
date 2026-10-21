using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class BetaPluginTargetRbacGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginTargetRbacGroup
        {
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
        };

        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group");

        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginTargetRbacGroup
        {
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginTargetRbacGroup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginTargetRbacGroup
        {
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginTargetRbacGroup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group");

        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginTargetRbacGroup
        {
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginTargetRbacGroup
        {
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
        };

        BetaPluginTargetRbacGroup copied = new(model);

        Assert.Equal(model, copied);
    }
}
