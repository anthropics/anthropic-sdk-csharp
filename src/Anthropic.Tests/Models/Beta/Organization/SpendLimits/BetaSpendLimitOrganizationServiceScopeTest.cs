using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class BetaSpendLimitOrganizationServiceScopeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSpendLimitOrganizationServiceScope { Service = "service" };

        string expectedService = "service";
        JsonElement expectedType = JsonSerializer.SerializeToElement("organization_service");

        Assert.Equal(expectedService, model.Service);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSpendLimitOrganizationServiceScope { Service = "service" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitOrganizationServiceScope>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSpendLimitOrganizationServiceScope { Service = "service" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitOrganizationServiceScope>(
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
        var model = new BetaSpendLimitOrganizationServiceScope { Service = "service" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSpendLimitOrganizationServiceScope { Service = "service" };

        BetaSpendLimitOrganizationServiceScope copied = new(model);

        Assert.Equal(model, copied);
    }
}
