using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class BetaSpendLimitRbacGroupScopeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSpendLimitRbacGroupScope { RbacGroupID = "rbac_group_id" };

        string expectedRbacGroupID = "rbac_group_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group");

        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSpendLimitRbacGroupScope { RbacGroupID = "rbac_group_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitRbacGroupScope>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSpendLimitRbacGroupScope { RbacGroupID = "rbac_group_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitRbacGroupScope>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRbacGroupID = "rbac_group_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group");

        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSpendLimitRbacGroupScope { RbacGroupID = "rbac_group_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSpendLimitRbacGroupScope { RbacGroupID = "rbac_group_id" };

        BetaSpendLimitRbacGroupScope copied = new(model);

        Assert.Equal(model, copied);
    }
}
