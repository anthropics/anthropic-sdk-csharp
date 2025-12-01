using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818DeleteCommandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818DeleteCommand
        {
            Command = JsonSerializer.Deserialize<JsonElement>("\"delete\""),
            Path = "/memories/old_file.txt",
        };

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"delete\"");
        string expectedPath = "/memories/old_file.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, model.Command));
        Assert.Equal(expectedPath, model.Path);
    }
}
