using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionCreateResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionCreateResultBlock { IsFileUpdate = true };

        bool expectedIsFileUpdate = true;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_create_result\""
        );

        Assert.Equal(expectedIsFileUpdate, model.IsFileUpdate);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionCreateResultBlock { IsFileUpdate = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlock>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTextEditorCodeExecutionCreateResultBlock { IsFileUpdate = true };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlock>(
            element
        );
        Assert.NotNull(deserialized);

        bool expectedIsFileUpdate = true;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_create_result\""
        );

        Assert.Equal(expectedIsFileUpdate, deserialized.IsFileUpdate);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTextEditorCodeExecutionCreateResultBlock { IsFileUpdate = true };

        model.Validate();
    }
}
