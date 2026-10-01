using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Models.Organization.Workspaces.RateLimits;

public class WorkspaceRateLimitOrganizationSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspaceRateLimitOrganizationSource { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkspaceRateLimitOrganizationSource { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceRateLimitOrganizationSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkspaceRateLimitOrganizationSource { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceRateLimitOrganizationSource>(
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
        var model = new WorkspaceRateLimitOrganizationSource { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspaceRateLimitOrganizationSource { };

        WorkspaceRateLimitOrganizationSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
