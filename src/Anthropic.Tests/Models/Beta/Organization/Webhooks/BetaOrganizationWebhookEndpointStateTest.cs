using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Webhooks;

namespace Anthropic.Tests.Models.Beta.Organization.Webhooks;

public class BetaOrganizationWebhookEndpointStateTest : TestBase
{
    [Theory]
    [InlineData(BetaOrganizationWebhookEndpointState.Disabled)]
    [InlineData(BetaOrganizationWebhookEndpointState.Enabled)]
    public void Validation_Works(BetaOrganizationWebhookEndpointState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOrganizationWebhookEndpointState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationWebhookEndpointState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaOrganizationWebhookEndpointState.Disabled)]
    [InlineData(BetaOrganizationWebhookEndpointState.Enabled)]
    public void SerializationRoundtrip_Works(BetaOrganizationWebhookEndpointState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOrganizationWebhookEndpointState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationWebhookEndpointState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationWebhookEndpointState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationWebhookEndpointState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
