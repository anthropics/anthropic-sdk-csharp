using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CodeExecutionResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CodeExecutionResultBlockParam
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };

        List<CodeExecutionOutputBlockParam> expectedContent = [new("file_id")];
        long expectedReturnCode = 0;
        string expectedStderr = "stderr";
        string expectedStdout = "stdout";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_result");

        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedReturnCode, model.ReturnCode);
        Assert.Equal(expectedStderr, model.Stderr);
        Assert.Equal(expectedStdout, model.Stdout);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CodeExecutionResultBlockParam
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CodeExecutionResultBlockParam
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CodeExecutionOutputBlockParam> expectedContent = [new("file_id")];
        long expectedReturnCode = 0;
        string expectedStderr = "stderr";
        string expectedStdout = "stdout";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_result");

        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedReturnCode, deserialized.ReturnCode);
        Assert.Equal(expectedStderr, deserialized.Stderr);
        Assert.Equal(expectedStdout, deserialized.Stdout);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CodeExecutionResultBlockParam
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CodeExecutionResultBlockParam
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };

        CodeExecutionResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
