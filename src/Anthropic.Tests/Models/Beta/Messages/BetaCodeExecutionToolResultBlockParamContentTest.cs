using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void ErrorParamValidationWorks()
    {
        BetaCodeExecutionToolResultBlockParamContent value = new(
            new BetaCodeExecutionToolResultErrorParam(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            )
        );
        value.Validate();
    }

    [Fact]
    public void ResultBlockParamValidationWorks()
    {
        BetaCodeExecutionToolResultBlockParamContent value = new(
            new BetaCodeExecutionResultBlockParam()
            {
                Content = [new("file_id")],
                ReturnCode = 0,
                Stderr = "stderr",
                Stdout = "stdout",
            }
        );
        value.Validate();
    }

    [Fact]
    public void ErrorParamSerializationRoundtripWorks()
    {
        BetaCodeExecutionToolResultBlockParamContent value = new(
            new BetaCodeExecutionToolResultErrorParam(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            )
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockParamContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ResultBlockParamSerializationRoundtripWorks()
    {
        BetaCodeExecutionToolResultBlockParamContent value = new(
            new BetaCodeExecutionResultBlockParam()
            {
                Content = [new("file_id")],
                ReturnCode = 0,
                Stderr = "stderr",
                Stdout = "stdout",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockParamContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }
}
