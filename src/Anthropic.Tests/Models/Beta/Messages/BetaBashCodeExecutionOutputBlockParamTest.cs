using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBashCodeExecutionOutputBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionOutputBlockParam { FileID = "file_id" };

        string expectedFileID = "file_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("bash_code_execution_output");

        Assert.Equal(expectedFileID, model.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionOutputBlockParam { FileID = "file_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionOutputBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBashCodeExecutionOutputBlockParam { FileID = "file_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionOutputBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("bash_code_execution_output");

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBashCodeExecutionOutputBlockParam { FileID = "file_id" };

        model.Validate();
    }
}
