using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsLimitedCredentialNetworkingResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingResponse
        {
            AllowedHosts = ["string"],
        };

        List<string> expectedAllowedHosts = ["string"];
        JsonElement expectedType = JsonSerializer.SerializeToElement("limited");

        Assert.Equal(expectedAllowedHosts.Count, model.AllowedHosts.Count);
        for (int i = 0; i < expectedAllowedHosts.Count; i++)
        {
            Assert.Equal(expectedAllowedHosts[i], model.AllowedHosts[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingResponse
        {
            AllowedHosts = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsLimitedCredentialNetworkingResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingResponse
        {
            AllowedHosts = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsLimitedCredentialNetworkingResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<string> expectedAllowedHosts = ["string"];
        JsonElement expectedType = JsonSerializer.SerializeToElement("limited");

        Assert.Equal(expectedAllowedHosts.Count, deserialized.AllowedHosts.Count);
        for (int i = 0; i < expectedAllowedHosts.Count; i++)
        {
            Assert.Equal(expectedAllowedHosts[i], deserialized.AllowedHosts[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingResponse
        {
            AllowedHosts = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsLimitedCredentialNetworkingResponse
        {
            AllowedHosts = ["string"],
        };

        BetaManagedAgentsLimitedCredentialNetworkingResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
