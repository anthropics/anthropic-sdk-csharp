using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CodeExecutionToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void ErrorParamValidationWorks()
    {
        CodeExecutionToolResultBlockParamContent value = new CodeExecutionToolResultErrorParam(
            CodeExecutionToolResultErrorCode.InvalidToolInput
        );
        value.Validate();
    }

    [Fact]
    public void ResultBlockParamValidationWorks()
    {
        CodeExecutionToolResultBlockParamContent value = new CodeExecutionResultBlockParam()
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };
        value.Validate();
    }

    [Fact]
    public void EncryptedCodeExecutionResultBlockParamValidationWorks()
    {
        CodeExecutionToolResultBlockParamContent value =
            new EncryptedCodeExecutionResultBlockParam()
            {
                Content = [new("file_id")],
                EncryptedStdout = "encrypted_stdout",
                ReturnCode = 0,
                Stderr = "stderr",
            };
        value.Validate();
    }

    [Fact]
    public void ErrorParamSerializationRoundtripWorks()
    {
        CodeExecutionToolResultBlockParamContent value = new CodeExecutionToolResultErrorParam(
            CodeExecutionToolResultErrorCode.InvalidToolInput
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ResultBlockParamSerializationRoundtripWorks()
    {
        CodeExecutionToolResultBlockParamContent value = new CodeExecutionResultBlockParam()
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EncryptedCodeExecutionResultBlockParamSerializationRoundtripWorks()
    {
        CodeExecutionToolResultBlockParamContent value =
            new EncryptedCodeExecutionResultBlockParam()
            {
                Content = [new("file_id")],
                EncryptedStdout = "encrypted_stdout",
                ReturnCode = 0,
                Stderr = "stderr",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
