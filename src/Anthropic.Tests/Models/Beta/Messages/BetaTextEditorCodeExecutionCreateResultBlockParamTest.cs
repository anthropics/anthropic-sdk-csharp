using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionCreateResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionCreateResultBlockParam { IsFileUpdate = true };

        bool expectedIsFileUpdate = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_create_result"
        );

        Assert.Equal(expectedIsFileUpdate, model.IsFileUpdate);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionCreateResultBlockParam { IsFileUpdate = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlockParam>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTextEditorCodeExecutionCreateResultBlockParam { IsFileUpdate = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlockParam>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedIsFileUpdate = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_create_result"
        );

        Assert.Equal(expectedIsFileUpdate, deserialized.IsFileUpdate);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTextEditorCodeExecutionCreateResultBlockParam { IsFileUpdate = true };

        model.Validate();
    }
}
