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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818StrReplaceCommand
        {
            NewStr = "Favorite color: green",
            OldStr = "Favorite color: blue",
            Path = "/memories/preferences.txt",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818StrReplaceCommand>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMemoryTool20250818StrReplaceCommand
        {
            NewStr = "Favorite color: green",
            OldStr = "Favorite color: blue",
            Path = "/memories/preferences.txt",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818StrReplaceCommand>(
            element
        );
        Assert.NotNull(deserialized);

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"str_replace\"");
        string expectedNewStr = "Favorite color: green";
        string expectedOldStr = "Favorite color: blue";
        string expectedPath = "/memories/preferences.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, deserialized.Command));
        Assert.Equal(expectedNewStr, deserialized.NewStr);
        Assert.Equal(expectedOldStr, deserialized.OldStr);
        Assert.Equal(expectedPath, deserialized.Path);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMemoryTool20250818StrReplaceCommand
        {
            NewStr = "Favorite color: green",
            OldStr = "Favorite color: blue",
            Path = "/memories/preferences.txt",
        };

        model.Validate();
    }
}
