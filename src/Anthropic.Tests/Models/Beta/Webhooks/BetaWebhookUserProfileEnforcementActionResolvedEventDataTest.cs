using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Webhooks;

namespace Anthropic.Tests.Models.Beta.Webhooks;

public class BetaWebhookUserProfileEnforcementActionResolvedEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebhookUserProfileEnforcementActionResolvedEventData
        {
            ID = "id",
            EnforcementActionID = "enforcement_action_id",
            OrganizationID = "organization_id",
        };

        string expectedID = "id";
        string expectedEnforcementActionID = "enforcement_action_id";
        string expectedOrganizationID = "organization_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "user_profile.enforcement_action_resolved"
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEnforcementActionID, model.EnforcementActionID);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebhookUserProfileEnforcementActionResolvedEventData
        {
            ID = "id",
            EnforcementActionID = "enforcement_action_id",
            OrganizationID = "organization_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaWebhookUserProfileEnforcementActionResolvedEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebhookUserProfileEnforcementActionResolvedEventData
        {
            ID = "id",
            EnforcementActionID = "enforcement_action_id",
            OrganizationID = "organization_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaWebhookUserProfileEnforcementActionResolvedEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedEnforcementActionID = "enforcement_action_id";
        string expectedOrganizationID = "organization_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "user_profile.enforcement_action_resolved"
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEnforcementActionID, deserialized.EnforcementActionID);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebhookUserProfileEnforcementActionResolvedEventData
        {
            ID = "id",
            EnforcementActionID = "enforcement_action_id",
            OrganizationID = "organization_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebhookUserProfileEnforcementActionResolvedEventData
        {
            ID = "id",
            EnforcementActionID = "enforcement_action_id",
            OrganizationID = "organization_id",
        };

        BetaWebhookUserProfileEnforcementActionResolvedEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
