using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Webhooks;

namespace Anthropic.Tests.Models.Beta.Organization.Webhooks;

public class BetaOrganizationWebhookEndpointSigningSecretTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOrganizationWebhookEndpointSigningSecret
        {
            SigningSecret = "signing_secret",
        };

        string expectedSigningSecret = "signing_secret";

        Assert.Equal(expectedSigningSecret, model.SigningSecret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOrganizationWebhookEndpointSigningSecret
        {
            SigningSecret = "signing_secret",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationWebhookEndpointSigningSecret>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOrganizationWebhookEndpointSigningSecret
        {
            SigningSecret = "signing_secret",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationWebhookEndpointSigningSecret>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSigningSecret = "signing_secret";

        Assert.Equal(expectedSigningSecret, deserialized.SigningSecret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOrganizationWebhookEndpointSigningSecret
        {
            SigningSecret = "signing_secret",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOrganizationWebhookEndpointSigningSecret
        {
            SigningSecret = "signing_secret",
        };

        BetaOrganizationWebhookEndpointSigningSecret copied = new(model);

        Assert.Equal(model, copied);
    }
}
