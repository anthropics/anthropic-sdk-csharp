using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionStrReplaceResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionStrReplaceResultBlock
        {
            Lines = ["string"],
            NewLines = 0,
            NewStart = 0,
            OldLines = 0,
            OldStart = 0,
            Type = JsonSerializer.Deserialize<JsonElement>(
                "\"text_editor_code_execution_str_replace_result\""
            ),
        };

        List<string> expectedLines = ["string"];
        long expectedNewLines = 0;
        long expectedNewStart = 0;
        long expectedOldLines = 0;
        long expectedOldStart = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_str_replace_result\""
        );

        Assert.Equal(expectedLines.Count, model.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], model.Lines[i]);
        }
        Assert.Equal(expectedNewLines, model.NewLines);
        Assert.Equal(expectedNewStart, model.NewStart);
        Assert.Equal(expectedOldLines, model.OldLines);
        Assert.Equal(expectedOldStart, model.OldStart);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
