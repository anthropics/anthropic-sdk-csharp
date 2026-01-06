using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionToolResultBlockContentTest : TestBase
{
    [Fact]
    public void ErrorValidationWorks()
    {
        BetaCodeExecutionToolResultBlockContent value = new(
            new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            )
        );
        value.Validate();
    }

    [Fact]
    public void ResultBlockValidationWorks()
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
    public void ErrorSerializationRoundtripWorks()
    {
        BetaCodeExecutionToolResultBlockContent value = new(
            new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            )
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ResultBlockSerializationRoundtripWorks()
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
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlockContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }
}
