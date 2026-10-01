using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.RbacGroups;

public class RbacGroupDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacGroupDeleteResponse { ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF" };

        string expectedID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RbacGroupDeleteResponse { ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacGroupDeleteResponse { ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RbacGroupDeleteResponse { ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacGroupDeleteResponse { ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF" };

        RbacGroupDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
