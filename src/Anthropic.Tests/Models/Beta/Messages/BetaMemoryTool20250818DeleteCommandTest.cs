using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818DeleteCommandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818DeleteCommand { Path = "/memories/old_file.txt" };

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"delete\"");
        string expectedPath = "/memories/old_file.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, model.Command));
        Assert.Equal(expectedPath, model.Path);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818DeleteCommand { Path = "/memories/old_file.txt" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818DeleteCommand>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMemoryTool20250818DeleteCommand { Path = "/memories/old_file.txt" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818DeleteCommand>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"delete\"");
        string expectedPath = "/memories/old_file.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, deserialized.Command));
        Assert.Equal(expectedPath, deserialized.Path);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMemoryTool20250818DeleteCommand { Path = "/memories/old_file.txt" };

        model.Validate();
    }
}
