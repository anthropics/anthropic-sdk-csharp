using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Webhooks;

namespace Anthropic.Tests.Models.Beta.Webhooks;

public class BetaWebhookUserProfileProgramStatusUpdatedEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebhookUserProfileProgramStatusUpdatedEventData
        {
            ID = "id",
            OrganizationID = "organization_id",
        };

        string expectedID = "id";
        string expectedOrganizationID = "organization_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "user_profile.program_status_updated"
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebhookUserProfileProgramStatusUpdatedEventData
        {
            ID = "id",
            OrganizationID = "organization_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaWebhookUserProfileProgramStatusUpdatedEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebhookUserProfileProgramStatusUpdatedEventData
        {
            ID = "id",
            OrganizationID = "organization_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaWebhookUserProfileProgramStatusUpdatedEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedOrganizationID = "organization_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "user_profile.program_status_updated"
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebhookUserProfileProgramStatusUpdatedEventData
        {
            ID = "id",
            OrganizationID = "organization_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebhookUserProfileProgramStatusUpdatedEventData
        {
            ID = "id",
            OrganizationID = "organization_id",
        };

        BetaWebhookUserProfileProgramStatusUpdatedEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
