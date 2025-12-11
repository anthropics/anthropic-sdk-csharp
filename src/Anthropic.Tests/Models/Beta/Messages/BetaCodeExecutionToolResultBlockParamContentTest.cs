using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void error_paramValidation_Works()
    {
        BetaCodeExecutionToolResultBlockParamContent value = new(
            new BetaCodeExecutionToolResultErrorParam(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            )
        );
        value.Validate();
    }

    [Fact]
    public void result_block_paramValidation_Works()
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
    public void error_paramSerializationRoundtrip_Works()
    {
        BetaCodeExecutionToolResultBlockParamContent value = new(
            new BetaCodeExecutionToolResultErrorParam(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            )
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockParamContent>(
            json
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void result_block_paramSerializationRoundtrip_Works()
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockParamContent>(
            json
        );

        Assert.Equal(value, deserialized);
    }
}
