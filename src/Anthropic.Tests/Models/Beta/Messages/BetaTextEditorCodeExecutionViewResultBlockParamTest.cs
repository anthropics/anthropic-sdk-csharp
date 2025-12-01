using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionViewResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,
            Type = JsonSerializer.Deserialize<JsonElement>(
                "\"text_editor_code_execution_view_result\""
            ),
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        string expectedContent = "content";
        ApiEnum<string, BetaTextEditorCodeExecutionViewResultBlockParamFileType> expectedFileType =
            BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_view_result\""
        );
        long expectedNumLines = 0;
        long expectedStartLine = 0;
        long expectedTotalLines = 0;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedFileType, model.FileType);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedNumLines, model.NumLines);
        Assert.Equal(expectedStartLine, model.StartLine);
        Assert.Equal(expectedTotalLines, model.TotalLines);
    }
}
