using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Webhooks;

namespace Anthropic.Tests.Models.Beta.Webhooks;

public class UnwrapWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnwrapWebhookEvent
        {
            ID = "whe_0f1e2d3c4b5a69788796a5b4c3d2e1f0",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Data = new BetaWebhookSessionStatusIdledEventData()
            {
                ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
                WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
            },
        };

        string expectedID = "whe_0f1e2d3c4b5a69788796a5b4c3d2e1f0";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        BetaWebhookEventData expectedData = new BetaWebhookSessionStatusIdledEventData()
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("event");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnwrapWebhookEvent
        {
            ID = "whe_0f1e2d3c4b5a69788796a5b4c3d2e1f0",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Data = new BetaWebhookSessionStatusIdledEventData()
            {
                ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
                WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnwrapWebhookEvent
        {
            ID = "whe_0f1e2d3c4b5a69788796a5b4c3d2e1f0",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Data = new BetaWebhookSessionStatusIdledEventData()
            {
                ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
                WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "whe_0f1e2d3c4b5a69788796a5b4c3d2e1f0";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        BetaWebhookEventData expectedData = new BetaWebhookSessionStatusIdledEventData()
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("event");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnwrapWebhookEvent
        {
            ID = "whe_0f1e2d3c4b5a69788796a5b4c3d2e1f0",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Data = new BetaWebhookSessionStatusIdledEventData()
            {
                ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
                WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnwrapWebhookEvent
        {
            ID = "whe_0f1e2d3c4b5a69788796a5b4c3d2e1f0",
            CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Data = new BetaWebhookSessionStatusIdledEventData()
            {
                ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
                WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
            },
        };

        UnwrapWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
