using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Webhooks;

namespace Anthropic.Tests.Models.Beta.Organization.Webhooks;

public class WebhookUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            WebhookEndpointID = "webhook_endpoint_id",
            Description = "description",
            EnabledEvents = [WebhookUpdateParamsEnabledEvent.ExternalKeyFailed],
            Name = "name",
            State = State.Disabled,
            UrlValue = "x",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        string expectedWebhookEndpointID = "webhook_endpoint_id";
        string expectedDescription = "description";
        List<ApiEnum<string, WebhookUpdateParamsEnabledEvent>> expectedEnabledEvents =
        [
            WebhookUpdateParamsEnabledEvent.ExternalKeyFailed,
        ];
        string expectedName = "name";
        ApiEnum<string, State> expectedState = State.Disabled;
        string expectedUrlValue = "x";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = [AnthropicBeta.ComputerUse2024_10_22];

        Assert.Equal(expectedWebhookEndpointID, parameters.WebhookEndpointID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.EnabledEvents);
        Assert.Equal(expectedEnabledEvents.Count, parameters.EnabledEvents.Count);
        for (int i = 0; i < expectedEnabledEvents.Count; i++)
        {
            Assert.Equal(expectedEnabledEvents[i], parameters.EnabledEvents[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedState, parameters.State);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookUpdateParams { WebhookEndpointID = "webhook_endpoint_id" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EnabledEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled_events"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            WebhookEndpointID = "webhook_endpoint_id",

            // Null should be interpreted as omitted for these properties
            Description = null,
            EnabledEvents = null,
            Name = null,
            State = null,
            UrlValue = null,
            Betas = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EnabledEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled_events"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            WebhookEndpointID = "webhook_endpoint_id",
            Description = "description",
            EnabledEvents = [WebhookUpdateParamsEnabledEvent.ExternalKeyFailed],
            Name = "name",
            State = State.Disabled,
            UrlValue = "x",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            EnabledEvents = null,
            Name = null,
            State = null,
            UrlValue = null,
            Betas = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EnabledEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled_events"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookUpdateParams parameters = new() { WebhookEndpointID = "webhook_endpoint_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/webhooks/webhook_endpoint_id"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookUpdateParams parameters = new()
        {
            WebhookEndpointID = "webhook_endpoint_id",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["computer-use-2024-10-22,webhooks-2026-10-07"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            WebhookEndpointID = "webhook_endpoint_id",
            Description = "description",
            EnabledEvents = [WebhookUpdateParamsEnabledEvent.ExternalKeyFailed],
            Name = "name",
            State = State.Disabled,
            UrlValue = "x",
            Betas = [AnthropicBeta.ComputerUse2024_10_22],
        };

        WebhookUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class WebhookUpdateParamsEnabledEventTest : TestBase
{
    [Theory]
    [InlineData(WebhookUpdateParamsEnabledEvent.ExternalKeyFailed)]
    [InlineData(WebhookUpdateParamsEnabledEvent.ExternalKeyRecovered)]
    [InlineData(WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionOpened)]
    [InlineData(WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionResolved)]
    [InlineData(WebhookUpdateParamsEnabledEvent.UserProfileProgramStatusUpdated)]
    public void Validation_Works(WebhookUpdateParamsEnabledEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookUpdateParamsEnabledEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookUpdateParamsEnabledEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookUpdateParamsEnabledEvent.ExternalKeyFailed, 0, "external_key.failed")]
    [InlineData(WebhookUpdateParamsEnabledEvent.ExternalKeyRecovered, 1, "external_key.recovered")]
    [InlineData(
        WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionOpened,
        2,
        "user_profile.enforcement_action_opened"
    )]
    [InlineData(
        WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionResolved,
        3,
        "user_profile.enforcement_action_resolved"
    )]
    [InlineData(
        WebhookUpdateParamsEnabledEvent.UserProfileProgramStatusUpdated,
        4,
        "user_profile.program_status_updated"
    )]
    public void EnumMemberSerializationRoundtrip_Works(
        WebhookUpdateParamsEnabledEvent rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookUpdateParamsEnabledEvent> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookUpdateParamsEnabledEvent>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookUpdateParamsEnabledEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookUpdateParamsEnabledEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StateTest : TestBase
{
    [Theory]
    [InlineData(State.Disabled)]
    [InlineData(State.Enabled)]
    public void Validation_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(State.Disabled, 0, "disabled")]
    [InlineData(State.Enabled, 1, "enabled")]
    public void EnumMemberSerializationRoundtrip_Works(State rawValue, int number, string apiValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
