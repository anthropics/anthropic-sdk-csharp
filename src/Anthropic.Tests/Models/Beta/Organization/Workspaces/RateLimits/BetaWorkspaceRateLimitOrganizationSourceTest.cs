using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces.RateLimits;

public class BetaWorkspaceRateLimitOrganizationSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWorkspaceRateLimitOrganizationSource { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWorkspaceRateLimitOrganizationSource { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspaceRateLimitOrganizationSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWorkspaceRateLimitOrganizationSource { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspaceRateLimitOrganizationSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWorkspaceRateLimitOrganizationSource { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWorkspaceRateLimitOrganizationSource { };

        BetaWorkspaceRateLimitOrganizationSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
