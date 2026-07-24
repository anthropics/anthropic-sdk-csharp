using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolChangeMcpToolsetReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolChangeMcpToolsetReference { ServerName = "server_name" };

        string expectedServerName = "server_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_toolset_reference");

        Assert.Equal(expectedServerName, model.ServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaToolChangeMcpToolsetReference { ServerName = "server_name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolChangeMcpToolsetReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolChangeMcpToolsetReference { ServerName = "server_name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolChangeMcpToolsetReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedServerName = "server_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_toolset_reference");

        Assert.Equal(expectedServerName, deserialized.ServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaToolChangeMcpToolsetReference { ServerName = "server_name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaToolChangeMcpToolsetReference { ServerName = "server_name" };

        BetaToolChangeMcpToolsetReference copied = new(model);

        Assert.Equal(model, copied);
    }
}
