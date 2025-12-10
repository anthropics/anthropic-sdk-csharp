using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818CommandTest : TestBase
{
    [Fact]
    public void tool_20250818_viewValidation_Works()
    {
        BetaMemoryTool20250818Command value = new(
            new() { Path = "/memories", ViewRange = [1, 10] }
        );
        value.Validate();
    }

    [Fact]
    public void tool_20250818_createValidation_Works()
    {
        BetaMemoryTool20250818Command value = new(
            new()
            {
                FileText = "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n",
                Path = "/memories/notes.txt",
            }
        );
        value.Validate();
    }

    [Fact]
    public void tool_20250818_str_replaceValidation_Works()
    {
        BetaMemoryTool20250818Command value = new(
            new()
            {
                NewStr = "Favorite color: green",
                OldStr = "Favorite color: blue",
                Path = "/memories/preferences.txt",
            }
        );
        value.Validate();
    }

    [Fact]
    public void tool_20250818_insertValidation_Works()
    {
        BetaMemoryTool20250818Command value = new(
            new()
            {
                InsertLine = 2,
                InsertText = "- Review memory tool documentation\n",
                Path = "/memories/todo.txt",
            }
        );
        value.Validate();
    }

    [Fact]
    public void tool_20250818_deleteValidation_Works()
    {
        BetaMemoryTool20250818Command value = new(new("/memories/old_file.txt"));
        value.Validate();
    }

    [Fact]
    public void tool_20250818_renameValidation_Works()
    {
        BetaMemoryTool20250818Command value = new(
            new() { NewPath = "/memories/final.txt", OldPath = "/memories/draft.txt" }
        );
        value.Validate();
    }

    [Fact]
    public void tool_20250818_viewSerializationRoundtrip_Works()
    {
        BetaMemoryTool20250818Command value = new(
            new() { Path = "/memories", ViewRange = [1, 10] }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_20250818_createSerializationRoundtrip_Works()
    {
        BetaMemoryTool20250818Command value = new(
            new()
            {
                FileText = "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n",
                Path = "/memories/notes.txt",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_20250818_str_replaceSerializationRoundtrip_Works()
    {
        BetaMemoryTool20250818Command value = new(
            new()
            {
                NewStr = "Favorite color: green",
                OldStr = "Favorite color: blue",
                Path = "/memories/preferences.txt",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_20250818_insertSerializationRoundtrip_Works()
    {
        BetaMemoryTool20250818Command value = new(
            new()
            {
                InsertLine = 2,
                InsertText = "- Review memory tool documentation\n",
                Path = "/memories/todo.txt",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_20250818_deleteSerializationRoundtrip_Works()
    {
        BetaMemoryTool20250818Command value = new(new("/memories/old_file.txt"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void tool_20250818_renameSerializationRoundtrip_Works()
    {
        BetaMemoryTool20250818Command value = new(
            new() { NewPath = "/memories/final.txt", OldPath = "/memories/draft.txt" }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(json);

        Assert.Equal(value, deserialized);
    }
}
