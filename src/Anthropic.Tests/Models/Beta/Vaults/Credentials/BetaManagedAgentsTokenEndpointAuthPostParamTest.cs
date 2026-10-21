using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsTokenEndpointAuthPostParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostParam { ClientSecret = "x" };

        string expectedClientSecret = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("client_secret_post");

        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostParam { ClientSecret = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthPostParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostParam { ClientSecret = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthPostParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClientSecret = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("client_secret_post");

        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostParam { ClientSecret = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostParam { ClientSecret = "x" };

        BetaManagedAgentsTokenEndpointAuthPostParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
