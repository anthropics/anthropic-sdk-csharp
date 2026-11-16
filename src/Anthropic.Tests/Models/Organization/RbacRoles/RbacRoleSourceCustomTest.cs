using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.RbacRoles;

namespace Anthropic.Tests.Models.Organization.RbacRoles;

public class RbacRoleSourceCustomTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacRoleSourceCustom { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("custom");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RbacRoleSourceCustom { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacRoleSourceCustom>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacRoleSourceCustom { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacRoleSourceCustom>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("custom");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RbacRoleSourceCustom { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacRoleSourceCustom { };

        RbacRoleSourceCustom copied = new(model);

        Assert.Equal(model, copied);
    }
}
