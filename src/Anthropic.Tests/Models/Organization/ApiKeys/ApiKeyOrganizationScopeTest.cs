using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.ApiKeys;

namespace Anthropic.Tests.Models.Organization.ApiKeys;

public class ApiKeyOrganizationScopeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeyOrganizationScope { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKeyOrganizationScope { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyOrganizationScope>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeyOrganizationScope { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyOrganizationScope>(
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
        var model = new ApiKeyOrganizationScope { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeyOrganizationScope { };

        ApiKeyOrganizationScope copied = new(model);

        Assert.Equal(model, copied);
    }
}
