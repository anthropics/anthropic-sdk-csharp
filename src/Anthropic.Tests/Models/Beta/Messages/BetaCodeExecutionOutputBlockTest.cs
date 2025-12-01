using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionOutputBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCodeExecutionOutputBlock
        {
            FileID = "file_id",
            Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_output\""),
        };

        string expectedFileID = "file_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"code_execution_output\""
        );

        Assert.Equal(expectedFileID, model.FileID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
