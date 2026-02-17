using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaServerToolCaller20260120Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaServerToolCaller20260120 { ToolID = "srvtoolu_SQfNkl1n_JR_" };

        string expectedToolID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_20260120");

        Assert.Equal(expectedToolID, model.ToolID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaServerToolCaller20260120 { ToolID = "srvtoolu_SQfNkl1n_JR_" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServerToolCaller20260120>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaServerToolCaller20260120 { ToolID = "srvtoolu_SQfNkl1n_JR_" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServerToolCaller20260120>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToolID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_20260120");

        Assert.Equal(expectedToolID, deserialized.ToolID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaServerToolCaller20260120 { ToolID = "srvtoolu_SQfNkl1n_JR_" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaServerToolCaller20260120 { ToolID = "srvtoolu_SQfNkl1n_JR_" };

        BetaServerToolCaller20260120 copied = new(model);

        Assert.Equal(model, copied);
    }
}
