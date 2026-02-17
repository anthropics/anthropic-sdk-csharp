using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class EncryptedCodeExecutionResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EncryptedCodeExecutionResultBlock
        {
            Content = [new("file_id")],
            EncryptedStdout = "encrypted_stdout",
            ReturnCode = 0,
            Stderr = "stderr",
        };

        List<CodeExecutionOutputBlock> expectedContent = [new("file_id")];
        string expectedEncryptedStdout = "encrypted_stdout";
        long expectedReturnCode = 0;
        string expectedStderr = "stderr";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "encrypted_code_execution_result"
        );

        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedEncryptedStdout, model.EncryptedStdout);
        Assert.Equal(expectedReturnCode, model.ReturnCode);
        Assert.Equal(expectedStderr, model.Stderr);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EncryptedCodeExecutionResultBlock
        {
            Content = [new("file_id")],
            EncryptedStdout = "encrypted_stdout",
            ReturnCode = 0,
            Stderr = "stderr",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EncryptedCodeExecutionResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EncryptedCodeExecutionResultBlock
        {
            Content = [new("file_id")],
            EncryptedStdout = "encrypted_stdout",
            ReturnCode = 0,
            Stderr = "stderr",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EncryptedCodeExecutionResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CodeExecutionOutputBlock> expectedContent = [new("file_id")];
        string expectedEncryptedStdout = "encrypted_stdout";
        long expectedReturnCode = 0;
        string expectedStderr = "stderr";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "encrypted_code_execution_result"
        );

        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedEncryptedStdout, deserialized.EncryptedStdout);
        Assert.Equal(expectedReturnCode, deserialized.ReturnCode);
        Assert.Equal(expectedStderr, deserialized.Stderr);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EncryptedCodeExecutionResultBlock
        {
            Content = [new("file_id")],
            EncryptedStdout = "encrypted_stdout",
            ReturnCode = 0,
            Stderr = "stderr",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EncryptedCodeExecutionResultBlock
        {
            Content = [new("file_id")],
            EncryptedStdout = "encrypted_stdout",
            ReturnCode = 0,
            Stderr = "stderr",
        };

        EncryptedCodeExecutionResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
