using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818StrReplaceCommandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818StrReplaceCommand
        {
            Command = JsonSerializer.Deserialize<JsonElement>("\"str_replace\""),
            NewStr = "Favorite color: green",
            OldStr = "Favorite color: blue",
            Path = "/memories/preferences.txt",
        };

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"str_replace\"");
        string expectedNewStr = "Favorite color: green";
        string expectedOldStr = "Favorite color: blue";
        string expectedPath = "/memories/preferences.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, model.Command));
        Assert.Equal(expectedNewStr, model.NewStr);
        Assert.Equal(expectedOldStr, model.OldStr);
        Assert.Equal(expectedPath, model.Path);
    }
}
