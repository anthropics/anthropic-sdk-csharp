using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolChangeMcpToolReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolChangeMcpToolReference
        {
            Name = "name",
            ServerName = "server_name",
        };

        string expectedName = "name";
        string expectedServerName = "server_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_tool_reference");

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedServerName, model.ServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaToolChangeMcpToolReference
        {
            Name = "name",
            ServerName = "server_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolChangeMcpToolReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolChangeMcpToolReference
        {
            Name = "name",
            ServerName = "server_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolChangeMcpToolReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedServerName = "server_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_tool_reference");

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedServerName, deserialized.ServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaToolChangeMcpToolReference
        {
            Name = "name",
            ServerName = "server_name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaToolChangeMcpToolReference
        {
            Name = "name",
            ServerName = "server_name",
        };

        BetaToolChangeMcpToolReference copied = new(model);

        Assert.Equal(model, copied);
    }
}
