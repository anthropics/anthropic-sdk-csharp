using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RateLimits;

namespace Anthropic.Tests.Models.Beta.Organization.RateLimits;

public class BetaOrganizationRateLimitModelGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOrganizationRateLimitModelGroup
        {
            ID = "id",
            DisplayName = "display_name",
        };

        string expectedID = "id";
        string expectedDisplayName = "display_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("model_group");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOrganizationRateLimitModelGroup
        {
            ID = "id",
            DisplayName = "display_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationRateLimitModelGroup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOrganizationRateLimitModelGroup
        {
            ID = "id",
            DisplayName = "display_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationRateLimitModelGroup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDisplayName = "display_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("model_group");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOrganizationRateLimitModelGroup
        {
            ID = "id",
            DisplayName = "display_name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOrganizationRateLimitModelGroup
        {
            ID = "id",
            DisplayName = "display_name",
        };

        BetaOrganizationRateLimitModelGroup copied = new(model);

        Assert.Equal(model, copied);
    }
}
