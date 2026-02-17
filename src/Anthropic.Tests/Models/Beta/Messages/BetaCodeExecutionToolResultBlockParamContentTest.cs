using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void ErrorParamValidationWorks()
    {
        BetaCodeExecutionToolResultBlockParamContent value =
            new BetaCodeExecutionToolResultErrorParam(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            );
        value.Validate();
    }

    [Fact]
    public void ResultBlockParamValidationWorks()
    {
        BetaCodeExecutionToolResultBlockParamContent value = new BetaCodeExecutionResultBlockParam()
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
        BetaCodeExecutionToolResultBlockParamContent value =
            new BetaEncryptedCodeExecutionResultBlockParam()
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
        BetaCodeExecutionToolResultBlockParamContent value =
            new BetaCodeExecutionToolResultErrorParam(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ResultBlockParamSerializationRoundtripWorks()
    {
        BetaCodeExecutionToolResultBlockParamContent value = new BetaCodeExecutionResultBlockParam()
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EncryptedCodeExecutionResultBlockParamSerializationRoundtripWorks()
    {
        BetaCodeExecutionToolResultBlockParamContent value =
            new BetaEncryptedCodeExecutionResultBlockParam()
            {
                Content = [new("file_id")],
                EncryptedStdout = "encrypted_stdout",
                ReturnCode = 0,
                Stderr = "stderr",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
