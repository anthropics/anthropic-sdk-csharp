using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        CodeExecutionToolResultBlockParamContent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "code_execution_tool_result_error",
                  "content": [
                    {
                      "file_id": "file_id",
                      "type": "code_execution_output"
                    }
                  ],
                  "return_code": 0,
                  "stderr": "stderr"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "code_execution_tool_result_error"
        );
        List<CodeExecutionOutputBlockParam> expectedContent = [new("file_id")];
        long expectedReturnCode = 0;
        string expectedStderr = "stderr";

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
        Assert.NotNull(value.Content);
        Assert.Equal(expectedContent.Count, value.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], value.Content[i]);
        }
        Assert.Equal(expectedReturnCode, value.ReturnCode);
        Assert.Equal(expectedStderr, value.Stderr);

        CodeExecutionToolResultBlockParamContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Content);
        Assert.Null(emptyValue.ReturnCode);
        Assert.Null(emptyValue.Stderr);

        CodeExecutionToolResultBlockParamContent mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "return_code": [
                    "invalid"
                  ],
                  "stderr": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.ReturnCode);
        Assert.Null(mismatchedValue.Stderr);
    }
}
