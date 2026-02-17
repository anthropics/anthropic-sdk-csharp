using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CodeExecutionToolResultBlockContentTest : TestBase
{
    [Fact]
    public void ErrorValidationWorks()
    {
        CodeExecutionToolResultBlockContent value = new CodeExecutionToolResultError(
            CodeExecutionToolResultErrorCode.InvalidToolInput
        );
        value.Validate();
    }

    [Fact]
    public void ResultBlockValidationWorks()
    {
        CodeExecutionToolResultBlockContent value = new CodeExecutionResultBlock()
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };
        value.Validate();
    }

    [Fact]
    public void EncryptedCodeExecutionResultBlockValidationWorks()
    {
        CodeExecutionToolResultBlockContent value = new EncryptedCodeExecutionResultBlock()
        {
            Content = [new("file_id")],
            EncryptedStdout = "encrypted_stdout",
            ReturnCode = 0,
            Stderr = "stderr",
        };
        value.Validate();
    }

    [Fact]
    public void ErrorSerializationRoundtripWorks()
    {
        CodeExecutionToolResultBlockContent value = new CodeExecutionToolResultError(
            CodeExecutionToolResultErrorCode.InvalidToolInput
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionToolResultBlockContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ResultBlockSerializationRoundtripWorks()
    {
        CodeExecutionToolResultBlockContent value = new CodeExecutionResultBlock()
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionToolResultBlockContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EncryptedCodeExecutionResultBlockSerializationRoundtripWorks()
    {
        CodeExecutionToolResultBlockContent value = new EncryptedCodeExecutionResultBlock()
        {
            Content = [new("file_id")],
            EncryptedStdout = "encrypted_stdout",
            ReturnCode = 0,
            Stderr = "stderr",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionToolResultBlockContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
