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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818RenameCommand
        {
            NewPath = "/memories/final.txt",
            OldPath = "/memories/draft.txt",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818RenameCommand>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMemoryTool20250818RenameCommand
        {
            NewPath = "/memories/final.txt",
            OldPath = "/memories/draft.txt",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818RenameCommand>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"rename\"");
        string expectedNewPath = "/memories/final.txt";
        string expectedOldPath = "/memories/draft.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, deserialized.Command));
        Assert.Equal(expectedNewPath, deserialized.NewPath);
        Assert.Equal(expectedOldPath, deserialized.OldPath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMemoryTool20250818RenameCommand
        {
            NewPath = "/memories/final.txt",
            OldPath = "/memories/draft.txt",
        };

        model.Validate();
    }
}
