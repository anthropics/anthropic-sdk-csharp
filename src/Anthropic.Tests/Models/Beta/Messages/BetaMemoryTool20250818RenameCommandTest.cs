using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818RenameCommandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818RenameCommand
        {
            Command = JsonSerializer.Deserialize<JsonElement>("\"rename\""),
            NewPath = "/memories/final.txt",
            OldPath = "/memories/draft.txt",
        };

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"rename\"");
        string expectedNewPath = "/memories/final.txt";
        string expectedOldPath = "/memories/draft.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, model.Command));
        Assert.Equal(expectedNewPath, model.NewPath);
        Assert.Equal(expectedOldPath, model.OldPath);
    }
}
