using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818InsertCommandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818InsertCommand
        {
            Command = JsonSerializer.Deserialize<JsonElement>("\"insert\""),
            InsertLine = 2,
            InsertText = "- Review memory tool documentation\n",
            Path = "/memories/todo.txt",
        };

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"insert\"");
        long expectedInsertLine = 2;
        string expectedInsertText = "- Review memory tool documentation\n";
        string expectedPath = "/memories/todo.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, model.Command));
        Assert.Equal(expectedInsertLine, model.InsertLine);
        Assert.Equal(expectedInsertText, model.InsertText);
        Assert.Equal(expectedPath, model.Path);
    }
}
