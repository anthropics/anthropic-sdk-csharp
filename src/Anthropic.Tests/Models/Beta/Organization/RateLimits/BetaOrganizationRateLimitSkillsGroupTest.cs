using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RateLimits;

namespace Anthropic.Tests.Models.Beta.Organization.RateLimits;

public class BetaOrganizationRateLimitSkillsGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOrganizationRateLimitSkillsGroup { ID = "id" };

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("skills");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOrganizationRateLimitSkillsGroup { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationRateLimitSkillsGroup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOrganizationRateLimitSkillsGroup { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationRateLimitSkillsGroup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("skills");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOrganizationRateLimitSkillsGroup { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOrganizationRateLimitSkillsGroup { ID = "id" };

        BetaOrganizationRateLimitSkillsGroup copied = new(model);

        Assert.Equal(model, copied);
    }
}
