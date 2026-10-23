using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Webhooks;

namespace Anthropic.Tests.Models.Beta.Organization.Webhooks;

public class WebhookCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookCreateParams
        {
            EnabledEvents = [EnabledEvent.UserProfileEnforcementActionOpened],
            UrlValue = "x",
            Description = "description",
            Name = "name",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        List<ApiEnum<string, EnabledEvent>> expectedEnabledEvents =
        [
            EnabledEvent.UserProfileEnforcementActionOpened,
        ];
        string expectedUrlValue = "x";
        string expectedDescription = "description";
        string expectedName = "name";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedEnabledEvents.Count, parameters.EnabledEvents.Count);
        for (int i = 0; i < expectedEnabledEvents.Count; i++)
        {
            Assert.Equal(expectedEnabledEvents[i], parameters.EnabledEvents[i]);
        }
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
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
        var parameters = new WebhookCreateParams
        {
            EnabledEvents = [EnabledEvent.UserProfileEnforcementActionOpened],
            UrlValue = "x",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookCreateParams
        {
            EnabledEvents = [EnabledEvent.UserProfileEnforcementActionOpened],
            UrlValue = "x",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Name = null,
            Betas = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new WebhookCreateParams
        {
            EnabledEvents = [EnabledEvent.UserProfileEnforcementActionOpened],
            UrlValue = "x",
            Description = "description",
            Name = "name",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        } with
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            Name = null,
            Betas = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookCreateParams parameters = new()
        {
            EnabledEvents = [EnabledEvent.UserProfileEnforcementActionOpened],
            UrlValue = "x",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/organizations/webhooks"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookCreateParams parameters = new()
        {
            EnabledEvents = [EnabledEvent.UserProfileEnforcementActionOpened],
            UrlValue = "x",
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
        var parameters = new WebhookCreateParams
        {
            EnabledEvents = [EnabledEvent.UserProfileEnforcementActionOpened],
            UrlValue = "x",
            Description = "description",
            Name = "name",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        WebhookCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EnabledEventTest : TestBase
{
    [Theory]
    [InlineData(EnabledEvent.UserProfileEnforcementActionOpened)]
    [InlineData(EnabledEvent.UserProfileEnforcementActionResolved)]
    public void Validation_Works(EnabledEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EnabledEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EnabledEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EnabledEvent.UserProfileEnforcementActionOpened)]
    [InlineData(EnabledEvent.UserProfileEnforcementActionResolved)]
    public void SerializationRoundtrip_Works(EnabledEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EnabledEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EnabledEvent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EnabledEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EnabledEvent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
