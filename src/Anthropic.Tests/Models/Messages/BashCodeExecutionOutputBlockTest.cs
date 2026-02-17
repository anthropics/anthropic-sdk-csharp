using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BashCodeExecutionOutputBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BashCodeExecutionOutputBlock { FileID = "file_id" };

        string expectedFileID = "file_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("bash_code_execution_output");

        Assert.Equal(expectedFileID, model.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BashCodeExecutionOutputBlock { FileID = "file_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BashCodeExecutionOutputBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BashCodeExecutionOutputBlock { FileID = "file_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BashCodeExecutionOutputBlock>(
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
        var model = new BashCodeExecutionOutputBlock { FileID = "file_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BashCodeExecutionOutputBlock { FileID = "file_id" };

        BashCodeExecutionOutputBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
