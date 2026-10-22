using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaServerToolCallerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaServerToolCaller { ToolID = "srvtoolu_c" };

        string expectedToolID = "srvtoolu_c";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_20250825");

        Assert.Equal(expectedToolID, model.ToolID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaServerToolCaller { ToolID = "srvtoolu_c" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServerToolCaller>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaServerToolCaller { ToolID = "srvtoolu_c" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServerToolCaller>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToolID = "srvtoolu_c";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_20250825");

        Assert.Equal(expectedToolID, deserialized.ToolID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaServerToolCaller { ToolID = "srvtoolu_c" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaServerToolCaller { ToolID = "srvtoolu_c" };

        BetaServerToolCaller copied = new(model);

        Assert.Equal(model, copied);
    }
}
