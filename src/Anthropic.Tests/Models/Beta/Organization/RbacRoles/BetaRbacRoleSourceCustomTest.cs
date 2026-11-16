using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacRoles;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles;

public class BetaRbacRoleSourceCustomTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRbacRoleSourceCustom { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("custom");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRbacRoleSourceCustom { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacRoleSourceCustom>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRbacRoleSourceCustom { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacRoleSourceCustom>(
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
        var model = new BetaRbacRoleSourceCustom { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRbacRoleSourceCustom { };

        BetaRbacRoleSourceCustom copied = new(model);

        Assert.Equal(model, copied);
    }
}
