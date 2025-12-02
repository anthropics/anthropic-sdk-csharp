using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBashCodeExecutionResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionResultBlock
        {
            Content = [new("file_id")],
            ReturnCode = 0,
            Stderr = "stderr",
            Stdout = "stdout",
            Type = JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_result\""),
        };

        List<BetaBashCodeExecutionOutputBlock> expectedContent = [new("file_id")];
        long expectedReturnCode = 0;
        string expectedStderr = "stderr";
        string expectedStdout = "stdout";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_result\""
        );

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
}
