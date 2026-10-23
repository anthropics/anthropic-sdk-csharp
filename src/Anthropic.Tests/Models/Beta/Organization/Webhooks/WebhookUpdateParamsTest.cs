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
            EnabledEvents = [WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionOpened],
            Name = "name",
            State = State.Disabled,
            UrlValue = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedWebhookEndpointID = "webhook_endpoint_id";
        string expectedDescription = "description";
        List<ApiEnum<string, WebhookUpdateParamsEnabledEvent>> expectedEnabledEvents =
        [
            WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionOpened,
        ];
        string expectedName = "name";
        ApiEnum<string, State> expectedState = State.Disabled;
        string expectedUrlValue = "x";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

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
            EnabledEvents = [WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionOpened],
            Name = "name",
            State = State.Disabled,
            UrlValue = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
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
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,webhooks-2026-10-07"],
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
            EnabledEvents = [WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionOpened],
            Name = "name",
            State = State.Disabled,
            UrlValue = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        WebhookUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class WebhookUpdateParamsEnabledEventTest : TestBase
{
    [Theory]
    [InlineData(WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionOpened)]
    [InlineData(WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionResolved)]
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
    [InlineData(WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionOpened)]
    [InlineData(WebhookUpdateParamsEnabledEvent.UserProfileEnforcementActionResolved)]
    public void SerializationRoundtrip_Works(WebhookUpdateParamsEnabledEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookUpdateParamsEnabledEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookUpdateParamsEnabledEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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
    [InlineData(State.Disabled)]
    [InlineData(State.Enabled)]
    public void SerializationRoundtrip_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
