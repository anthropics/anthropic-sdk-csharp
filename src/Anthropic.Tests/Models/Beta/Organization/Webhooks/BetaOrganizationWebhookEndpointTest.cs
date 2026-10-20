using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Webhooks;

namespace Anthropic.Tests.Models.Beta.Organization.Webhooks;

public class BetaOrganizationWebhookEndpointTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOrganizationWebhookEndpoint
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
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisabledReason = "disabled_reason";
        List<ApiEnum<string, BetaOrganizationWebhookEndpointEnabledEvent>> expectedEnabledEvents =
        [
            BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
        ];
        string expectedName = "name";
        ApiEnum<string, BetaOrganizationWebhookEndpointState> expectedState =
            BetaOrganizationWebhookEndpointState.Disabled;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisabledReason, model.DisabledReason);
        Assert.Equal(expectedEnabledEvents.Count, model.EnabledEvents.Count);
        for (int i = 0; i < expectedEnabledEvents.Count; i++)
        {
            Assert.Equal(expectedEnabledEvents[i], model.EnabledEvents[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOrganizationWebhookEndpoint
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationWebhookEndpoint>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOrganizationWebhookEndpoint
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationWebhookEndpoint>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisabledReason = "disabled_reason";
        List<ApiEnum<string, BetaOrganizationWebhookEndpointEnabledEvent>> expectedEnabledEvents =
        [
            BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened,
        ];
        string expectedName = "name";
        ApiEnum<string, BetaOrganizationWebhookEndpointState> expectedState =
            BetaOrganizationWebhookEndpointState.Disabled;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisabledReason, deserialized.DisabledReason);
        Assert.Equal(expectedEnabledEvents.Count, deserialized.EnabledEvents.Count);
        for (int i = 0; i < expectedEnabledEvents.Count; i++)
        {
            Assert.Equal(expectedEnabledEvents[i], deserialized.EnabledEvents[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOrganizationWebhookEndpoint
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOrganizationWebhookEndpoint
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
        };

        BetaOrganizationWebhookEndpoint copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaOrganizationWebhookEndpointEnabledEventTest : TestBase
{
    [Theory]
    [InlineData(BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened)]
    [InlineData(BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionResolved)]
    public void Validation_Works(BetaOrganizationWebhookEndpointEnabledEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOrganizationWebhookEndpointEnabledEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationWebhookEndpointEnabledEvent>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionOpened)]
    [InlineData(BetaOrganizationWebhookEndpointEnabledEvent.UserProfileEnforcementActionResolved)]
    public void SerializationRoundtrip_Works(BetaOrganizationWebhookEndpointEnabledEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOrganizationWebhookEndpointEnabledEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationWebhookEndpointEnabledEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationWebhookEndpointEnabledEvent>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationWebhookEndpointEnabledEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
