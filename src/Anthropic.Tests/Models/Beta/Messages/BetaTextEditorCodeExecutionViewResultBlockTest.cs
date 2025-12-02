using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionViewResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlock
        {
            Content = "content",
            FileType = FileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
            Type = JsonSerializer.Deserialize<JsonElement>(
                "\"text_editor_code_execution_view_result\""
            ),
        };

        string expectedContent = "content";
        ApiEnum<string, FileType> expectedFileType = FileType.Text;
        long expectedNumLines = 0;
        long expectedStartLine = 0;
        long expectedTotalLines = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_view_result\""
        );

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedFileType, model.FileType);
        Assert.Equal(expectedNumLines, model.NumLines);
        Assert.Equal(expectedStartLine, model.StartLine);
        Assert.Equal(expectedTotalLines, model.TotalLines);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
