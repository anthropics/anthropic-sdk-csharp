using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818CreateCommandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818CreateCommand
        {
            Command = JsonSerializer.Deserialize<JsonElement>("\"create\""),
            FileText = "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n",
            Path = "/memories/notes.txt",
        };

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"create\"");
        string expectedFileText =
            "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n";
        string expectedPath = "/memories/notes.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, model.Command));
        Assert.Equal(expectedFileText, model.FileText);
        Assert.Equal(expectedPath, model.Path);
    }
}
