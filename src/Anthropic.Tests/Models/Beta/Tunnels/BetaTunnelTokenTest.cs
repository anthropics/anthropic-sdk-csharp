using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Tunnels;

namespace Anthropic.Tests.Models.Beta.Tunnels;

public class BetaTunnelTokenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTunnelToken { ID = "id", TunnelToken = "tunnel_token" };

        string expectedID = "id";
        string expectedTunnelToken = "tunnel_token";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tunnel_token");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedTunnelToken, model.TunnelToken);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTunnelToken { ID = "id", TunnelToken = "tunnel_token" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTunnelToken>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTunnelToken { ID = "id", TunnelToken = "tunnel_token" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTunnelToken>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedTunnelToken = "tunnel_token";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tunnel_token");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedTunnelToken, deserialized.TunnelToken);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTunnelToken { ID = "id", TunnelToken = "tunnel_token" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTunnelToken { ID = "id", TunnelToken = "tunnel_token" };

        BetaTunnelToken copied = new(model);

        Assert.Equal(model, copied);
    }
}
