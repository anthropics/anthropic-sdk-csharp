using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818ViewCommandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818ViewCommand
        {
            Command = JsonSerializer.Deserialize<JsonElement>("\"view\""),
            Path = "/memories",
            ViewRange = [1, 10],
        };

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"view\"");
        string expectedPath = "/memories";
        List<long> expectedViewRange = [1, 10];

        Assert.True(JsonElement.DeepEquals(expectedCommand, model.Command));
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedViewRange.Count, model.ViewRange.Count);
        for (int i = 0; i < expectedViewRange.Count; i++)
        {
            Assert.Equal(expectedViewRange[i], model.ViewRange[i]);
        }
    }
}
