using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Webhooks;

namespace Anthropic.Tests.Models.Beta.Organization.Webhooks;

public class WebhookListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisabledReason = "disabled_reason",
                    EnabledEvents =
                    [
                        BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
                    ],
                    Name = "name",
                    State = BetaOrganizationWebhookEndpointState.Disabled,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "url",
                },
            ],
            HasMore = true,
            FirstID = "first_id",
            LastID = "last_id",
        };

        List<BetaOrganizationWebhookEndpoint> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisabledReason = "disabled_reason",
                EnabledEvents =
                [
                    BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
                ],
                Name = "name",
                State = BetaOrganizationWebhookEndpointState.Disabled,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "url",
            },
        ];
        bool expectedHasMore = true;
        string expectedFirstID = "first_id";
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedFirstID, model.FirstID);
        Assert.Equal(expectedLastID, model.LastID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisabledReason = "disabled_reason",
                    EnabledEvents =
                    [
                        BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
                    ],
                    Name = "name",
                    State = BetaOrganizationWebhookEndpointState.Disabled,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "url",
                },
            ],
            HasMore = true,
            FirstID = "first_id",
            LastID = "last_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisabledReason = "disabled_reason",
                    EnabledEvents =
                    [
                        BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
                    ],
                    Name = "name",
                    State = BetaOrganizationWebhookEndpointState.Disabled,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "url",
                },
            ],
            HasMore = true,
            FirstID = "first_id",
            LastID = "last_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaOrganizationWebhookEndpoint> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisabledReason = "disabled_reason",
                EnabledEvents =
                [
                    BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
                ],
                Name = "name",
                State = BetaOrganizationWebhookEndpointState.Disabled,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "url",
            },
        ];
        bool expectedHasMore = true;
        string expectedFirstID = "first_id";
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedFirstID, deserialized.FirstID);
        Assert.Equal(expectedLastID, deserialized.LastID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisabledReason = "disabled_reason",
                    EnabledEvents =
                    [
                        BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
                    ],
                    Name = "name",
                    State = BetaOrganizationWebhookEndpointState.Disabled,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "url",
                },
            ],
            HasMore = true,
            FirstID = "first_id",
            LastID = "last_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisabledReason = "disabled_reason",
                    EnabledEvents =
                    [
                        BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
                    ],
                    Name = "name",
                    State = BetaOrganizationWebhookEndpointState.Disabled,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "url",
                },
            ],
            HasMore = true,
        };

        Assert.Null(model.FirstID);
        Assert.False(model.RawData.ContainsKey("first_id"));
        Assert.Null(model.LastID);
        Assert.False(model.RawData.ContainsKey("last_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisabledReason = "disabled_reason",
                    EnabledEvents =
                    [
                        BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
                    ],
                    Name = "name",
                    State = BetaOrganizationWebhookEndpointState.Disabled,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "url",
                },
            ],
            HasMore = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisabledReason = "disabled_reason",
                    EnabledEvents =
                    [
                        BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
                    ],
                    Name = "name",
                    State = BetaOrganizationWebhookEndpointState.Disabled,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "url",
                },
            ],
            HasMore = true,

            FirstID = null,
            LastID = null,
        };

        Assert.Null(model.FirstID);
        Assert.True(model.RawData.ContainsKey("first_id"));
        Assert.Null(model.LastID);
        Assert.True(model.RawData.ContainsKey("last_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisabledReason = "disabled_reason",
                    EnabledEvents =
                    [
                        BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
                    ],
                    Name = "name",
                    State = BetaOrganizationWebhookEndpointState.Disabled,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "url",
                },
            ],
            HasMore = true,

            FirstID = null,
            LastID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisabledReason = "disabled_reason",
                    EnabledEvents =
                    [
                        BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
                    ],
                    Name = "name",
                    State = BetaOrganizationWebhookEndpointState.Disabled,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "url",
                },
            ],
            HasMore = true,
            FirstID = "first_id",
            LastID = "last_id",
        };

        WebhookListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
