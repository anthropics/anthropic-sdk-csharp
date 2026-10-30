using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Organization.SpendLimits;

public class SpendLimitOrganizationServiceScopeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SpendLimitOrganizationServiceScope { Service = "service" };

        string expectedService = "service";
        JsonElement expectedType = JsonSerializer.SerializeToElement("organization_service");

        Assert.Equal(expectedService, model.Service);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SpendLimitOrganizationServiceScope { Service = "service" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimitOrganizationServiceScope>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SpendLimitOrganizationServiceScope { Service = "service" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimitOrganizationServiceScope>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedService = "service";
        JsonElement expectedType = JsonSerializer.SerializeToElement("organization_service");

        Assert.Equal(expectedService, deserialized.Service);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SpendLimitOrganizationServiceScope { Service = "service" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SpendLimitOrganizationServiceScope { Service = "service" };

        SpendLimitOrganizationServiceScope copied = new(model);

        Assert.Equal(model, copied);
    }
}
