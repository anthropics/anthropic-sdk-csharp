using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionToolResultBlockContentTest : TestBase
{
    [Fact]
    public void errorValidation_Works()
    {
        BetaCodeExecutionToolResultBlockContent value = new(
            new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            )
        );
        value.Validate();
    }

    [Fact]
    public void result_blockValidation_Works()
    {
        BetaCodeExecutionToolResultBlockContent value = new(
            new BetaCodeExecutionResultBlock()
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
    public void errorSerializationRoundtrip_Works()
    {
        BetaCodeExecutionToolResultBlockContent value = new(
            new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            )
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockContent>(
            json
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void result_blockSerializationRoundtrip_Works()
    {
        BetaCodeExecutionToolResultBlockContent value = new(
            new BetaCodeExecutionResultBlock()
            {
                Content = [new("file_id")],
                ReturnCode = 0,
                Stderr = "stderr",
                Stdout = "stdout",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockContent>(
            json
        );

        Assert.Equal(value, deserialized);
    }
}
