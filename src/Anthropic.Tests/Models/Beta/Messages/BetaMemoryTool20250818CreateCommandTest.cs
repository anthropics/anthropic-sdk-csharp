using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818CreateCommandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818CreateCommand
        {
            FileText = "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n",
            Path = "/memories/notes.txt",
        };

        JsonElement expectedCommand = JsonSerializer.SerializeToElement("create");
        string expectedFileText =
            "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n";
        string expectedPath = "/memories/notes.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, model.Command));
        Assert.Equal(expectedFileText, model.FileText);
        Assert.Equal(expectedPath, model.Path);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818CreateCommand
        {
            FileText = "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n",
            Path = "/memories/notes.txt",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818CreateCommand>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMemoryTool20250818CreateCommand
        {
            FileText = "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n",
            Path = "/memories/notes.txt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818CreateCommand>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedCommand = JsonSerializer.SerializeToElement("create");
        string expectedFileText =
            "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n";
        string expectedPath = "/memories/notes.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, deserialized.Command));
        Assert.Equal(expectedFileText, deserialized.FileText);
        Assert.Equal(expectedPath, deserialized.Path);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMemoryTool20250818CreateCommand
        {
            FileText = "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n",
            Path = "/memories/notes.txt",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaMemoryTool20250818CreateCommand
        {
            FileText = "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n",
            Path = "/memories/notes.txt",
        };

        BetaMemoryTool20250818CreateCommand copied = new(model);

        Assert.Equal(model, copied);
    }
}
