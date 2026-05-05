using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Webhooks;

namespace Anthropic.Tests.Models.Beta.Webhooks;

public class BetaWebhookSessionOutcomeEvaluationEndedEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebhookSessionOutcomeEvaluationEndedEventData
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        string expectedID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        string expectedOrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "session.outcome_evaluation_ended"
        );
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebhookSessionOutcomeEvaluationEndedEventData
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaWebhookSessionOutcomeEvaluationEndedEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebhookSessionOutcomeEvaluationEndedEventData
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaWebhookSessionOutcomeEvaluationEndedEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        string expectedOrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "session.outcome_evaluation_ended"
        );
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebhookSessionOutcomeEvaluationEndedEventData
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebhookSessionOutcomeEvaluationEndedEventData
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        BetaWebhookSessionOutcomeEvaluationEndedEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
